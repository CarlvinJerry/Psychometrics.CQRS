using AutoMapper;
using Psychometrics.Application.Common.DTOs;
using Psychometrics.Domain.Entities;

namespace Psychometrics.Application.Common.Mappings
{
    public class ItemSubGroupMappingProfile : Profile
    {
        public ItemSubGroupMappingProfile()
        {
            CreateMap<ItemSubGroup, ItemSubGroupDto>()
                .ForMember(d => d.ItemSubGroupID, opt => opt.MapFrom(s => s.ItemSubGroupID))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Code, opt => opt.MapFrom(s => s.Code))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.ItemGroupID, opt => opt.MapFrom(s => s.ItemGroupID))
                .ForMember(d => d.ItemSubGroupTypeID, opt => opt.MapFrom(s => s.ItemSubGroupTypeID))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(s => s.IsActive))
                .ForMember(d => d.CreatedAt, opt => opt.MapFrom(s => s.CreatedAt))
                .ForMember(d => d.UpdatedAt, opt => opt.MapFrom(s => s.UpdatedAt));
        }
    }
} 