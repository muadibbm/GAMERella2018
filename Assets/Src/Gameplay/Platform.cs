using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Platform : MonoBehaviour {

    private GameObjectMover mover;
    private Vector3 prevPos;
    private Transform player;

    private void Awake() {
        this.mover = this.GetComponentInParent<GameObjectMover>();
    }

    private void FixedUpdate() {
        if(this.player) {
            this.player.transform.position += Time.fixedDeltaTime * mover.speed * 
                (this.transform.position - this.prevPos).normalized;
        }
        this.prevPos = this.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        this.player = other.transform;
    }

    private void OnTriggerExit2D(Collider2D other) {
        this.player = null;
    }
}