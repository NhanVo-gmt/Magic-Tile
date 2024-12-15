using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundClipType
{
    Click
}

[Serializable]
public class SoundClip
{
    public SoundClipType soundClipType;
    public AudioClip     clip;
}

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource     source;
    [SerializeField] private List<SoundClip> soundClips = new();

    public static AudioSource                          Source;
    public static Dictionary<SoundClipType, SoundClip> TypeToClips = new();

    private void Awake()
    {
        Source = source;

        foreach (SoundClip soundClip in soundClips)
        {
            TypeToClips.Add(soundClip.soundClipType, soundClip);
        }
    }

    public static void PlayOneShot(SoundClipType soundClipType)
    {
        Source.PlayOneShot(TypeToClips[soundClipType].clip);
    }
}
