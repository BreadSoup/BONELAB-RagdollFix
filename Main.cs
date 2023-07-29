using BoneLib;
using MelonLoader;
using SLZ.VRMK;
using UnityEngine;

namespace RagdollFix
{
    internal partial class Main : MelonMod
    {
        bool SceneLoaded = false;
        bool PreviousRagdollState;
        bool CurrentRagdollState;

        public override void OnInitializeMelon()
        {
            BoneLib.Hooking.OnLevelInitialized += (_) => { OnSceneAwake(); };
            Preferences.MelonPreferencesCreator();
            Preferences.BonemenuCreator();
        }

        public void OnSceneAwake()
        {
            SceneLoaded = true;
            PreviousRagdollState = Player.physicsRig._legsKinematic;
        }

        public override void OnUpdate()
        {
            if (SceneLoaded)
            {
                if (Preferences.IsEnabled)
                {
                    CurrentRagdollState = BoneLib.Player.physicsRig._legsKinematic;
                    if (!PreviousRagdollState && CurrentRagdollState)
                    {
                        Vector3 Teleport = BoneLib.Player.physicsRig.feet.transform.position + new Vector3(0, 0.25f, 0);
                        BoneLib.Player.rigManager.Teleport(Teleport, true);
                    }
                }
            }

            PreviousRagdollState = CurrentRagdollState;
        }

    }
}
