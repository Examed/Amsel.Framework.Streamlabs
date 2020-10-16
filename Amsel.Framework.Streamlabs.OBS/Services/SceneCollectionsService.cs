using Amsel.Framework.Streamlabs.OBS.Clients;
using Amsel.Framework.Streamlabs.OBS.Models.Request;
using Amsel.Framework.Streamlabs.OBS.Models.Response;
using Amsel.Utilities.Collections.Extentions;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Amsel.Framework.Streamlabs.OBS.Services
{
    public class SceneCollectionsService
    {
        const string RESOURCE = "SceneCollectionsService";

        readonly StreamlabsOBSClient client;
        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSEvent> CollectionAddedHandler =
            new StreamlabsOBSSubscriptionHandler<StreamlabsOBSEvent>(new StreamlabsOBSRequest("collectionAdded",
                                                                                              RESOURCE));
        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSEvent> CollectionRemovedHandler =
            new StreamlabsOBSSubscriptionHandler<StreamlabsOBSEvent>(new StreamlabsOBSRequest("collectionRemoved",
                                                                                              RESOURCE));
        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSCollection> CollectionSwitchedHandler =
            new StreamlabsOBSSubscriptionHandler<StreamlabsOBSCollection>(new StreamlabsOBSRequest("collectionSwitched",
                                                                                                   RESOURCE));
        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSEvent> CollectionUpdatedHandler =
            new StreamlabsOBSSubscriptionHandler<StreamlabsOBSEvent>(new StreamlabsOBSRequest("collectionUpdated",
                                                                                              RESOURCE));
        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSEvent> CollectionWillSwitchHandler =
            new StreamlabsOBSSubscriptionHandler<StreamlabsOBSEvent>(new StreamlabsOBSRequest("collectionWillSwitch",
                                                                                              RESOURCE));

        public SceneCollectionsService() { client = new StreamlabsOBSClient(); }

        public SceneCollectionsService(StreamlabsOBSClient client) { this.client = client; }

        public event EventHandler<StreamlabsOBSEvent> OnCollectionAdded
        {
            add => CollectionAddedHandler.Subscribe(value);
            remove => CollectionAddedHandler.UnSubscribe(value);
        }

        public event EventHandler<StreamlabsOBSEvent> OnCollectionRemoved
        {
            add => CollectionRemovedHandler.Subscribe(value);
            remove => CollectionRemovedHandler.UnSubscribe(value);
        }

        public event EventHandler<StreamlabsOBSCollection> OnCollectionSwitched
        {
            add => CollectionSwitchedHandler.Subscribe(value);
            remove => CollectionSwitchedHandler.UnSubscribe(value);
        }

        public event EventHandler<StreamlabsOBSEvent> OnCollectionUpdated
        {
            add => CollectionUpdatedHandler.Subscribe(value);
            remove => CollectionUpdatedHandler.UnSubscribe(value);
        }

        public event EventHandler<StreamlabsOBSEvent> OnCollectionWillSwitch
        {
            add => CollectionWillSwitchHandler.Subscribe(value);
            remove => CollectionWillSwitchHandler.UnSubscribe(value);
        }

        public StreamlabsOBSCollection ActiveCollection()
        {
            return client.SendRequest<StreamlabsOBSCollection>(new StreamlabsOBSRequest("activeCollection",
                                                                                                                                              RESOURCE))?.FirstOrDefault();
        }

        public StreamlabsOBSCollection Create(string name) { return Create(new StreamlabsOBSSceneCollectionCreateOptions(name)); }

        public StreamlabsOBSCollection Create(StreamlabsOBSSceneCollectionCreateOptions options)
        {
            return client.SendRequest<StreamlabsOBSEvent>(new StreamlabsOBSRequest("create",
                                                                                                                                                                                RESOURCE,
                                                                                                                                                                                options))?.FirstOrDefault()
                .GetData<StreamlabsOBSCollection>()
                .FirstOrDefault();
        }

        public StreamlabsOBSEvent DeleteCollection(StreamlabsOBSCollection collection) { return DeleteCollection(collection.Id); }

        public StreamlabsOBSEvent DeleteCollection(string id)
        {
            return client.SendRequest<StreamlabsOBSEvent>(new StreamlabsOBSRequest("delete",
                                                                                                                                             RESOURCE,
                                                                                                                                             id))?.FirstOrDefault();
        }

        public IEnumerable<SceneCollectionSchema> FetchSchema()
        {
            return client.SendRequest<StreamlabsOBSEvent>(new StreamlabsOBSRequest("fetchSceneCollectionsSchema",
                                                                                                                                               RESOURCE))?.FirstOrDefault()
                .GetData<SceneCollectionSchema>();
        }

        public SceneCollectionSchema FetchSchemaForCollectionById([NotNull] string id) {
            if(id == null) {
                throw new ArgumentNullException(nameof(id));
            }

            return FetchSchema()?.Where(x => x.Id == id).PickRandom();
        }

        public SceneCollectionSchema FetchSchemaForCollectionByName(string name) {
            if(name == null) {
                throw new ArgumentNullException(nameof(name));
            }

            return FetchSchema()?.Where(x => x.Name == name).PickRandom();
        }

        public StreamlabsOBSCollection GetCollectionByName(string name)
        { return GetCollections()?.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)); }

        public IEnumerable<StreamlabsOBSCollection> GetCollections()
        {
            return client.SendRequest<StreamlabsOBSCollection>(new StreamlabsOBSRequest("collections",
                                                                                                                                                         RESOURCE));
        }

        public StreamlabsOBSEvent LoadCollection(StreamlabsOBSCollection collection) { return LoadCollection(collection.Id); }

        public StreamlabsOBSEvent LoadCollection(string id) {
            StreamlabsOBSCollection current = ActiveCollection();
            return (current?.Id == id) ? null
                : (client.SendRequest<StreamlabsOBSEvent>(new StreamlabsOBSRequest("load", RESOURCE, id))?.FirstOrDefault());
        }

        public void LoadCollectionByName(string name) {
            StreamlabsOBSCollection collection = GetCollectionByName(name);
            LoadCollection(collection);
        }

        public StreamlabsOBSEvent RenameCollection(StreamlabsOBSCollection collection, string newName)
        {
            return RenameCollection(collection.Id,
                                                                                                                                       newName);
        }

        public StreamlabsOBSEvent RenameCollection(string id, string newNamem)
        {
            return client.SendRequest<StreamlabsOBSEvent>(new StreamlabsOBSRequest("rename",
                                                                                                                                                              RESOURCE,
                                                                                                                                                              newNamem,
                                                                                                                                                              id))?.FirstOrDefault();
        }
    }
}