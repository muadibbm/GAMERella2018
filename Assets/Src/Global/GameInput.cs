
using UnityEngine;

public class GameInput {

    private Controller controller;

    private _Input inputJ1X;
    private _Input inputJ1Y;

    public struct Controller {
        public Vector2 joy1;
        public Vector2 joy1Down;
        public bool buttonJump;
        public bool buttonJumpDown;
        public bool buttonInteract;
        public bool buttonInteractDown;
    }

    public GameInput() {
        this.controller = new Controller();
        this.inputJ1X = new _Input();
        this.inputJ1Y = new _Input();
    }

    public void Update() {
        this.controller.joy1.x = Input.GetAxis("Horizontal");
        this.controller.joy1.y = Input.GetAxis("Vertical");

        this.controller.joy1Down.x = (this.inputJ1X.GetAxisDown("Horizontal")) ? this.controller.joy1.x : 0f;
        this.controller.joy1Down.y = (this.inputJ1Y.GetAxisDown("Vertical")) ? this.controller.joy1.y : 0f;

        this.controller.buttonJump = Input.GetButtonDown("Jump");

        this.controller.buttonJumpDown = Input.GetButton("Jump");
    }

    public Controller GetController() {
        return this.controller;
    }

    public struct _Input {

        private bool lastInputState;

        public bool GetAxisDown(string axisName) {
            var currentInputValue = Mathf.Abs(Input.GetAxis(axisName)) > 0.5f;
            
            if (currentInputValue && lastInputState) {
                return false;
            }

            lastInputState = currentInputValue;

            return currentInputValue;
        }
    }
}
