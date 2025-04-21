using AutoMapper;
using Psychometrics.Application.Common.DTOs;
using Psychometrics.Domain.Entities;

namespace Psychometrics.Application.Common.Mappings
{
    public class PivotTableClassMappingProfile : Profile
    {
        public PivotTableClassMappingProfile()
        {
            CreateMap<PivotTableClass, PivotTableClassDto>();
            CreateMap<PivotTableClassDto, PivotTableClass>();
        }
    }
} 