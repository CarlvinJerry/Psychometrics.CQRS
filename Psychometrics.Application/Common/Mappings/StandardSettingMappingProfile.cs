using AutoMapper;
using Psychometrics.Application.Common.DTOs;
using Psychometrics.Domain.Entities;

namespace Psychometrics.Application.Common.Mappings
{
    public class StandardSettingMappingProfile : Profile
    {
        public StandardSettingMappingProfile()
        {
            CreateMap<StandardSetting, StandardSettingDto>()
                .ForMember(d => d.StandardSettingID, opt => opt.MapFrom(s => s.StandardSettingID))
                .ForMember(d => d.Method, opt => opt.MapFrom(s => s.Method))
                .ForMember(d => d.RecordMonth, opt => opt.MapFrom(s => s.RecordMonth))
                .ForMember(d => d.CalendarYear, opt => opt.MapFrom(s => s.CalendarYear))
                .ForMember(d => d.AcademicYear, opt => opt.MapFrom(s => s.AcademicYear))
                .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Category))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(d => d.TeachingPeriod, opt => opt.MapFrom(s => s.TeachingPeriod))
                .ForMember(d => d.YearLevel, opt => opt.MapFrom(s => s.YearLevel))
                .ForMember(d => d.Phase, opt => opt.MapFrom(s => s.Phase))
                .ForMember(d => d.PassingScore, opt => opt.MapFrom(s => s.PassingScore))
                .ForMember(d => d.EXCScore, opt => opt.MapFrom(s => s.EXCScore))
                .ForMember(d => d.MaxScoreRaw, opt => opt.MapFrom(s => s.MaxScoreRaw))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(s => s.IsActive))
                .ForMember(d => d.CreatedAt, opt => opt.MapFrom(s => s.CreatedAt))
                .ForMember(d => d.UpdatedAt, opt => opt.MapFrom(s => s.UpdatedAt));
        }
    }
} 