using System.Net;

namespace GetTalim.Domain.Exceptions;

public class AlreadyExistsExcaption : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.Conflict;
    public override string TitleMessage { get; protected set; } = string.Empty;
}
