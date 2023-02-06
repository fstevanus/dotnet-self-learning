using Learning.Entities.Dtos;
using Learning.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace Learning.WebApi.Controllers;

[Route("api/blog")]
[ApiController]
public class BlogController : CrudController<Blog,BlogRequestDto,BlogResponseDto>
{
  public BlogController(IRepositoryManager repository, ILogger logger) : base(repository, logger)
  {
  }

  [HttpGet]
  public async Task<IActionResult> ListBlog() => await ListAsync();
}