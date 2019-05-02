// -----------------------------------------------------------------------------
#region File Info - MoveToAction.cs
// -----------------------------------------------------------------------------
// Project:     Dino Unity Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Sets a Rigidbody2D's velocity to move toward a target
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
#region Component: MoveToAction
// -----------------------------------------------------------------------------
[RequireComponent(typeof(Rigidbody2D))]
[AddComponentMenu("Dino Toolkit/Actions/MoveToAction")]
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/MoveToAction")]
public class MoveToAction : MonoBehaviour
{


    // -------------------------------------------------------------------------
    #region Editor Variables
    // -------------------------------------------------------------------------
    [Tooltip("Whether to move to the target instantly or not.")]
    public bool instant = false;
    [Tooltip("Multiplier used to alter velocity sent from Activators. Use 1 to leave velocities unaltered.")]
    [ShowInInspectorIf("instant", false)]
    public float speed = 1.0f;
    [Tooltip("Whether to stop when we reach our target, or keep moving / following.")]
    public bool stopOnArrival = true;
    [Tooltip("When we reach within this distance of the target, we will stop. Keep slightly above 0.")]
    [ShowInInspectorIf("stopOnArrival")]
    public float arrivalDistance = 0.1f;
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Target Type
    // -------------------------------------------------------------------------
    private enum Target
    {
        NONE, POINT, OBJECT, MOUSE
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Internal Variables
    // -------------------------------------------------------------------------
    private Rigidbody2D rigidBody = null;
    private Vector3 targetPoint = Vector3.zero;
    private GameObject targetObject = null;
    private Target targetType = Target.NONE;
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Unity Functions
    // -------------------------------------------------------------------------
    private void Awake()
    {
        // Get the Rigidbody2D component from our GameObject 
        // and store it for later use
        rigidBody = GetComponent<Rigidbody2D>();
    }
    // -------------------------------------------------------------------------
    private void FixedUpdate()
    {
        // Move toward our target
        // based on possible target types we might have
        switch(targetType)
        {
            case Target.NONE:
                {
                    // do nothing
                    break;
                }

            case Target.POINT:
                {
                    // move toward the point
                    Vector3 direction = (targetPoint - transform.position).normalized;
                    rigidBody.velocity = direction * speed;

                    break;
                }

            case Target.OBJECT:
                {
                    // move toward the point
                    Vector3 objectPosition = targetObject.transform.position;
                    Vector3 direction = (objectPosition - transform.position).normalized;
                    rigidBody.velocity = direction * speed;

                    break;
                }

            case Target.MOUSE:
                {
                    // move toward the mouse
                    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector3 direction = (mousePosition - transform.position).normalized;
                    rigidBody.velocity = direction * speed;

                    break;
                }

            default:
                {
                    // do nothing
                    break;
                }
        }
    }
    // -------------------------------------------------------------------------
    private void LateUpdate()
    {
        // Check if we arrived at our location
        // based on possible target types we might have
        switch (targetType)
        {
            case Target.NONE:
                {
                    // do nothing
                    break;
                }

            case Target.POINT:
                {
                    // Calculate distance to target
                    float distance = (targetPoint - transform.position).magnitude;
                    // If the distance is less than our arrival distance, then we arrived
                    if (stopOnArrival && distance <= arrivalDistance)
                    {
                        // set target type to none to stop movement
                        targetType = Target.NONE;
                        rigidBody.velocity = Vector2.zero;
                    }

                    break;
                }

            case Target.OBJECT:
                {
                    // Calculate distance to target
                    Vector3 objectPosition = targetObject.transform.position;
                    float distance = (objectPosition - transform.position).magnitude;
                    // If the distance is less than our arrival distance, then we arrived
                    if (stopOnArrival && distance <= arrivalDistance)
                    {
                        // set target type to none to stop movement
                        targetType = Target.NONE;
                        rigidBody.velocity = Vector2.zero;
                    }

                    break;
                }

            case Target.MOUSE:
                {
                    // Calculate distance to target
                    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    float distance = (mousePosition - transform.position).magnitude;
                    // If the distance is less than our arrival distance, then we arrived
                    if (stopOnArrival && distance <= arrivalDistance)
                    {
                        // set target type to none to stop movement
                        targetType = Target.NONE;
                        rigidBody.velocity = Vector2.zero;
                    }
                    break;
                }

            default:
                {
                    // do nothing
                    break;
                }
        }
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Action Functions
    // -------------------------------------------------------------------------
    public void ActionMoveToPoint(Vector2 newTargetPoint)
    {
        // Check if we are in instant mode
        if (instant == true)
        {
            // Move instantly to the new point
            transform.position = newTargetPoint;
        }
        else
        {
            // Set up the target to move to over time
            targetType = Target.POINT;
            targetPoint = newTargetPoint;
        }
    }
    // -------------------------------------------------------------------------
    public void ActionMoveToCurrentObjectWithTagPoint(string tagName)
    {
        // Find any object with this tag
        GameObject objectWithTag = GameObject.FindWithTag(tagName);
        // If we found an object...
        if (objectWithTag != null)
        {
            // Move to it
            ActionMoveToCurrentObjectPoint(objectWithTag);
        }
    }
    // -------------------------------------------------------------------------
    public void ActionMoveToCurrentObjectPoint(GameObject newTargetObject)
    {
        ActionMoveToPoint(newTargetObject.transform.position);
    }
    // -------------------------------------------------------------------------
    public void ActionFollowObjectWithTag(string tagName)
    {
        // Find any object with this tag
        GameObject objectWithTag = GameObject.FindWithTag(tagName);
        // If we found an object...
        if (objectWithTag != null)
        {
            // Follow it
            ActionFollowObject(objectWithTag);
        }
    }
    // -------------------------------------------------------------------------
    public void ActionFollowObject(GameObject newTargetObject)
    {
        // Check if we are in instant mode
        if (instant == true)
        {
            // Move instantly to the new point
            transform.position = newTargetObject.transform.position;
        }
        else
        {
            // Set up the target to move to over time
            targetType = Target.OBJECT;
            targetObject = newTargetObject;
        }
    }
    // -------------------------------------------------------------------------
    public void ActionMoveToCurrentMousePoint()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ActionMoveToPoint(mousePosition);
    }
    // -------------------------------------------------------------------------
    public void ActionFollowMouse()
    {
        // Check if we are in instant mode
        if (instant == true)
        {
            // Move instantly to the new point
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition;
        }
        else
        {
            // Set up the target to move to over time
            targetType = Target.MOUSE;
        }
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------