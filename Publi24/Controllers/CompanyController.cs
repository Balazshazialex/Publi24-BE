using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Publi24.BMs;
using Publi24.Entities;
using Publi24.Services;

namespace Publi24.Controllers
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class CompanyController : BaseController<ICompanyService<Company>, Company, CompanyCreateBM>
    {
        public CompanyController(ICompanyService<Company> service) : base(service)
        {

        }
        
        [HttpGet("isin/{isin}")]
        public virtual IActionResult GetByIsin(string isin)
        {
            var result = _service.Get(isin);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
