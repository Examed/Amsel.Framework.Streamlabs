using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace Amsel.Framework.Streamlabs.OBS.Tests.Attribute
{
    public class DebugOnlyFact : FactAttribute
    {
        public DebugOnlyFact()
        {
            if (!Debugger.IsAttached)
            {
                Skip = "Only running in interactive mode.";
            }
        }
    }
}
