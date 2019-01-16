// -----------------------------------------------------------------------------
#region File Info - FloatData.cs
// -----------------------------------------------------------------------------
// Project:     Dino Unity Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Storage for a mumerical value
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
#region Component: FloatData
// -----------------------------------------------------------------------------
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/FloatData")]
public class FloatData : MonoBehaviour
{
    // -------------------------------------------------------------------------
    #region Custom Unity Event: FloatDataAction
    // -------------------------------------------------------------------------
    [System.Serializable]
    public class FloatDataAction : UnityEvent<float> { }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Editor Variables
    // -------------------------------------------------------------------------

    // -------------------------------------------------------------------------
    [Header("Settings")]
    // -------------------------------------------------------------------------
    [Tooltip("The timer initially starts at this value")]
    public float startingValue = 0f;
    [Tooltip("Is there a minimum time for this timer?")]
    public bool hasMinValue = true;
    [Tooltip("The timer won't go lower than this minimum value")]
    [ShowInInspectorIf("hasMinValue")]
    public float minValue = 0f;
    [Tooltip("Is there a maximum time for this timer?")]
    public bool hasMaxValue = false;
    [Tooltip("The timer won't go higher than this maximum value")]
    [ShowInInspectorIf("hasMaxValue")]
    public float maxValue = 0f;
    [Tooltip("What ID should this value be saved under? This must be UNIQUE " +
    	"- any shared IDs will override eachother when saving.")]
    public string saveID = "";


    // -------------------------------------------------------------------------

    [Header("Actions")]
    [Tooltip("Perform these actions when the value changes. " +
             "Also passes along the value it was changed to.")]
    public FloatDataAction onValueChange;
    [Tooltip("Perform these actions when the timer reaches its max" +
             "Also passes along the value it was changed to.")]
    public FloatDataAction onValueMax;
    [Tooltip("Perform these actions when the timer reaches its min" +
             "Also passes along the value it was changed to.")]
    public FloatDataAction onValueMin;


    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Internal Variables
    // -------------------------------------------------------------------------
    private float currentValue = 0f;
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Unity Functions
    // -------------------------------------------------------------------------
    private void Awake()
    {
        // Set our initial value
        currentValue = startingValue;
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Action Functions
    // -------------------------------------------------------------------------
    public void ActionResetValue()
    {
        // Reset the value, but don't stop it
        currentValue = startingValue;
    }
    // -------------------------------------------------------------------------
    public void ActionSetValue(float newValue)
    {
        // Check if the we have a max value, 
        // and if the new value is bigger than our max
        if (hasMaxValue && newValue >= maxValue)
        {
            // The new value is bigger than our max
            // Check if we were already at the max value
            if (currentValue < maxValue)
            {
                // We were NOT already at our max value
                // Set our current value to be the max now
                currentValue = maxValue;
                // Perform any actions for hitting the max value
                onValueMax.Invoke(currentValue);
                // Also perform actions for changing the value
                onValueChange.Invoke(currentValue);
            }
        }

        // Check if we have a min value, 
        // and if the new value is smaller than our min
        else if (hasMinValue && newValue <= minValue)
        {
            // The new value is smaller than our min
            // Check if we were already at the min value
            if (currentValue > minValue)
            {
                // We were NOT already at our min value
                // Set our current value to be the min now
                currentValue = minValue;
                // Perform any actions for hitting the min value
                onValueMin.Invoke(currentValue);
                // Also perform actions for changing the value
                onValueChange.Invoke(currentValue);
            }
        }

        // We are not at max or min, so change value normally
        else
        {
            // Check if these values are actually different
            if (currentValue != newValue)
            {
                // Set our current value to the new value
                currentValue = newValue;

                // Perform actions for changing the value
                onValueChange.Invoke(currentValue);
            }
        }
    }
    // -------------------------------------------------------------------------
    public void ActionAddValue(float toAdd)
    {
        // Use our ActionSetValue function to do all the checking and callbacks
        ActionSetValue(currentValue + toAdd);
    }
    // -------------------------------------------------------------------------
    public void ActionSaveValue()
    {
        // Do we have a valid save id?
        if (saveID != "")
        {
            // We have a valid save id
            // Save the current value
            PlayerPrefs.SetFloat(saveID, currentValue);
        }
        else
        {
            // We don't have a valid ID, print a warning
            Debug.LogWarning("FloatData: Attempt to save value with invalid " +
            	"save ID.");
        }
    }
    // -------------------------------------------------------------------------
    public void ActionLoadValue()
    {
        // Do we have a valid save id?
        if (saveID != "")
        {
            // We have a valid save id
            // Load the value and store it in our current value
            currentValue = PlayerPrefs.GetFloat(saveID, currentValue);
        }
        else
        {
            // We don't have a valid ID, print a warning
            Debug.LogWarning("FloatData: Attempt to load value with invalid " +
            	"save ID.");
        }
    }
    // -------------------------------------------------------------------------
    public void ActionClearSavedValue()
    {
        // Do we have a valid save id?
        if (saveID != "")
        {
            // We have a valid save id
            // Delete the saved data for this id
            PlayerPrefs.DeleteKey(saveID);
        }
        else
        {
            // We don't have a valid ID, print a warning
            Debug.LogWarning("FloatData: Attempt to clear saved value with " +
            	"invalid save ID.");
        }
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------