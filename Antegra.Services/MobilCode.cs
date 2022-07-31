using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labote.Services
{
    public static class MobilCode
    {
        public static string GenerateSmsCode()
        {
            var rend = new Random();
            return rend.Next(111111, 999999).ToString();
        }
    }
}
