using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public bool hiding = false;
    public float speed = 6f;
    public GameObject cam;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;
    private float currStam = 20;
    private float maxStam = 20;
    private float percentStam;
    public GameObject sprintRing;
    public Material sprintRingColor;
    private float stamTimer = 0.0f;

    public GameObject Artio;
    public Texture leftFacing,
                   rightFacing;
    private Renderer text;


    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        playerRigidbody = GetComponent<Rigidbody>();
        text = Artio.GetComponent<MeshRenderer>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.A))
            text.material.SetTexture("_MainTex", leftFacing);

        if (Input.GetKey(KeyCode.D))
            text.material.SetTexture("_MainTex", rightFacing);

        if (!hiding) Move(h, v);
        if (hiding)
            sprintRing.GetComponent<MeshRenderer>().enabled = false;

        if (percentStam == 1.0f)
            stamTimer += Time.deltaTime;

        if (stamTimer > 1.0f)
            sprintRing.GetComponent<MeshRenderer>().enabled = false;
    }

    private void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        if (Input.GetKey(KeyCode.LeftShift) && currStam > 0)
        {
            speed = 4f;
            movement = movement.normalized * speed * Time.deltaTime;
            playerRigidbody.MovePosition(transform.position + movement);
            cam.GetComponent<CameraFollow>().smoothing = 2.0f;

            if (currStam > 0)
                currStam = currStam - .5f;
            percentStam = currStam / maxStam;

            sprintRing.GetComponent<MeshRenderer>().enabled = true;
            stamTimer = 0.0f;
            sprintRing.transform.localScale = new Vector3(percentStam, -0.001071769f, percentStam);
            Color c = new Color((255f * (1 - percentStam)) / 255f, 0, (255f * percentStam) / 255f);
            sprintRingColor.SetColor("_Color", c);
        }
        else
        {
            speed = 2f;
            movement = movement.normalized * speed * Time.deltaTime;
            playerRigidbody.MovePosition(transform.position + movement);
            cam.GetComponent<CameraFollow>().smoothing = 1.0f;
            if(currStam < maxStam && !Input.GetKey(KeyCode.LeftShift))
                currStam = currStam + .5f;
            percentStam = currStam / maxStam;
            sprintRing.transform.localScale = new Vector3(percentStam, -0.001071769f, percentStam);
            Color c = new Color((255f * (1 - percentStam)) / 255f, 0, (255f * percentStam) / 255f);
            sprintRingColor.SetColor("_Color", c);
        }
    }
}
