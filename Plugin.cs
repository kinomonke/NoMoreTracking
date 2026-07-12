using BepInEx;
using GorillaNetworking;
using HarmonyLib;
using System;
using System.Linq;

namespace NoMoreTracking;

[BepInPlugin(Constants.GUID, Constants.NAME, Constants.VERS)]
public class Plugin : BaseUnityPlugin
{
    static readonly Random Random = new();

    void Start() =>
        Harmony.CreateAndPatchAll(typeof(Plugin).Assembly, Constants.GUID);

    public static bool CorrectTab =>
        GorillaComputer.instance.currentState == GorillaComputer.ComputerState.Room;

    public static void JoinRandomString()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(
            new string([.. Enumerable.Range(0, 6).Select(_ => chars[Random.Next(chars.Length)])]),
            JoinType.Solo);
    }
}

class Constants
{
    public const string GUID = "kinomonke.nomoretracking",
        NAME = "NoMoreTracking",
        VERS = "1.00";
}