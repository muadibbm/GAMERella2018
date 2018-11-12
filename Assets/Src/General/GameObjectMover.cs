using UnityEngine;

public class GameObjectMover : MonoBehaviour {

    public GameObject target;
    public float speed;
    public Vector3 dir;
    public bool flipX;
    public bool flipY;
    public bool loop;

    private SpriteRenderer rend;
    private Vector3 initPos;
    private bool toTarget = true;
    private float minStoppingDist = 0.1f;

    private void Awake() {
        this.rend = this.GetComponent<SpriteRenderer>();
        this.initPos = this.transform.position;
    }

    private void FixedUpdate() {
        Vector3 currentDest = Vector3.zero;
        if(this.target != null) {
            if (this.loop) {
                if(this.toTarget) {
                    if ((this.target.transform.position - this.transform.position).magnitude < this.minStoppingDist) {
                        this.toTarget = false;
                    }
                    currentDest = this.target.transform.position;
                } else {
                    if ((initPos - this.transform.position).magnitude < this.minStoppingDist) {
                        this.toTarget = true;
                    }
                    currentDest = initPos;
                }
            } else {
                if ((this.target.transform.position - this.transform.position).magnitude < this.minStoppingDist) {
                    this.transform.position = this.target.transform.position;
                    currentDest = this.transform.position;
                } else {
                    currentDest = this.target.transform.position;
                }
            }
        }
        Vector3 tDir = (this.target == null) ? this.dir :
            (currentDest - this.transform.position);
        this.transform.position += tDir.normalized * this.speed * Time.fixedDeltaTime;
        if (this.flipX) this.rend.flipX = (tDir.x < 0);
        if (this.flipY) this.rend.flipY = (tDir.y < 0);
    }
    
    private void OnDrawGizmos() {
        Gizmos.color = Color.white;
        if(this.target) Gizmos.DrawLine(this.transform.position, this.target.transform.position);
    }
}