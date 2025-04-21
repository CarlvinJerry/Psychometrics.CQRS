using MediatR;
using Microsoft.AspNetCore.Mvc;
using PsychometricsV2.Application.DTOs;
using PsychometricsV2.Application.Features.Students.Commands.CreateStudent;
using PsychometricsV2.Application.Features.Students.Commands.DeleteStudent;
using PsychometricsV2.Application.Features.Students.Commands.UpdateStudent;
using PsychometricsV2.Application.Features.Students.Queries.GetStudentById;
using PsychometricsV2.Application.Features.Students.Queries.GetStudents;

namespace PsychometricsV2.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Gets all students
    /// </summary>
    /// <returns>List of students</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<StudentDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<StudentDto>>> GetAll()
    {
        var students = await _mediator.Send(new GetStudentsQuery());
        return Ok(students);
    }

    /// <summary>
    /// Gets a student by ID
    /// </summary>
    /// <param name="id">The student ID</param>
    /// <returns>The student if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(StudentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<StudentDto>> Get(int id)
    {
        var student = await _mediator.Send(new GetStudentByIdQuery(id));
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

    /// <summary>
    /// Creates a new student
    /// </summary>
    /// <param name="command">The student creation command</param>
    /// <returns>The ID of the created student</returns>
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> Create(CreateStudentCommand command)
    {
        var studentId = await _mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id = studentId }, studentId);
    }

    /// <summary>
    /// Updates an existing student
    /// </summary>
    /// <param name="id">The student ID</param>
    /// <param name="command">The student update command</param>
    /// <returns>No content if successful</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, UpdateStudentCommand command)
    {
        if (id != command.StudentId)
        {
            return BadRequest();
        }

        var success = await _mediator.Send(command);
        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Deletes a student
    /// </summary>
    /// <param name="id">The student ID</param>
    /// <returns>No content if successful</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _mediator.Send(new DeleteStudentCommand(id));
        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }
} 