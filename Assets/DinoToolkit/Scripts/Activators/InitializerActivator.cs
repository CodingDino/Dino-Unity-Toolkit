// -----------------------------------------------------------------------------
#region File Info - InitializerActivator.cs
// -----------------------------------------------------------------------------
// Project:     Dino Unity Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Perform actions when Unity initialization functions are called
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
#region Component: InitializerActivator
// -----------------------------------------------------------------------------
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/InitializerActivator")]
public class InitializerActivator : MonoBehaviour
{


    // -------------------------------------------------------------------------
    #region Editor Variables
    // -------------------------------------------------------------------------
    [Tooltip("Perform these actions once when the GameObject is first created.")]
    public UnityEvent onAwake;
    [Tooltip("Perform these actions every time this component or its GameObject are enabled.")]
    public UnityEvent onEnable;
    [Tooltip("Perform these actions once when the GameObject is about to enter it's first Update loop.")]
    public UnityEvent onStart;
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Unity Functions
    // -------------------------------------------------------------------------
    private void Awake()
    {
        // Perform Awake actions
        onAwake.Invoke();
    }
    // -------------------------------------------------------------------------
    private void OnEnable()
    {
        // Perform OnEnable actions
        onEnable.Invoke();
    }
    // -------------------------------------------------------------------------
    private void Start()
    {
        // Perform Start actions
        onStart.Invoke();
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------
}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------