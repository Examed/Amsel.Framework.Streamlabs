using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;
using Amsel.Clients.Sample.SLOBS.Models.Request;
using Amsel.Clients.Sample.SLOBS.Models.Response;
using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Service
{
    public class SceneCollectionsService
    {
        private readonly StreamlabsSubscription<StreamlabsResponse> collectionAdded
            = new StreamlabsSubscription<StreamlabsResponse>(new StreamlabsRequest("collectionAdded", "SceneCollectionsService"));

        public event EventHandler<StreamlabsResponse> OnCollectionAdded
        {
            add => collectionSwitched.Subscribe(value);
            remove => collectionSwitched.UnSubscribe(value);
        }

        private readonly StreamlabsSubscription<StreamlabsResponse> collectionRemoved
            = new StreamlabsSubscription<StreamlabsResponse>(new StreamlabsRequest("collectionRemoved", "SceneCollectionsService"));

        public event EventHandler<StreamlabsResponse> OnCollectionRemoved
        {
            add => collectionSwitched.Subscribe(value);
            remove => collectionSwitched.UnSubscribe(value);
        }
        
        private readonly StreamlabsSubscription<StreamlabsResponse> collectionSwitched
            = new StreamlabsSubscription<StreamlabsResponse>(new StreamlabsRequest("collectionSwitched", "SceneCollectionsService"));

        public event EventHandler<StreamlabsResponse> OnCollectionSwitched
        {
            add => collectionSwitched.Subscribe(value);
            remove => collectionSwitched.UnSubscribe(value);
        }

        private readonly StreamlabsSubscription<StreamlabsResponse> collectionUpdated
            = new StreamlabsSubscription<StreamlabsResponse>(new StreamlabsRequest("collectionUpdated", "SceneCollectionsService"));

        public event EventHandler<StreamlabsResponse> OnCollectionUpdated
        {
            add => collectionSwitched.Subscribe(value);
            remove => collectionSwitched.UnSubscribe(value);
        }

        private readonly StreamlabsSubscription<StreamlabsResponse> collectionWillSwitch
            = new StreamlabsSubscription<StreamlabsResponse>(new StreamlabsRequest("collectionWillSwitch", "SceneCollectionsService"));

        public event EventHandler<StreamlabsResponse> OnCollectionWillSwitch
        {
            add => collectionSwitched.Subscribe(value);
            remove => collectionSwitched.UnSubscribe(value);
        }
    }
}
