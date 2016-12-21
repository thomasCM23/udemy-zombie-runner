using UnityEngine;
using System.Collections;

public class RadioSystem : MonoBehaviour {
    AudioSource aSource;
    
    public AudioClip callHeli;
    public AudioClip replyHeli;
    // Use this for initialization
    void Start ()
    {
        aSource = GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMakeInitialHeliCall()
    {
        aSource.clip = callHeli;
        aSource.Play();
        Invoke("OnInitialCallReply", callHeli.length + 1.5f);
    }
    void OnInitialCallReply()
    {
        aSource.clip = replyHeli;
        aSource.Play();
        BroadcastMessage("OnDispatchHelicopter");
    }
}
