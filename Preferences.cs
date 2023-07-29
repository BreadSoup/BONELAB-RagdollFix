using BoneLib.BoneMenu;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RagdollFix
{
    internal class Preferences
    {
        public static MelonPreferences_Category MelonPrefCategory { get; private set; }
        public static MelonPreferences_Entry<bool> MelonPrefEnabled { get; private set; }
        public static bool IsEnabled { get; private set; }
        public static void MelonPreferencesCreator()
        {
            MelonPrefCategory = MelonPreferences.CreateCategory("Crumble");
            MelonPrefEnabled = MelonPrefCategory.CreateEntry<bool>("IsEnabled", true, null, null, false, false, null, null);
            IsEnabled = MelonPrefEnabled.Value;
        }
        public static void BonemenuCreator()
        {
            var category = MenuManager.CreateCategory("Ragdoll Fix", Color.yellow);
            category.CreateBoolElement("Mod Toggle", Color.yellow, IsEnabled, new Action<bool>(OnSetEnabled));
        }
        public static void OnSetEnabled(bool value) //wish I could figure out how to use overflows with bonemenu
        {
            IsEnabled = value;
            MelonPrefEnabled.Value = value;
            MelonPrefCategory.SaveToFile(false);
        }
    }
}
