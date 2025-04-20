using AutoMapper;
using Psychometrics.Domain.Entities;
using Psychometrics.Application.Features.Students.Queries.GetStudentById;

namespace Psychometrics.Application.Common.Mappings
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<Student, StudentDto>();
        }
    }
} 