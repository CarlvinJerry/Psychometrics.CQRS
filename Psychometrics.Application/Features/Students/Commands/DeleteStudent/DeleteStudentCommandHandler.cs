using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Exceptions;

namespace Psychometrics.Application.Features.Students.Commands.DeleteStudent
{
    /// <summary>
    /// Handler for deleting a Student
    /// </summary>
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the DeleteStudentCommandHandler class
        /// </summary>
        /// <param name="context">The application database context</param>
        public DeleteStudentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the request to delete a Student
        /// </summary>
        /// <param name="request">The command request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>True if the Student was deleted, false otherwise</returns>
        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Students
                .FirstOrDefaultAsync(x => x.StudentID == request.StudentID, cancellationToken);

            if (entity == null)
                return false;

            _context.Students.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
} 