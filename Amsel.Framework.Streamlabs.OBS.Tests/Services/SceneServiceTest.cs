using Amsel.Framework.Streamlabs.OBS.Models.Response;
using Amsel.Framework.Streamlabs.OBS.Services;
using Amsel.Framework.Streamlabs.OBS.Tests.Attribute;
using Amsel.Framework.Streamlabs.OBS.Tests.Utilities;
using System;
using System.Diagnostics;
using Xunit;

namespace Amsel.Framework.Streamlabs.OBS.Tests.Services {
    public class SceneServiceTest {
        private readonly ScenesService service = new ScenesService();

        [DebugOnlyFact]
        public void ActiveScene() => _ = service.ActiveScene();

        [DebugOnlyFact]
        public void CreateScene() => _ = service.CreateScene("test");

        [DebugOnlyFact]
        public void GetScene()
        {
            StreamlabsOBSScene scene = service.ActiveScene();
            _ = service.GetScene(scene.Id);
        }

        [DebugOnlyFact]
        public void GetSceneByName() => _ = service.GetSceneByName("test");

        [DebugOnlyFact]
        public void GetScenes() => _ = service.GetScenes();

        [DebugOnlyFact]
        public void ItemAdded()
        {
            service.OnItemAdded += (s, e) => { Debug.Write(nameof(service.OnItemAdded)); };

            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void ItemRemoved()
        {
            service.OnItemRemoved += (s, e) => { Debug.Write(nameof(service.OnItemRemoved)); };

            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void ItemUpdated()
        {
            service.OnItemUpdated += (s, e) => { Debug.Write(nameof(service.OnItemUpdated)); };

            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void MakeSceneActive()
        {
            StreamlabsOBSScene scene = service.GetSceneByName("test");
            _ = service.MakeSceneActive(scene.Id);
        }

        [Fact]
        public void PassTest() => Assert.True(true);

        [DebugOnlyFact]
        public void RemoveScene()
        {
            StreamlabsOBSScene scene = service.GetSceneByName("test");
            _ = service.RemoveScene(scene.Id);
        }

        [DebugOnlyFact]
        public void SceneAdded()
        {
            service.OnSceneAdded += (s, e) => { Debug.Write(nameof(service.OnSceneAdded)); };
            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void SceneRemoved()
        {
            service.OnSceneRemoved += (s, e) => { Debug.Write(nameof(service.OnSceneRemoved)); };
            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void SceneSwitched()
        {
            service.OnSceneSwitched += (s, e) => { Debug.Write(nameof(service.OnSceneSwitched)); };
            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }
    }
}