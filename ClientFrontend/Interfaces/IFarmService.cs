using System.Net;
using ClientFrontend.Models;

namespace ClientFrontend.Interfaces;

public interface IFarmService
{
    Task<HttpResponseMessage> GetFarms();
    Task<HttpResponseMessage> GetFarm(int id);
    Task<HttpResponseMessage> CreateFarm(CreateFarm dto);
    Task<HttpResponseMessage> DeleteFarm(int id);
}