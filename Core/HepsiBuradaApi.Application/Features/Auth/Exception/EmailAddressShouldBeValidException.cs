using HepsiBuradaApi.Application.Bases;

namespace HepsiBuradaApi.Application.Features.Auth.Exception
{
    public class EmailAddressShouldBeValidException : BaseException
    {
        public EmailAddressShouldBeValidException() : base("Böyle bir email adresi bulunmamaktadır.") { }
    }
}
