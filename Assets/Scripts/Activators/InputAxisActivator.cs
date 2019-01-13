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

    [Tooltip("How frequently can this activation happen, in seconds? 0 for no cooldown.")]
    public float cooldown = 0;

    // -------------------------------------------------------------------------

    [Header("Actions")]
    [Tooltip("Perform these actions when the axis changes from its previous value.")]
    public AxisAction onAxisChanged;
    [Tooltip("Perform these actions when the axis becomes non-zero.")]
    public AxisAction onAxisStart;
    [Tooltip("Perform these actions when the axis becomes zero.")]
    public AxisAction onAxisEnd;

    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Internal Variables
    // -------------------------------------------------------------------------
    private float previousAxisValue = 0;
    private float lastActivate = 0;
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

        // Each frame, check if we should perform actions
        // Before we try to perform any actions, check if we are off cooldown
        if (Time.time >= lastActivate + cooldown)
        {
            // Has the axis value changed?
            if (axisValue != previousAxisValue)
            {
                // The axis has changed since last frame, so perform the actions.
                onAxisChanged.Invoke(axisValue);

                // Record this time in lastActivate so we can check 
                // when we next come off cooldown
                lastActivate = Time.time;
            }

            // Did the axis just become active (non-zero)?
            if (previousAxisValue == 0 && axisValue != 0)
            {
                // The axis just became non-zero, so perform actions.
                onAxisStart.Invoke(axisValue);

                // Record this time in lastActivate so we can check 
                // when we next come off cooldown
                lastActivate = Time.time;
            }

            // Did the axis just become inactive (zero)?
            if (previousAxisValue != 0 && axisValue == 0)
            {
                // The axis just became zero, so perform actions.
                onAxisEnd.Invoke(axisValue);

                // Record this time in lastActivate so we can check 
                // when we next come off cooldown
                lastActivate = Time.time;
            }

            // The current value for the axis now becomes the previous value 
            // for the next frame
            previousAxisValue = axisValue;
        }
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------
}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------