using AutoMapper;

namespace SIRS.RMT.ApplicationServices.MappingProfile
{
    public class StatisticWordsProfile : Profile
    {
        public StatisticWordsProfile()
        {
            //CreateMap<WordsStatisticDTO, StatisticWordsLog>()
            //    .ForMember(x => x.Time, x => x.MapFrom(t => TimeSpan.FromSeconds(t.TimeSeconds)))
            //    .ForMember(x => x.User, x => x.MapFrom<UserWordsResolver>())
            //    .ForMember(x => x.ActivityLog, x => x.Ignore())
            //    ;

            //CreateMap<StatisticWordsLog, WordsStatisticDTO>()
            //    .ForMember(x => x.TimeSeconds, x => x.MapFrom(t => (int) t.Time.TotalSeconds))
            //    ;
            //CreateMap<WordsStatisticDTO, StatisticWordsLog>();
            //CreateMap<StatisticWordsLog, WordsStatisticDTO>();
        }

    }

    //public class UserWordsResolver : IValueResolver<WordsStatisticDTO, StatisticWordsLog, User>
    //{
    //    public User Resolve(WordsStatisticDTO source, StatisticWordsLog destination, User destMember, ResolutionContext context)
    //    {
    //        return context.Options.CreateInstance<ReadingMemoryThinkingDbContext>().Set<User>().First();
    //    }
    //}
}