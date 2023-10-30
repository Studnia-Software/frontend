using ClientFrontend.Models;

namespace ClientFrontend.Interfaces;

public interface IOrderService
{
    Task<HttpResponseMessage> CreateOrder(CreateOrder dto);
}