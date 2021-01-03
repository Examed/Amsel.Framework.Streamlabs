using System.Diagnostics;
using Xunit;

namespace Amsel.Framework.Streamlabs.OBS.Tests.Attribute
{
    public class DebugOnlyFact : FactAttribute
    {
        #region Constructors
        public DebugOnlyFact()
        {
            if(!Debugger.IsAttached) {
                Skip = "Only running in interactive mode.";
            }
        }
        #endregion
    }
}