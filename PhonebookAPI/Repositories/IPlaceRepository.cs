using PhonebookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonebookAPI.Repositories
{
    /// <summary>
    /// Репозиторий для работы с моделью класса Place в БД.
    /// </summary>
    public interface IPlaceRepository
    {
        /// <summary>
        /// Получить из базы все не отмеченые на удаление объекты.
        /// </summary>
        /// <returns>Вернуть задачу с ожидаемым резуьтатом IEnumerable<Place></returns>
        Task<IEnumerable<Place>> GetPlacesAsync();

        /// <summary>
        /// Обновить объект.
        /// </summary>
        /// <param name="id">Id выбранного объекта</param>
        /// <param name="place">Обновляемая модель класса Place</param>
        /// <returns></returns>
        Task UpdatePlaceAsync(int id, Place place);

        /// <summary>
        /// Добавить новый объект.
        /// </summary>
        /// <param name="place">Добовляемый модель класса Place</param>
        /// <returns></returns>
        Task AddPlaceAsync(Place place);

        /// <summary>
        /// Пометить объкет в БД как удаленный isDeleted = 1, такие обекты не отображаются в выводена представление.
        /// </summary>
        /// <param name="id">Id выбранного объекта</param>
        /// <returns></returns>
        Task DeletePlaceAsynk(int id);
    }
}
