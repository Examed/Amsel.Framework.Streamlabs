using Amsel.Clients.Sample.SLOBS.Models.Response;

namespace Amsel.Clients.Sample.SLOBS.Interfaces.Response
{
    public interface ISLOBSTransform
    {
        SLOBSCrop Crop { get; set; }
        SLOBSPosition Position { get; set; }
        long Rotation { get; set; }
        SLOBSPosition Scale { get; set; }
    }
}