using Microsoft.AspNetCore.Mvc;
using TaskManager.Communication.Request;
using TaskManager.Communication.Response;
using TaskManager.Services.Exceptions;
using TaskManager.Services.UseCase.Tasks.Delete;
using TaskManager.Services.UseCase.Tasks.GetAll;
using TaskManager.Services.UseCase.Tasks.GetById;
using TaskManager.Services.UseCase.Tasks.Register;
using TaskManager.Services.UseCase.Tasks.Update;

namespace TaskManager.API.Controllers;

[Route("api/tasks")]
[ApiController]
public class TasksController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(TaskResponseJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult CreateTask([FromBody] TaskRequestJson request)
    {
        try
        {
            var response = new RegisterTaskUseCase().Execute(request);

            return Created(string.Empty, response);
        }
        catch (ErrorOnValidationException ex)
        {
            return BadRequest(new ResponseErrorJson { Errors = ex.Errors });
        }
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseGetAllTasksJson), StatusCodes.Status200OK)]
    public IActionResult GetAllTasks()
    {
        var response = new GetAllTasksUseCase().Execute();

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(TaskResponseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFoundException), StatusCodes.Status404NotFound)]
    public IActionResult GetTaskById([FromRoute] Guid id)
    {
        try
        {
            var response = new GetTaskByIdUseCase().Execute(id);

            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new ResponseErrorJson { Errors = [ex.Message] });
        }
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(typeof(TaskResponseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult UpdateTask([FromRoute] Guid id, [FromBody] TaskRequestJson request)
    {
        try
        {
            var response = new UpdateTaskUseCase().Execute(id, request);

            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new ResponseErrorJson { Errors = new List<string> { ex.Message } });
        }
        catch (ErrorOnValidationException ex)
        {
            return BadRequest(new ResponseErrorJson { Errors = ex.Errors });
        }
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult DeleteTask([FromRoute] Guid id)
    {
        try
        {
            new DeleteTaskUseCase().Execute(id);

            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(new ResponseErrorJson { Errors = new List<string> { ex.Message } });
        }
    }
}
