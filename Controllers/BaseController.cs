using LR4_Baranov.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LR4_Baranov.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<T> : ControllerBase where T : class
    {
        protected readonly IBaseService<T> service;

        public BaseController(IBaseService<T> service)
        {
            this.service = service;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<T>>> GetAll()
        {
            var entities = await service.GetAllAsync();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<T>> GetById(int id)
        {
            var entity = await service.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost]
        public virtual async Task<ActionResult<T>> Create([FromBody] T entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdEntity = await service.CreateAsync(entity);
            var id = GetEntityId(createdEntity);

            return CreatedAtAction(nameof(GetById), new { id = id }, createdEntity);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(int id, [FromBody] T entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await service.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var entity = await service.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            await service.DeleteAsync(entity);
            return NoContent();
        }

        protected virtual object? GetEntityId(T entity)
        {
            var property = typeof(T).GetProperty($"{typeof(T).Name}Id")
                        ?? typeof(T).GetProperty("Id");

            return property?.GetValue(entity);
        }
    }
}