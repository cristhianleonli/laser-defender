﻿using UnityEngine;

[CreateAssetMenu(fileName = "AudioData", menuName = "Data/AudioData", order = 1)]

public class AudioData : ScriptableObject
{
    public AudioClip hoverSound;
    public AudioClip clickSound;
    public AudioClip backgroundLoop;
}