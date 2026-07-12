using GorillaNetworking;
using HarmonyLib;

namespace NoMoreTracking.Patches;

[HarmonyPatch(typeof(GorillaKeyboardButton), "OnButtonPressedEvent")]
class KeyPatch
{
    static void Postfix(GorillaKeyboardButton __instance)
    {
        if (__instance.Binding == GorillaKeyboardBindings.option3 && Plugin.CorrectTab)
            Plugin.JoinRandomString();
    }
}