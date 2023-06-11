using AutoMapper;

namespace SIRS.RMT.ApplicationServices.MappingProfile
{
    public class StatisticColorsProfile : Profile
    {
        public StatisticColorsProfile()
        {
            //CreateMap<ColorsStatisticDTO, StatisticColorLog>()
            //    .ForMember(x => x.ExerciseType, x => x.MapFrom(t => (ColorsExerciseType) t.ExerciseType))
            //    .ForMember(x => x.ColorsSet, x => x.MapFrom(t => (ColorsSet) t.ColorsSet))
            //    .ForMember(x => x.Time, x => x.MapFrom(t => TimeSpan.FromSeconds(t.TimeSeconds)))
            //    .ForMember(x => x.User, x => x.MapFrom<UserResolver>())
            //    .ForMember(x => x.ActivityLog, x => x.Ignore())
            //    ;

            //CreateMap<StatisticColorLog, ColorsStatisticDTO>()
            //    .ForMember(x => x.TimeSeconds, x => x.MapFrom(t => (int) t.Time.TotalSeconds))
            //    .ForMember(x => x.ColorsSet, x => x.MapFrom(t => (int) t.ColorsSet))
            //    .ForMember(x => x.ExerciseType, x => x.MapFrom(t => (int) t.ExerciseType))
            //    ;
            //CreateMap<ColorsStatisticDTO, StatisticColorLog>();
            //CreateMap<StatisticColorLog, ColorsStatisticDTO>();

        }
    }

    //public class UserResolver : IValueResolver<ColorsStatisticDTO, StatisticColorLog, User>
    //{
    //    public User Resolve(ColorsStatisticDTO source, StatisticColorLog destination, User destMember, ResolutionContext context)
    //    {
    //        return context.Options.CreateInstance<ReadingMemoryThinkingDbContext>().Set<User>().First();
    //    }
    //}
}