// -----------------------------------------------------------------------------
#region File Info - UpdateActivator.cs
// -----------------------------------------------------------------------------
// Project:     Dino Unity Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Perform actions when Unity update functions are called
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
#region Component: UpdateActivator
// -----------------------------------------------------------------------------
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/UpdateActivator")]
public class UpdateActivator : MonoBehaviour
{


    // -------------------------------------------------------------------------
    #region Editor Variables
    // -------------------------------------------------------------------------
    [Tooltip("Perform these actions every time physics effects are processed.")]
    public UnityEvent onFixedUpdate;
    [Tooltip("Perform these actions every frame.")]
    public UnityEvent onUpdate;
    [Tooltip("Perform these actions every frame, after other effects.")]
    public UnityEvent onLateUpdate;
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Unity Functions
    // -------------------------------------------------------------------------
    private void FixedUpdate()
    {
        // Perform FixedUpdate actions
        onFixedUpdate.Invoke();
    }
    // -------------------------------------------------------------------------
    private void Update()
    {
        // Perform Update actions
        onUpdate.Invoke();
    }
    // -------------------------------------------------------------------------
    private void LateUpdate()
    {
        // Perform LateUpdate actions
        onLateUpdate.Invoke();
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------
}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------