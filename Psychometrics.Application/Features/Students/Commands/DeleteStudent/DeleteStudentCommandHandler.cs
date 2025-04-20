using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Exceptions;

namespace Psychometrics.Application.Features.Students.Commands.DeleteStudent
{
    /// <summary>
    /// Handler for processing DeleteStudentCommand requests.
    /// </summary>
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the DeleteStudentCommandHandler class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public DeleteStudentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the deletion of an existing Student.
        /// </summary>
        /// <param name="request">The command containing the ID of the Student to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Unit value indicating completion.</returns>
        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FindAsync(request.Id);
            if (student == null)
            {
                return Unit.Value;
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
} 