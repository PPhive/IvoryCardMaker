using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Diagnostics;
using System.IO;

public class ExploererOpener : MonoBehaviour
{
    /// <summary>
    /// Opens the OS file explorer at the given absolute path.
    /// </summary>
    /// <param name="absolutePath">An absolute folder path on the local filesystem.</param>
    /// 
    void Start()
    {
        OpenFolder(Application.persistentDataPath);
    }

    public void OpenFolder(string absolutePath)
    {
        if (string.IsNullOrEmpty(absolutePath))
        {
            UnityEngine.Debug.LogError("OpenFolder: path is null or empty.");
            return;
        }

        if (!Directory.Exists(absolutePath))
        {
            UnityEngine.Debug.LogError($"OpenFolder: Directory not found: {absolutePath}");
            return;
        }

#if UNITY_EDITOR
        // In the Editor, use RevealInFinder (Windows & macOS)
        EditorUtility.RevealInFinder(absolutePath);
#else
        // At runtime, launch the system file browser
#if UNITY_STANDALONE_WIN
            string windowsPath = absolutePath.Replace('/', '\\');
            Process.Start("explorer.exe", $"\"{windowsPath}\"");
#elif UNITY_STANDALONE_OSX
            Process.Start("open", $"\"{absolutePath}\"");
#elif UNITY_STANDALONE_LINUX
            Process.Start("xdg-open", $"\"{absolutePath}\"");
#else
            // Fallback for other platforms
            Application.OpenURL("file://" + absolutePath);
#endif
#endif
    }
}