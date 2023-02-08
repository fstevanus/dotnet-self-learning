using AutoMapper;
using Learning.Entities.Dtos;
using Learning.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace Learning.WebApi.Controllers;

[Route("api/blog")]
[ApiController]
public class BlogController : CrudController<Blog,BlogRequestDto,BlogResponseDto>
{
  public BlogController(IRepositoryManager repository, IMapper mapper) : base(repository, mapper)
  {
  }

  [HttpGet]
  public async Task<IActionResult> ListBlog() => await ListAsync();

  [HttpPost]
  public async Task<IActionResult> CreateBlog([FromBody] BlogRequestDto dto) => await CreateAsync(dto);
}