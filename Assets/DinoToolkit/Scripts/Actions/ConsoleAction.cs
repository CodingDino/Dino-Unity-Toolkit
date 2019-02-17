// -----------------------------------------------------------------------------
#region File Info - ConsoleAction.cs
// -----------------------------------------------------------------------------
// Project:     Dino Unity Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Print a message to Unity's console
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
#region Component: ConsoleAction
// -----------------------------------------------------------------------------
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/ConsoleAction")]
public class ConsoleAction : MonoBehaviour
{


    // -------------------------------------------------------------------------
    #region Action Functions
    // -------------------------------------------------------------------------
    public void ActionPrintLog(string messageToPrint)
    {
        // Use a normal log to print the message
        Debug.Log(messageToPrint);
    }
    // -------------------------------------------------------------------------
    public void ActionPrintWarning(string messageToPrint)
    {
        // Use a warning log to print the message
        Debug.LogWarning(messageToPrint);
    }
    // -------------------------------------------------------------------------
    public void ActionPrintError(string messageToPrint)
    {
        // Use an error log to print the message
        Debug.LogError(messageToPrint);
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------