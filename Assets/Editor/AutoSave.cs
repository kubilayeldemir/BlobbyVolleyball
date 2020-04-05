using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEditor;

[InitializeOnLoad]
public class AutoSave
{
    static AutoSave()
    {
        EditorApplication.playModeStateChanged += (PlayModeStateChange state) => {
            // If we're about to run the scene...
            if (EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)
            {
                // Save the scene and the assets.
                Debug.Log("Auto-saving all open scenes... " + state);
                EditorSceneManager.SaveOpenScenes();
                AssetDatabase.SaveAssets();
            }
        };
    }
}
