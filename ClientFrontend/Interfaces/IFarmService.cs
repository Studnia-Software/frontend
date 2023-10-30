using System.Net;
using APIClient.Models;

namespace ClientFrontend.Interfaces;

public interface IFarmService
{
    Task<HttpResponseMessage> GetFarms();
    Task<HttpResponseMessage> GetFarm(int id);
    Task<HttpResponseMessage> CreateFarm(CreateFarm dto);
    Task<HttpResponseMessage> DeleteFarm(int id);
}