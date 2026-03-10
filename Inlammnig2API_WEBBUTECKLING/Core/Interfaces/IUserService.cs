using Inlammnig2API_WEBBUTECKLING.Data.Enteties;
using Inlammnig2API_WEBBUTECKLING.DTO;

namespace Inlammnig2API_WEBBUTECKLING.Interfaces
{
    public interface IUserService
    {
        Users Register(RegisterDTO dto);

        string Logon(LogonDTO dto);
    }
}
