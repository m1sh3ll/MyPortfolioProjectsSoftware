using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.API.Data;

namespace ToDoList.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TodoController : ControllerBase
  {
    private readonly TodoDbContext _db;

   public TodoController(TodoDbContext todoDbContext) {
      _db = todoDbContext;
   }
  }
}
