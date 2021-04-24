using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCache 
{
    readonly Dictionary<String, Sprite> spriteCache = new Dictionary<String, Sprite>();
    readonly Dictionary<String, AudioClip> audioClipCache = new Dictionary<String, AudioClip>();

    public Sprite GetSprit(string path)
    {
        if (!spriteCache.TryGetValue(path, out Sprite sprite))
        {
            sprite = Resources.Load<Sprite>(path);

            if (sprite != default)
            {
                spriteCache[path] = sprite;
            }
        }
        return sprite;
    }

    public AudioClip GetAudioClip(String path)
    {
        if (!audioClipCache.TryGetValue(path, out AudioClip audioClip))
        {
            audioClip = Resources.Load<AudioClip>(path);

            if (audioClip != default)
            {
                audioClipCache[path] = audioClip;
            }
        }

        return audioClip;
    }

}
