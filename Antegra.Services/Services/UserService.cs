using Labote.Core;
using Labote.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labote.Services.Services
{
    
    public class UserService : IUserService
    {
        private readonly LaboteContext _context;

        public UserService(LaboteContext context)
        {
            _context = context;
        }


    }
}
