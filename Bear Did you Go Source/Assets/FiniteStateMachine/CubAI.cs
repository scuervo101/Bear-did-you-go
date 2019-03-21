using UnityEngine;
using System.Collections;
using Common.FSM;

public class CubAI : MonoBehaviour
{
    public bool raycast;
    public float dist;

    public Texture leftFacing,
               rightFacing;

    private FSM fsm;
    private FSMState FollowState;
    private FSMState FleeState;

    private FollowAction FollowAction;
    private FleeAction FleeAction;

    private void Start()
    {
        fsm = new FSM("Cub AI");
        FleeState = fsm.AddState("FleeState");
        FollowState = fsm.AddState("FollowState");

        FleeAction = new FleeAction(FleeState);
        FollowAction = new FollowAction(FollowState);

        FollowState.AddAction(FollowAction);
        FleeState.AddAction(FleeAction);

        FollowState.AddTransition("ToFlee", FleeState);
        FleeState.AddTransition("ToFollow", FollowState);

        FollowAction.Init(this.transform, .1f, gameObject);
        FleeAction.Init(this.transform, .1f, gameObject);

        fsm.Start("FollowState");
    }

    private void Update()
    {
        fsm.Update();
        dist = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
        raycast = Physics.Raycast(transform.position + transform.TransformDirection(Vector3.forward), transform.TransformDirection(Vector3.forward), 2);
        Debug.DrawRay(transform.position + transform.TransformDirection(Vector3.forward), transform.TransformDirection(Vector3.forward), Color.blue);
    }

    public bool getRay()
    {
        return raycast;
    }
}
