using Tools.Exceptions;

namespace PetanquePlanning.Business.Identity.Domain.Exceptions
{
    public class InvalidTokenException : PetanquePlanningException
    {
        public InvalidTokenException(string token) : base($"The {token} token is invalid")
        {
        }
    }
}