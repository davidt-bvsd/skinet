using System;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using API.RequestHelpers;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class BaseAPIController : ControllerBase
{
    protected async Task<ActionResult> CreatePagedResult<T>(IGenericRepository<T> repo, 
        ISpecification<T> spec, int PageIndex, int PageSize) where T : BaseEntity
    {
        var items = await repo.ListAsync(spec);
        var count = await repo.CountAsync(spec);

        var pagination = new Pagination<T>(PageIndex, PageSize, count, items);

        return Ok(pagination);
    }
}
