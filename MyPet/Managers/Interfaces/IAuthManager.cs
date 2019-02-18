using System;

namespace MyPet.Managers.Interfaces
{
    public interface IAuthManager
    {
        String Authenticate(string userName, string password);
    }
}
