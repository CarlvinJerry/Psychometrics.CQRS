using AutoMapper;
using Psychometrics.Application.Common.DTOs;
using Psychometrics.Domain.Entities;
using Psychometrics.Application.Features.ItemResponses.Queries.GetItemResponseById;

namespace Psychometrics.Application.Common.Mappings
{
    public class ResponseMappingProfile : Profile
    {
        public ResponseMappingProfile()
        {
            CreateMap<ItemResponse, ItemResponseDto>()
                .ForMember(d => d.Student, opt => opt.MapFrom(s => new StudentBriefDto
                {
                    CandidateNumber = s.StudentCandidateNumber,
                    FullName = $"{s.Student.FirstName} {s.Student.Surname}"
                }))
                .ForMember(d => d.Item, opt => opt.MapFrom(s => new ItemBriefDto
                {
                    Code = s.ItemCode,
                    Name = s.Item.Name
                }));

            CreateMap<ResponseDto, Response>();
        }
    }
} 