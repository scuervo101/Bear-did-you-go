using UnityEngine;
using System.Collections;
using Common.FSM;

public class FleeAction : FSMAction
{
    private Transform transform;
    private Vector3 playerPos;
    private GameObject cub;
    private float dist;
    private float moveSpeed;
    private string finishEvent;
    private bool raycast;
    private Vector3 target;

    public FleeAction(FSMState owner) : base(owner)
    {
    }

    public void Init(Transform transform, float moveSpeed, GameObject g)
    {
        this.transform = transform;
        this.moveSpeed = moveSpeed;
        this.cub = g;
    }

    public override void OnEnter()
    {
    }

    public override void OnUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            target = new Vector3(playerPos.x+1, playerPos.y+5, playerPos.z+1);
            transform.position = target;
            GetOwner().SendEvent("ToFollow");
        }
        dist = Vector3.Distance(GameObject.Find("Player").transform.position, cub.transform.position);
        playerPos = GameObject.Find("Player").transform.position;
        Vector3 direction = transform.position - playerPos;
        direction.Normalize();
        if (cub.name == "CubChungus")
        {
            target = new Vector3(playerPos.x, playerPos.y, playerPos.z + 100);
            moveSpeed = 2.0f;
            if (dist > 5.0f)
            {
                moveSpeed = 0.0f;
            }
        }
        if (cub.name == "Brett")
        {
            target = new Vector3(playerPos.x + 100 * direction.x, playerPos.y, playerPos.z + 100);
            moveSpeed = 5.0f;
            if (dist > 8.0f)
            {
                moveSpeed = 0.0f;
            }
        }
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }

    private void Finish()
    {
    }
}
