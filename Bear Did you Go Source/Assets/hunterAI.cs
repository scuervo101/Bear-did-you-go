using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hunterAI : MonoBehaviour
{
    public GameObject hunter;
    public GameObject zone;
    public GameObject ex;
    public AudioClip exSound;
    private AudioSource source;
    private bool antiLoop = false;
    private bool inZone;
    private bool gameOver = false;
    public GameObject fade;
    private float resetTimer = 0.0f;

    public Texture MainTexture, ChangeTexture;

    private bool toggle = false;
    private float Timer = 0.0f;
    private Renderer text;
    // Start is called before the first frame update
    void Start()
    {
        text = hunter.GetComponent<Renderer>();
        source = GetComponent<AudioSource>();
        if(this.tag == "Flipped")
            text.material.SetTexture("_MainTex", MainTexture);

    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        inZone = zone.GetComponent<zoneBehavior>().visible;
        if(Timer > 5.0f && toggle == false)
        {
            Timer = 0f;

            text.material.SetTexture("_MainTex", MainTexture);

            toggle = true;
        }
        if (Timer > 5.0f && toggle == true)
        {
            Timer = 0f;

            text.material.SetTexture("_MainTex", ChangeTexture);

            toggle = false;
        }

        if (gameOver)
        {
            resetTimer += Time.deltaTime;
            fade.GetComponent<Image>().enabled = true;
            fade.GetComponent<Image>().color = Color.black;
            fade.GetComponent<CanvasGroup>().alpha = 0.0f + (resetTimer/3.0f);
            if (resetTimer > 3.0f)
                SceneManager.LoadScene("Intro");
        }

        alertSystem(toggle);
    }

    private void alertSystem(bool tog)
    {
        if(tog == true)
        {
            if (inZone)
            {
                Debug.Log("SPOTTED");
                ex.GetComponent<MeshRenderer>().enabled = true;
                if (!antiLoop)
                {
                    source.PlayOneShot(exSound, 1F);
                    antiLoop = true;
                    gameOver = true;
                }
            }
        }
    }
}
