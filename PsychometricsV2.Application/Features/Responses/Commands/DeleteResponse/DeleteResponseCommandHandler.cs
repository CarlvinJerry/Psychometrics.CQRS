using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PsychometricsV2.Application.Interfaces;

namespace PsychometricsV2.Application.Features.Responses.Commands.DeleteResponse;

public class DeleteResponseCommandHandler : IRequestHandler<DeleteResponseCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteResponseCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteResponseCommand request, CancellationToken cancellationToken)
    {
        var response = await _context.Responses.FindAsync(new object[] { request.Id }, cancellationToken);

        if (response == null)
        {
            return false;
        }

        _context.Responses.Remove(response);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
} 