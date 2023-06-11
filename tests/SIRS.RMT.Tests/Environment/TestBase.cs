using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SIRS.RMT.ApplicationServices.Services.WordsExercise;
using SIRS.RMT.Config;
using SIRS.RMT.Domain.EntityFramework;
using SIRS.RMT.Domain.Memory.Colors;
using SIRS.RMT.Domain.Memory.Word;
using SIRS.RMT.Domain.SharedKernel;
using System;
using System.Linq;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace SIRS.RMT.Tests.Environment
{
    public class TestBase
    {
        protected ReadingMemoryThinkingConfiguration configuration;
        protected ReadingMemoryThinkingDbContext dbContext;
        protected IServiceProvider serviceProvider;
        protected IServiceScope scope;

        public IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection()
                           .AddLogging()
                           .AddSingleton(x => configuration)
                           .AddSingleton(provider => new DbContextOptionsBuilder<ReadingMemoryThinkingDbContext>().UseInMemoryDatabase("TestDb")
                                                                                                                  .EnableSensitiveDataLogging()
                                                                                                                  .UseApplicationServiceProvider(provider)
                                                                                                                  .Options)
                           .AddScoped(x =>
                                      {
                                          var options = x.GetService<DbContextOptions<ReadingMemoryThinkingDbContext>>();
                                          return new ReadingMemoryThinkingDbContext(options, new SirsDbContextOptions(() => "tester"));
                                      })
                           .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
                           .AddScoped<IMapper>(provider => new Mapper(provider.GetRequiredService<IConfigurationProvider>(), provider.GetService))
                           .AddScoped<WordExerciseService>()
                ;

            return services.BuildServiceProvider();
        }

        protected TestBase()
        {
            configuration = new ConfigurationBuilder()
                            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                            .AddJsonFile("appsettings.json", false, true)
                            .AddJsonFile("appsettings.Development.json", true, true)
                            .AddJsonFile($"appsettings.{ReadingMemoryThinkingConfiguration.AppCodeSuffix}.json", false, true)
                            .AddJsonFile($"appsettings.{ReadingMemoryThinkingConfiguration.AppCodeSuffix}.Development.json", true, true)
                            .Build()
                            .Get<ReadingMemoryThinkingConfiguration>();

            serviceProvider = GetServiceProvider();
        }

        [SetUp]
        public void Setup()
        {
            var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
            scope = scopeFactory.CreateScope();
            dbContext = scope.ServiceProvider.GetRequiredService<ReadingMemoryThinkingDbContext>();

            // Assert Automapper configuration
            serviceProvider.GetRequiredService<IConfigurationProvider>().AssertConfigurationIsValid();

            _ = dbContext.Database.EnsureDeleted();
            _ = dbContext.Database.EnsureCreated();

            // TODO for easy developing was predefined the user
            var user = new User { Id = Guid.Parse("F9821756-6A60-4092-9905-6A6A95956ED8") };
            _ = dbContext.Set<User>().Add(user);
            _ = dbContext.SaveChanges();

            // TODO for easy developing was predefined the words
            var predefinedWords = new[]
                                      {
                                                  "Компьютер", "Смартфон", "Наушники", "Мышь", "Книга",
                                                  "Ручка", "Карандаш", "Перо", "Футляр", "Фотоаппарат",
                                                  "Пленка", "Платок", "Кошка", "Собака", "Лошадь",
                                                  "Велосипед", "Мотоцикл", "Автомобиль", "Колесо", "Ящик",
                                                  "Коробка", "Стол", "Стул", "Диван", "Кресло",
                                                  "Закат", "Рассвет", "Сумерки", "Облака", "Дождь", "Гроза", "Ливень"
                                              };

            foreach (var t in predefinedWords)
            {
                _ = dbContext.Set<WordsDictionary>().Add(new WordsDictionary(t));
            }

            _ = dbContext.SaveChanges();

            // TODO for easy developing add default colors
            var defaultColors = new[] { "#4286f5", "#673bb7", "#b19bd9", "#109d58", "#f5b400", "#fe5722", "#ea1e63", "#e8d1a8", "#795547", "#607d8b" };
            foreach (var t in defaultColors)
            {
                _ = dbContext.Set<ColorsDictionary>().Add(new ColorsDictionary(t));
            }

            _ = dbContext.SaveChanges();

            var dic = dbContext.Set<ColorsDictionary>().ToList();
            var colorsSetting = new ColorsSetting("#ff1122", dic.Take(6).ToList(), user);
            _ = dbContext.Set<ColorsSetting>().Add(colorsSetting);
            _ = dbContext.SaveChanges();
        }

        [TearDown]
        public void Down()
        {
            dbContext.Dispose();
            scope.Dispose();
        }
    }
}