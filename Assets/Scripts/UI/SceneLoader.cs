using UnityEditor;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public static void LoadNextScene()
    {
        ScenesManager.Scene++;
    }

    public static void LoadFirstScene()
    {
        ScenesManager.Scene = 0;
    }

    public static void LoadLastScene()
    {
        ScenesManager.Scene = ScenesManager.ScenesQuantity - 1;
    }
}