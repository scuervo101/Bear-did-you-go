using UnityEngine;
using System.Collections;
using Common.FSM;

public class MoveAction : FSMAction
{
    private Transform transform;
    private float duration;
    private float moveSpeed;
    private string finishEvent;
    private bool raycast;


    public MoveAction(FSMState owner) : base(owner)
    {
    }

    public void Init(Transform transform, float moveSpeed, float duration, string finishEvent = null)
    {
        this.transform = transform;
        this.duration = duration;
        this.moveSpeed = moveSpeed;
        this.finishEvent = finishEvent;
    }

    public override void OnEnter()
    {

        if (duration <= 0)
        {
            Finish();
            return;
        }

    }

    public override void OnUpdate()
    {
        duration -= Time.deltaTime;

        if (duration <= 0 || raycast)
        {
            Finish();
            return;
        }
        transform.position = transform.position + (transform.forward * moveSpeed);
    }

    private void Finish()
    {
        if (!string.IsNullOrEmpty(finishEvent))
        {
            if (raycast)
                GetOwner().SendEvent("ToTurn");
            else
                GetOwner().SendEvent(finishEvent);
        }

        duration = Random.Range(1, 3);
    }

    private void SetPosition(Vector3 position)
    {
        this.transform.position = position;
    }
}
