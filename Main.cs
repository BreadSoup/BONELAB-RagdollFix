using BoneLib;
using MelonLoader;
using UnityEngine;
using static RagdollFix.Preferences;

namespace RagdollFix
{
    internal partial class Main : MelonMod
    {
        private bool _sceneLoaded;
        private bool _previousRagdollState;
        private bool _currentRagdollState;

        public override void OnInitializeMelon()
        {
            Hooking.OnLevelInitialized += _ => { OnSceneAwake(); };
            MelonPreferencesCreator();
            BoneMenuCreator();
        }

        private void OnSceneAwake()
        {
            _sceneLoaded = true;
            _previousRagdollState = Player.physicsRig._legsKinematic;
        }

        public override void OnUpdate()
        {
            if (_sceneLoaded)
            {
                if (IsEnabled)
                {
                    _currentRagdollState = Player.physicsRig._legsKinematic;
                    if (!_previousRagdollState && _currentRagdollState)
                    {
                        var teleport = Player.physicsRig.feet.transform.position + new Vector3(0, 0.25f, 0);
                        Player.rigManager.Teleport(teleport);
                    }
                }
            }

            _previousRagdollState = _currentRagdollState;
        }

    }
}
