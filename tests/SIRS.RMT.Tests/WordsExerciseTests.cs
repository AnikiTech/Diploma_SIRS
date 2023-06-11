using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SIRS.RMT.ApplicationServices.DTO.Memory.WordsExercise;
using SIRS.RMT.ApplicationServices.Services.WordsExercise;
using SIRS.RMT.Tests.Environment;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SIRS.RMT.Tests
{
    public sealed class WordsExerciseTests : TestBase
    {
        private WordExerciseService service;

        [Test]
        public async Task Words_NotEqual_With_Words_For_Answer()
        {
            service ??= serviceProvider.GetRequiredService<WordExerciseService>();
            var wordsForExercise = await service.GetWordsForExerciseAsync(new ExerciseOrderWordsSetupDTO
            {
                AmountWords = 7,
                IsRandomSequenceWords = false,
                TimeToRemember = TimeSpan.FromSeconds(125)
            });

            Assert.IsTrue(service.wordsForExercise.Length != wordsForExercise.WordsDictionaryForAnswer.Length);
        }

        [Test]
        public async Task Words_Must_Have_Random_Order()
        {
            service ??= serviceProvider.GetRequiredService<WordExerciseService>();
            var wordsForExercise = await service.GetWordsForExerciseAsync(new ExerciseOrderWordsSetupDTO
            {
                AmountWords = 7,
                IsRandomSequenceWords = true,
                TimeToRemember = TimeSpan.FromSeconds(125)
            });

            var words = service.wordsForExercise.Select(x => x.Order).ToArray();
            var wordsForAnswer = wordsForExercise.WordsDictionaryForAnswer.Select(x => x.Order).Take(7).ToArray();

            var result = words.SequenceEqual(wordsForAnswer);

            Assert.IsFalse(result);
        }
    }
}