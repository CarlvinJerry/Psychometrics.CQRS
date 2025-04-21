using AutoMapper;
using Psychometrics.Application.Common.DTOs;
using Psychometrics.Domain.Entities;

namespace Psychometrics.Application.Common.Mappings
{
    public class ItemResponseMappingProfile : Profile
    {
        public ItemResponseMappingProfile()
        {
            CreateMap<ItemResponse, ItemResponseDto>()
                .ForMember(d => d.ItemResponseID, opt => opt.MapFrom(s => s.ItemResponseID))
                .ForMember(d => d.ItemID, opt => opt.MapFrom(s => s.ItemID))
                .ForMember(d => d.StudentCandidateNumber, opt => opt.MapFrom(s => s.StudentCandidateNumber))
                .ForMember(d => d.ItemCode, opt => opt.MapFrom(s => s.ItemCode))
                .ForMember(d => d.ResponseValue, opt => opt.MapFrom(s => s.ResponseValue))
                .ForMember(d => d.MSCAAID, opt => opt.MapFrom(s => s.MSCAAID))
                .ForMember(d => d.CalendarYear, opt => opt.MapFrom(s => s.CalendarYear))
                .ForMember(d => d.TeachingPeriod, opt => opt.MapFrom(s => s.TeachingPeriod))
                .ForMember(d => d.ResponseTime, opt => opt.MapFrom(s => s.ResponseTime))
                .ForMember(d => d.CreatedAt, opt => opt.MapFrom(s => s.CreatedAt))
                .ForMember(d => d.UpdatedAt, opt => opt.MapFrom(s => s.UpdatedAt));
        }
    }
} 