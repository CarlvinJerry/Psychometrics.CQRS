using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;

namespace Psychometrics.Application.Features.ItemSubGroupTypes.Commands.UpdateItemSubGroupType
{
    public class UpdateItemSubGroupTypeCommandHandler : IRequestHandler<UpdateItemSubGroupTypeCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateItemSubGroupTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateItemSubGroupTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ItemSubGroupTypes.FindAsync(request.ItemSubGroupTypeID);

            if (entity == null)
            {
                return false;
            }

            entity.Code = request.Code;
            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
} 