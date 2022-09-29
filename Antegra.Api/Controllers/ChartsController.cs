using Labote.Api.Controllers.LaboteController;
using Labote.Core;
using Labote.Core.BindingModels.response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labote.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : LaboteControllerBase
    {
        private readonly LaboteContext _context;

        public ChartsController(LaboteContext context)
        {
            _context = context;
        }
  
        [HttpGet("getDocumentTypeByYear/{year}")]
        public async Task<dynamic> getDocumentTypeByYear(int? year)
        {
            var Dataset = new List<dynamic>();
            if (year==null)
            {
                year = DateTime.Now.Year;
            }

            var data = _context.Documents.Where(x => x.DocumentDate.Year == year);
            var mount =new List<string>() { "Ocak", "Şubat","Mart","Nisan","Mayıs","Haziran","Temmuz","Eylül","Ekim","Kasım","Aralık" };
            var mountValFirm = new List<int>();
            var mountValPerson = new List<int>();
            var mountValProduct = new List<int>();
            
            var mountCount = 1;
            foreach (var item in mount)
            {
              var firmC=  data.Where(x => x.DocumnetKind == Core.Constants.Enums.DocumnetKind.Company && x.DocumentDate.Month == mountCount).Count();
                var personC = data.Where(x => x.DocumnetKind == Core.Constants.Enums.DocumnetKind.Person && x.DocumentDate.Month == mountCount).Count();
                var productC = data.Where(x => x.DocumnetKind == Core.Constants.Enums.DocumnetKind.Product && x.DocumentDate.Month == mountCount).Count();
                mountValFirm.Add(firmC);
                mountValPerson.Add(personC);
                mountValProduct.Add(productC);

                mountCount++;
            }


            Dataset.Add(new { Data = mountValFirm, Label = "Firma", BorderColor= "#004d40", BackgroundColor="#39796b" });
            Dataset.Add(new { Data = mountValPerson, Label = "Kişi", BorderColor = "#f9a825", BackgroundColor = "#ffd95a" });
            Dataset.Add(new { Data = mountValProduct, Label = "Ürün" , BorderColor = "#ad1457", BackgroundColor = "#e35183" });

            PageResponse.Data = new { Datasets = Dataset,Labels=mount};
            return PageResponse;
        }
     
        
        [HttpGet("GetDocumentApplicationStatusChart/{year}/{mout?}")]
        public async Task<dynamic> GetDocumentApplicationStatusChart(int? year,int? mout=null)
        {
            var Dataset = new List<dynamic>();
            if (year==null)
            {
                year = DateTime.Now.Year;
            }
            if (mout == null)
            {
                mout = 1;
            }

            var data = _context.DocumentAppilications.Where(x => x.CreateDate.Year == year && x.CreateDate.Month==mout);

            var notMeet = data.Where(x => x.DocumentApplicationMeetStatus == Core.Constants.Enums.DocumentApplicationMeetStatus.NotMeet).Count(); ;
            var negative = data.Where(x => x.DocumentApplicationMeetStatus == Core.Constants.Enums.DocumentApplicationMeetStatus.Nagative).Count(); ;
            var positive = data.Where(x => x.DocumentApplicationMeetStatus == Core.Constants.Enums.DocumentApplicationMeetStatus.Nagative).Count(); ;
            var dda = new List<int>() { notMeet, negative, positive };
            var bbs = new List<string>() { "#ff980096", "#f443369e", "#0b7210a1" };
            var lbls = new List<string>() { "Görüşülmedi", "Olumsuz", "Olumlu" };
            DocumentApplicationStatuschartResponseModel dd = new DocumentApplicationStatuschartResponseModel();
            dd.datasets.Add(new DocumentApplicationStatuschartDataset
            {
                data= dda,
                backgroundColor= bbs,
                borderWidth=1,
            });
            dd.labels = lbls;
            PageResponse.Data = dd;
            return PageResponse;
        }

    }
}
