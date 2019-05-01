// -----------------------------------------------------------------------------
#region File Info - InputMouseActivator.cs
// -----------------------------------------------------------------------------
// Project:     Dino Unity Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Perform actions when the mouse is clicked
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
#region Component: InputMouseActivator
// -----------------------------------------------------------------------------
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/InputMouseActivator")]
public class InputMouseActivator : MonoBehaviour
{
    // -------------------------------------------------------------------------
    #region Editor Variables
    // -------------------------------------------------------------------------

    // -------------------------------------------------------------------------
    [Header("Conditions")]
    // -------------------------------------------------------------------------

    [Tooltip("If true, the activator will only work if this object is clicked. Otherwise it works wherever the mouse is clicked.")]
    public bool thisObjectOnly = true;

    [Tooltip("Which mouse button to listen for. 0 = left, 1 = right, 2 = middle")]
    public int button = 0;

    [Tooltip("How frequently can this activation happen, in seconds? 0 for no cooldown.")]
    public float cooldown = 0;

    // -------------------------------------------------------------------------

    [Header("Actions")]
    [Tooltip("Perform these actions when the mouse button is first pressed down.")]
    public UnityEvent onButtonPressed;
    [Tooltip("Perform these actions every frame the mouse button is held down.")]
    public UnityEvent onButtonHeld;
    [Tooltip("Perform these actions when the mouse button is released and comes back up.")]
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
        // Only perform generic actions if we aren't restricted to this object
        if (thisObjectOnly == false)
        {
            // Each frame, check if we should perform actions
            // Before we try to perform any actions, check if we are off cooldown
            if (Time.time >= lastActivate + cooldown)
            {
                // We are off cooldown, so check if we should activate based on the type of press style

                // Check if the button has just now been pushed down
                if (Input.GetMouseButtonDown(button))
                {
                    // The button has just been pressed, so perform the actions.
                    onButtonPressed.Invoke();

                    // Record this time in lastActivate so we can check 
                    // when we next come off cooldown
                    lastActivate = Time.time;
                }


                // Check if the button is being held this frame
                if (Input.GetMouseButton(button))
                {
                    // The button is being held, so perform the actions.
                    onButtonHeld.Invoke();

                    // Record this time in lastActivate so we can check 
                    // when we next come off cooldown
                    lastActivate = Time.time;
                }

                // Check if the button has just now been released
                if (Input.GetMouseButtonUp(button))
                {
                    // The button has just been released, so perform the actions.
                    onButtonReleased.Invoke();

                    // Record this time in lastActivate so we can check 
                    // when we next come off cooldown
                    lastActivate = Time.time;
                }
            }
        }

    }
    // -------------------------------------------------------------------------
    private void OnMouseDown()
    {
        // The mouse has been pressed down on our object

        // Only perform actions if we are listening to clicks on this object only
        if (thisObjectOnly == true && enabled)
        {

            // Before we try to perform any actions, check if we are off cooldown
            if (Time.time >= lastActivate + cooldown)
            {
                // We are off cooldown and
                // The button has just been pressed, so perform the actions.
                onButtonPressed.Invoke();

                // Record this time in lastActivate so we can check 
                // when we next come off cooldown
                lastActivate = Time.time;
            }
        }
    }
    // -------------------------------------------------------------------------
    private void OnMouseUpAsButton()
    {
        // The mouse has been released on our object, and was pressed down on 
        // our object originally.

        // Only perform actions if we are listening to clicks on this object only
        if (thisObjectOnly == true && enabled)
        {

            // Before we try to perform any actions, check if we are off cooldown
            if (Time.time >= lastActivate + cooldown)
            {
                // We are off cooldown and
                // The button has just been pressed, so perform the actions.
                onButtonReleased.Invoke();

                // Record this time in lastActivate so we can check 
                // when we next come off cooldown
                lastActivate = Time.time;
            }
        }
    }
    // -------------------------------------------------------------------------
    private void OnMouseOver()
    {
        // The mouse is over our object, if we are holding the button we should
        // trigger actions

        // Only perform actions if we are listening to clicks on this object only
        if (thisObjectOnly == true && enabled)
        {

            // Before we try to perform any actions, check if we are off cooldown
            if (Time.time >= lastActivate + cooldown)
            {
                // We are off cooldown

                // Check if the button is being held this frame
                if (Input.GetMouseButton(button))
                {
                    // The button is being held, so perform the actions.
                    onButtonHeld.Invoke();

                    // Record this time in lastActivate so we can check 
                    // when we next come off cooldown
                    lastActivate = Time.time;
                }
            }
        }

    }
    #endregion
    // -------------------------------------------------------------------------
}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------