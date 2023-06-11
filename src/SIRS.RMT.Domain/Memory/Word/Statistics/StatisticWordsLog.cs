using SIRS.RMT.Domain.Memory.Colors.Statistics;
using SIRS.RMT.Domain.SharedKernel;
using System;

namespace SIRS.RMT.Domain.Memory.Word.Statistics
{
    public sealed class StatisticWordsLog : StatisticLog
    {


        #region Поля



        #endregion

        #region Свойства
        

        #endregion

        #region Методы
        public object ToObject()
        {
            return new
            {
                this.Id,
                this.UserId,
                this.UserLogin,
                this.QuestionsCount,
                this.CorrectAnswersCount,
                this.IncorrectAnswersCount,
                this.UnknownAnswersCount,
                this.RawPercent,
                this.CoffPercent,
                this.Mark,
                this.TotalTimeStr,
                this.TypeStr,
                this.Time,
                this.Date
            };
        }
        #endregion

        #region Конструкторы/Деструкторы
        public StatisticWordsLog(
            User user,
            int questionsCount,
            int correctAnswersCount,
            int unknownAnswersCount,
            TimeSpan time,
            DateTime date,
            ExersiseType type
        ) : base(user, questionsCount, correctAnswersCount, unknownAnswersCount, time, date, type)
        {

        }
        public StatisticWordsLog() : base() { }
        #endregion

        #region Операторы

        #endregion

        #region Обработчики событий

        #endregion





    }
}
