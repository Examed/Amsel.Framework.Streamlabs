using System.Collections.Generic;
using Amsel.Clients.Sample.SLOBS.Enums;

namespace Amsel.Clients.Sample.SLOBS.Interfaces.Response
{
    public interface ISLOBSNode
    {
        string Id { get; set; }
        string SceneId { get; set; }
        ESLOBSSceneNodeType SceneNodeType { get; set; }
        string ParentId { get; set; }
        List<string> ChildrenIds { get; set; }
        string Name { get; set; }

    }
}