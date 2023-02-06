using Learning.Entities.Dtos;
using Learning.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Learning.WebApi.Controllers;

public abstract class CrudController<TEntity, TRequestDto, TResponseDto> : ControllerBase where TEntity : ModelBase
  where TRequestDto : IRequestDto
  where TResponseDto : IResponseDto
{
  protected CrudController(IRepositoryManager repository, ILogger logger)
  {
    Repository = repository;
    Logger = logger;
  }

  protected IRepositoryManager Repository { get; }
  protected ILogger Logger { get; }

  protected async Task<IActionResult> ListAsync()
  {
    var entities = await GetEntitiesAsync();

    return Ok(entities);
  }

  protected async Task<IActionResult> CreateAsync(TRequestDto creatDto)
  {
    
  }

  protected virtual async Task<List<TEntity>> GetEntitiesAsync() =>
    await Repository.Set<TEntity>().FindAll(false).ToListAsync();
}