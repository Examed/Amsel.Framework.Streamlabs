using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Amsel.Framework.Streamlabs.OBS.Services;
using Amsel.Framework.Streamlabs.OBS.Tests.Attribute;
using Amsel.Framework.Streamlabs.OBS.Tests.Utilities;
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
        public void ActiveCollection()
        {
            var result = service.ActiveCollection();
        }

        [DebugOnlyFact]
        public void FetchSchemaCollectionByResorceId()
        {
            var collection = service.ActiveCollection();
            var result = service.FetchSchema(collection.ResourceId);
        }

        [DebugOnlyFact]
        public void FetchSchemaCollection()
        {
            var collection = service.ActiveCollection();
            var result = service.FetchSchema(collection);
        }

        [DebugOnlyFact]
        public void LoadCollectionById()
        {
            var collection = service.ActiveCollection();
            service.LoadCollection(collection.Id);
        }

        [DebugOnlyFact]
        public void LoadCollection()
        {
            var collection = service.ActiveCollection();
            service.LoadCollection(collection);
        }

        [DebugOnlyFact]
        public void RenameCollectionById()
        {
            var collection = service.ActiveCollection();
            service.RenameCollection(collection.Id, collection.Name + "Test");
        }

        [DebugOnlyFact]
        public void RenameCollection()
        {
            var collection = service.ActiveCollection();
            service.RenameCollection(collection, collection.Name + "Test");
        }

        [DebugOnlyFact]
        public void DeleteCollection()
        {
            var result = service.Create("test");
            service.DeleteCollection(result.Id);
        }

        [DebugOnlyFact]
        public void GetCollectionByName()
        {
            var result = service.GetCollectionByName("test");
        }
        [DebugOnlyFact]
        public void GetCollections()
        {
            var result = service.GetCollections();
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
