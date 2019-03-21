using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeApple : MonoBehaviour
{

    public GameObject AppleA;
    public GameObject AppleB;
    // Start is called before the first frame update

    private float timer = 0.0f;

    private bool Empty = false;
    private int Num = 2;
    private int ate = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log(timer);

        if (timer > 10.0f)
            timer = 0;
    }

    private void OnTriggerEnter(Collider other)
    {

        /*if(Empty != true && timer > 1.0f)
        {
            var val = (int)Random.Range(0, 2);
            if (val == 0)
            {
                
            }
            else if(val == 1)
            {
                Instantiate(Apple, new Vector3(-4.3f, 1.06f, -4.02f), Quaternion.identity);
            }
            else if (val == 2)
            {
                Instantiate(Apple, new Vector3(-3.91f, 1.96f, -4.02f), Quaternion.identity);
            }
            ate++;
        }*/
        if(Empty != true && timer > 1.0f)
        {
            ate++;
            if (ate == 2)
            {
                AppleA.GetComponent<Rigidbody>().useGravity = true;
                //GameObject goapple = GameObject.Find("AppleInTree (1)");
                //Instantiate(Apple, goapple.transform.position, Quaternion.identity);
                //goapple.SetActive(false);
            }
            if (ate == 1)
            {
                AppleB.GetComponent<Rigidbody>().useGravity = true;
                //GameObject goapple = GameObject.Find("AppleInTree");
                //Debug.Log(goapple.transform.position);
                //Instantiate(Apple, goapple.transform.position, Quaternion.identity);
                //goapple.SetActive(false);
            }
            
        }

        timer = 0.0f;
        
            
        if (!(ate < Num))
            Empty = true;
        
    }

}
