using APIClient.Models;

namespace ClientFrontend.Interfaces;

public interface IInfrastructureService
{
    Task<HttpResponseMessage> Ping();
}