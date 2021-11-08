using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;

public class CutScene : MonoBehaviour
{

    public PlayableDirector cutscene;

    public UnityEvent onPlay;
    public UnityEvent onStop;

    public void Play()
    {
        onPlay.Invoke();
        cutscene.Play();
        Invoke("Stop",(float)cutscene.duration);
    }
    void Stop()
    {
        onStop.Invoke();
    }
   
}
