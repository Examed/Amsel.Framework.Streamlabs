using Amsel.Clients.Sample.SLOBS.Models.Request;

namespace Amsel.Clients.Sample.SLOBS.Interfaces.Request
{
    public interface ISlobsRequest
    {
        string Id { get; }
        string JsonRpc { get; }
        string Method { get; }
        SlobsParameters Parameters { get; }

        string ToJson();
    }
}