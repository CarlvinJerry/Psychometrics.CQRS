using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Domain.Entities;

namespace Psychometrics.Application.Features.ItemSubGroups.Commands.CreateItemSubGroup
{
    public class CreateItemSubGroupCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ItemGroupId { get; set; }
    }

    public class CreateItemSubGroupCommandHandler : IRequestHandler<CreateItemSubGroupCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateItemSubGroupCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateItemSubGroupCommand request, CancellationToken cancellationToken)
        {
            var itemSubGroup = new ItemSubGroup
            {
                Name = request.Name,
                Description = request.Description,
                ItemGroupId = request.ItemGroupId
            };

            _context.ItemSubGroups.Add(itemSubGroup);
            await _context.SaveChangesAsync(cancellationToken);

            return itemSubGroup.Id;
        }
    }
} 