// -----------------------------------------------------------------------------
#region File Info - ConsoleLogAction.cs
// -----------------------------------------------------------------------------
// Project:     Drag N Drop Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Print a message to the console log
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
#region Component: ConsoleLogAction
// -----------------------------------------------------------------------------
public class ConsoleLogAction : MonoBehaviour
{

    // -------------------------------------------------------------------------
    #region Enum: LogType
    // -------------------------------------------------------------------------
    public enum LogType 
    {
        INFO,
        WARNING,
        ERROR
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Editor Variables
    // -------------------------------------------------------------------------
    [Tooltip("The type of log to use to print messages to the console.")]
    public LogType logTypeToUse = LogType.INFO;
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Public Functions
    // -------------------------------------------------------------------------
    public void PerformAction(string messageToPrint)
    {
        // Check which log type we have specified
        switch (logTypeToUse)
        {
            // In this case, our log type is INFO.
            case LogType.INFO:
                // Use a normal log to print the message
                Debug.Log(messageToPrint);
                break;

            // In this case, our log type is WARNING.
            case LogType.WARNING:
                // Use a warning log to print the message
                Debug.LogWarning(messageToPrint);
                break;

            // In this case, our log type is ERROR.
            case LogType.ERROR:
                // Use an error log to print the message
                Debug.LogError(messageToPrint);
                break;

            // logTypToUse wasn't any of the cases above...
            default:
                // Print out an error indicating an incorrect log type was provided.
                Debug.LogError("ConsoleAction Error: Unrecognised logTypeToUse \""+logTypeToUse+"\" provided");
                break;
        }
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------
}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------