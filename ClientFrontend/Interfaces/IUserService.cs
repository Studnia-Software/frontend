using ClientFrontend.Models;

namespace ClientFrontend.Interfaces;

public interface IUserService
{
    Task<HttpResponseMessage> GetUsers();
    Task<HttpResponseMessage> GetUser(int id);
    Task<HttpResponseMessage> CreateUser(CreateUser dto);
}