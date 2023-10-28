namespace ClientFrontend.Exception;

public class BadRequestException : System.Exception
{
    public BadRequestException(string Message) : base(Message)
    {
        
    }
}