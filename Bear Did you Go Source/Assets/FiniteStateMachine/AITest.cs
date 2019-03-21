using UnityEngine;
using System.Collections;
using Common.FSM;

public class AITest : MonoBehaviour
{
    public bool raycast;

    private FSM fsm;
    private FSMState MoveForwardState;
    private FSMState IdleState;
    private FSMState TurnState;

    private MoveAction MoveForwardAction;
    private MoveAction IdleAction;
    private TurnAction TurnAction;

    private void Start()
    {
        fsm = new FSM("AITest FSM Two");
        MoveForwardState = fsm.AddState("MoveForwardState");
        IdleState = fsm.AddState("MoveRightState");
        TurnState = fsm.AddState("TurnState");

        MoveForwardAction = new MoveAction(MoveForwardState);
        IdleAction = new MoveAction(IdleState);
        TurnAction = new TurnAction(TurnState);

        MoveForwardState.AddAction(MoveForwardAction);
        IdleState.AddAction(IdleAction);
        TurnState.AddAction(TurnAction);

        MoveForwardState.AddTransition("ToTurn", TurnState);

        TurnState.AddTransition("ToIdle", IdleState);
        TurnState.AddTransition("ToTurn", TurnState);

        IdleState.AddTransition("ToForward", MoveForwardState);
        IdleState.AddTransition("ToTurn", TurnState);


        MoveForwardAction.Init(this.transform, .1f, 2.0f, "ToTurn");
        TurnAction.Init(this.transform, 2.0f, "ToIdle");
        IdleAction.Init(this.transform, 0, 2.0f, "ToForward");

        fsm.Start("MoveForwardState");
    }

    private void Update()
    {
        fsm.Update();
        raycast = Physics.Raycast(transform.position + transform.TransformDirection(Vector3.forward), transform.TransformDirection(Vector3.forward), 2);
        Debug.DrawRay(transform.position + transform.TransformDirection(Vector3.forward), transform.TransformDirection(Vector3.forward), Color.blue);
    }

    public bool getRay(){
        return raycast;
    }
}
