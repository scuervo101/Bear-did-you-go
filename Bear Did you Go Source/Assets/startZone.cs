using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class startZone : MonoBehaviour
{
    public GameObject fade;
    private bool leave = false;
    private bool antiRepeat = true;
    private float resetTimer = 0.0f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (leave && antiRepeat)
        {
            resetTimer += Time.deltaTime;
            fade.GetComponent<Image>().enabled = true;
            fade.GetComponent<Image>().color = Color.black;
            fade.GetComponent<CanvasGroup>().alpha = 1.0f - (resetTimer / 2.5f);
            if (resetTimer > 2.5f)
                antiRepeat = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            leave = true;
        }
    }
}
