using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Psychometrics.Application.Common.Interfaces;
using Psychometrics.Application.Exceptions;

namespace Psychometrics.Application.Features.Students.Commands.UpdateStudent
{
    /// <summary>
    /// Handler for updating a Student
    /// </summary>
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the UpdateStudentCommandHandler class
        /// </summary>
        /// <param name="context">The application database context</param>
        public UpdateStudentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the request to update a Student
        /// </summary>
        /// <param name="request">The command request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>True if the Student was updated, false otherwise</returns>
        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Students
                .FirstOrDefaultAsync(x => x.StudentID == request.StudentID, cancellationToken);

            if (entity == null)
                return false;

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Email = request.Email;
            entity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
} 