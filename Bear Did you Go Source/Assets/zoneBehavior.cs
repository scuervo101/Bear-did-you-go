using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoneBehavior : MonoBehaviour {

    public bool visible = false;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            visible = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (GameObject.Find("Player").GetComponent<PlayerMovement>().hiding)
                visible = false;
            else
                visible = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            visible = false;
    }
}
