using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IPasswordService
    {

        string HashPassword(string plainpassword); // devuelve iteraciones salt hash
        bool VerifyPassword(string password, string storedHash);

    }
}
