﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Amsel.Framework.Streamlabs.OBS.Models.Request;
using Amsel.Framework.Streamlabs.OBS.Models.Response;
using Amsel.Framework.Streamlabs.OBS.Services;
using Amsel.Framework.Streamlabs.OBS.Tests.Attribute;
using Amsel.Framework.Streamlabs.OBS.Tests.Utilities;

namespace Amsel.Framework.Streamlabs.OBS.Tests.Services
{
    public class SceneCollectionsServiceTest
    {
        #region STATICS, CONST and FIELDS

        private readonly SceneCollectionsService service = new SceneCollectionsService();

        #endregion

        [DebugOnlyFact]
        public void CreateWithName() {
            StreamlabsOBSCollection result = service.Create("test");
        }

        [DebugOnlyFact]
        public void CreateWithOptions() {
            StreamlabsOBSCollection result = service.Create(new StreamlabsOBSSceneCollectionCreateOptions("test"));
        }

        [DebugOnlyFact]
        public void ActiveCollection() {
            StreamlabsOBSCollection result = service.ActiveCollection();
        }

        [DebugOnlyFact]
        public void FetchSchemaCollectionByResorceId() {
            StreamlabsOBSCollection collection = service.ActiveCollection();
            IEnumerable<SceneCollectionSchema> result = service.FetchSchema(collection.ResourceId);
        }

        [DebugOnlyFact]
        public void FetchSchemaCollection() {
            StreamlabsOBSCollection collection = service.ActiveCollection();
            IEnumerable<SceneCollectionSchema> result = service.FetchSchema(collection);
        }

        [DebugOnlyFact]
        public void LoadCollectionById() {
            StreamlabsOBSCollection collection = service.ActiveCollection();
            service.LoadCollection(collection.Id);
        }

        [DebugOnlyFact]
        public void LoadCollection() {
            StreamlabsOBSCollection collection = service.ActiveCollection();
            service.LoadCollection(collection);
        }

        [DebugOnlyFact]
        public void RenameCollectionById() {
            StreamlabsOBSCollection collection = service.ActiveCollection();
            service.RenameCollection(collection.Id, collection.Name + "Test");
        }

        [DebugOnlyFact]
        public void RenameCollection() {
            StreamlabsOBSCollection collection = service.ActiveCollection();
            service.RenameCollection(collection, collection.Name + "Test");
        }

        [DebugOnlyFact]
        public void DeleteCollection() {
            StreamlabsOBSCollection result = service.Create("test");
            service.DeleteCollection(result.Id);
        }

        [DebugOnlyFact]
        public void GetCollectionByName() {
            StreamlabsOBSCollection result = service.GetCollectionByName("test");
        }

        [DebugOnlyFact]
        public void GetCollections() {
            IEnumerable<StreamlabsOBSCollection> result = service.GetCollections();
        }


        [DebugOnlyFact]
        public void CollectionAdded() {
            service.OnCollectionAdded += (s, e) => { Debug.Write(nameof(service.OnCollectionAdded)); };
            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void CollectionRemoved() {
            service.OnCollectionRemoved += (s, e) => { Debug.Write(nameof(service.OnCollectionRemoved)); };

            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void CollectionSwitched() {
            service.OnCollectionSwitched += (s, e) => { Debug.Write(nameof(service.OnCollectionRemoved)); };

            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void CollectionUpdated() {
            service.OnCollectionUpdated += (s, e) => { Debug.Write(nameof(service.OnCollectionUpdated)); };

            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void CollectionWillSwitch() {
            service.OnCollectionWillSwitch += (s, e) => { Debug.Write(nameof(service.OnCollectionWillSwitch)); };
            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }
    }
}