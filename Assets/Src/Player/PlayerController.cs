
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public float speed;
    public float jumpSpeed;
    public LayerMask groundRaycastLayer;
    public float groundRaycastDist;

    private GameInput.Controller controller;
    private float jumpDuartion = 2f;
    private float elsapsedTime;

    private enum State { Idle, Walk, Jump }
    private State currentState;
    private bool frozen = false;

    void Update () {
        this.controller = Bootstrap.instance.gameInput.GetController();
        this.UpdateStates();
    }

    private void FixedUpdate() {
        if (!this.frozen) this.UpdateLocomotion();
    }

    public GameInput.Controller GetController() {
        return this.controller;
    }

    public void FreezePlayer() {
        this.frozen = true;
    }

    public void UnFreezePlayer() {
        this.frozen = false;
    }

    private void UpdateStates() {
        switch (this.currentState) {
            case State.Idle:
                this.DoIdle();
                break;
            case State.Walk:
                this.DoWalk();
                break;
            case State.Jump:
                this.DoJump();
                break;
        }
        this.CheckForNextState();
    }

    private void CheckForNextState() {
        if (this.currentState != State.Jump) {
            if (this.controller.buttonJumpDown) { // from idle or walk to jump
                this.currentState = State.Jump;
            } else if (this.controller.joy1.magnitude != 0) { // from idle to walk
                this.currentState = State.Walk;
            } else {
                this.currentState = State.Idle; // from walk to idle
            }
        } else {
            if (Physics2D.Raycast(this.transform.position, -Vector2.up, this.groundRaycastDist, this.groundRaycastLayer)) {
                if (this.controller.joy1.magnitude != 0) {
                    this.currentState = State.Walk; // from jump to walk
                } else {
                    this.currentState = State.Idle; // from jump to idle
                }
            }
        }
    }

    private void UpdateLocomotion() {
        Vector2 dir = this.controller.joy1;
        Vector3 motion = Vector3.right * dir.x * this.speed * Time.deltaTime;
        if (this.currentState == State.Jump) {
            this.elsapsedTime += Time.deltaTime;
            if (this.elsapsedTime < this.jumpDuartion) {
                motion += Vector3.up * this.jumpSpeed * Time.deltaTime;
            }
        } else {
            this.elsapsedTime = 0f;
        }
        this.transform.position += motion;
    }

    private void DoIdle() {

    }

    private void DoWalk() {

    }

    private void DoJump() {

    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position, this.transform.position - Vector3.up * this.groundRaycastDist);
    }
}
