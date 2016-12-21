using UnityEngine;
using System.Collections;

public class InnerVoice : MonoBehaviour {

    AudioSource aSource;

    public AudioClip whatHappend;
    public AudioClip goodlandingArea;

    // Use this for initialization
    void Start ()
    {
        aSource = GetComponent<AudioSource>();
        aSource.clip = whatHappend;
        aSource.Play();
	}
    void OnFindClearArea()
    {
        aSource.clip = goodlandingArea;
        aSource.Play();
        Invoke("CallHeli", goodlandingArea.length + 1.5f);
    }
    void CallHeli()
    {
        SendMessageUpwards("OnMakeInitialHeliCall");
    }
}
