using System.Reflection;
using RagdollFix;
using MelonLoader;

[assembly: AssemblyTitle(RagdollFix.Main.Description)]
[assembly: AssemblyDescription(RagdollFix.Main.Description)]
[assembly: AssemblyCompany(RagdollFix.Main.Company)]
[assembly: AssemblyProduct(RagdollFix.Main.Name)]
[assembly: AssemblyCopyright("Developed by " + RagdollFix.Main.Author)]
[assembly: AssemblyTrademark(RagdollFix.Main.Company)]
[assembly: AssemblyVersion(RagdollFix.Main.Version)]
[assembly: AssemblyFileVersion(RagdollFix.Main.Version)]
[assembly: MelonInfo(typeof(RagdollFix.Main), RagdollFix.Main.Name, RagdollFix.Main.Version, RagdollFix.Main.Author, RagdollFix.Main.DownloadLink)]
[assembly: MelonColor(System.ConsoleColor.White)]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame("Stress Level Zero", "BONELAB")]