using DimitriSauvageTools.Exceptions;

namespace PetanquePlanning.Business.Identity.Domain.Exceptions
{
    public class InvalidTokenException : AppException
    {
        public InvalidTokenException(string token) : base($"The {token} token is invalid")
        {
        }
    }
}