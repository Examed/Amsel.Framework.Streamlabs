namespace Amsel.Clients.Sample.SLOBS.Interfaces.Response
{
    public interface ISLOBSCrop
    {
        long Bottom { get; set; }
        long Left { get; set; }
        long Right { get; set; }
        long Top { get; set; }
    }
}