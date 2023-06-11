using SIRS.RMT.Domain.EntityFramework;
using SIRS.RMT.Domain.SharedKernel;
using System;
using System.Linq;

namespace SIRS.RMT.ApplicationServices.Services.Common
{
    /// <summary>
    /// Общий сервис
    /// </summary>
    public class CommonService
    {


        #region Поля
        /// <summary>
        /// Контекст БД
        /// </summary>
        private ReadingMemoryThinkingDbContext db;
        /// <summary>
        /// GUID тесктового пользователя
        /// TODO: удалить, как будут сделаны пользователи
        /// </summary>
        public Guid testUserGUID = new Guid("F9821756-6A60-4092-9905-6A6A95956ED8");
        #endregion

        #region Свойства
        /// <summary>
        /// Контекст БД
        /// </summary>
        public ReadingMemoryThinkingDbContext DB
        {
            set => db = value;
            get => db;
        }
        #endregion

        #region Методы
        /// <summary>
        /// Получает пользователя по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUser(Guid id)
        {
            return db.Set<User>().FirstOrDefault(x => x.Id == id);
        }
        /// <summary>
        /// Получает пользователя по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUser(string id)
        {
            return GetUser(new Guid(id));
        }
        /// <summary>
        /// Получает логин пользователя по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetUserLogin(Guid id)
        {
            var user = GetUser(id);
            return user == null ? null : user.Login;
        }
        /// <summary>
        /// Получает логин пользователя по ID
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public string GetUserLogin(string guid)
        {
            return GetUserLogin(new Guid(guid));
        }
        #endregion

        #region Конструкторы/Деструкторы

        #endregion

        #region Операторы

        #endregion

        #region Обработчики событий

        #endregion


    }
}
