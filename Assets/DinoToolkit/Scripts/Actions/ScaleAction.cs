// -----------------------------------------------------------------------------
#region File Info - ScaleAction.cs
// -----------------------------------------------------------------------------
// Project:     Dino Unity Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Scales an object
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
#region Component: ScaleAction
// -----------------------------------------------------------------------------
[AddComponentMenu("Dino Toolkit/Actions/ScaleAction")]
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/ScaleAction")]
public class ScaleAction : MonoBehaviour
{
    // -------------------------------------------------------------------------
    #region Action Functions
    // -------------------------------------------------------------------------
    public void ActionSetScaleX(float scaleX)
    {
        transform.localScale = new Vector3( scaleX,
                                            transform.localScale.y,
                                            transform.localScale.z);
    }
    // -------------------------------------------------------------------------
    public void ActionSetScaleY(float scaleY)
    {
        transform.localScale = new Vector3( transform.localScale.x,
                                            scaleY,
                                            transform.localScale.z);
    }
    // -------------------------------------------------------------------------
    public void ActionScaleXBy(float scaleX)
    {
        transform.localScale = new Vector3( transform.localScale.z * scaleX,
                                            transform.localScale.y,
                                            transform.localScale.z);
    }
    // -------------------------------------------------------------------------
    public void ActionScaleYBy(float scaleY)
    {
        transform.localScale = new Vector3( transform.localScale.x,
                                            transform.localScale.y * scaleY,
                                            transform.localScale.z);
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------
}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------