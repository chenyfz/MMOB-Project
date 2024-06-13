using System.Runtime.InteropServices;
using UnityEngine;

public class JsBridgeHelper
{
    [DllImport("__Internal")]
    private static extern string GetGameVersionJSBridge();
    
    [DllImport("__Internal")]
    private static extern void ReportDataJSBridge(string jsonStr);

    // possible values: "control", "non-diegetic", "diegetic"
    public static string GetGameVersion()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        return GetGameVersionJSBridge();
#else
        // for testing in unity editor
        return "control";
#endif
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