using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioHelper : MonoBehaviour {

    public AudioClip ORASP;
    public Animation Player;
	
	void Start ()
    {
        GetComponent<Animator>();
    }
	

	void Update ()
    {
        if (GetComponent<Animation>().IsPlaying("Player"))
        {
            GetComponent<AudioSource>().PlayOneShot(ORASP);
        }
    }
}
