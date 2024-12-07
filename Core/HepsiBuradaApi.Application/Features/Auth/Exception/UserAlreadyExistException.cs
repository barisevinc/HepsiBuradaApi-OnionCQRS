using HepsiBuradaApi.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaApi.Application.Features.Auth.Exception
{
    public class UserAlreadyExistException :BaseException
    {
        public UserAlreadyExistException() : base("Böyle bir kullanıcı zaten var.") { }
    }
}
