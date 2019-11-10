using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Amsel.Framework.Streamlabs.OBS.Tests.Attribute;
using Amsel.Framework.Streamlabs.OBS.Tests.Utilities;
using Amsel.Framework.StreamlabsOBS.OBS.Service;
using FakeItEasy;
using Xunit;

namespace Amsel.Framework.Streamlabs.OBS.Tests.Services
{
    public class SceneCollectionsServiceTest
    {
        private readonly SceneCollectionsService service = new SceneCollectionsService();

        [DebugOnlyFact]
        public void CreateWithName()
        {
            var result = service.Create("test");
        }

        [DebugOnlyFact]
        public void CreateWithOptions()
        {
            var result = service.Create(new SceneCollectionCreateOptions("test"));
        }

        [DebugOnlyFact]
        public void CollectionAdded()
        {
            service.OnCollectionAdded += (s, e) =>
            {
                Debug.Write(nameof(service.OnCollectionAdded));
            };
            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void CollectionRemoved()
        {
            service.OnCollectionRemoved += (s, e) =>
            {
                Debug.Write(nameof(service.OnCollectionRemoved));
            };

            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void CollectionSwitched()
        {
            service.OnCollectionSwitched += (s, e) =>
            {
                Debug.Write(nameof(service.OnCollectionRemoved));
            };

            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void CollectionUpdated()
        {
            service.OnCollectionUpdated += (s, e) =>
            {
                Debug.Write(nameof(service.OnCollectionUpdated));
            };

            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void CollectionWillSwitch()
        {
            service.OnCollectionWillSwitch += (s, e) =>
            {
                Debug.Write(nameof(service.OnCollectionWillSwitch));
            };
            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

    }
}
