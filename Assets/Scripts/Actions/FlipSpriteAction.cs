// -----------------------------------------------------------------------------
#region File Info - FlipSpriteAction.cs
// -----------------------------------------------------------------------------
// Project:     Dino Unity Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Conrtols the flip setting for a sprite
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
#region Component: FlipSpriteAction
// -----------------------------------------------------------------------------
[RequireComponent(typeof(SpriteRenderer))]
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/FlipSpriteAction")]
public class FlipSpriteAction : MonoBehaviour
{
    // -------------------------------------------------------------------------
    #region Editor Variables
    // -------------------------------------------------------------------------
    [Tooltip("If true, actions that would normally set flip true will set it to false, and vice versa")]
    public bool invert = false;
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Internal Variables
    // -------------------------------------------------------------------------
    private SpriteRenderer spriteObject = null;
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Unity Functions
    // -------------------------------------------------------------------------
    private void Awake()
    {
        // Store our sprite object for later use
        spriteObject = GetComponent<SpriteRenderer>();
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Action Functions
    // -------------------------------------------------------------------------
    public void ActionSetFlipBool(bool newFlip)
    {
        // Set our chosen parameter to the given value, based on invert
        if (invert == false)
        {
            // We should NOT invert, so just set to the new value 
            spriteObject.flipX = newFlip;
        }
        else
        {
            // We should invert, so set the flip to the opposite of the new value
            spriteObject.flipX = !newFlip;
        }
    }
    // -------------------------------------------------------------------------
    public void ActionSetFlipFloat(float floatFlip)
    {
        // Determine if we should flip or not based on a float value
        // We should only flip the sprite if the floatFlip value is negative
        if (floatFlip >= 0)
        {
            // The float is positive, so do NOT flip the x
            ActionSetFlipBool(false);
        }
        else
        {
            // The float is negative, so DO flip the x
            ActionSetFlipBool(true);
        }
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------