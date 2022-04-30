using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using HarmonyLib;
using NoHudMod.Patches;

namespace NoHudMod
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BasePlugin
    {
        internal static new ManualLogSource Log;
        public override void Load()
        {
            // Plugin startup logic
            base.Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Plugin.Log = base.Log;
            Harmony.CreateAndPatchAll(typeof(MapPlayerHooks));
            
        }
    }
}