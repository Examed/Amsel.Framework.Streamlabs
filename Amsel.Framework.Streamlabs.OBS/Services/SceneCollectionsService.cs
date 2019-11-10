using System;
using System.Linq;
using Amsel.Framework.StreamlabsOBS.OBS.Models.Request;
using Amsel.Framework.StreamlabsOBS.OBS.Models.Response;
using Newtonsoft.Json;

namespace Amsel.Framework.StreamlabsOBS.OBS.Service
{
    public class SceneCollectionsService
    {
        private const string RESOURCE = "SceneCollectionsService";

        private readonly StreamlabsOBSClient client;

        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSEvent> collectionAddedHandler
            = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSEvent>(new StreamlabsOBSRequest("collectionAdded", RESOURCE));

        public event EventHandler<StreamlabsOBSEvent> OnCollectionAdded
        {
            add => collectionAddedHandler.Subscribe(value);
            remove => collectionAddedHandler.UnSubscribe(value);
        }

        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSEvent> collectionRemovedHandler
            = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSEvent>(new StreamlabsOBSRequest("collectionRemoved", RESOURCE));

        public event EventHandler<StreamlabsOBSEvent> OnCollectionRemoved
        {
            add => collectionRemovedHandler.Subscribe(value);
            remove => collectionRemovedHandler.UnSubscribe(value);
        }

        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSCollection> CollectionSwitchedHandler
            = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSCollection>(new StreamlabsOBSRequest("collectionSwitched", RESOURCE));

        public event EventHandler<StreamlabsOBSCollection> OnCollectionSwitched
        {
            add => CollectionSwitchedHandler.Subscribe(value);
            remove => CollectionSwitchedHandler.UnSubscribe(value);
        }

        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSEvent> collectionUpdatedHandler
            = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSEvent>(new StreamlabsOBSRequest("collectionUpdated", RESOURCE));

        public event EventHandler<StreamlabsOBSEvent> OnCollectionUpdated
        {
            add => collectionUpdatedHandler.Subscribe(value);
            remove => collectionUpdatedHandler.UnSubscribe(value);
        }

        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSEvent> collectionWillSwitchHandler
            = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSEvent>(new StreamlabsOBSRequest("collectionWillSwitch", RESOURCE));


        public event EventHandler<StreamlabsOBSEvent> OnCollectionWillSwitch
        {
            add => collectionWillSwitchHandler.Subscribe(value);
            remove => collectionWillSwitchHandler.UnSubscribe(value);
        }

        public SceneCollectionsService()
        {
            this.client = new StreamlabsOBSClient();
        }

        public SceneCollectionsService(StreamlabsOBSClient client)
        {
            this.client = client;
        }

        public StreamlabsOBSCollection Create(string name)
        {
            return Create(new SceneCollectionCreateOptions(name));
        }
        public StreamlabsOBSCollection Create(SceneCollectionCreateOptions options)
        {
            return client.SendRequest<StreamlabsOBSEvent>(new StreamlabsOBSRequest("create", RESOURCE, options))?.FirstOrDefault().GetData<StreamlabsOBSCollection>()?.FirstOrDefault();
        }

    }

    public class SceneCollectionCreateOptions
    {
        public SceneCollectionCreateOptions(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        [JsonProperty("name")]
        public string Name { get; protected set; }
    }
}
