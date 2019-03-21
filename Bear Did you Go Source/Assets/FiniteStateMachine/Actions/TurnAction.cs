using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.FSM;

public class TurnAction : FSMAction {

    private Transform transform;
    private float duration;
    private string finishEvent;
    private Vector3 direction;
    private bool raycast;

    public TurnAction(FSMState owner) : base(owner)
    {
    }

    public void Init(Transform transform, float duration, string finishEvent = null)
    {
        this.transform = transform;
        this.duration = duration;
        this.finishEvent = finishEvent;
        getDirection();
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
        if (duration <= 0)
        {
            Finish();
            return;
        }
        transform.Rotate(direction);
    }

    private void Finish()
    {
        if (!string.IsNullOrEmpty(finishEvent))
        {
            if(raycast)
                GetOwner().SendEvent("ToTurn");
            else
                GetOwner().SendEvent(finishEvent);
        }
        getDirection();
        duration = Random.Range(1, 3);
    }

    private void getDirection(){
        float temp = Random.Range(0, 2);
        direction = (temp < 1) ? Vector3.up : Vector3.down;
    }

}
