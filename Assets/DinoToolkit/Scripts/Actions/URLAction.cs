﻿// -----------------------------------------------------------------------------
#region File Info - URLAction.cs
// -----------------------------------------------------------------------------
// Project:     Dino Unity Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Opens a URL
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------


// -----------------------------------------------------------------------------
#region Libraries
// -----------------------------------------------------------------------------
using UnityEngine;
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------


// -----------------------------------------------------------------------------
#region Component: URLAction
// -----------------------------------------------------------------------------
[AddComponentMenu("Dino Toolkit/Actions/URLAction")]
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/URLAction")]
public class URLAction : MonoBehaviour
{
    // -------------------------------------------------------------------------
    #region Action Functions
    // -------------------------------------------------------------------------
    public void ActionOpenURL(string url)
    {
        Application.OpenURL(url);
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------
}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------