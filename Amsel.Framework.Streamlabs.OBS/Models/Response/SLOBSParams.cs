namespace Amsel.Clients.Sample.SLOBS.Models.Response
{
    public class SLOBSParams
    {
        public SLOBSParams(string resource, params object[] args)
        {
            this.Resource = resource;
            this.Args = args;
        }

        public string Resource { get; set; }
        public object[] Args { get; set; }

    }
}