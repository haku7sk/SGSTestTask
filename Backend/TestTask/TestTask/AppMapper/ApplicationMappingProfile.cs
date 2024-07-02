using System.ComponentModel;
using AutoMapper;
using TestTask.Models.Dbo;
using TestTask.Models.Dto;

namespace TestTask.AppMapper;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<ContainerDbo, ContainerDto>();
        CreateMap<ContainerDto, ContainerDbo>();

        CreateMap<OperationDbo, OperationDto>();
        CreateMap<OperationDto, OperationDbo>();
    }
}