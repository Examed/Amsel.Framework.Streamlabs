using System;
using System.Diagnostics;
using Amsel.Framework.Streamlabs.OBS.Models.Request;
using Amsel.Framework.Streamlabs.OBS.Models.Response;
using Amsel.Framework.Streamlabs.OBS.Services;
using Amsel.Framework.Streamlabs.OBS.Tests.Attribute;
using Amsel.Framework.Streamlabs.OBS.Tests.Utilities;
using Xunit;

namespace Amsel.Framework.Streamlabs.OBS.Tests.Services
{
    public class SceneCollectionsServiceTest
    {
        #region Fields
        private readonly SceneCollectionsService service = new SceneCollectionsService();
        #endregion

        #region Methods
        [DebugOnlyFact]
        public void ActiveCollection() { _ = service.ActiveCollection(); }
        [DebugOnlyFact]
        public void CollectionAdded()
        {
            service.OnCollectionAdded += (s, e) => Debug.Write(nameof(service.OnCollectionAdded));
            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void CollectionRemoved()
        {
            service.OnCollectionRemoved += (s, e) => Debug.Write(nameof(service.OnCollectionRemoved));

            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void CollectionSwitched()
        {
            service.OnCollectionSwitched += (s, e) => Debug.Write(nameof(service.OnCollectionRemoved));

            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void CollectionUpdated()
        {
            service.OnCollectionUpdated += (s, e) => Debug.Write(nameof(service.OnCollectionUpdated));

            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void CollectionWillSwitch()
        {
            service.OnCollectionWillSwitch += (s, e) => Debug.Write(nameof(service.OnCollectionWillSwitch));
            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void CreateWithName() { _ = service.Create("test"); }
        [DebugOnlyFact]
        public void CreateWithOptions() { _ = service.Create(new StreamlabsOBSSceneCollectionCreateOptions("test")); }
        [DebugOnlyFact]
        public void DeleteCollection()
        {
            StreamlabsOBSCollection result = service.Create("test");
            service.DeleteCollection(result.Id);
        }

        [DebugOnlyFact]
        public void FetchSchemaCollection() { _ = service.FetchSchema(); }
        [DebugOnlyFact]
        public void FetchSchemaCollectionByName()
        {
            StreamlabsOBSCollection collection = service.ActiveCollection();
            _ = service.FetchSchemaForCollectionByName(collection.Name);
        }

        [DebugOnlyFact]
        public void FetchSchemaCollectionByResourceId()
        {
            StreamlabsOBSCollection collection = service.ActiveCollection() ?? throw new ArgumentNullException($"{nameof(service.ActiveCollection)}");
            _ = service.FetchSchemaForCollectionById(collection.ResourceId ?? throw new InvalidOperationException());
        }

        [DebugOnlyFact]
        public void GetCollectionByName() { _ = service.GetCollectionByName("test"); }
        [DebugOnlyFact]
        public void GetCollections() { _ = service.GetCollections(); }
        [DebugOnlyFact]
        public void LoadCollection()
        {
            StreamlabsOBSCollection collection = service.GetCollectionByName("test");
            service.LoadCollection(collection);
        }

        [DebugOnlyFact]
        public void LoadCollectionById()
        {
            StreamlabsOBSCollection collection = service.GetCollectionByName("test");
            service.LoadCollection(collection.Id);
        }

        [Fact]
        public void PassTest() { Assert.True(true); }
        [DebugOnlyFact]
        public void RenameCollection()
        {
            StreamlabsOBSCollection collection = service.ActiveCollection();
            service.RenameCollection(collection, $"{collection.Name}Test");
        }

        [DebugOnlyFact]
        public void RenameCollectionById()
        {
            StreamlabsOBSCollection collection = service.ActiveCollection();
            service.RenameCollection(collection.Id, $"{collection.Name}Test");
        }
        #endregion
    }
}