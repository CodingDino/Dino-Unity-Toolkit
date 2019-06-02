// -----------------------------------------------------------------------------
#region File Info - CountObjectsActivator.cs
// -----------------------------------------------------------------------------
// Project:     Dino Unity Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Perform an action when the right number of objects are found
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
#region Component: CountObjectsActivator
// -----------------------------------------------------------------------------
[AddComponentMenu("Dino Toolkit/Activators/CountObjectsActivator")]
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/CountObjectsActivator")]
public class CountObjectsActivator : MonoBehaviour
{
    // -------------------------------------------------------------------------
    #region Editor Variables
    // -------------------------------------------------------------------------

    // -------------------------------------------------------------------------
    [Header("Conditions")]
    // -------------------------------------------------------------------------

    [Tooltip("The tag of the target to check against.")]
    public string targetTag;

    [Tooltip("The number to compare our objects to.")]
    public int comparison;

    // -------------------------------------------------------------------------

    [Header("Actions")]
    [Tooltip("Perform these actions when there are less objects than the comparison value.")]
    public UnityEvent onLessThan;
    [Tooltip("Perform these actions when there are and equal number objects than the comparison value.")]
    public UnityEvent onEqualTo;
    [Tooltip("Perform these actions when there are more objects than the comparison value.")]
    public UnityEvent onGreaterThan;

    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Unity Functions
    // -------------------------------------------------------------------------
    private void Update()
    {
        // Check number of objects with this tag
        int numObjects = GameObject.FindGameObjectsWithTag(targetTag).Length;

        // Perform actions based on comparison

        if (numObjects < comparison)
            onLessThan.Invoke();

        if (numObjects == comparison)
            onEqualTo.Invoke();

        if (numObjects > comparison)
            onGreaterThan.Invoke();
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------
}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------