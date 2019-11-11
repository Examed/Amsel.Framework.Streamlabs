using System;
using System.Collections.Generic;
using System.Linq;
using Amsel.Framework.Streamlabs.OBS.Clients;
using Amsel.Framework.Streamlabs.OBS.Models.Request;
using Amsel.Framework.Streamlabs.OBS.Models.Response;

namespace Amsel.Framework.Streamlabs.OBS.Services
{
    public class ScenesService
    {
        private const string RESOURCE = "ScenesService";

        private readonly StreamlabsOBSClient client;

        public ScenesService()
        {
            this.client = new StreamlabsOBSClient();
        }

        public ScenesService(StreamlabsOBSClient client)
        {
            this.client = client;
        }

        public StreamlabsOBSScene ActiveScene()
        {
            return client.SendRequest<StreamlabsOBSScene>(new StreamlabsOBSRequest("activeScene", RESOURCE))?.FirstOrDefault();
        }

        public string ActiveSceneId()
        {
            return client.SendRequest<string>(new StreamlabsOBSRequest("activeSceneId", RESOURCE))?.FirstOrDefault();

        }

        public StreamlabsOBSScene CreateScene(string name)
        {
            return client.SendRequest<StreamlabsOBSScene>(new StreamlabsOBSRequest("createScene", RESOURCE, name))?.FirstOrDefault();
        }

        public StreamlabsOBSScene GetScene(string id)
        {
            return client.SendRequest<StreamlabsOBSScene>(new StreamlabsOBSRequest("getScene", RESOURCE, id))?.FirstOrDefault();
        }

        public StreamlabsOBSScene GetSceneByName(string name)
        {
            return GetScenes()?.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<StreamlabsOBSScene> GetScenes()
        {
            return client.SendRequest<StreamlabsOBSScene>(new StreamlabsOBSRequest("getScenes", RESOURCE));
        }

        public bool MakeSceneActive(string id)
        {
            return client.SendRequest<bool>(new StreamlabsOBSRequest("makeSceneActive", RESOURCE, id))?.FirstOrDefault() ?? false;
        }

        public StreamlabsOBSSceneBase RemoveScene(string id)
        {
            return client.SendRequest<StreamlabsOBSSceneBase>(new StreamlabsOBSRequest("removeScene", RESOURCE, id))?.FirstOrDefault();
        }


        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSItem> ItemAdded
            = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSItem>(new StreamlabsOBSRequest("itemAdded", RESOURCE));

        public event EventHandler<StreamlabsOBSItem> OnItemAdded
        {
            add => ItemAdded.Subscribe(value);
            remove => ItemAdded.UnSubscribe(value);
        }

        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSItem> ItemRemoved
            = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSItem>(new StreamlabsOBSRequest("itemRemoved", RESOURCE));

        public event EventHandler<StreamlabsOBSItem> OnItemRemoved
        {
            add => ItemRemoved.Subscribe(value);
            remove => ItemRemoved.UnSubscribe(value);
        }

        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSItem> ItemUpdated
            = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSItem>(new StreamlabsOBSRequest("itemUpdated", RESOURCE));

        public event EventHandler<StreamlabsOBSItem> OnItemUpdated
        {
            add => ItemUpdated.Subscribe(value);
            remove => ItemUpdated.UnSubscribe(value);
        }

        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSScene> SceneAdded
            = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSScene>(new StreamlabsOBSRequest("sceneAdded", RESOURCE));

        public event EventHandler<StreamlabsOBSScene> OnSceneAdded
        {
            add => SceneAdded.Subscribe(value);
            remove => SceneAdded.UnSubscribe(value);
        }

        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSScene> SceneRemoved
            = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSScene>(new StreamlabsOBSRequest("sceneRemoved", RESOURCE));

        public event EventHandler<StreamlabsOBSScene> OnSceneRemoved
        {
            add => SceneRemoved.Subscribe(value);
            remove => SceneRemoved.UnSubscribe(value);
        }

        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSScene> SceneSwitched
            = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSScene>(new StreamlabsOBSRequest("sceneSwitched", RESOURCE));

        public event EventHandler<StreamlabsOBSScene> OnSceneSwitched
        {
            add => SceneSwitched.Subscribe(value);
            remove => SceneSwitched.UnSubscribe(value);
        }

    }

}
