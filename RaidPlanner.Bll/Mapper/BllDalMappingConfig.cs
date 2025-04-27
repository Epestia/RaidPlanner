using Mapster;
using RaidPlanner.Bll.ObjectModels;
using RaidPlanner.DAL.Models;

namespace RaidPlanner.Bll.Mappers
{
    public static class BllDalMappingConfig
    {
        public static void ConfigureMappings()
        {
            TypeAdapterConfig<User, UserModel>.NewConfig();
            TypeAdapterConfig<UserModel, User>.NewConfig();
            TypeAdapterConfig<Role, RoleModel>.NewConfig();
            TypeAdapterConfig<RoleModel, Role>.NewConfig();
            TypeAdapterConfig<Character, CharacterModel>.NewConfig()
                .Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest.JobId, src => src.JobId);
            TypeAdapterConfig<CharacterModel, Character>.NewConfig()
                .Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest.JobId, src => src.JobId);
            TypeAdapterConfig<Job, JobModel>.NewConfig()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Role, src => src.Role);
            TypeAdapterConfig<JobModel, Job>.NewConfig()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Role, src => src.Role);
            TypeAdapterConfig<Availability, AvailabilityModel>.NewConfig();
            TypeAdapterConfig<AvailabilityModel, Availability>.NewConfig();
            TypeAdapterConfig<Extension, ExtensionModel>.NewConfig();
            TypeAdapterConfig<ExtensionModel, Extension>.NewConfig();
            TypeAdapterConfig<Raid, RaidModel>.NewConfig();
            TypeAdapterConfig<RaidModel, Raid>.NewConfig();
            TypeAdapterConfig<RaidSession, RaidSessionModel>.NewConfig();
            TypeAdapterConfig<RaidSessionModel, RaidSession>.NewConfig();
            TypeAdapterConfig<Recompense, RecompenseModel>.NewConfig();
            TypeAdapterConfig<RecompenseModel, Recompense>.NewConfig();
        }
    }
}
