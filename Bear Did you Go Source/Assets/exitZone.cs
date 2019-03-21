using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class exitZone : MonoBehaviour
{
    public GameObject fade;
    public string target;
    public float fadeTime;
    private bool leave = false;
    private float resetTimer = 0.0f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (leave)
        {
            resetTimer += Time.deltaTime;
            fade.GetComponent<Image>().enabled = true;
            fade.GetComponent<Image>().color = Color.black;
            fade.GetComponent<CanvasGroup>().alpha = 0.0f + (resetTimer / fadeTime);
            if (resetTimer > fadeTime)
                SceneManager.LoadScene(target);
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
