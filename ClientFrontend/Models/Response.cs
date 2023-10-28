namespace ClientFrontend.Models;

public class Response<T>
{
    public string Result { get; set; }
    public T Data { get; set; }
}