// -----------------------------------------------------------------------------
#region File Info - DecommissionActivator.cs
// -----------------------------------------------------------------------------
// Project:     Dino Unity Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Perform actions when Unity decommission functions are called
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------


// -----------------------------------------------------------------------------
#region Libraries
// -----------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------


// -----------------------------------------------------------------------------
#region Component: DecommissionActivator
// -----------------------------------------------------------------------------
[AddComponentMenu("Dino Toolkit/Activators/DecommissionActivator")]
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/DecommissionActivator")]
public class DecommissionActivator : MonoBehaviour
{

    // -------------------------------------------------------------------------
    #region Editor Variables
    // -------------------------------------------------------------------------
    [Tooltip("Perform these actions once when the GameObject is being disabled or destroyed.")]
    public UnityEvent onDisable;
    [Tooltip("Perform these actions once when the GameObject is being destroyed.")]
    public UnityEvent onDestroy;
    [Tooltip("Perform these actions once when the scene is being unloaded.")]
    public UnityEvent onSceneUnloaded;
    [Tooltip("Perform these actions once when the game quits.")]
    public UnityEvent onApplicationQuit;
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Unity Functions
    // -------------------------------------------------------------------------
    public void Start()
    {
        SceneManager.sceneLoaded += OnSceneUnloaded;
        Debug.Log("DecommissionActivator.Start()");
    }
    // -------------------------------------------------------------------------
    private void OnDisable()
    {
        onDisable.Invoke();
        Debug.Log("DecommissionActivator.OnDisable()");
    }
    // -------------------------------------------------------------------------
    private void OnDestroy()
    {
        onDestroy.Invoke();
        Debug.Log("DecommissionActivator.OnDestroy()");
    }
    // -------------------------------------------------------------------------
    private void OnSceneUnloaded(Scene  current, LoadSceneMode mode)
    {
        onSceneUnloaded.Invoke();
        Debug.Log("DecommissionActivator.OnSceneUnloaded()");
    }
    // -------------------------------------------------------------------------
    private void OnApplicationQuit()
    {
        onApplicationQuit.Invoke();
        Debug.Log("DecommissionActivator.OnApplicationQuit()");
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------
}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------