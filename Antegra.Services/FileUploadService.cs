using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labote.Services
{
    public static class FileUploadService
    {


        public static string UploadFile(this IFormFile f, IHostingEnvironment _hostingEnvironment)
        {
            if (f != null)
            {
                string name = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(f.FileName);
                using (Stream fileStream = new FileStream(_hostingEnvironment.ContentRootPath + "/wwwroot/Upload/" + name, FileMode.Create))
                {
                    f.CopyTo(fileStream);
                }
                return name;
            }
            return null;
        }

        public static void Delete(string fileName, IHostingEnvironment _hostingEnvironment)
        {
            try
            {
                System.IO.File.Delete(_hostingEnvironment.ContentRootPath + "/wwwroot/Upload/" + fileName);
            }
            catch (Exception)
            {
            }



        }



    }
}
