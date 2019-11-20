using System;
using System.Collections.Generic;
using System.Diagnostics;
using Amsel.Framework.Streamlabs.OBS.Models.Response;
using Amsel.Framework.Streamlabs.OBS.Services;
using Amsel.Framework.Streamlabs.OBS.Tests.Attribute;
using Amsel.Framework.Streamlabs.OBS.Tests.Utilities;

namespace Amsel.Framework.Streamlabs.OBS.Tests.Services
{
    public class SceneServiceTest
    {
        #region STATICS, CONST and FIELDS

        private readonly ScenesService service = new ScenesService();

        #endregion

        [DebugOnlyFact]
        public void CreateScene() {
            StreamlabsOBSScene result = service.CreateScene("test");
        }

        [DebugOnlyFact]
        public void ActiveScene() {
            StreamlabsOBSScene result = service.ActiveScene();
        }

        [DebugOnlyFact]
        public void GetScene() {
            StreamlabsOBSScene scene = service.ActiveScene();
            StreamlabsOBSScene result = service.GetScene(scene.Id);
        }

        [DebugOnlyFact]
        public void GetScenes() {
            IEnumerable<StreamlabsOBSScene> result = service.GetScenes();
        }

        [DebugOnlyFact]
        public void GetSceneByName() {
            StreamlabsOBSScene result = service.GetSceneByName("test");
        }

        [DebugOnlyFact]
        public void MakeSceneActive() {
            StreamlabsOBSScene scene = service.GetSceneByName("test");
            bool result = service.MakeSceneActive(scene.Id);
        }

        [DebugOnlyFact]
        public void RemoveScene() {
            StreamlabsOBSScene scene = service.GetSceneByName("test");
            StreamlabsOBSSceneBase result = service.RemoveScene(scene.Id);
        }


        [DebugOnlyFact]
        public void ItemAdded() {
            service.OnItemAdded += (s, e) => { Debug.Write(nameof(service.OnItemAdded)); };

            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void ItemRemoved() {
            service.OnItemRemoved += (s, e) => { Debug.Write(nameof(service.OnItemRemoved)); };

            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void ItemUpdated() {
            service.OnItemUpdated += (s, e) => { Debug.Write(nameof(service.OnItemUpdated)); };

            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void SceneAdded() {
            service.OnSceneAdded += (s, e) => { Debug.Write(nameof(service.OnSceneAdded)); };
            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void SceneRemoved() {
            service.OnSceneRemoved += (s, e) => { Debug.Write(nameof(service.OnSceneRemoved)); };
            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }

        [DebugOnlyFact]
        public void SceneSwitched() {
            service.OnSceneSwitched += (s, e) => { Debug.Write(nameof(service.OnSceneSwitched)); };
            TimeoutUtils.WhileTimeout(TimeSpan.FromMinutes(1));
        }
    }
}