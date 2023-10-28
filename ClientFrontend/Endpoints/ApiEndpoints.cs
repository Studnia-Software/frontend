namespace ClientFrontend.Endpoints;

public class ApiEndpoints
{
    public string Ping { get => "api/test/ping"; } 
    public string Farm { get =>  "api/get-farms/"; }
    public string GetFarmPosts { get =>  $"api/get-farm-posts/"; } //Dorzucić Id
    public string StorePost { get =>  "api/store"; }
    public string GetUser { get =>  "api/get-user/"; } //Dorzuić id
    public string GetFarmsUserArea { get =>  "api/'get-farms-user-area/"; }
}