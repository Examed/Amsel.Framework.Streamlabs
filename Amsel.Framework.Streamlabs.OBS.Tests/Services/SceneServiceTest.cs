using Amsel.Framework.Streamlabs.OBS.Models.Response;
using Amsel.Framework.Streamlabs.OBS.Services;
using Amsel.Framework.Streamlabs.OBS.Tests.Attribute;
using Amsel.Framework.Streamlabs.OBS.Tests.Utilities;
using System;
using System.Diagnostics;
using Xunit;

namespace Amsel.Framework.Streamlabs.OBS.Tests.Services {
    public class SceneServiceTest {
        private readonly ScenesService _service = new ScenesService();

        [DebugOnlyFact]
        public void ActiveScene() => _ = _service.ActiveScene();

        [DebugOnlyFact]
        public void CreateScene() => _ = _service.CreateScene("test");

        [DebugOnlyFact]
        public void GetScene()
        {
            StreamlabsOBSScene scene = _service.ActiveScene();
            _ = _service.GetScene(scene.Id);
        }

        [DebugOnlyFact]
        public void GetSceneByName() => _ = _service.GetSceneByName("test");

        [DebugOnlyFact]
        public void GetScenes() => _ = _service.GetScenes();

        [DebugOnlyFact]
        public void ItemAdded()
        {
            _service.OnItemAdded += (s, e) => { Debug.Write(nameof(_service.OnItemAdded)); };

            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void ItemRemoved()
        {
            _service.OnItemRemoved += (s, e) => { Debug.Write(nameof(_service.OnItemRemoved)); };

            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void ItemUpdated()
        {
            _service.OnItemUpdated += (s, e) => { Debug.Write(nameof(_service.OnItemUpdated)); };

            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void MakeSceneActive()
        {
            StreamlabsOBSScene scene = _service.GetSceneByName("test");
            _ = _service.MakeSceneActive(scene.Id);
        }

        [Fact]
        public void PassTest() => Assert.True(true);

        [DebugOnlyFact]
        public void RemoveScene()
        {
            StreamlabsOBSScene scene = _service.GetSceneByName("test");
            _ = _service.RemoveScene(scene.Id);
        }

        [DebugOnlyFact]
        public void SceneAdded()
        {
            _service.OnSceneAdded += (s, e) => { Debug.Write(nameof(_service.OnSceneAdded)); };
            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void SceneRemoved()
        {
            _service.OnSceneRemoved += (s, e) => { Debug.Write(nameof(_service.OnSceneRemoved)); };
            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void SceneSwitched()
        {
            _service.OnSceneSwitched += (s, e) => { Debug.Write(nameof(_service.OnSceneSwitched)); };
            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }
    }
}