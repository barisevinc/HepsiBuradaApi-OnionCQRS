using HepsiBuradaApi.Application.Bases;

namespace HepsiBuradaApi.Application.Features.Auth.Exception
{
    public class EmailOrPasswordShouldNotBeInvalidException : BaseException
    {
        public EmailOrPasswordShouldNotBeInvalidException() : base("Kullanıcı adı veya şifre hatalı.") { }
    }
}
