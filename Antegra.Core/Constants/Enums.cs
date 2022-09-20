using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Labote.Core.Constants
{
    public class Enums
    {
        public const string SecretKey = "9fbac4553b7548e6ad7401f201056083";

    

        public enum JobScheduleTimeType
        {
            [Display(Description = "Dakika")]
            Minute = 1,
            [Display(Description = "Saat")]
            Hour = 2,
            [Display(Description = "Gün")]
            Day = 3,
        }

        public enum DocumnetKind
        {
            [Display(Description = "Kişi")]
            Person = 1,
            [Display(Description = "Firma")]
            Company = 2,
            [Display(Description = "Ürün")]
            Product = 3,
        }
        public enum DocumentType
        {
            [Display(Description = "Rapor")]
            report = 1,
            [Display(Description = "Sertifika")]
            Certifica = 2,
       
        }

        public enum DocumentApplicationMeetStatus
        {
            [Display(Description = "Görüşülmedi")]
            NotMeet = 1,
            [Display(Description = "Olumlu")]
            Positive = 2,
            [Display(Description = "Olumsuz")]
            Nagative = 2,

        }
        public enum CertificaType
        {
            [Display(Description = "Kişi")]
            Person = 1,
            [Display(Description = "Kurum")]
            Company = 2,
            [Display(Description = "Ürün")]
            Product = 3,
        }

        public const string Admin = "Admin";
        public const string User = "Kullanici";


    }


    public static class EnumDisplay
    {

        public static string GetDisiplayDescription(this Enum enm)
        {

            var das = enm;
            var enumType = enm.GetType().GetMember(enm.ToString());
            try
            {
                return enumType.FirstOrDefault().GetCustomAttribute<DisplayAttribute>()?.Description;
            }
            catch (Exception)
            {

                return "";
            }




        }

    }

}
