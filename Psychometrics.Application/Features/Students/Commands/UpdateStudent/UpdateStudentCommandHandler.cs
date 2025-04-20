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
    /// Handler for processing UpdateStudentCommand requests.
    /// </summary>
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the UpdateStudentCommandHandler class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public UpdateStudentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the update of an existing Student.
        /// </summary>
        /// <param name="request">The command containing the updated Student details.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Unit value indicating completion.</returns>
        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FindAsync(request.Id);
            if (student == null)
            {
                return Unit.Value;
            }

            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.Email = request.Email;
            student.PhoneNumber = request.PhoneNumber;
            student.DateOfBirth = request.DateOfBirth;
            student.Gender = request.Gender;
            student.StudentNumber = request.StudentNumber;
            student.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
} 