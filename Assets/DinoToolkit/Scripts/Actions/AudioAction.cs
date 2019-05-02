﻿// -----------------------------------------------------------------------------
#region File Info - AudioAction.cs
// -----------------------------------------------------------------------------
// Project:     Dino Unity Toolkit
// Created:     Sarah Herzog 2019
// Purpose:     Controls playback for an audio source
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
#region Component: AudioAction
// -----------------------------------------------------------------------------
[RequireComponent(typeof(AudioSource))]
[AddComponentMenu("Dino Toolkit/Actions/AudioAction")]
[HelpURL("https://github.com/CodingDino/FifeCollege-Unity-DragNDrop/wiki/AudioAction")]
public class AudioAction : MonoBehaviour
{


    // -------------------------------------------------------------------------
    #region Internal Variables
    // -------------------------------------------------------------------------
    private AudioSource audioObject = null;
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Unity Functions
    // -------------------------------------------------------------------------
    private void Awake()
    {
        // Store our audio object for later use
        audioObject = GetComponent<AudioSource>();
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    #region Action Functions
    // -------------------------------------------------------------------------
    public void ActionPlayAudio()
    {
        // Tell the audio to play
        audioObject.Play();
    }
    // -------------------------------------------------------------------------
    public void ActionStopAudio()
    {
        // Tell the audio to stop
        audioObject.Stop();
    }
    // -------------------------------------------------------------------------
    public void ActionPauseAudio()
    {
        // Tell the audio to pause
        audioObject.Pause();
    }
    // -------------------------------------------------------------------------
    public void ActionPlayOneShot(AudioClip clipToPlay)
    {
        // Tell the audio to play a particular clip
        audioObject.PlayOneShot(clipToPlay);
    }
    // -------------------------------------------------------------------------
    #endregion
    // -------------------------------------------------------------------------


}
// -----------------------------------------------------------------------------
#endregion
// -----------------------------------------------------------------------------