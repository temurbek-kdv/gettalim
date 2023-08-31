﻿using GetTalim.DataAccess.Utils;
using GetTalim.Service.Dtos.Categories;
using GetTalim.Service.Interfaces.Categories;
using GetTalim.Service.Validators.Dtos.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GetTalim.Api.Controller;


[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;
    private readonly int maxPageSize = 30;

    public CategoriesController(ICategoryService service)
    {
        this._service = service;
    }

    [HttpGet]
    [AllowAnonymous]

    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("{categoryId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(long categoryId)
        => Ok(await _service.GetByIdAsync(categoryId));

    [HttpGet("count")]
    [AllowAnonymous]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] CategoryCreateDto dto)
    {
        var categoryCreateValidator = new CategoryCreateValidator();
        var result  = categoryCreateValidator.Validate(dto);
        if(result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    [HttpPut("{categoryId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(long categoryId, [FromForm] CategoryUpdateDto dto)
    {
        var categoryUpdateValidator  = new CategoryUpdateValidator();
        var result = categoryUpdateValidator.Validate(dto);
        if(result.IsValid) return Ok(await _service.UpdateAsync(categoryId, dto));
        else return BadRequest(result.Errors);
    }

    [HttpDelete("{categoryId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long categoryId)
        => Ok(await _service.DeleteAsync(categoryId));

}
