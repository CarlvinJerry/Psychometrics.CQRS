using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Psychometrics.Application.Interfaces;
using Psychometrics.Domain.Entities;

namespace Psychometrics.Application.Features.ItemSubGroupTypes.Commands.CreateItemSubGroupType
{
    public class CreateItemSubGroupTypeCommandHandler : IRequestHandler<CreateItemSubGroupTypeCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateItemSubGroupTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateItemSubGroupTypeCommand request, CancellationToken cancellationToken)
        {
            var itemSubGroupType = new ItemSubGroupType
            {
                ItemSubGroupTypeID = Guid.NewGuid(),
                Code = request.Code,
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow
            };

            _context.ItemSubGroupTypes.Add(itemSubGroupType);
            await _context.SaveChangesAsync(cancellationToken);

            return itemSubGroupType.ItemSubGroupTypeID;
        }
    }
} 