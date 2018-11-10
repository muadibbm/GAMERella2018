using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Trigger : MonoBehaviour {

    public delegate void Event(Collider2D other);

    public event Event OnEnter2D;
    public event Event OnExit2D;
    public event Event OnStay2D;

    private void OnTriggerEnter2D(Collider2D other) {
        if(this.OnEnter2D != null) this.OnEnter2D(other);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (this.OnExit2D != null) this.OnExit2D(other);
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (this.OnStay2D != null) this.OnStay2D(other);
    }
}