using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YatApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected  IUnitOfWork _unitofWork;

        public BaseApiController(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
    }
}
