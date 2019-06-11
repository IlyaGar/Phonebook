using PhonebookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonebookAPI.Repositories
{
    public interface IPhoneRepository
    {
        /// <summary>
        /// Получить из базы все не отмеченые на удаление объекты.
        /// </summary>
        /// <returns>Вернуть задачу с ожидаемым резуьтатом IEnumerable<PhoneItem></returns>
        Task<List<PhoneItem>> GetPhonesAsync();
        Task<IEnumerable<PhoneItem>> GetPhonesAsync(string place, string post, string name);

        /// <summary>
        /// Обновить объект.
        /// </summary>
        /// <param name="id">Id выбранного объекта</param>
        /// <param name="phoneItem">Обновляемая модель класса PhoneItem</param>
        /// <returns></returns>
        Task UpdatePhoneAsync(int id, PhoneItem phoneItem);

        /// <summary>
        /// Добавить новый объект.
        /// </summary>
        /// <param name="phoneItem">Добовляемый модель класса PhoneItem</param>
        /// <returns></returns>
        Task AddPhoneAsync(PhoneItem phoneItem);

        /// <summary>
        /// Пометить объкет в БД как удаленный isDeleted = 1, такие обекты не отображаются в выводена представление.
        /// </summary>
        /// <param name="id">Id выбранного объекта</param>
        /// <returns></returns>
        Task DeletePhoneAsynk(int id);
    }
}
