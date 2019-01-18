// -----------------------------------------------------------------------------
#region File Info - OnTrigger2DActivator.cs
// -----------------------------------------------------------------------------
// Project:     Dino Unity Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Perform actions based on 2D Triggers
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
#region Component: OnTrigger2DActivator
// -----------------------------------------------------------------------------
[RequireComponent(typeof(Collider2D))]
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/OnTrigger2DActivator")]
public class OnTrigger2DActivator : MonoBehaviour
{
    // -------------------------------------------------------------------------
    #region Custom Unity Event: TriggerAction
    // -------------------------------------------------------------------------
    [System.Serializable]
    public class TriggerAction : UnityEvent<GameObject> { }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Editor Variables
    // -------------------------------------------------------------------------

    // -------------------------------------------------------------------------
    [Header("Conditions")]
    // -------------------------------------------------------------------------

    [Tooltip("Should we only respond to triggers with objects of a certain name?")]
    public bool checkName = false;
    [Tooltip("The name of the target to check against.")]
    [ShowInInspectorIf("checkName")]
    public string targetName;

    [Tooltip("Should we only respond to triggers with objects of a certain tag?")]
    public bool checkTag = false;
    [Tooltip("The tag of the target to check against.")]
    [ShowInInspectorIf("checkTag")]
    public string targetTag;

    [Tooltip("Should we only respond to triggers with objects of a certain layer?")]
    public bool checkLayer = false;
    [Tooltip("The layer of the target to check against.")]
    [ShowInInspectorIf("checkLayer")]
    public string targetLayer;

    // -------------------------------------------------------------------------
    [Header("Activator List")]
    // -------------------------------------------------------------------------
    [Tooltip("Perform these actions when the two colliders first touch.")]
    public TriggerAction onTriggerEnterActions;
    [Tooltip("Perform these actions every frame while the two colliders are touching.")]
    public TriggerAction onTriggerStayActions;
    [Tooltip("Perform these actions when the two colliders first separate after having touched.")]
    public TriggerAction onTriggerExitActions;

    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Internal Functions
    // -------------------------------------------------------------------------
    private bool IsTriggerValid(Collider2D otherCollider)
    {
        // Check each of our conditions, if we have them
        // First, assume that this is a valid collision
        bool validCollision = true;

        // Are we colliding with our target name?
        if (checkName == true && targetName != otherCollider.name)
        {
            // We are colliding with something other than our target name
            // so this collision is not valid
            validCollision = false;
        }

        // Are we colliding with our target tag?
        if (checkTag == true && targetTag != otherCollider.tag)
        {
            // We are colliding with something other than our target tag
            // so this collision is not valid
            validCollision = false;
        }

        // Are we colliding with our target layer?
        if (checkLayer == true &&
            targetName != LayerMask.LayerToName(otherCollider.gameObject.layer))
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
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // If after all our checks, this was a valid trigger...
        if (IsTriggerValid(otherCollider) == true)
        {
            // Inform our listening actions that the trigger started
            onTriggerEnterActions.Invoke(otherCollider.gameObject);
        }
    }
    // -------------------------------------------------------------------------
    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        // If after all our checks, this was a valid trigger...
        if (IsTriggerValid(otherCollider) == true)
        {
            // Inform our listening actions that the trigger continues
            onTriggerStayActions.Invoke(otherCollider.gameObject);
        }
    }
    // -------------------------------------------------------------------------
    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        // If after all our checks, this was a valid trigger...
        if (IsTriggerValid(otherCollider) == true)
        {
            // Inform our listening actions that the trigger ended
            onTriggerExitActions.Invoke(otherCollider.gameObject);
        }
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------