// -----------------------------------------------------------------------------
#region File Info - OnCollision2DActivator.cs
// -----------------------------------------------------------------------------
// Project:     Dino Unity Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Perform actions based on 2D collisions
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
#region Component: OnCollision2DActivator
// -----------------------------------------------------------------------------
[RequireComponent(typeof(Collider2D))]
[AddComponentMenu("Dino Toolkit/Activators/OnCollision2DActivator")]
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/OnCollision2DActivator")]
public class OnCollision2DActivator : MonoBehaviour
{
    // -------------------------------------------------------------------------
    #region Custom Unity Event: CollisionAction
    // -------------------------------------------------------------------------
    [System.Serializable]
    public class CollisionAction : UnityEvent<GameObject> { }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Editor Variables
    // -------------------------------------------------------------------------

    // -------------------------------------------------------------------------
    [Header("Conditions")]
    // -------------------------------------------------------------------------

    [Tooltip("Should we only respond to collisions with objects of a certain name?")]
    public bool checkName = false;
    [Tooltip("The name of the target to check against.")]
    [ShowInInspectorIf("checkName")]
    public string targetName;

    [Tooltip("Should we only respond to collisions with objects of a certain tag?")]
    public bool checkTag = false;
    [Tooltip("The tag of the target to check against.")]
    [ShowInInspectorIf("checkTag")]
    public string targetTag;

    [Tooltip("Should we only respond to collisions with objects of a certain layer?")]
    public bool checkLayer = false;
    [Tooltip("The layer of the target to check against.")]
    [ShowInInspectorIf("checkLayer")]
    public string targetLayer;

    // -------------------------------------------------------------------------

    [Header("Activator List")]
    [Tooltip("Perform these actions when the two colliders first touch.")]
    public CollisionAction onCollisionEnterActions;
    [Tooltip("Perform these actions every frame while the two colliders are touching.")]
    public CollisionAction onCollisionStayActions;
    [Tooltip("Perform these actions when the two colliders first separate after having touched.")]
    public CollisionAction onCollisionExitActions;

    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Internal Functions
    // -------------------------------------------------------------------------
    private bool IsCollisionValid(Collision2D collision)
    {
        // Check each of our conditions, if we have them
        // First, assume that this is a valid collision
        bool validCollision = true;

        // Are we colliding with our target name?
        if (checkName == true && targetName != collision.collider.name)
        {
            // We are colliding with something other than our target name
            // so this collision is not valid
            validCollision = false;
        }

        // Are we colliding with our target tag?
        if (checkTag == true && targetTag != collision.collider.tag)
        {
            // We are colliding with something other than our target tag
            // so this collision is not valid
            validCollision = false;
        }

        // Are we colliding with our target layer?
        if (checkLayer == true &&
            targetName != LayerMask.LayerToName(collision.collider.gameObject.layer))
        {
            // We are colliding with something other than our target layer
            // so this collision is not valid
            validCollision = false;
        }

        return validCollision;
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Unity Functions
    // -------------------------------------------------------------------------
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If after all our checks, this was a valid collision...
        if (IsCollisionValid(collision) == true)
        {
            // Inform our listening actions that the collision started
            onCollisionEnterActions.Invoke(collision.collider.gameObject);
        }
    }
    // -------------------------------------------------------------------------
    private void OnCollisionStay2D(Collision2D collision)
    {
        // If after all our checks, this was a valid collision...
        if (IsCollisionValid(collision) == true)
        {
            // Inform our listening actions that the collision continues
            onCollisionStayActions.Invoke(collision.collider.gameObject);
        }
    }
    // -------------------------------------------------------------------------
    private void OnCollisionExit2D(Collision2D collision)
    {
        // If after all our checks, this was a valid collision...
        if (IsCollisionValid(collision) == true)
        {
            // Inform our listening actions that the collision ended
            onCollisionExitActions.Invoke(collision.collider.gameObject);
        }
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------
}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------