using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSound : MonoBehaviour
{
    public AudioClip walkSound;

    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal")!=0 || Input.GetAxisRaw("Vertical") != 0)
        {
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(walkSound, vol);
        }
    }
}
