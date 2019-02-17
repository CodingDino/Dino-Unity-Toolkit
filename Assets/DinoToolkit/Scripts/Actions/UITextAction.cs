// -----------------------------------------------------------------------------
#region File Info - UITextAction.cs
// -----------------------------------------------------------------------------
// Project:     Dino Unity Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Controls text in the UI
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------


// -----------------------------------------------------------------------------
#region Libraries
// -----------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------


// -----------------------------------------------------------------------------
#region Component: UITextAction
// -----------------------------------------------------------------------------
[RequireComponent(typeof(Text))]
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/UITextAction")]
public class UITextAction : MonoBehaviour
{
    // -------------------------------------------------------------------------
    #region Editor Variables
    // -------------------------------------------------------------------------
    [Tooltip("Should we limit the display of decimals for float values?")]
    public bool limitFloatDecimals = false;
    [Tooltip("Float values will only display this many decimal places")]
    [ShowInInspectorIf("limitFloatDecimals")]
    public int numDecimals = 0;
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------

    // -------------------------------------------------------------------------
    #region Internal Variables
    // -------------------------------------------------------------------------
    private Text textObject = null;
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Unity Functions
    // -------------------------------------------------------------------------
    private void Awake()
    {
        // Store our text object for later use
        textObject = GetComponent<Text>();
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Action Functions
    // -------------------------------------------------------------------------
    public void ActionSetTextString(string newText)
    {
        // Set the text object to use our new string
        textObject.text = newText;
    }
    // -------------------------------------------------------------------------
    public void ActionSetTextInt(int newText)
    {
        // Convert the int to a string using the default method
        textObject.text = newText.ToString();
    }
    // -------------------------------------------------------------------------
    public void ActionSetTextFloat(float newText)
    {
        // Check if we should limit the float's decimal places...
        if (limitFloatDecimals)
        {
            // We should limit them!
            // Convert the float to a string using a special formatting method
            textObject.text = newText.ToString("F" + numDecimals);
        }
        else
        {
            // We should not limit them
            // Convert the float to a string using the default method
            textObject.text = newText.ToString();
        }
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------