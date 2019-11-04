using Amsel.Clients.Sample.SLOBS.Models.Response;

namespace Amsel.Clients.Sample.SLOBS.Interfaces.Response
{
    public interface ISLOBSSceneItem : ISLOBSNode
    {
        string ResourceId { get; set; }
        string SceneItemId { get; set; }
        string SourceId { get; set; }
        SLOBSTransform Transform { get; set; }
        bool? Visible { get; set; }
        bool? Locked { get; set; }
    }
}