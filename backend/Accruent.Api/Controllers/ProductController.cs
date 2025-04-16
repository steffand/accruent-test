using System.Runtime.CompilerServices;
using Accruent.Data.Interface;
using Accruent.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Accruent.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IBaseRepository<Product> productRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Product>> Get(CancellationToken cancellationToken)
        {
            return await productRepository.GetAllAsync(cancellationToken: cancellationToken);
        }
    }
}
