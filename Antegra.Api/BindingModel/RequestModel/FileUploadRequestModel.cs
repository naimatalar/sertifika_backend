using Microsoft.AspNetCore.Http;

namespace Labote.Api.BindingModel.RequestModel
{
    public class FileUploadRequestModel
    {
        public IFormFile  File { get; set; }
    }
}
