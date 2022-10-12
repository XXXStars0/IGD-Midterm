using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    public AudioSource snd1;
    public AudioSource snd2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!snd1.isPlaying&& !snd2.isPlaying && !this.GetComponent<AudioSource>().isPlaying)
        {
            this.GetComponent<AudioSource>().Play();
        }
    }
}
