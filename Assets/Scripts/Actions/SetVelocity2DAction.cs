// -----------------------------------------------------------------------------
#region File Info - SetVelocity2DAction.cs
// -----------------------------------------------------------------------------
// Project:     Drag N Drop Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Sets a Rigidbody2D's velocity
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
#region Component: SetVelocity2DAction
// -----------------------------------------------------------------------------
[RequireComponent(typeof(Rigidbody2D))]
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/SetVelocity2DAction")]
public class SetVelocity2DAction : MonoBehaviour
{


    // -------------------------------------------------------------------------
    #region Editor Variables
    // -------------------------------------------------------------------------
    [Tooltip("Multiplier used to alter velocity sent from Activators. Use 1 to leave velocities unaltered.")]
    public float speed = 1.0f;
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Internal Variables
    // -------------------------------------------------------------------------
    private Rigidbody2D rigidBody = null;
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Unity Functions
    // -------------------------------------------------------------------------
    private void Start()
    {
        // Get the Rigidbody2D component from our GameObject 
        // and store it for later use
        rigidBody = GetComponent<Rigidbody2D>();
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Action Functions
    // -------------------------------------------------------------------------
    public void ActionSetVelocity(Vector2 newVelocity)
    {
        // Apply the new velocity to our rigidbody
        // Scale by speed value
        rigidBody.velocity = newVelocity * speed;
    }
    // -------------------------------------------------------------------------
    public void ActionSetXVelocity(float newXVelocity)
    {
        // Get the current velocity from our rigidbody, and store it in a vector
        Vector2 newVelocity = rigidBody.velocity;
        // Update the new velocity with the x portion that was passed in
        // Scale by speed value
        newVelocity.x = newXVelocity * speed;
        // Apply the new velocity to our rigidbody
        rigidBody.velocity = newVelocity;
    }
    // -------------------------------------------------------------------------
    public void ActionSetYVelocity(float newYVelocity)
    {
        // Get the current velocity from our rigidbody, and store it in a vector
        Vector2 newVelocity = rigidBody.velocity;
        // Update the new velocity with the y portion that was passed in
        // Scale by speed value
        newVelocity.y = newYVelocity * speed;
        // Apply the new velocity to our rigidbody
        rigidBody.velocity = newVelocity;
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------