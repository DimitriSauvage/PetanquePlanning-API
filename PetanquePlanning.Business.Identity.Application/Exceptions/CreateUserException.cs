using Tools.Exceptions;

namespace PetanquePlanning.Business.Identity.Application.Exceptions
{
    public class CreateUserException : AppException
    {
        public CreateUserException() : base("Error while creating the user")
        {
        }

        public CreateUserException(string error) : base(error)
        {
        }
    }
}