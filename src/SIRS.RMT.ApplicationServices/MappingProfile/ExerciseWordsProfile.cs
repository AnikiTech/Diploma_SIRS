using AutoMapper;
using SIRS.RMT.ApplicationServices.DTO.Memory.WordsExercise;
using SIRS.RMT.Domain.EntityFramework;
using SIRS.RMT.Domain.Memory.Word;
using SIRS.RMT.Domain.SharedKernel;
using System.Linq;

namespace SIRS.RMT.ApplicationServices.MappingProfile
{
    public class ExerciseWordsProfile : Profile
    {
        public ExerciseWordsProfile()
        {
            _ = CreateMap<ExerciseSetup, ExerciseOrderWordsSetupDTO>();

            _ = CreateMap<ExerciseOrderWordsSetupDTO, ExerciseSetup>()
                .ForMember(x => x.User, x => x.MapFrom<UserResolver>())
                .ForMember(x => x.ActivityLog, x => x.Ignore())
                .ForMember(x => x.Id, x => x.Ignore())
                ;
        }

        private class UserResolver : IValueResolver<ExerciseOrderWordsSetupDTO, ExerciseSetup, User>
        {
            public User Resolve(ExerciseOrderWordsSetupDTO source, ExerciseSetup destination, User destMember, ResolutionContext context)
            {
                return context.Options.CreateInstance<ReadingMemoryThinkingDbContext>().Set<User>().First();
            }
        }
    }
}