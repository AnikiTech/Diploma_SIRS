using SIRS.Infrastructure.Domain.Base.Audit;
using SIRS.RMT.Domain.SharedKernel;
using System;

namespace SIRS.RMT.Domain.Memory.Word
{
    public class ExerciseSetup : SirsUserLoggableEntity<User>
    {
        private readonly Action<object, string> lazyLoader;
        private User _user;

        public int AmountWords { get; protected set; } = ExerciseConstants.MIN_WORDS;
        public bool IsRandomSequenceWords { get; protected set; }
        public TimeSpan TimeToRemember { get; protected set; } = TimeSpan.FromSeconds(ExerciseConstants.MIN_TIME_TO_REMEMBER);

        public override User User
        {
            get => lazyLoader.Load(this, ref _user);
            protected set => _user = value;
        }

        private ExerciseSetup(Action<object, string> lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }

        protected ExerciseSetup()
        { }

        public ExerciseSetup(int amountWords, bool isRandomSequenceWords, TimeSpan timeToRemember, User user) : base(user)
        {
            if (amountWords < ExerciseConstants.MIN_WORDS || amountWords > ExerciseConstants.MAX_WORDS) throw new Exception("The count word is not predefined");
            if (timeToRemember.TotalSeconds < ExerciseConstants.MIN_TIME_TO_REMEMBER || timeToRemember.TotalSeconds > ExerciseConstants.MAX_TIME_TO_REMEMBER)
                throw new Exception($"The time for remembering is bigger, than {ExerciseConstants.MAX_TIME_TO_REMEMBER} seconds, or less than {ExerciseConstants.MIN_TIME_TO_REMEMBER} seconds");

            this.AmountWords = amountWords;
            this.IsRandomSequenceWords = isRandomSequenceWords;
            this.TimeToRemember = timeToRemember;
        }

        public int GetAmountWordsForAnswer()
        {
            switch (this.AmountWords)
            {
                case 5: return this.AmountWords + 2;
                case 6: return this.AmountWords + 3;
                case 7: return this.AmountWords + 3;
                case 8: return this.AmountWords + 4;
                case 9: return this.AmountWords + 4;
                case 10: return this.AmountWords + 5;
                case 11: return this.AmountWords + 5;
                case 12: return this.AmountWords + 6;
                case 13: return this.AmountWords + 6;
                case 14: return this.AmountWords + 7;
                case 15: return this.AmountWords + 7;
                default: return this.AmountWords + ExerciseConstants.MAX_WORDS;
            }
        }
    }
}