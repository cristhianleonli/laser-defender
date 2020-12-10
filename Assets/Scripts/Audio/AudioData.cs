﻿using UnityEngine;

[CreateAssetMenu(fileName = "AudioData", menuName = "Data/AudioData", order = 1)]

public class AudioData : ScriptableObject
{
    public AudioClip hoverSound;
    public AudioClip clickSound;
    public AudioClip openLevelSound;
    public AudioClip backgroundLoop;

    public AudioClip emptyClickSound;
    public AudioClip closeLevelSound;
    public AudioClip playerLaser;
}