namespace api_ska.models;

public class Response
{
    public int status { get; set; }
    public string message { get; set; }
    public dynamic data { get; set; }
}