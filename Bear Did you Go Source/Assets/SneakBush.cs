using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneakBush : MonoBehaviour
{
    
    public GameObject BushPlane;
    public Texture MainTexture, ChangeTexture;
    public MeshRenderer playersMesh;

    public bool inBush = false;

    private GameObject player;
    private bool pressing = false;
    private Renderer child;

    // Start is called before the first frame update
    void Start()
    {
        var boxCollider = gameObject.GetComponent<BoxCollider>();
        child = BushPlane.GetComponentInChildren<Renderer>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            pressing = true;
        }
        else if (Input.GetKeyDown("d"))
        {
            pressing = true;
        }
        else if (Input.GetKeyDown("a"))
        {
            pressing = true;
        }
        else if (Input.GetKeyDown("s"))
        {
            pressing = true;
        }
        else
        {
            pressing = false;
        }

        if (inBush == true && pressing == true)
            fixBush();
    }

    private void fixBush()
    {
        playersMesh.enabled = true;

        child.material.SetTexture("_MainTex", MainTexture);

        player.GetComponent<PlayerMovement>().hiding = false;

        inBush = false;
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.transform.parent.gameObject.name == "Player")
        {
            playersMesh.enabled = false;

            player.GetComponent<PlayerMovement>().hiding = true;

            child.material.SetTexture("_MainTex", ChangeTexture);

            inBush = true;
        }
        
        /*Rigidbody rig = player.GetComponent<Rigidbody>();
        rig.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        */

    }
}
