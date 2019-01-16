// -----------------------------------------------------------------------------
#region File Info - ApplyForce2DAction.cs
// -----------------------------------------------------------------------------
// Project:     Dino Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Applies a force to a Rigidbody2D
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
#region Component: ApplyForce2DAction
// -----------------------------------------------------------------------------
[RequireComponent(typeof(Rigidbody2D))]
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/ApplyForce2DAction")]
public class ApplyForce2DAction : MonoBehaviour
{


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
    public void ActionApplyForce(Vector2 forceToApply)
    {
        // Apply the force to our rigidBody
        rigidBody.AddForce(forceToApply);
    }
    // -------------------------------------------------------------------------
    public void ActionApplyXForce(float xForceToApply)
    {
        // Start with a zero vector
        Vector2 forceToApply = Vector2.zero;
        // Set our x force
        forceToApply.x = xForceToApply;
        // Apply the force to our rigidBody
        rigidBody.AddForce(forceToApply);
    }
    // -------------------------------------------------------------------------
    public void ActionApplyYForce(float yForceToApply)
    {
        // Start with a zero vector
        Vector2 forceToApply = Vector2.zero;
        // Set our y force
        forceToApply.y = yForceToApply;
        // Apply the force to our rigidBody
        rigidBody.AddForce(forceToApply);
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------