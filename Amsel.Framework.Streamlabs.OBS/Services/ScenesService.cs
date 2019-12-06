using System;
using System.Collections.Generic;
using System.Linq;
using Amsel.Framework.Streamlabs.OBS.Clients;
using Amsel.Framework.Streamlabs.OBS.Models.Request;
using Amsel.Framework.Streamlabs.OBS.Models.Response;
using Amsel.Framework.Utilities.Extentions.Types;
using JetBrains.Annotations;

namespace Amsel.Framework.Streamlabs.OBS.Services
{
    public class ScenesService
    {
        public StreamlabsOBSScene ActiveScene() { return client.SendRequest<StreamlabsOBSScene>(new StreamlabsOBSRequest("activeScene", RESOURCE))?.FirstOrDefault(); }

        public string ActiveSceneId() { return client.SendRequest<string>(new StreamlabsOBSRequest("activeSceneId", RESOURCE))?.FirstOrDefault(); }

        public StreamlabsOBSScene CreateScene(string name) { return client.SendRequest<StreamlabsOBSScene>(new StreamlabsOBSRequest("createScene", RESOURCE, name))?.FirstOrDefault(); }

        public StreamlabsOBSScene GetScene(string id) { return client.SendRequest<StreamlabsOBSScene>(new StreamlabsOBSRequest("getScene", RESOURCE, id))?.FirstOrDefault(); }

        public StreamlabsOBSScene GetSceneByName(string name) { return GetScenes()?.Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).PickRandom(); }

        public IEnumerable<StreamlabsOBSScene> GetScenes() { return client.SendRequest<StreamlabsOBSScene>(new StreamlabsOBSRequest("getScenes", RESOURCE)); }

        public bool MakeSceneActiveByName([NotNull] string name) {
            if (name == null) throw new ArgumentNullException(nameof(name));

            StreamlabsOBSScene scene = GetSceneByName(name) ?? throw new ArgumentNullException($"{nameof(GetSceneByName)}");
            return MakeSceneActive(scene.Id);
        }

        public bool MakeSceneActiveByNameAndCollectionName([NotNull] string collectionName, [NotNull] string sceneName) {
            if (sceneName == null) throw new ArgumentNullException(nameof(sceneName));
            if (collectionName == null) throw new ArgumentNullException(nameof(collectionName));

            collectionsService.LoadCollectionByName(collectionName);
            return MakeSceneActiveByName(sceneName);
        }

        public bool MakeSceneActiveByIdAndCollectionId([NotNull] string collectionId, [NotNull] string sceneId) {
            if (sceneId == null) throw new ArgumentNullException(nameof(sceneId));
            if (collectionId == null) throw new ArgumentNullException(nameof(collectionId));


            collectionsService.LoadCollection(collectionId);
            return MakeSceneActiveByName(sceneId);
        }


        public bool MakeSceneActive(string id) { return client.SendRequest<bool>(new StreamlabsOBSRequest("makeSceneActive", RESOURCE, id))?.FirstOrDefault() ?? false; }

        public StreamlabsOBSSceneBase RemoveScene(string id) { return client.SendRequest<StreamlabsOBSSceneBase>(new StreamlabsOBSRequest("removeScene", RESOURCE, id))?.FirstOrDefault(); }

        public event EventHandler<StreamlabsOBSItem> OnItemAdded {
            add => ItemAdded.Subscribe(value);
            remove => ItemAdded.UnSubscribe(value);
        }

        public event EventHandler<StreamlabsOBSItem> OnItemRemoved {
            add => ItemRemoved.Subscribe(value);
            remove => ItemRemoved.UnSubscribe(value);
        }

        public event EventHandler<StreamlabsOBSItem> OnItemUpdated {
            add => ItemUpdated.Subscribe(value);
            remove => ItemUpdated.UnSubscribe(value);
        }

        public event EventHandler<StreamlabsOBSScene> OnSceneAdded {
            add => SceneAdded.Subscribe(value);
            remove => SceneAdded.UnSubscribe(value);
        }

        public event EventHandler<StreamlabsOBSScene> OnSceneRemoved {
            add => SceneRemoved.Subscribe(value);
            remove => SceneRemoved.UnSubscribe(value);
        }

        public event EventHandler<StreamlabsOBSScene> OnSceneSwitched {
            add => SceneSwitched.Subscribe(value);
            remove => SceneSwitched.UnSubscribe(value);
        }

        #region STATICS, CONST and FIELDS

        private const string RESOURCE = "ScenesService";

        [NotNull] private readonly StreamlabsOBSClient client;
        [NotNull] private readonly SceneCollectionsService collectionsService;


        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSItem> ItemAdded = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSItem>(new StreamlabsOBSRequest("itemAdded", RESOURCE));

        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSItem> ItemRemoved = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSItem>(new StreamlabsOBSRequest("itemRemoved", RESOURCE));

        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSItem> ItemUpdated = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSItem>(new StreamlabsOBSRequest("itemUpdated", RESOURCE));

        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSScene> SceneAdded = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSScene>(new StreamlabsOBSRequest("sceneAdded", RESOURCE));

        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSScene>
            SceneRemoved = new StreamlabsOBSSubscriptionHandler<StreamlabsOBSScene>(new StreamlabsOBSRequest("sceneRemoved", RESOURCE));

        public readonly StreamlabsOBSSubscriptionHandler<StreamlabsOBSScene> SceneSwitched =
            new StreamlabsOBSSubscriptionHandler<StreamlabsOBSScene>(new StreamlabsOBSRequest("sceneSwitched", RESOURCE));

        #endregion

        #region  CONSTRUCTORS

        public ScenesService() {
            client = new StreamlabsOBSClient();
            collectionsService = new SceneCollectionsService(client);
        }

        public ScenesService([NotNull] StreamlabsOBSClient client, [NotNull] SceneCollectionsService collectionsService) {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            this.collectionsService = collectionsService ?? throw new ArgumentNullException(nameof(collectionsService));
        }

        #endregion
    }
}