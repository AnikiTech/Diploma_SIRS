using SIRS.Infrastructure.Domain.Base.User;
using SIRS.RMT.Domain.Memory.Colors;
using SIRS.RMT.Domain.Memory.Colors.Statistics;
using SIRS.RMT.Domain.Memory.Word;
using SIRS.RMT.Domain.Memory.Word.Statistics;
using System;
using System.Collections.Generic;

namespace SIRS.RMT.Domain.SharedKernel
{
    public class User : UserBase
    {
        private readonly Action<object, string> lazyLoader;
        private ICollection<StatisticColorLog> _statistics = new List<StatisticColorLog>();
        private ICollection<StatisticWordsLog> _statisticsWords = new List<StatisticWordsLog>();
        private Setting _setting;
        private ColorsSetting _colorsSetting;
        private ExerciseSetup _exerciseSetup;
        public string Login { set; get; }
        public string Password { set; get; }
        public ICollection<StatisticColorLog> Statistics
        {
            get => lazyLoader.Load(this, ref _statistics);
            protected set => _statistics = value;
        }

        public ICollection<StatisticWordsLog> StatisticsWords
        {
            get => lazyLoader.Load(this, ref _statisticsWords);
            protected set => _statisticsWords = value;
        }

        public ColorsSetting ColorsSetting
        {
            get => lazyLoader.Load(this, ref _colorsSetting);
            protected set => _colorsSetting = value;
        }

        public ExerciseSetup ExerciseSetup
        {
            get => lazyLoader.Load(this, ref _exerciseSetup);
            protected set => _exerciseSetup = value;
        }

        public Setting Setting
        {
            get => lazyLoader.Load(this, ref _setting);
            protected set => _setting = value;
        }

        public User()
        {
            this.ExerciseSetup = new ExerciseSetup(5, false, TimeSpan.FromSeconds(30), this);
        }

        private User(Action<object, string> lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }
    }
}