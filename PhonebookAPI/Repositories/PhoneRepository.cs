using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhonebookAPI.Context;
using PhonebookAPI.Models;

namespace PhonebookAPI.Repositories
{
    public class PhoneRepository : IPhoneRepository
    {
        /// <inheritdoc />
        public async Task AddPhoneAsync(PhoneItem phoneitem)
        {
            using (var context = new PhoneContextApi())
            {
                var place = await context.Places.FirstOrDefaultAsync(p => p.Name == phoneitem.Place);
                var phone = new Phone() {
                    Name = phoneitem.Name,
                    Post = phoneitem.Post,
                    Department = phoneitem.Department,
                    Description = phoneitem.Description,
                    Nomer = phoneitem.Nomer,
                    PlaceId = place.Id};
                context.Phones.Add(phone);
                await context.SaveChangesAsync();
            }
        }

        /// <inheritdoc />
        public async Task DeletePhoneAsynk(int id)
        {
            using (var context = new PhoneContextApi())
            {
                var phone = await context.Phones.FirstOrDefaultAsync(p => p.Id == id);
                phone.IsDeleted = 1;
                context.Entry(phone).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        /// <inheritdoc />
        public async Task<List<PhoneItem>> GetPhonesAsync()
        {
            using (var context = new PhoneContextApi())
            {
                var phones = Mapper.Map<IEnumerable<Phone>, List<PhoneItem>>(await context.Phones.Include(p => p.Place).Where(p => p.IsDeleted != 1).ToListAsync());
                return phones;
            }
        }

        /// <inheritdoc />
        public async Task<IEnumerable<PhoneItem>> GetPhonesAsync(string place, string post, string name)
        {
            List<PhoneItem> phones = null;

            using (var context = new PhoneContextApi())
            {
                phones = Mapper.Map<IEnumerable<Phone>, List<PhoneItem>>(await context.Phones.Include(p => p.Place).Where(p => p.IsDeleted != 1).ToListAsync());
            }
            //phones = phones.Take(100).ToList();
            if (place != null && place != "Объект" && place != "null" && place != "undefined")
                phones = phones.Where(p => p.Place != null).Where(p => p.Place.ToLower() == place.ToLower()).ToList();

            if (post != null && post != "null" && post != "undefined")
                phones = phones.Where(p => p.Post != null).Where(p => p.Post.ToLower().Contains(post.ToLower())).ToList();

            if (name != null && name != "null" && name != "undefined")
                phones = phones.Where(p => p.Name != null).Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();

            return phones;
        }

        /// <inheritdoc />
        public async Task UpdatePhoneAsync(int id, PhoneItem phoneitem)
        {
            using (var context = new PhoneContextApi())
            {
                var place = await context.Places.FirstOrDefaultAsync(p => p.Name == phoneitem.Place);
                
                var phone = new Phone()
                {
                    Id = phoneitem.Id,
                    Name = phoneitem.Name,
                    Post = phoneitem.Post,
                    Department = phoneitem.Department,
                    Description = phoneitem.Description,
                    Nomer = phoneitem.Nomer,
                    PlaceId = place.Id
                };
                context.Entry(phone).State = EntityState.Modified;
                var phoneInDb = await context.Phones.FirstOrDefaultAsync(p => p.Id == id);
                await context.SaveChangesAsync();
            }
        }
    }
}
