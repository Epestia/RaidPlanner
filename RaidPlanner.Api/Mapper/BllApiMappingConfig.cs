using Mapster;
using RaidPlanner.Api.Dto;
using RaidPlanner.Api.Dtos;
using RaidPlanner.Bll.ObjectModels;
using RaidPlanner.DAL.Models;

namespace RaidPlanner.Api.Mapping
{
    public class BllApiMappingConfig
    {
        public static void ConfigureMappings()
        {
            TypeAdapterConfig<UserModel, UserDto>.NewConfig();
            TypeAdapterConfig<UserDto, UserModel>.NewConfig();
            TypeAdapterConfig<RoleModel, RoleDto>.NewConfig();
            TypeAdapterConfig<RoleDto, RoleModel>.NewConfig();
            TypeAdapterConfig<CharacterModel, CharacterDto>.NewConfig();
            TypeAdapterConfig<CharacterDto, CharacterModel>.NewConfig();
            TypeAdapterConfig<JobModel, JobDto>.NewConfig();
            TypeAdapterConfig<JobDto, JobModel>.NewConfig();
            TypeAdapterConfig<AvailabilityModel, AvailabilityDto>.NewConfig();
            TypeAdapterConfig<AvailabilityDto, AvailabilityModel>.NewConfig();
            TypeAdapterConfig<ExtensionModel, ExtensionDto>.NewConfig();
            TypeAdapterConfig<ExtensionDto, ExtensionModel>.NewConfig();
            TypeAdapterConfig<RaidModel, RaidDto>.NewConfig();
            TypeAdapterConfig<RaidDto, RaidModel>.NewConfig();
            TypeAdapterConfig<RaidSessionModel, RaidSessionDto>.NewConfig();
            TypeAdapterConfig<RaidSessionDto, RaidSessionModel>.NewConfig();
            TypeAdapterConfig<RecompenseModel, RecompenseDto>.NewConfig();
            TypeAdapterConfig<RecompenseDto, RecompenseModel>.NewConfig();
        }
    }
}
