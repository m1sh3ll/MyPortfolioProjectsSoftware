using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.API.Data;
using ToDoList.API.Models;

namespace ToDoList.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TodoController : ControllerBase
  {
    private readonly TodoDbContext _db;

    public TodoController(TodoDbContext todoDbContext)
    {
      _db = todoDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTodos()
    {
      var todos = await _db.Todos
      .Where(x=>x.IsDeleted ==false)
      .OrderByDescending(x=>x.CreatedDate)
      .ToListAsync();

      return Ok(todos);
    }

    //[HttpGet]
    //[Route("get-deleted-todos")]
    //public async Task<IActionResult> GetDeletedTodos()
    //{

    //}

    [HttpPost]
    public async Task<IActionResult> AddTodo(Todo todo)
    {
      todo.Id = Guid.NewGuid();
      await _db.Todos.AddAsync(todo);
      await _db.SaveChangesAsync();
      return Ok(todo);
    }

    [HttpPut]
    [Route("{id:Guid}")]
    public async Task<IActionResult> UpdateTodo([FromRoute] Guid id, Todo todoRequest)
    {
      var todo = await _db.Todos.FindAsync(id);

      if(todo == null) {
        return NotFound();
      }

      todo.IsCompleted = todoRequest.IsCompleted;
      todo.CompletedDate = DateTime.Now;
      await _db.SaveChangesAsync();
      return Ok(todo);
    }


    //[HttpPut]
    //[Route("undo-delete-todo/{id:Guid}")]
    //public async Task<IActionResult> UndoDeleteTodo([FromRoute] Guid id, Todo undoDeleteRequest)
    //{
    //}

    [HttpDelete]
    [Route("{id:Guid}")]
    public async Task<IActionResult> DeleteTodo([FromRoute] Guid id)
    {
      var todo = await _db.Todos.FindAsync(id);
      if (todo == null)
      {
        return NotFound();
      }

      todo.IsDeleted = true;
      todo.DeletedDate = DateTime.Now;

      await _db.SaveChangesAsync();
      return Ok(todo);
    }








    }
}
