using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhonebookAPI.Context;
using PhonebookAPI.Models;

namespace PhonebookAPI.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        /// <inheritdoc />
        public async Task AddPlaceAsync(Place place)
        {
            using (var context = new PhoneContextApi())
            {
                context.Places.Add(place);
                await context.SaveChangesAsync();
            }
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Place>> GetPlacesAsync()
        {
            using (var context = new PhoneContextApi())
            {
                return await context.Places.Where(p => p.IsDeleted == 0).ToListAsync();
            }
        }

        /// <inheritdoc />
        public async Task UpdatePlaceAsync(int id, Place place)
        {
            using (var context = new PhoneContextApi())
            {
                context.Entry(place).State = EntityState.Modified;
                var placeInDb = await context.Places.FirstOrDefaultAsync(p => p.Id == id);
                await context.SaveChangesAsync();
            }
        }

        /// <inheritdoc />
        public async Task DeletePlaceAsynk(int id)
        {
            using (var context = new PhoneContextApi())
            {
                var place = await context.Places.FirstOrDefaultAsync(p => p.Id == id);
                //context.Places.Remove(place);
                place.IsDeleted = 1;
                context.Entry(place).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
