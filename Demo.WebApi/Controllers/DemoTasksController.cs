using Demo.Contracts.Bl;
using Demo.Contracts.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoTasksController : ControllerBase
    {
        private IDemoTaskBl BlController { get; }
        public DemoTasksController(IDemoTaskBl model)
        {
            this.BlController = model;
        }

        [HttpGet]
        public async Task<ActionResult<List<DemoTask>>> GetAllAsync()
        {
            try
            {
                return Ok(await this.BlController.GetAllAsync().ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                return Problem(ex.InnerException?.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<DemoTask>>> GetByIdAsync(int id)
        {
            try
            {
                var demoTask = await this.BlController.GetByIdAsync(id).ConfigureAwait(false);
                if (demoTask == null)
                    return BadRequest("Not Found.");


                return Ok(demoTask);

            }
            catch (Exception ex)
            {
                return Problem(ex.InnerException?.ToString());
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<DemoTask>>> CreateAsync(DemoTask demoTask)
        {
            if (demoTask == null)
            {
                return BadRequest();
            }
            try
            {
                await this.BlController.CreateAsync(demoTask).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return Problem(ex.InnerException?.ToString());
            }

            return Ok(await this.BlController.GetAllAsync().ConfigureAwait(false));
        }

        [HttpPut]
        public async Task<ActionResult<List<DemoTask>>> UpdateAsyc(DemoTask demoTask)
        {
            if (demoTask == null)
            {
                return BadRequest();
            }
            try
            {
                if (!await this.BlController.UpdateAsync(demoTask))
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.InnerException?.ToString());
            }

            return Ok(await this.BlController.GetAllAsync().ConfigureAwait(false));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<DemoTask>>> DeleteAsync(int id)
        {
            try
            {
                var demoTaskOld = await this.BlController.DeleteAsync(id).ConfigureAwait(false);
                if (demoTaskOld == null)
                    return BadRequest("Not Found.");
            }
            catch (Exception ex)
            {
                return Problem(ex.InnerException?.ToString());
            }

            return Ok(await this.BlController.GetAllAsync().ConfigureAwait(false));
        }
    }
}
