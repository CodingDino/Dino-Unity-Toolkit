﻿// -----------------------------------------------------------------------------
#region File Info - SceneAction.cs
// -----------------------------------------------------------------------------
// Project:     Dino Unity Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Controls changes between scenes
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------


// -----------------------------------------------------------------------------
#region Libraries
// -----------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------


// -----------------------------------------------------------------------------
#region Component: SceneAction
// -----------------------------------------------------------------------------
[AddComponentMenu("Dino Toolkit/Actions/SceneAction")]
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/SceneAction")]
public class SceneAction : MonoBehaviour
{

    // -------------------------------------------------------------------------
    #region Action Functions
    // -------------------------------------------------------------------------
    public void ActionLoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    // -------------------------------------------------------------------------
    public void ActionReloadCurrentScene()
    {
        // Get current scene
        string sceneName = SceneManager.GetActiveScene().name;
        // Reload that scene
        SceneManager.LoadScene(sceneName);
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------