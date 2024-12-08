using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaApi.Application.Features.Auth.Command.Login
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
        [DefaultValue("barissevinc088@gmail.com")]
        public String Email {  get; set; }
        [DefaultValue("1234567")]
        public String Password { get; set; }
    }
}
