// -----------------------------------------------------------------------------
#region File Info - RotateAction.cs
// -----------------------------------------------------------------------------
// Project:     Dino Unity Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Rotates an object
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
#region Component: RotateAction
// -----------------------------------------------------------------------------
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/RotateAction")]
public class RotateAction : MonoBehaviour
{



    // -------------------------------------------------------------------------
    #region Action Functions
    // -------------------------------------------------------------------------
    public void ActionSetRotationTo(float degrees)
    {
        transform.rotation = Quaternion.Euler(0, 0, degrees);
    }
    // -------------------------------------------------------------------------
    public void ActionRotateBy(float degrees)
    {
        transform.rotation = transform.rotation * Quaternion.Euler(0, 0, degrees);
    }
    // -------------------------------------------------------------------------
    public void ActionRotateTowardsObjectWithTag(string tagName)
    {
        // Find any object with this tag
        GameObject objectWithTag = GameObject.FindWithTag(tagName);
        // If we found an object...
        if (objectWithTag != null)
        {
            // Rotate towards it
            ActionRotateTowardsObject(objectWithTag);
        }
    }
    // -------------------------------------------------------------------------
    public void ActionRotateTowardsObject(GameObject rotateTowards)
    {
        Vector3 vectorToTarget = rotateTowards.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    // -------------------------------------------------------------------------
    public void ActionRotateTowardMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 vectorToTarget = mousePosition - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------