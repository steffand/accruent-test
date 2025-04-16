using Accruent.Data.Interface;
using Accruent.Domain;
using Accruent.Models.Dto;
using Accruent.Models.Entity;
using Accruent.Models.Exception;
using Microsoft.AspNetCore.Mvc;

namespace Accruent.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovementController(IBaseRepository<Movement> movementRepository, IMovementService movementService) : ControllerBase
    {
        [HttpGet]
        public async Task<BaseResponse<IEnumerable<Movement>>> Get(int skip, [FromServices] CancellationToken cancellationToken)
        {
            var result = await movementRepository.GetAllAsync(skip, cancellationToken);

            return new BaseResponse<IEnumerable<Movement>>
            {
                Data = result,
                TotalRecords = result.Count
            };
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(MovementDto movement, CancellationToken cancellationToken)
        {
            try
            {
                await movementService.ProcessAsync(movement, cancellationToken).ConfigureAwait(false);
            }
            catch(InsuficientBalanceException e)
            {
                return BadRequest(e.Message);
            }
            catch(ProductNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return Ok();
        }
    }
}
