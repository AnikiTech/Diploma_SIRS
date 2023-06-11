using AutoMapper;
using Microsoft.Extensions.Logging;
using SIRS.RMT.ApplicationServices.DTO.Memory.WordsExercise;
using SIRS.RMT.Domain.EntityFramework;
using SIRS.RMT.Domain.Memory.Word;
using SIRS.RMT.Domain.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIRS.RMT.ApplicationServices.Services.WordsExercise
{
    public class WordExerciseService
    {
        private readonly ReadingMemoryThinkingDbContext dbContext;
        private readonly ILogger<WordExerciseService> logger;
        private readonly IMapper mapper;

        internal WordDictionaryDTO[] wordsForExercise;

        public WordExerciseService(ReadingMemoryThinkingDbContext dbContext, ILogger<WordExerciseService> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
        }

        public ExerciseOrderWordsSetupDTO GetExerciseSetup()
        {
            return mapper.Map<ExerciseOrderWordsSetupDTO>(dbContext.Set<ExerciseSetup>().First());
        }

        public async Task<WordExerciseDTO> GetWordsForExerciseAsync(ExerciseOrderWordsSetupDTO dto)
        {
            var currentSetup = dbContext.Set<ExerciseSetup>().First();
            var newSetup = mapper.Map(dto, currentSetup);

            _ = await dbContext.SaveChangesAsync();
            logger.LogDebug("Successfully updated setup for exercise of words");

            var words = dbContext.Set<WordsDictionary>().Select(x => x.Word).Take(newSetup.GetAmountWordsForAnswer()).ToArray();
            logger.LogDebug("Total words '{total}' for generation exercise", words.Length - 1);

            var wordsDictionary = words.Select((x, order) => new WordDictionaryDTO
            {
                Order = order + 1,
                Word = x
            }).ToArray();

            wordsForExercise = wordsDictionary.Take(newSetup.AmountWords).ToArray();

            if (newSetup.IsRandomSequenceWords)
            {
                wordsDictionary.Shuffle();
            }

            return new WordExerciseDTO
            {
                WordsDictionaryForAnswer = wordsDictionary
            };
        }

        public WordExerciseResultDTO CheckAnswer(WordUserAnswerDTO dto)
        {
            var currentSetup = dbContext.Set<ExerciseSetup>().First();
            var userAnswers = dto.UserAnswer;

            var markedAnswers = wordsForExercise.Select((t, i) => t.Word == userAnswers[i]).ToList();

            return new WordExerciseResultDTO
            {
                markTrueAnswers = markedAnswers.ToArray()
            };
        }

        public WordExerciseDTO GetWord(int count)
        {
            if (count > ExerciseConstants.MAX_WORDS || count <= 0)
            {
                logger.LogError("The count word is not predefined");
                throw new Exception("The count word is not predefined");
            }

            var words = dbContext.Set<WordsDictionary>().Select(x => x.Word).ToArray();
            logger.LogDebug("Total words '{total}' for generation exercise", words.Length - 1);

            words.Shuffle();

            var answer_words = words;

            Array.Resize(ref answer_words, count + 2);
            Array.Resize(ref words, count);

            answer_words.Shuffle();

            return new WordExerciseDTO
            {
                Words = words,
                AnswerWords = answer_words
            };
        }

        public int CalculateMark(double percent)
        {
            int mark = 1;
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

        public WordExerciseResultDTO GetResult(WordUserAnswerDTO dto)
        {
            string[] words = dto.Words;
            string[] user_answer = dto.UserAnswer;

            double points = 0d;
            List<bool> markTrueAnswers = new List<bool>();

            if (dto.UserAnswer.Length == 0)
            {
                return new WordExerciseResultDTO
                {
                    markTrueAnswers = markTrueAnswers.ToArray(),
                    Points = points
                };
            }

            if (dto.Words.Length > dto.UserAnswer.Length)
            {
                Array.Resize(ref words, dto.UserAnswer.Length);
            }

            if (dto.UserAnswer.Length > dto.Words.Length)
            {
                Array.Resize(ref user_answer, dto.Words.Length);
            }

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == user_answer[i])
                {
                    markTrueAnswers.Add(true);
                    points++;
                }
                else
                {
                    markTrueAnswers.Add(false);
                }
            }

            System.Console.WriteLine($"Lenght answer: {markTrueAnswers.ToArray().Length}" +
                                     $"\nLenght dto.Words: {dto.Words.Length}" +
                                     $"\nLenght dto.UserAnsrwer: {dto.UserAnswer.Length}" +
                                     $""
                                     );

            if (dto.Words.Length > dto.UserAnswer.Length)
            {

                for (int j = dto.UserAnswer.Length; j < dto.Words.Length; j++)
                {
                    markTrueAnswers.Insert(j, false);
                }
            }

            else if (dto.UserAnswer.Length > dto.Words.Length)
            {
                for (int j = dto.Words.Length; j < dto.UserAnswer.Length; j++)
                {
                    markTrueAnswers.Insert(j, false);
                }
            }

            return new WordExerciseResultDTO
            {
                markTrueAnswers = markTrueAnswers.ToArray(),
                Points = points
            };
        }
    }
}