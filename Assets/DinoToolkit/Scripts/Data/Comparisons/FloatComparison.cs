// -----------------------------------------------------------------------------
#region File Info - FloatComparison.cs
// -----------------------------------------------------------------------------
// Project:     Dino Unity Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Compares two floats and performs actions accordingly
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
#region Component: FloatComparison
// -----------------------------------------------------------------------------
[AddComponentMenu("Dino Toolkit/Comparisons/FloatComparison")]
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/FloatComparison")]
public class FloatComparison : MonoBehaviour
{
    // -------------------------------------------------------------------------
    #region Enum: StandardType
    // -------------------------------------------------------------------------
    public enum StandardType
    {
        DATA,
        RAW
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------



    // -------------------------------------------------------------------------
    #region Editor Variables
    // -------------------------------------------------------------------------

    // -------------------------------------------------------------------------
    [Header("Settings")]
    // -------------------------------------------------------------------------

    [Tooltip("Should our standard value be a Data component, or a raw integer?")]
    public StandardType standardType = StandardType.DATA;
    [Tooltip("The standard FloatData value that we'll be comparing to")]
    [ShowOnEnum("standardType", (int)StandardType.DATA)]
    public FloatData standardData = null;
    [Tooltip("The standard float value that we'll be comparing to")]
    [ShowOnEnum("standardType", (int)StandardType.RAW)]
    public float standardRaw = 0;

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
    private float GetStandard()
    {
        if (standardType == StandardType.DATA)
        {
            return standardData.GetCurrentValue();
        }
        else
        {
            return standardRaw;
        }
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------



    // -------------------------------------------------------------------------
    #region Action Functions
    // -------------------------------------------------------------------------
    public void ActionCompareToTarget(float value)
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
    public void ActionCompareToTarget(FloatData value)
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