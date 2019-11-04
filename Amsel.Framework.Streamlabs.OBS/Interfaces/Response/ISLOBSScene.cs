using System.Collections.Generic;
using Amsel.Clients.Sample.SLOBS.Models.Response;

namespace Amsel.Clients.Sample.SLOBS.Interfaces.Response
{
    public interface ISLOBSScene
    {
        string Id { get; set; }
        string Name { get; set; }
        List<SLOBSNode> Nodes { get; set; }
        string ResourceId { get; set; }
        string ResultType { get; set; }
    }
}