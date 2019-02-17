// -----------------------------------------------------------------------------
#region File Info - DecommissionActivator.cs
// -----------------------------------------------------------------------------
// Project:     Dino Unity Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Perform actions when Unity decommission functions are called
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------


// -----------------------------------------------------------------------------
#region Libraries
// -----------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.Events;
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------


// -----------------------------------------------------------------------------
#region Component: DecommissionActivator
// -----------------------------------------------------------------------------
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/DecommissionActivator")]
public class DecommissionActivator : MonoBehaviour
{


    // -------------------------------------------------------------------------
    #region Editor Variables
    // -------------------------------------------------------------------------
    [Tooltip("Perform these actions once when the game quits.")]
    public UnityEvent onApplicationQuit;
    [Tooltip("Perform these actions once when the GameObject is being disabled or destroyed.")]
    public UnityEvent onDisable;
    [Tooltip("Perform these actions once when the GameObject is being destroyed.")]
    public UnityEvent onDestroy;
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Unity Functions
    // -------------------------------------------------------------------------
    private void OnApplicationQuit()
    {
        onApplicationQuit.Invoke();
    }
    // -------------------------------------------------------------------------
    private void OnDisable()
    {
        onDisable.Invoke();
    }
    // -------------------------------------------------------------------------
    private void OnDestroy()
    {
        onDestroy.Invoke();
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------
}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------