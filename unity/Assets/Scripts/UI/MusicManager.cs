using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public AudioSource AudioSource1;
    public AudioSource AudioSource2;
    public List<AudioClip> clips;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
        
    //private void ShuffleAudio()
    //{
    //    var newClip = default(AudioClip);

    //    if (clips.Count > 0)
    //    {
    //        newClip = clips[Random.Range(0, clips.Count)];
    //    }

    //    if (newClip != default)
    //    {
    //        if (AudioSource.clip != newClip)
    //        {
    //            AudioSource.clip = newClip;
    //        }

    //        Debug.Log(string.Format("Now Playing: {0} - Duration {1}", newClip.name, newClip.length));

    //        AudioSource.Play();
    //        StartCoroutine(AudioSource.WaitForFinished(ShuffleAudio));
    //    }
    //}
}
