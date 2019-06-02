// -----------------------------------------------------------------------------
#region File Info - IntComparison.cs
// -----------------------------------------------------------------------------
// Project:     Dino Unity Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Compares two integers and performs actions accordingly
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
#region Component: IntComparison
// -----------------------------------------------------------------------------
[AddComponentMenu("Dino Toolkit/Comparisons/IntComparison")]
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/IntComparison")]
public class IntComparison : MonoBehaviour
{

    // -------------------------------------------------------------------------
    #region Editor Variables
    // -------------------------------------------------------------------------

    // -------------------------------------------------------------------------
    [Header("Settings")]
    // -------------------------------------------------------------------------

    [Tooltip("Should our standard value be Data, or a static integer?")]
    public bool isStandardData = true;
    [Tooltip("The standard IntData value that we'll be comparing to")]
    [ShowInInspectorIf("isStandardData", true)]
    public IntData standardData = null;
    [Tooltip("The standard integer value that we'll be comparing to")]
    [ShowInInspectorIf("isStandardData", false)]
    public int standardInt = 0;

    // -------------------------------------------------------------------------
    [Header("Activation Lists")]
    // -------------------------------------------------------------------------

    [Tooltip("Perform these actions when the target value is less than the standard value.")]
    public UnityEvent onLessThan;
    [Tooltip("Perform these actions when the target value is equal to the standard value.")]
    public UnityEvent onEqualTo;
    [Tooltip("Perform these actions when the target value is greater than the standard value.")]
    public UnityEvent onGreaterThan;

    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------



    // -------------------------------------------------------------------------
    #region Internal Functions
    // -------------------------------------------------------------------------
    private int GetStandard()
    {
        if (isStandardData)
        {
            return standardData.GetCurrentValue();
        }
        else
        {
            return standardInt;
        }
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------



    // -------------------------------------------------------------------------
    #region Action Functions
    // -------------------------------------------------------------------------
    public void ActionCompareToTarget(int value)
    {
        // Compare the supplied value to our standard value

        // Check less than
        if (value < GetStandard())
            onLessThan.Invoke();

        // Check equal to
        else if (value == GetStandard())
            onEqualTo.Invoke();

        // Check greater than
        else if (value > GetStandard())
            onGreaterThan.Invoke();
    }
    // -------------------------------------------------------------------------
    public void ActionCompareToTarget(IntData value)
    {
        ActionCompareToTarget(value.GetCurrentValue());
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------
}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------