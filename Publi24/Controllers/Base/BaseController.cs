using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Publi24.Services;
using System.Threading.Tasks;

namespace Publi24.Controllers
{
   
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    public  abstract class BaseController<TService, TModel, TCreateModel> : ControllerBase
        where TService : IBaseService<TModel>
    {   
        protected readonly TService _service;

        public BaseController(TService service)
        {
            _service = service;
        }

        [HttpGet()]
        public virtual IActionResult GetList()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result=_service.GetAll();
            return Ok(result);
        }

        [HttpPost()]
        public virtual async Task<IActionResult> Post([FromBody] TCreateModel value)
        {
            if (!ModelState.IsValid || value == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Add(value);
                return CreatedAtAction("", result);
            }
            catch (System.Exception ex)
            {
               return BadRequest(ex.Message);
            }      
        }

        [HttpGet("{id:int}")]
        public virtual IActionResult Get(int id)
        {
            var result= _service.Get(id);
            if(result==null) return NotFound();
            return Ok(result);
        }

        [HttpPut()]
        public virtual IActionResult Put([FromBody] TModel value)
        {
            if (!ModelState.IsValid || value == null)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = _service.Put(value);
                return CreatedAtAction("", result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
