using Inlammnig2API_WEBBUTECKLING.Data.Enteties;
using Inlammnig2API_WEBBUTECKLING.Data;

namespace Inlammnig2API_WEBBUTECKLING.Data.Interfaces
{
    public interface IUserRepo
    {
        Users GetUserByemail(string email);

        Users GetUsersbyId(int id);


        Users CreateUser(Users user);


        bool deleteUser(int id);



    }
}
