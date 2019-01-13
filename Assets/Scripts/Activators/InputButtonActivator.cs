// -----------------------------------------------------------------------------
#region File Info - InputButtonActivator.cs
// -----------------------------------------------------------------------------
// Project:     Drag N Drop Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Perform actions when a keyboard or gamepad button is pressed
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
#region Component: InputButtonActivator
// -----------------------------------------------------------------------------
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/InputButtonActivator")]
public class InputButtonActivator : MonoBehaviour
{


    // -------------------------------------------------------------------------
    #region Editor Variables
    // -------------------------------------------------------------------------

    // -------------------------------------------------------------------------
    [Header("Conditions")]
    // -------------------------------------------------------------------------

    [Tooltip("The button the player must press to activate these actions. Button must be set up in InputManager.")]
    public string button;

    [Tooltip("How frequently can this activation happen, in seconds? 0 for no cooldown.")]
    public float cooldown = 0;

    // -------------------------------------------------------------------------

    [Header("Actions")]
    [Tooltip("Perform these actions when the button is first pressed down.")]
    public UnityEvent onButtonPressed;
    [Tooltip("Perform these actions every frame the button is held down.")]
    public UnityEvent onButtonHeld;
    [Tooltip("Perform these actions when the button is released and comes back up.")]
    public UnityEvent onButtonReleased;

    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Internal Variables
    // -------------------------------------------------------------------------
    private float lastActivate = 0;
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Unity Functions
    // -------------------------------------------------------------------------
    private void Update()
    {
        // Each frame, check if we should perform actions
        // Before we try to perform any actions, check if we are off cooldown
        if (Time.time >= lastActivate + cooldown)
        {
            // We are off cooldown, so check if we should activate based on the type of press style

            // Check if the button has just now been pushed down
            if (Input.GetButtonDown(button))
            {
                // The button has just been pressed, so perform the actions.
                onButtonPressed.Invoke();

                // Record this time in lastActivate so we can check 
                // when we next come off cooldown
                lastActivate = Time.time;
            }


            // Check if the button is being held this frame
            if (Input.GetButton(button))
            {
                // The button is being held, so perform the actions.
                onButtonHeld.Invoke();

                // Record this time in lastActivate so we can check 
                // when we next come off cooldown
                lastActivate = Time.time;
            }

            // Check if the button has just now been released
            if (Input.GetButtonUp(button))
            {
                // The button has just been released, so perform the actions.
                onButtonReleased.Invoke();

                // Record this time in lastActivate so we can check 
                // when we next come off cooldown
                lastActivate = Time.time;
            }
        }       
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------
}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------