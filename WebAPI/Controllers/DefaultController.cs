using Business.Abstract.Services;
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete.Models;

namespace WebAPI.Controllers
{
    [Route("api/default")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        #region Constructor Method
        IDefaultService _defaultManager;

        public DefaultController(IDefaultService defaultManager)
        {
            _defaultManager = defaultManager;
        }
        #endregion

        #region Controller Methods

        [HttpGet]
        [Route("list")]
        public IActionResult Get()
        {
            var result = _defaultManager.GetAll();

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("list/{id}")]
        public IActionResult Get(int id)
        {
            var result = _defaultManager.GetById(id);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(Default entity)
        {
            var result = _defaultManager.Delete(entity);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(Default entity)
        {
            var result = _defaultManager.Update(entity);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(Default entity)
        {
            var result = _defaultManager.Add(entity);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        #endregion
    }
}
