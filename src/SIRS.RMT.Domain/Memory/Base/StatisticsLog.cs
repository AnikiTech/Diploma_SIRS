using SIRS.Infrastructure.Domain.Base.Audit;
using SIRS.RMT.Domain.SharedKernel;
using System;

namespace SIRS.RMT.Domain.Memory.Colors.Statistics
{
    /// <summary>
    /// Тип упражнения
    /// </summary>
    public enum ExersiseType
    {
        Diagnostic,
        Trainer
    }
    /// <summary>
    /// Статистика выполнения теста
    /// </summary>
    public class StatisticLog : SirsUserLoggableEntity<User>
    {
        #region Поля
        private TimeSpan time;
        private ExersiseType type;
        public int сorrectAnswersCount;
        public int incorrectAnswersCount;
        public int unknownAnswersCount;
        String totalTimeStr;
        #endregion

        #region Свойства
        /// <summary>
        /// ИД пользователя
        /// </summary>
        public Guid UserId
        {
            set; get;
        }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string UserLogin
        {
            set; get;
        }

        /// <summary>
        /// Число вопросов 
        /// </summary>
        public int QuestionsCount { get; set; }

        /// <summary>
        /// Число правильных ответов
        /// </summary>
        public int CorrectAnswersCount
        {
            get => сorrectAnswersCount;
            set =>
                //if (value > this.QuestionsCount)
                //    throw new Exception("Количество правильных ответов не может быть больше вопросов");
                сorrectAnswersCount = value;
        }

        /// <summary>
        /// Число неправильных ответов
        /// </summary>
        public int IncorrectAnswersCount
        {
            get => this.QuestionsCount - this.CorrectAnswersCount - unknownAnswersCount;
            set =>
                //if (value > this.QuestionsCount)
                //    throw new Exception("Количество неправильных ответов не может быть больше вопросов");
                incorrectAnswersCount = value;
        }

        /// <summary>
        /// Число пропущенных ответов
        /// </summary>
        public int UnknownAnswersCount
        {
            get => unknownAnswersCount;
            set =>
                //if (value > this.QuestionsCount)
                //    throw new Exception("Количество пропущенных ответов не может быть больше вопросов");
                unknownAnswersCount = value;
        }

        /// <summary>
        /// Время прохождения теста
        /// </summary>
        public TimeSpan Time
        {
            get
            {
                return this.time;
            }
            set
            {
                this.time = value;
                this.TotalTimeStr = this.Time.ToString(@"mm\:ss");
            }
        }

        /// <summary>
        /// Дата прохождения теста
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Тип упражнения
        /// </summary>
        public ExersiseType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value; this.TypeStr = this.GetTypeStr(value);
            }
        }

        public String TypeStr { get; set; }

        public string TotalTimeStr { get => totalTimeStr; set => totalTimeStr = value; }

        /// <summary>
        /// Процент правильных ответов (%): соотношение правильных ответов к неправильным
        /// </summary>
        public double RawPercent
        {
            get
            {
                if (this.QuestionsCount != 0)
                    return (double)this.CorrectAnswersCount / this.QuestionsCount * 100;
                return 0;
            }
        }

        /// <summary>
        /// Коффицент правильных ответов (%): соотношение правильных ответов к неправильным
        /// </summary>
        public double CoffPercent
        {
            get
            {
                if (this.IncorrectAnswersCount != 0)
                    return (double)this.CorrectAnswersCount / (this.CorrectAnswersCount + this.IncorrectAnswersCount) * 100;
                return 100;
            }
        }
        /// <summary>
        /// Оценка за тест по пятибальной шкале.
        /// Привязка к процентам правильных ответов:
        /// 40% <= 2 < 60%
        /// 60% <= 3 < 75%
        /// 75% <= 4 < 90%
        /// 90% <= 5 <= 100%
        /// </summary>
        public int Mark
        {
            get
            {
                int mark = 1;
                double percent = this.RawPercent;
                if (percent >= 90)
                {
                    mark = 5;
                }
                else if (percent >= 75)
                {
                    mark = 4;
                }
                else if (percent >= 60)
                {
                    mark = 3;
                }
                else if (percent >= 40)
                {
                    mark = 2;
                }
                return mark;
            }
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструкторы
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="questionsCount">Количество вопросов</param>
        /// <param name="correctAnswersCount">Количество правильных ответов</param>
        /// <param name="unknownAnswersCount">Количество пропущенных ответов</param>
        /// <param name="time">Время прохождения теста</param>
        /// <param name="date">Дата прохождения теста</param>
        public StatisticLog(
            User user,
            int questionsCount,
            int correctAnswersCount,
            int unknownAnswersCount,
            TimeSpan time,
            DateTime date,
            ExersiseType type
            )
        {
            SetUser(user);
            this.QuestionsCount = questionsCount;
            this.CorrectAnswersCount = correctAnswersCount;
            this.UnknownAnswersCount = unknownAnswersCount;
            this.Time = time;
            this.Date = date;
            this.Type = type;
            this.TypeStr = this.GetTypeStr(this.Type);
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public StatisticLog() : this(new User(), 0, 0, 0, new TimeSpan(), new DateTime(), ExersiseType.Trainer) { }
        #endregion

        #region Методы
        /// <summary>
        /// Методы 
        /// Задает пользователя для текущего элемента.
        /// Метод set для User защищен, поэтому добавлен этот метод.
        /// </summary>
        /// <param name="user">Пользователь</param>
        public void SetUser(User user)
        {
            this.User = user;
            this.UserId = user.Id;
            this.UserLogin = user.Login;
        }

        public string GetTypeStr(ExersiseType type)
        {
            if (type == ExersiseType.Diagnostic)
            {
                return "Диагностика";
            }
            if (type == ExersiseType.Trainer)
            {
                return "Треннинг";
            }
            return "Неизвестный тип упражнения";
        }
        #endregion

    }
}