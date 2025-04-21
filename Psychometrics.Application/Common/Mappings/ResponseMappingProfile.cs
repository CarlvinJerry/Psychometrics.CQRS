using AutoMapper;
using Psychometrics.Application.Common.DTOs;
using Psychometrics.Domain.Entities;
using Psychometrics.Application.Features.Responses.Queries.GetResponseById;

namespace Psychometrics.Application.Common.Mappings
{
    public class ResponseMappingProfile : Profile
    {
        public ResponseMappingProfile()
        {
            CreateMap<Response, ResponseDto>()
                .ForMember(d => d.Student, opt => opt.MapFrom(s => new StudentBriefDto
                {
                    Id = s.Student.Id,
                    StudentNumber = s.Student.StudentNumber,
                    FullName = $"{s.Student.FirstName} {s.Student.LastName}"
                }))
                .ForMember(d => d.Item, opt => opt.MapFrom(s => new ItemBriefDto
                {
                    Id = s.Item.Id,
                    ItemCode = s.Item.ItemCode,
                    Question = s.Item.Question
                }));

            CreateMap<ResponseDto, Response>();
        }
    }
} 