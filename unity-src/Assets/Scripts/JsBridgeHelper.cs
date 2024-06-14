using System.Runtime.InteropServices;
using UnityEngine;

public class JsBridgeHelper
{
    [DllImport("__Internal")]
    private static extern string GetGameVersionJSBridge();
    
    [DllImport("__Internal")]
    private static extern void ReportDataJSBridge(string jsonStr);

    // possible values from js: "control", "non-diegetic", "diegetic"
    public static GameVersion GetGameVersion()
    {
        var gameVersionFromJs = GetGameVersionJSBridge();
        return gameVersionFromJs switch
        {
            "control" => GameVersion.NoFeedback,
            "non-diegetic" => GameVersion.TopBar,
            _ => GameVersion.Character
        };
    }

    // stringify the input json!
    public static void ReportData(string jsonStr)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        ReportDataJSBridge(jsonStr);
#else
        // for testing in unity editor
        Debug.Log(jsonStr);
#endif     
    }
}