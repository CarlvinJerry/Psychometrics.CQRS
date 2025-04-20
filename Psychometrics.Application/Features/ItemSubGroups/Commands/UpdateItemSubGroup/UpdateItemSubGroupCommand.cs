using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Exceptions;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Domain.Entities;

namespace Psychometrics.Application.Features.ItemSubGroups.Commands.UpdateItemSubGroup
{
    public class UpdateItemSubGroupCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ItemGroupId { get; set; }
    }

    public class UpdateItemSubGroupCommandHandler : IRequestHandler<UpdateItemSubGroupCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateItemSubGroupCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateItemSubGroupCommand request, CancellationToken cancellationToken)
        {
            var itemSubGroup = await _context.ItemSubGroups.FindAsync(request.Id);
            if (itemSubGroup == null)
            {
                return Unit.Value;
            }

            itemSubGroup.Name = request.Name;
            itemSubGroup.Description = request.Description;
            itemSubGroup.ItemGroupId = request.ItemGroupId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
} 