using UnityEngine;
using System.Collections;
using Common.FSM;

public class FollowAction : FSMAction
{
    private Transform transform;
    private GameObject cub;
    private float dist;
    private float moveSpeed;
    private string finishEvent;
    private bool raycast;

    private Renderer text;
    private Texture leftFacing,
               rightFacing;


    public FollowAction(FSMState owner) : base(owner)
    {
    }

    public void Init(Transform transform, float moveSpeed, GameObject g)
    {
        this.transform = transform;
        this.moveSpeed = moveSpeed;
        this.cub = g;

        leftFacing = cub.GetComponent<CubAI>().leftFacing;
        rightFacing = cub.GetComponent<CubAI>().rightFacing;
        if (cub.name == "CubChungus")
        {
            text = GameObject.Find("BearyA").GetComponent<MeshRenderer>();
        }
        if (cub.name == "Brett")
        {
            text = GameObject.Find("BearyB").GetComponent<MeshRenderer>();
        }
    }

public override void OnEnter()
    {
    }

    public override void OnUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            GetOwner().SendEvent("ToFlee");
        }

        if (cub.transform.position.x - GameObject.Find("Player").transform.position.x > 0)
            text.material.SetTexture("_MainTex", leftFacing);
        else
            text.material.SetTexture("_MainTex", rightFacing);

        dist = Vector3.Distance(GameObject.Find("Player").transform.position, cub.transform.position);
        if (dist < 1.5f)
            moveSpeed = 0.0f;
        else
        {
            if (cub.name == "CubChungus")
            {
                moveSpeed = 1.3f;
            }
            if (cub.name == "Brett")
            {
                moveSpeed = 2.0f;
            }
        }
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").transform.position, step);
    }

    private void Finish()
    {
    }
}
