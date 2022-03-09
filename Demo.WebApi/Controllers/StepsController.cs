using Demo.Contracts.Bl;
using Demo.Contracts.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepsController : ControllerBase
    {
        private IStepBl BlController { get; }
        public StepsController(IStepBl model)
        {
            this.BlController = model;
        }

        [HttpGet]
        public async Task<ActionResult<List<Step>>> GetAllAsync()
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
        public async Task<ActionResult<List<Step>>> GetByIdAsync(int id)
        {
            try
            {
                var step = await this.BlController.GetByIdAsync(id).ConfigureAwait(false);
                if (step == null)
                    return BadRequest("Not Found.");


                return Ok(step);

            }
            catch (Exception ex)
            {
                return Problem(ex.InnerException?.ToString());
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Step>>> CreateAsync(Step step)
        {
            if (step == null)
            {
                return BadRequest();
            }
            try
            {
                await this.BlController.CreateAsync(step).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return Problem(ex.InnerException?.ToString());
            }

            return Ok(await this.BlController.GetAllAsync().ConfigureAwait(false));
        }

        [HttpPut]
        public async Task<ActionResult<List<Step>>> UpdateAsyc(Step step)
        {
            if (step == null)
            {
                return BadRequest();
            }
            try
            {
                if (!await this.BlController.UpdateAsync(step))
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
        public async Task<ActionResult<List<Step>>> DeleteAsync(int id)
        {
            try
            {
                var stepOld = await this.BlController.DeleteAsync(id).ConfigureAwait(false);
                if (stepOld == null)
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
