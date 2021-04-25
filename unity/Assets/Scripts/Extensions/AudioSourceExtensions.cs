using System;
using System.Collections;

using UnityEngine;

public static class AudioSourceExtensions
{
    public static IEnumerator WaitForSound(this AudioSource audioSource, Action onFinishedAction)
    {
        if (audioSource != default)
        {
            if (audioSource.loop)
            {
                throw new InvalidOperationException("AudioSource will never finish playing, it is set to loop");
            }

            while (audioSource.isPlaying)
            {
                yield return default;
            }

            onFinishedAction();
        }

        yield return default;
    }
}
