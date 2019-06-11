using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PhonebookAPI.Models;
using PhonebookAPI.Repositories;

namespace PhonebookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        /// <summary>
        /// Репозиторий для работы с БД
        /// </summary>
        private readonly IPhoneRepository _repository;

        /// <summary>
        /// Констуктор с внедрением репозитория
        /// </summary>
        /// <param name="repository">Объект интерфейса IPhoneRepository</param>
        public PhonesController(IPhoneRepository repository) => _repository = repository;

        /// <summary>
        /// GET api/phones
        /// </summary>
        /// <param name="place">объект</param>
        /// <param name="post">должность</param>
        /// <param name="name">фио</param>
        /// <returns>HTTP код 200 и коллекцию IEnumerable<PhoneItem></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneItem>>> Get(string place, string post, string name)
            => Ok(await _repository.GetPhonesAsync(place, post, name));

        /// <summary>
        /// POST api/phones
        /// </summary>
        /// <param name="phone">Модель PhoneItem</param>
        /// <returns>HTTP код 200</returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PhoneItem phone)
        {
            if (phone != null)
            {
                await _repository.AddPhoneAsync(phone);
                return Ok();
            }
            else return BadRequest();
        }

        /// <summary>
        /// PUT api/phones/id
        /// </summary>
        /// <param name="id">Id выбранного объекта</param>
        /// <param name="phone">Измененная модель</param>
        /// <returns>HTTP код 200</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PhoneItem phone)
        {
            if (phone != null)
            {
                await _repository.UpdatePhoneAsync(id, phone);
                return Ok();
            }
            else return BadRequest();
        }

        /// <summary>
        /// DELETE api/phones/id
        /// </summary>
        /// <param name="id">Id удаляемого объекта</param>
        /// <returns>HTTP код 200</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id > 0)
            {
                await _repository.DeletePhoneAsynk(id);
                return Ok();
            }
            else return BadRequest();
        }
    }
}
