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
    #region Enum: PressType
    // -------------------------------------------------------------------------
    public enum PressType
    {
        PRESS,
        HOLD,
        RELEASE
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Editor Variables
    // -------------------------------------------------------------------------

    // -------------------------------------------------------------------------
    [Header("Conditions")]
    // -------------------------------------------------------------------------

    [Tooltip("The button the player must press to activate these actions. Button must be set up in InputManager.")]
    public string button;

    [Tooltip("Style for pressing the button:\n" +
             "PRESS - Only activates when button is first pressed down.\n" +
             "HOLD - Activates every frame the button is held down\n" +
             "RELEASE - Only activates when  a button is released.")]
    public PressType pressType;

    [Tooltip("How frequently can this activation happen, in seconds? 0 for no cooldown.")]
    public float cooldown = 0;

    // -------------------------------------------------------------------------

    [Header("")]
    [Tooltip("The action(s) to be performed.")]
    public UnityEvent actions;

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
            // Check which press type we have specified
            switch (pressType)
            {
                // In this case, our press type is PRESS.
                case PressType.PRESS:
                    // Check if the button has just now been pushed down
                    if (Input.GetButtonDown(button))
                    {
                        // The button has just been pressed, so perform the actions.
                        actions.Invoke();

                        // Record this time in lastActivate so we can check 
                        // when we next come off cooldown
                        lastActivate = Time.time;
                    }
                    break;

                // In this case, our press type is PRESS.
                case PressType.HOLD:
                    // Check if the button is being held this frame
                    if (Input.GetButton(button))
                    {
                        // The button is being held, so perform the actions.
                        actions.Invoke();

                        // Record this time in lastActivate so we can check 
                        // when we next come off cooldown
                        lastActivate = Time.time;
                    }
                    break;

                // In this case, our press type is RELEASE.
                case PressType.RELEASE:
                    // Check if the button has just now been released
                    if (Input.GetButtonUp(button))
                    {
                        // The button has just been released, so perform the actions.
                        actions.Invoke();

                        // Record this time in lastActivate so we can check 
                        // when we next come off cooldown
                        lastActivate = Time.time;
                    }
                    break;

                // pressType wasn't any of the cases above...
                default:
                    // Print out an error indicating an incorrect log type was provided.
                    Debug.LogError("ButtonActivator Error: Unrecognised pressType \"" + pressType + "\" provided");
                    break;
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