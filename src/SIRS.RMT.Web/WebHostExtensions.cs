using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using SIRS.RMT.Domain.EntityFramework;
using SIRS.RMT.Domain.Memory.Colors;
using SIRS.RMT.Domain.Memory.Colors.Statistics;
using SIRS.RMT.Domain.Memory.Word;
using SIRS.RMT.Domain.Memory.Word.Statistics;
using SIRS.RMT.Domain.SharedKernel;
using System;
using System.Linq;

namespace SIRS.RMT.Web
{
    internal static class WebHostExtensions
    {
        public static IWebHost InitializeDatabase(this IWebHost host)
        {
            RollOutDatabaseMigrations();

            return host;

            void RollOutDatabaseMigrations()
            {
                try
                {
                    using var scope = host.Services.CreateScope();
                    var factory = scope.ServiceProvider.GetRequiredService<ReadingMemoryThinkingDbContextFactory>();

                    Log.Information("Apply database migrations...");
                    using (var context = factory.CreateAsApplication())
                    {
                        _ = context.Database.EnsureDeleted();
                        _ = context.Database.EnsureCreated();
                        //context.Database.Migrate();
                    }

                    Log.Information("Database migrations were applied.");
                }
                catch (Exception exception)
                {
                    throw new Exception("An error occurred during rolling up new database schema", exception);
                }
            }
        }

        public static IWebHost SeedDatabase(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var factory = scope.ServiceProvider.GetRequiredService<ReadingMemoryThinkingDbContextFactory>();

                using var context = factory.CreateAsApplication();
                // Добавление тестового пользователя
                var testUser = new User
                {
                    Id = Guid.Parse("F9821756-6A60-4092-9905-6A6A95956ED8"),
                    Login = "test",
                    Password = "123"
                };
                _ = context.Set<User>().Add(testUser);
                _ = context.SaveChanges();
                Log.Debug("Created user with ID = '{userId}'", Guid.Parse("F9821756-6A60-4092-9905-6A6A95956ED8"));


                // Добавление тестовый результат для теста "Запоминание цветов"
                _ = context.Set<StatisticColorLog>().Add(new StatisticColorLog(
                    user: testUser,
                    correctAnswersCount: 5,
                    unknownAnswersCount: 0,
                    time: new TimeSpan(),
                    date: DateTime.Now,
                    colorsSet: ColorsSet.VeryHard,
                    exerciseType: ColorsExerciseType.Training
                    ));
                _ = context.Set<StatisticColorLog>().Add(new StatisticColorLog(
                    user: testUser,
                    correctAnswersCount: 4,
                    unknownAnswersCount: 0,
                    time: new TimeSpan(),
                    date: DateTime.Now,
                    colorsSet: ColorsSet.VeryHard,
                    exerciseType: ColorsExerciseType.Training
                   ));
                _ = context.SaveChanges();


                // Добавление случайных пользователей
                // Создание случайный генератор
                var random = new Random();

                // Создание 10 пользователей
                for (int i = 0; i < 10; i++)
                {
                    var userId = Guid.NewGuid();
                    var user = new User
                    {
                        Id = userId,
                        Login = $"user_{i}",
                        Password = "123"
                    };
                    _ = context.Set<User>().Add(user);
                    _ = context.SaveChanges();

                    Log.Debug("Created user with ID = '{userId}'", userId);

                    // Добавление 10 результатов теста для каждого пользователя
                    for (int j = 0; j < 10; j++)
                    {
                        var correctAnswersCount = random.Next(0, 4);
                        var unknownAnswersCount = random.Next(0, 4 - correctAnswersCount);
                        var time = TimeSpan.FromSeconds(random.Next(1, 1000));
                        var date = DateTime.Now.AddDays(-random.Next(0, 30));
                        var colorsSet = ColorsSet.VeryHard;//(ColorsSet)random.Next(1, 11);
                        var exerciseType = (ColorsExerciseType)random.Next(0, 2);

                        var statisticColorLog = new StatisticColorLog(
                            user: user,
                            correctAnswersCount: correctAnswersCount,
                            unknownAnswersCount: unknownAnswersCount,
                            time: time,
                            date: date,
                            colorsSet: colorsSet,
                            exerciseType: exerciseType
                          );
                        var staticsticWordLog = new StatisticWordsLog(
                             user: user,
                             questionsCount: correctAnswersCount + unknownAnswersCount,
                             correctAnswersCount: correctAnswersCount,
                             unknownAnswersCount: unknownAnswersCount,
                             time: time,
                             date: date,
                             type: ExersiseType.Trainer
                         );

                        _ = context.Set<StatisticColorLog>().Add(statisticColorLog);
                        _ = context.Set<StatisticWordsLog>().Add(staticsticWordLog);
                    }
                }


                // TODO for easy developing was predefined the words
                var predefinedWords = new[]
                                      {
                                        "арбуз","акула","ананас","аист","антилопа","апельсин","арфа","адрес","аура","автор","атлас","афиша",
                                        "банан","белка","бабочка","барабан","бочка","боль","брат","буря","балет","бронза","бумага","бамбук",
                                        "волк","виноград","ведро","вишня","воин","враг","вдох","вальс","вилка","волна","воздух","версия",
                                        "гусь","гриб","гусеница","голова","груша","год","глаз","гном","герой","грива","губка","газ",
                                        "дом","дельфин","дыня","дятел","дерево","дым","день","даль","дождь","дверь","дозор","друг",
                                        "жук","жемчуг","жаба","жар","жизнь","жанр","желе","жажда","жакет","живот","жираф","жадина",
                                        "заяц","зонт","звезда","заря","зебра","зло","земля","зуд","зима","змея","злак","закон",
                                        "игла","идея","интерес","игра","искра","ива","имя","изюм","итог","истина","игрушка","история",
                                        "крот","картина","ключ","книга","клад","камень","коза","краб","куст","карта","кирка","крест",
                                        "лук","лягушка","лавина","ложь","лицо","лев","лоб","лава","лиса","лемур","лотос","лебедь",
                };

                foreach (var t in predefinedWords)
                {
                    _ = context.Set<WordsDictionary>().Add(new WordsDictionary(t));
                }

                _ = context.SaveChanges();
                Log.Debug("Saved predefined words '{total}'", predefinedWords.Length - 1);

                // TODO for easy developing add default colors
                var defaultColors = new[] { "#4286f5", "#673bb7", "#b19bd9", "#109d58", "#f5b400", "#fe5722", "#ea1e63", "#e8d1a8", "#795547", "#607d8b" };
                foreach (var t in defaultColors)
                {
                    _ = context.Set<ColorsDictionary>().Add(new ColorsDictionary(t));
                }

                _ = context.SaveChanges();
                Log.Debug("Saved default colors '{total}'", defaultColors.Length - 1);

                var dic = context.Set<ColorsDictionary>().ToList();
                var colorsSetting = new ColorsSetting("#ff1122", dic.Take(6).ToList(), testUser);
                _ = context.Set<ColorsSetting>().Add(colorsSetting);
                _ = context.SaveChanges();
            }

            return host;
        }
    }
}