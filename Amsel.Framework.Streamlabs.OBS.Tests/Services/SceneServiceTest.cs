using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Amsel.Framework.Streamlabs.OBS.Services;
using Amsel.Framework.Streamlabs.OBS.Tests.Attribute;
using Amsel.Framework.Streamlabs.OBS.Tests.Utilities;
using FakeItEasy;
using Xunit;

namespace Amsel.Framework.Streamlabs.OBS.Tests.Services
{
    public class SceneServiceTest
    {
        private readonly ScenesService service = new ScenesService();

        [DebugOnlyFact]
        public void CreateScene()
        {
            var result = service.CreateScene("test");
        }

        [DebugOnlyFact]
        public void ActiveScene()
        {
            var result = service.ActiveScene();
        }

        [DebugOnlyFact]
        public void GetScene()
        {
            var scene = service.ActiveScene();
            var result = service.GetScene(scene.Id);
        }

        [DebugOnlyFact]
        public void GetScenes()
        {
            var result = service.GetScenes();
        }

        [DebugOnlyFact]
        public void GetSceneByName()
        {
            var result = service.GetSceneByName("test");
        }

        [DebugOnlyFact]
        public void MakeSceneActive()
        {
            var scene = service.GetSceneByName("test");
            var result = service.MakeSceneActive(scene.Id);
        }

        [DebugOnlyFact]
        public void RemoveScene()
        {
            var scene = service.GetSceneByName("test");
            var result = service.RemoveScene(scene.Id);
        }


        [DebugOnlyFact]
        public void ItemAdded()
        {
            service.OnItemAdded += (s, e) =>
            {
                Debug.Write(nameof(service.OnItemAdded));
            };

            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void ItemRemoved()
        {
            service.OnItemRemoved += (s, e) =>
            {
                Debug.Write(nameof(service.OnItemRemoved));
            };

            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void ItemUpdated()
        {
            service.OnItemUpdated += (s, e) =>
            {
                Debug.Write(nameof(service.OnItemUpdated));
            };

            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void SceneAdded()
        {
            service.OnSceneAdded += (s, e) =>
            {
                Debug.Write(nameof(service.OnSceneAdded));
            };
            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void SceneRemoved()
        {
            service.OnSceneRemoved += (s, e) =>
            {
                Debug.Write(nameof(service.OnSceneRemoved));
            };
            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void SceneSwitched()
        {
            service.OnSceneSwitched += (s, e) =>
            {
                Debug.Write(nameof(service.OnSceneSwitched));
            };
            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

    }
}
