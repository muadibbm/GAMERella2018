using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Trigger : MonoBehaviour {

    public delegate void Event(Collider2D other);

    public event Event OnEnter;
    public event Event OnExit;
    public event Event OnStay;

    private void OnTriggerEnter2D(Collider2D other) {
        if(this.OnEnter != null) this.OnEnter(other);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (this.OnEnter != null) this.OnExit(other);
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (this.OnEnter != null) this.OnStay(other);
    }
}