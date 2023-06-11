using SIRS.RMT.Domain.SharedKernel;
using System;

namespace SIRS.RMT.Domain.Memory.Colors.Statistics
{
    public sealed class StatisticColorLog : StatisticLog
    {

        #region Поля
        private ColorsSet colorsSet;
        #endregion

        #region Свойства
        public ColorsSet ColorsSet
        {
            get => colorsSet;
            set
            {
                colorsSet = value;
                this.QuestionsCount = (int)this.ColorsSet;
            }
        }
        public ColorsExerciseType ExerciseType { get; set; }
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
                this.Time,
                this.Date,
                this.ColorsSet,
                this.TotalTimeStr,
                this.ExerciseType
            };
        }
        #endregion

        #region Конструкторы/Деструкторы
        public StatisticColorLog()
        {
            this.ColorsSet = ColorsSet.Normal;
            this.ExerciseType = ColorsExerciseType.Diagnostic;
        }
        public StatisticColorLog(
            User user,
            int correctAnswersCount,
            int unknownAnswersCount,
            TimeSpan time,
            DateTime date,
            ColorsSet colorsSet,
            ColorsExerciseType exerciseType
            ) : base(user, (int)colorsSet, correctAnswersCount, unknownAnswersCount, time, date, (ExersiseType)exerciseType)
        {
            this.ColorsSet = colorsSet;
            this.ExerciseType = exerciseType;
        }
        #endregion

        #region Операторы

        #endregion

        #region Обработчики событий

        #endregion



    }
}