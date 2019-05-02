// -----------------------------------------------------------------------------
#region File Info - TimerAction.cs
// -----------------------------------------------------------------------------
// Project:     Dino Unity Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Keeps track of time, counting up or down
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
#region Component: TimerAction
// -----------------------------------------------------------------------------
[RequireComponent(typeof(FloatData))]
[AddComponentMenu("Dino Toolkit/Actions/TimerAction")]
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/TimerAction")]
public class TimerAction : MonoBehaviour
{
    // -------------------------------------------------------------------------
    #region Count Mode
    // -------------------------------------------------------------------------
    public enum CountMode
    {
        COUNT_UP,
        COUNT_DOWN
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Editor Variables
    // -------------------------------------------------------------------------
    [Tooltip("Should the timer count up or count down?")]
    public CountMode countMode = CountMode.COUNT_UP;

    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Internal Variables
    // -------------------------------------------------------------------------
    private bool timerRunning = false;
    private FloatData timerData = null;
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Unity Functions
    // -------------------------------------------------------------------------
    private void Awake()
    {
        timerData = GetComponent<FloatData>();
    }
    // -------------------------------------------------------------------------
    private void Update()
    {
        // If our time is running...
        if (timerRunning == true)
        {
            // The timer is running, we should change our time value
            // Are we counting up?
            if (countMode == CountMode.COUNT_UP)
            {
                // We're counting up, so add to our time value
                // We add Time.deltaTime, the amount of time passed since
                timerData.ActionAddValue(Time.deltaTime);
            }
            // Or, are we counting down?
            else if (countMode == CountMode.COUNT_DOWN)
            {
                // We're counting down, so subtract from our time value
                // We subtract Time.deltaTime, the amount of time passed since
                // (Adding a negative value is the same as subtracting it)
                timerData.ActionAddValue(-Time.deltaTime);
            }

        }
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Action Functions
    // -------------------------------------------------------------------------
    public void ActionStartTimer()
    {
        // Set the timer as running
        timerRunning = true;
    }
    // -------------------------------------------------------------------------
    public void ActionStopTimer()
    {
        // Set the timer as not running
        timerRunning = false;
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------