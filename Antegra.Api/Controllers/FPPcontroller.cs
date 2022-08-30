using Labote.Api.BindingModel;
using Labote.Api.BindingModel.RequestModel;
using Labote.Api.Controllers.LaboteController;
using Labote.Core;
using Labote.Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Labote.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FPPcontroller : LaboteControllerBase
    {
        private readonly LaboteContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public FPPcontroller(LaboteContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost("GetData")]
        [AllowAnonymous]
        public async Task<BaseResponseModel> GetData(GetByObjectId model)
        {
            if (model.DocumnetKind == (int)Enums.DocumnetKind.Company)
            {
                var data = _context.Companies.Where(x => x.Id == model.ObjectId).Select(x => new
                {
                    x.Address,
                    x.Description,
                    x.LogoUrl,
                    x.Name,
                    x.Phone,
                    x.Email,
                    Documents = x.Documents.Select(y => new
                    {
                        y.Description,
                        y.DocumentNo,
                        DocumentDate = y.DocumentDate.ToString("dd/MM/yyyy"),
                        y.DocumentType,
                        y.Name,
                        ExpireDate = y.ExpireDate.ToString("dd/MM/yyyy"),
                        DocumentFiles = y.DocumentFiles.Select(z => new
                        {
                            z.Url,
                            z.Type,
                            Extension = Path.GetExtension(z.Url),
                            Size = new FileInfo(_hostingEnvironment.ContentRootPath + "/wwwroot/Upload/" + z.Url).Length / 1024,
                        })
                    })
                });
                PageResponse.Data = data.FirstOrDefault();
            }
            else if (model.DocumnetKind == (int)Enums.DocumnetKind.Person)
            {
                var data = _context.Persons.Where(x => x.Id == model.ObjectId).Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.LogoUrl,
                    x.Title,
                    x.Description,
                    Documents = x.Documents.Select(y => new
                    {
                        y.Description,
                        y.DocumentNo,
                        DocumentDate = y.DocumentDate.ToString("dd/MM/yyyy"),
                        y.DocumentType,
                        y.Name,
                        ExpireDate = y.ExpireDate.ToString("dd/MM/yyyy"),
                        DocumentFiles = y.DocumentFiles.Select(z => new
                        {
                            z.Url,
                            z.Type,
                            Extension = Path.GetExtension(z.Url),
                            Size = new FileInfo(_hostingEnvironment.ContentRootPath + "/wwwroot/Upload/" + z.Url).Length / 1024,
                        })
                    })
                });
                PageResponse.Data = data.FirstOrDefault();

            }
            else
            {
                var data = _context.Products.Where(x => x.Id == model.ObjectId).Select(x => new
                {
                    x.Name,
                    x.LogoUrl,
                    x.Barcode,
                    x.CompanyName,
                    x.Description,
                    Documents = x.Documents.Select(y => new
                    {
                        y.Description,
                        y.DocumentNo,
                        DocumentDate = y.DocumentDate.ToString("dd/MM/yyyy"),
                        y.DocumentType,
                        y.Name,
                        ExpireDate = y.ExpireDate.ToString("dd/MM/yyyy"),
                        DocumentFiles = y.DocumentFiles.Select(z => new
                        {
                            z.Url,
                            z.Type,
                            Extension = Path.GetExtension(z.Url),
                            Size = new FileInfo(_hostingEnvironment.ContentRootPath + "/wwwroot/Upload/" + z.Url).Length / 1024,
                        })
                    })
                });
                try
                {
                PageResponse.Data = data.FirstOrDefault();

                }
                catch (Exception e )
                {

                    throw;
                }

            }

            return PageResponse;
        }
    }
}
