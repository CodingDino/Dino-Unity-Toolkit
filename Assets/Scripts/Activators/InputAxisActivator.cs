// -----------------------------------------------------------------------------
#region File Info - InputAxisActivator.cs
// -----------------------------------------------------------------------------
// Project:     Drag N Drop Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Perform actions based on axis input
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
#region Component: InputAxisActivator
// -----------------------------------------------------------------------------
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/InputAxisActivator")]
public class InputAxisActivator : MonoBehaviour
{
    // -------------------------------------------------------------------------
    #region Custom Unity Event: AxisAxtion
    // -------------------------------------------------------------------------
    [System.Serializable]
    public class AxisAction : UnityEvent<float> { }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Editor Variables
    // -------------------------------------------------------------------------

    // -------------------------------------------------------------------------
    [Header("Conditions")]
    // -------------------------------------------------------------------------

    [Tooltip("The name of the axis the player must use to activate these actions. Axis must be set up in InputManager.")]
    public string axisName;

    // -------------------------------------------------------------------------

    [Header("Actions")]
    [Tooltip("Perform these actions when the axis changes from its previous value.")]
    public AxisAction onAxisChanged;
    [Tooltip("Perform these actions when the axis becomes non-zero.")]
    public AxisAction onAxisStart;
    [Tooltip("Perform these actions when the axis becomes zero.")]
    public AxisAction onAxisRest;

    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Internal Variables
    // -------------------------------------------------------------------------
    private float previousAxisValue = 0;
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Unity Functions
    // -------------------------------------------------------------------------
    private void Update()
    {
        // Get the current value for the axis
        float axisValue = Input.GetAxis(axisName);

        // Has the axis value changed?
        if (axisValue != previousAxisValue)
        {
            // The axis has changed since last frame, so perform the actions.
            onAxisChanged.Invoke(axisValue);
        }

        // Did the axis just become active (non-zero)?
        if (previousAxisValue == 0 && axisValue != 0)
        {
            // The axis just became non-zero, so perform actions.
            onAxisStart.Invoke(axisValue);
        }

        // Did the axis just become inactive (zero)?
        if (previousAxisValue != 0 && axisValue == 0)
        {
            // The axis just became zero, so perform actions.
            onAxisRest.Invoke(axisValue);
        }

        // The current value for the axis now becomes the previous value 
        // for the next frame
        previousAxisValue = axisValue;
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------
}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------