using BoneLib.BoneMenu;
using MelonLoader;
using UnityEngine;

namespace RagdollFix
{
    internal static class Preferences
    {
        private static MelonPreferences_Category MelonPrefCategory { get; set; }
        private static MelonPreferences_Entry<bool> MelonPrefEnabled { get; set; }
        public static bool IsEnabled { get; private set; }
        public static void MelonPreferencesCreator()
        {
            MelonPrefCategory = MelonPreferences.CreateCategory("Crumble");
            MelonPrefEnabled = MelonPrefCategory.CreateEntry("IsEnabled", true);
            IsEnabled = MelonPrefEnabled.Value;
        }
        public static void BoneMenuCreator()
        {
            var category = MenuManager.CreateCategory("Ragdoll Fix", Color.yellow);
            category.CreateBoolElement("Mod Toggle", Color.yellow, IsEnabled, OnSetEnabled);
        }

        private static void OnSetEnabled(bool value) //wish I could figure out how to use overflows with BONEMENU
        {
            IsEnabled = value;
            MelonPrefEnabled.Value = value;
            MelonPrefCategory.SaveToFile(false);
        }
    }
}
