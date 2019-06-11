using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhonebookAPI.Models;
using PhonebookAPI.Repositories;

namespace PhonebookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        /// <summary>
        /// Репозиторий для работы с БД
        /// </summary>
        private readonly IPlaceRepository _repository;

        /// <summary>
        /// Констуктор с внедрением репозитория
        /// </summary>
        /// <param name="repository">Объект интерфейса IPlaceRepository</param>
        public PlacesController(IPlaceRepository repository) => _repository = repository;

        /// <summary>
        ///GET api/places
        /// </summary>
        /// <returns>HTTP код 200 и коллекцию IEnumerable<PhoneItem></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place>>> Get()
        {
            var result = await _repository.GetPlacesAsync();
            return Ok(result);
        }

        /// <summary>
        /// PUT api/places/id
        /// </summary>
        /// <param name="id">Id выбранного объекта</param>
        /// <param name="place">Измененная модель</param>
        /// <returns>HTTP код 200</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]Place place)
        {
            if (place != null)
            {
                await _repository.UpdatePlaceAsync(id, place);
                return Ok();
            }
            else return BadRequest();
        }

        /// <summary>
        /// POST api/places
        /// </summary>
        /// <param name="place">Модель Place</param>
        /// <returns>HTTP код 200</returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Place place)
        {
            if (place != null)
            {
                await _repository.AddPlaceAsync(place);
                return Ok();
            }
            else return BadRequest();
        }

        /// <summary>
        /// DELETE api/places/id
        /// </summary>
        /// <param name="id">Id удаляемого объекта</param>
        /// <returns>HTTP код 200</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.DeletePlaceAsynk(id);
            return Ok();
        }
    }
}