using AutoMapper;
using Psychometrics.Application.Common.DTOs;
using Psychometrics.Domain.Entities;

namespace Psychometrics.Application.Common.Mappings
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(d => d.StudentId, opt => opt.MapFrom(s => s.StudentId))
                .ForMember(d => d.CandidateNumber, opt => opt.MapFrom(s => s.CandidateNumber))
                .ForMember(d => d.EmailAddress, opt => opt.MapFrom(s => s.EmailAddress))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.Surname, opt => opt.MapFrom(s => s.Surname))
                .ForMember(d => d.Year, opt => opt.MapFrom(s => s.Year))
                .ForMember(d => d.YearOfEntry, opt => opt.MapFrom(s => s.YearOfEntry))
                .ForMember(d => d.SCJCode, opt => opt.MapFrom(s => s.SCJCode))
                .ForMember(d => d.AcademicYear, opt => opt.MapFrom(s => s.AcademicYear))
                .ForMember(d => d.Block, opt => opt.MapFrom(s => s.Block))
                .ForMember(d => d.ProgressCodeName, opt => opt.MapFrom(s => s.ProgressCodeName))
                .ForMember(d => d.Gender, opt => opt.MapFrom(s => s.Gender))
                .ForMember(d => d.AgeOnEntry, opt => opt.MapFrom(s => s.AgeOnEntry))
                .ForMember(d => d.Ethnicity, opt => opt.MapFrom(s => s.Ethnicity))
                .ForMember(d => d.Disability, opt => opt.MapFrom(s => s.Disability))
                .ForMember(d => d.HighestQualificationOnEntry, opt => opt.MapFrom(s => s.HighestQualificationOnEntry))
                .ForMember(d => d.RegionofDomicile, opt => opt.MapFrom(s => s.RegionofDomicile))
                .ForMember(d => d.Religion, opt => opt.MapFrom(s => s.Religion))
                .ForMember(d => d.SocioEconomicClass, opt => opt.MapFrom(s => s.SocioEconomicClass))
                .ForMember(d => d.PersonalTutor, opt => opt.MapFrom(s => s.PersonalTutor))
                .ForMember(d => d.ExternalTutorEmail, opt => opt.MapFrom(s => s.ExternalTutorEmail))
                .ForMember(d => d.HomeAddress, opt => opt.MapFrom(s => s.HomeAddress))
                .ForMember(d => d.LocalNonLocalWP, opt => opt.MapFrom(s => s.LocalNonLocalWP))
                .ForMember(d => d.DANU, opt => opt.MapFrom(s => s.DANU))
                .ForMember(d => d.Notes, opt => opt.MapFrom(s => s.Notes))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(s => s.IsActive))
                .ForMember(d => d.CreatedAt, opt => opt.MapFrom(s => s.CreatedAt))
                .ForMember(d => d.UpdatedAt, opt => opt.MapFrom(s => s.UpdatedAt));
        }
    }
} 