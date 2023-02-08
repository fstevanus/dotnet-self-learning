using AutoMapper;
using Learning.Entities.Dtos;
using Learning.Entities.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Learning.WebApi.Controllers;

public abstract class CrudController<TEntity, TRequestDto, TResponseDto> : ControllerBase where TEntity : ModelBase
  where TRequestDto : IRequestDto
  where TResponseDto : IResponseDto
{
  protected CrudController(IRepositoryManager repository, IMapper mapper)
  {
    Repository = repository;
    Mapper = mapper;
  }

  protected IRepositoryManager Repository { get; }
  protected IMapper Mapper { get; }

  protected async Task<IActionResult> ListAsync()
  {
    var entities = await GetEntitiesAsync();

    return Ok(entities);
  }

  protected async Task<IActionResult> CreateAsync(TRequestDto createDto)
  {
    var entity = Mapper.Map<TEntity>(createDto);
    Repository.Set<TEntity>().Create(entity);
    await Repository.SaveAsync();

    var dto = Mapper.Map<TResponseDto>(entity);

    var actionName = $"Get{typeof(TEntity).Name}";
    if (GetType().GetMethod(actionName) != null)
    {
      return CreatedAtAction(actionName, new { id = dto.Id }, dto);
    }

    return Created($"{Request.GetDisplayUrl()}/{dto.Id}", dto);
  }

  protected virtual async Task<List<TEntity>> GetEntitiesAsync() =>
    await Repository.Set<TEntity>().FindAll(false).ToListAsync();
}