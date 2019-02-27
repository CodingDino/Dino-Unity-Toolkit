// -----------------------------------------------------------------------------
#region File Info - AnimationAction.cs
// -----------------------------------------------------------------------------
// Project:     Dino Unity Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Conrtols the parameters of an animator component
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
#region Component: AnimationAction
// -----------------------------------------------------------------------------
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/AnimationAction")]
public class AnimationAction : MonoBehaviour
{

    // -------------------------------------------------------------------------
    #region Editor Variables
    // -------------------------------------------------------------------------
    [Tooltip("The parameter that will be set. Can be changed via action.")]
    public string parameterName = "";
    [Tooltip("Should we use an animator on a different GameObject other than this one?")]
    public bool useDifferentAnimator = false;
    [Tooltip("The animator that will be used.")]
    [ShowInInspectorIf("useDifferentAnimator")]
    public Animator animatorObject = null;
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Unity Functions
    // -------------------------------------------------------------------------
    private void Awake()
    {
        // If we are NOT using a different animator...
        if (useDifferentAnimator == false)
        {
            // Store our animator for later use
            animatorObject = GetComponent<Animator>();
        }
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Action Functions
    // -------------------------------------------------------------------------
    public void ActionSetParameterName(string newParameter)
    {
        // Change which parameter the next action will modify
        parameterName = newParameter;
    }
    // -------------------------------------------------------------------------
    public void ActionSetFloatParameter(float newValue)
    {
        // Set our chosen parameter to the given value
        animatorObject.SetFloat(parameterName, newValue);
    }
    // -------------------------------------------------------------------------
    public void ActionSetIntParameter(int newValue)
    {
        // Set our chosen parameter to the given value
        animatorObject.SetInteger(parameterName, newValue);
    }
    // -------------------------------------------------------------------------
    public void ActionSetBoolParameter(bool newValue)
    {
        // Set our chosen parameter to the given value
        animatorObject.SetBool(parameterName, newValue);
    }
    // -------------------------------------------------------------------------
    public void ActionSetTriggerParapeter()
    {
        // Set our chosen parameter to the given value
        animatorObject.SetTrigger(parameterName);
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------