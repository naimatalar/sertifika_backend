using Labote.Api.BindingModel.RequestModel;
using Labote.Api.Controllers.LaboteController;
using Labote.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Labote.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FileUploadController : LaboteControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FileUploadController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpPost("Upload")]
        public async Task<dynamic> Upload([FromForm]FileUploadRequestModel model)
        {
            PageResponse.Data = new { FileName = model.File.UploadFile(_hostingEnvironment) };
            return PageResponse;
        }

    }
}
