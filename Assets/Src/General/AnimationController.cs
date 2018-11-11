using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour {

    public enum Action { SetBool, SetFloat }
    public Action action;
    
    public Animator animator;
    public string parameter;
    public float fVal;
    public bool bVal;

    private void Start() {
        switch (this.action) {
            case Action.SetBool:
                this.animator.SetBool(this.parameter, this.bVal); break;
            case Action.SetFloat:
                this.animator.SetFloat(this.parameter, this.fVal); break;
        }
    }
}