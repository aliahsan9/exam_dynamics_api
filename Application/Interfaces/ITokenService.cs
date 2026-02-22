using ExamDynamics.API.Domain.Entities;

namespace ExamDynamics.API.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user, IList<string> roles);
    }
}  
                                                