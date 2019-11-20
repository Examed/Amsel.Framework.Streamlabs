using System;
using System.Collections.Generic;
using System.Linq;
using Amsel.Framework.Streamlabs.OBS.Clients;
using Amsel.Framework.Streamlabs.OBS.Models.Request;
using Amsel.Framework.Streamlabs.OBS.Models.Response;

namespace Amsel.Framework.Streamlabs.OBS.Services
{
    public class SceneCollectionsService
    {
        #region STATICS, CONST and FIELDS

        private const string RESOURCE = "SceneCollectionsService";

        private readonly StreamlabsOBSClient client;

        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSEvent> CollectionAddedHandler
            = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSEvent>(new StreamlabsOBSRequest("collectionAdded",
                                                                                                RESOURCE));

        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSEvent> CollectionRemovedHandler
            = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSEvent>(new StreamlabsOBSRequest("collectionRemoved",
                                                                                                RESOURCE));

        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSCollection> CollectionSwitchedHandler
            = new
                StreamlabsOBSSubscriptionHandler<StreamlabsOBSCollection>(new StreamlabsOBSRequest("collectionSwitched",
                                                                                                   RESOURCE));

        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSEvent> CollectionUpdatedHandler
            = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSEvent>(new StreamlabsOBSRequest("collectionUpdated",
                                                                                                RESOURCE));

        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSEvent> CollectionWillSwitchHandler
            = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSEvent>(new StreamlabsOBSRequest("collectionWillSwitch",
                                                                                                RESOURCE));

        #endregion

        #region  CONSTRUCTORS

        public SceneCollectionsService() {
            client = new StreamlabsOBSClient();
        }

        public SceneCollectionsService(StreamlabsOBSClient client) {
            this.client = client;
        }

        #endregion

        public event EventHandler<StreamlabsOBSEvent> OnCollectionAdded {
            add => CollectionAddedHandler.Subscribe(value);
            remove => CollectionAddedHandler.UnSubscribe(value);
        }

        public event EventHandler<StreamlabsOBSEvent> OnCollectionRemoved {
            add => CollectionRemovedHandler.Subscribe(value);
            remove => CollectionRemovedHandler.UnSubscribe(value);
        }

        public event EventHandler<StreamlabsOBSCollection> OnCollectionSwitched {
            add => CollectionSwitchedHandler.Subscribe(value);
            remove => CollectionSwitchedHandler.UnSubscribe(value);
        }

        public event EventHandler<StreamlabsOBSEvent> OnCollectionUpdated {
            add => CollectionUpdatedHandler.Subscribe(value);
            remove => CollectionUpdatedHandler.UnSubscribe(value);
        }


        public event EventHandler<StreamlabsOBSEvent> OnCollectionWillSwitch {
            add => CollectionWillSwitchHandler.Subscribe(value);
            remove => CollectionWillSwitchHandler.UnSubscribe(value);
        }

        public StreamlabsOBSCollection Create(string name) {
            return Create(new StreamlabsOBSSceneCollectionCreateOptions(name));
        }

        public StreamlabsOBSCollection Create(StreamlabsOBSSceneCollectionCreateOptions options) {
            return client.SendRequest<StreamlabsOBSEvent>(new StreamlabsOBSRequest("create", RESOURCE, options))
                         ?.FirstOrDefault().GetData<StreamlabsOBSCollection>()?.FirstOrDefault();
        }

        public IEnumerable<SceneCollectionSchema> FetchSchema(StreamlabsOBSCollection collection) {
            return FetchSchema(collection.ResourceId);
        }

        public IEnumerable<SceneCollectionSchema> FetchSchema(string ressourceId) {
            return client
                   .SendRequest<StreamlabsOBSEvent>(new StreamlabsOBSRequest("fetchSceneCollectionsSchema", RESOURCE,
                                                                             ressourceId))?.FirstOrDefault()
                   .GetData<SceneCollectionSchema>();
        }

        public StreamlabsOBSCollection ActiveCollection() {
            return client.SendRequest<StreamlabsOBSCollection>(new StreamlabsOBSRequest("activeCollection", RESOURCE))
                         ?.FirstOrDefault();
        }

        public void LoadCollection(StreamlabsOBSCollection collection) {
            LoadCollection(collection.Id);
        }

        public void LoadCollection(string id) {
            StreamlabsOBSEvent result = client
                                        .SendRequest<StreamlabsOBSEvent>(new StreamlabsOBSRequest("load", RESOURCE, id))
                                        ?.FirstOrDefault();
            ;
        }

        public IEnumerable<StreamlabsOBSCollection> GetCollections() {
            return client.SendRequest<StreamlabsOBSCollection>(new StreamlabsOBSRequest("collections", RESOURCE));
        }

        public StreamlabsOBSCollection GetCollectionByName(string name) {
            return GetCollections()?.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void LoadCollectionByName(string name) {
            StreamlabsOBSCollection collection = GetCollectionByName(name);
            LoadCollection(collection);
        }

        public void DeleteCollection(StreamlabsOBSCollection collection) {
            DeleteCollection(collection.Id);
        }

        public void DeleteCollection(string id) {
            StreamlabsOBSEvent result = client
                                        .SendRequest<StreamlabsOBSEvent>(new StreamlabsOBSRequest("delete", RESOURCE,
                                                                                                  id))
                                        ?.FirstOrDefault();
            ;
        }


        public void RenameCollection(StreamlabsOBSCollection collection, string newName) {
            RenameCollection(collection.Id, newName);
        }

        public void RenameCollection(string id, string newNamem) {
            StreamlabsOBSEvent result = client
                                        .SendRequest<StreamlabsOBSEvent>(new StreamlabsOBSRequest("rename", RESOURCE,
                                                                                                  newNamem, id))
                                        ?.FirstOrDefault();
            ;
        }
    }
}