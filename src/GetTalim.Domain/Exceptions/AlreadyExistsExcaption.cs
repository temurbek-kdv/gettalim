using System.Net;

namespace GetTalim.Domain.Exceptions;

public class AlreadyExistsExcaption :Exception
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.Conflict;
    public string TitleMessage { get; protected set; } = string.Empty;
}
