using Amsel.Framework.Streamlabs.OBS.Clients;
using Amsel.Framework.Streamlabs.OBS.Models.Request;
using Amsel.Framework.Streamlabs.OBS.Models.Response;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using Amsel.Utilities.Collections.Extentions;

namespace Amsel.Framework.Streamlabs.OBS.Services
{
    public class ScenesService
    {
        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSItem> ItemAdded = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSItem>(new StreamlabsOBSRequest("itemAdded",
                                                                                                                                                                         RESOURCE));
        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSItem> ItemRemoved = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSItem>(new StreamlabsOBSRequest("itemRemoved",
                                                                                                                                                                           RESOURCE));
        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSItem> ItemUpdated = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSItem>(new StreamlabsOBSRequest("itemUpdated",
                                                                                                                                                                           RESOURCE));
        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSScene> SceneAdded = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSScene>(new StreamlabsOBSRequest("sceneAdded",
                                                                                                                                                                            RESOURCE));
        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSScene>
            SceneRemoved = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSScene>(new StreamlabsOBSRequest("sceneRemoved",
                                                                                                             RESOURCE));
        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSScene> SceneSwitched =
            new StreamlabsOBSSubscriptionHandler<StreamlabsOBSScene>(new StreamlabsOBSRequest("sceneSwitched", RESOURCE));
        const string RESOURCE = "ScenesService";
        [NotNull] readonly StreamlabsOBSClient client;
        [NotNull] readonly SceneCollectionsService collectionsService;

        public ScenesService()
        {
            client = new StreamlabsOBSClient();
            collectionsService = new SceneCollectionsService(client);
        }

        public ScenesService([NotNull] StreamlabsOBSClient client, [NotNull] SceneCollectionsService collectionsService)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            this.collectionsService = collectionsService ?? throw new ArgumentNullException(nameof(collectionsService));
        }

        public event EventHandler<StreamlabsOBSItem> OnItemAdded
        {
            add => ItemAdded.Subscribe(value);
            remove => ItemAdded.UnSubscribe(value);
        }

        public event EventHandler<StreamlabsOBSItem> OnItemRemoved
        {
            add => ItemRemoved.Subscribe(value);
            remove => ItemRemoved.UnSubscribe(value);
        }

        public event EventHandler<StreamlabsOBSItem> OnItemUpdated
        {
            add => ItemUpdated.Subscribe(value);
            remove => ItemUpdated.UnSubscribe(value);
        }

        public event EventHandler<StreamlabsOBSScene> OnSceneAdded
        {
            add => SceneAdded.Subscribe(value);
            remove => SceneAdded.UnSubscribe(value);
        }

        public event EventHandler<StreamlabsOBSScene> OnSceneRemoved
        {
            add => SceneRemoved.Subscribe(value);
            remove => SceneRemoved.UnSubscribe(value);
        }

        public event EventHandler<StreamlabsOBSScene> OnSceneSwitched
        {
            add => SceneSwitched.Subscribe(value);
            remove => SceneSwitched.UnSubscribe(value);
        }

        public StreamlabsOBSScene ActiveScene() => client.SendRequest<StreamlabsOBSScene>(new StreamlabsOBSRequest("activeScene",
                                                                                                                   RESOURCE))?.FirstOrDefault();

        public string ActiveSceneId() => client.SendRequest<string>(new StreamlabsOBSRequest("activeSceneId", RESOURCE))?.FirstOrDefault();

        public StreamlabsOBSScene CreateScene(string name) => client.SendRequest<StreamlabsOBSScene>(new StreamlabsOBSRequest("createScene",
                                                                                                                              RESOURCE,
                                                                                                                              name))?.FirstOrDefault();

        public StreamlabsOBSScene GetScene(string id) => client.SendRequest<StreamlabsOBSScene>(new StreamlabsOBSRequest("getScene",
                                                                                                                         RESOURCE,
                                                                                                                         id))?.FirstOrDefault();

        public StreamlabsOBSScene GetSceneByName(string name) => GetScenes()?.Where(x => x.Name
            .Equals(name, StringComparison.OrdinalIgnoreCase))
            .PickRandom();

        public IEnumerable<StreamlabsOBSScene> GetScenes() => client.SendRequest<StreamlabsOBSScene>(new StreamlabsOBSRequest("getScenes",
                                                                                                                              RESOURCE));

        public bool MakeSceneActive(string id) => client.SendRequest<bool>(new StreamlabsOBSRequest("makeSceneActive",
                                                                                                    RESOURCE,
                                                                                                    id))?.FirstOrDefault() ??
            false;

        public bool MakeSceneActiveByIdAndCollectionId([NotNull] string collectionId, [NotNull] string sceneId)
        {
            if(sceneId == null)
            {
                throw new ArgumentNullException(nameof(sceneId));
            }

            if(collectionId == null)
            {
                throw new ArgumentNullException(nameof(collectionId));
            }

            collectionsService.LoadCollection(collectionId);
            return MakeSceneActiveByName(sceneId);
        }

        public bool MakeSceneActiveByName(string name)
        {
            if(name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            StreamlabsOBSScene scene = GetSceneByName(name) ?? throw new ArgumentNullException($"{nameof(name)}");
            return MakeSceneActive(scene.Id);
        }

        public bool MakeSceneActiveByNameAndCollectionName([NotNull] string collectionName, [NotNull] string sceneName)
        {
            if(sceneName == null)
            {
                throw new ArgumentNullException(nameof(sceneName));
            }

            if(collectionName == null)
            {
                throw new ArgumentNullException(nameof(collectionName));
            }

            collectionsService.LoadCollectionByName(collectionName);
            return MakeSceneActiveByName(sceneName);
        }

        public StreamlabsOBSSceneBase RemoveScene(string id) => client.SendRequest<StreamlabsOBSSceneBase>(new StreamlabsOBSRequest("removeScene",
                                                                                                                                    RESOURCE,
                                                                                                                                    id))?.FirstOrDefault();
    }
}