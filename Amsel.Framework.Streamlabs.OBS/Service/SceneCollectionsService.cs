using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;
using Amsel.Framework.Streamlabs.OBS.Models.Request;
using Amsel.Framework.Streamlabs.OBS.Models.Response;
using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Service
{
    public class SceneCollectionsService
    {
        private readonly StreamlabsSubscriptionHandler<StreamlabsResponse> collectionAdded
            = new StreamlabsSubscriptionHandler<StreamlabsResponse>(new StreamlabsRequest("collectionAdded", "SceneCollectionsService"));

        public event EventHandler<StreamlabsResponse> OnCollectionAdded
        {
            add => collectionSwitched.Subscribe(value);
            remove => collectionSwitched.UnSubscribe(value);
        }

        private readonly StreamlabsSubscriptionHandler<StreamlabsResponse> collectionRemoved
            = new StreamlabsSubscriptionHandler<StreamlabsResponse>(new StreamlabsRequest("collectionRemoved", "SceneCollectionsService"));

        public event EventHandler<StreamlabsResponse> OnCollectionRemoved
        {
            add => collectionSwitched.Subscribe(value);
            remove => collectionSwitched.UnSubscribe(value);
        }
        
        private readonly StreamlabsSubscriptionHandler<StreamlabsResponse> collectionSwitched
            = new StreamlabsSubscriptionHandler<StreamlabsResponse>(new StreamlabsRequest("collectionSwitched", "SceneCollectionsService"));

        public event EventHandler<StreamlabsResponse> OnCollectionSwitched
        {
            add => collectionSwitched.Subscribe(value);
            remove => collectionSwitched.UnSubscribe(value);
        }

        private readonly StreamlabsSubscriptionHandler<StreamlabsResponse> collectionUpdated
            = new StreamlabsSubscriptionHandler<StreamlabsResponse>(new StreamlabsRequest("collectionUpdated", "SceneCollectionsService"));

        public event EventHandler<StreamlabsResponse> OnCollectionUpdated
        {
            add => collectionSwitched.Subscribe(value);
            remove => collectionSwitched.UnSubscribe(value);
        }

        private readonly StreamlabsSubscriptionHandler<StreamlabsResponse> collectionWillSwitch
            = new StreamlabsSubscriptionHandler<StreamlabsResponse>(new StreamlabsRequest("collectionWillSwitch", "SceneCollectionsService"));

        public event EventHandler<StreamlabsResponse> OnCollectionWillSwitch
        {
            add => collectionSwitched.Subscribe(value);
            remove => collectionSwitched.UnSubscribe(value);
        }
    }
}
