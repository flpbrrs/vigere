using vigere.comunication.Requests;
using vigere.domain.Entities;

namespace vigere.application;

public static class UserMapProfile
{
    public static User ToEntity(this RequestRegisterUserJson request) =>
        new()
        {
            Email = request.Email,
            Password = request.Password
        };

    public static User ToEntityWithEncryptedPassword(this RequestRegisterUserJson request, string encryptedPassword) =>
        new()
        {
            Email = request.Email,
            Password = encryptedPassword
        };
}
