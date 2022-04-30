using HarmonyLib;
using UnityEngine;

namespace NoHudMod.Patches;

public class MapPlayerHooks
{

    static void HideAllGameObjects(GameObject obj)
    {
        Plugin.Log.LogInfo($"new : {obj.name} & {obj.transform.childCount}");
        obj.SetActive(false);
        // for(int i=0; i<obj.transform.childCount; i++)
        // {
        //     var newObj = obj.transform.GetChild(i).gameObject;
        //     newObj.SetActive(false);
        //     Plugin.Log.LogInfo(newObj.name);
        //     HideAllGameObjects(newObj);
        // }
    }
    
    [HarmonyPatch(typeof(MapPlayer), "FixedUpdate")]
    [HarmonyPrefix]
    static void OnFixedUpdate(MapPlayer __instance)
    {
        Plugin.Log.LogInfo($"p1 : {__instance.p1} ");
        if (__instance.p1)
        {
            HideAllGameObjects(__instance.p1);
            HideAllGameObjects(__instance.p2);
            // __instance.p1.SetActive(false);
            // __instance.p2.SetActive(false);
            
        }
    }
}