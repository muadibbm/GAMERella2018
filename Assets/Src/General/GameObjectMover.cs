using UnityEngine;

public class GameObjectMover : MonoBehaviour {

    public GameObject target;
    public float speed;
    public Vector3 dir;
    public bool flipX;
    public bool flipY;

    private SpriteRenderer rend;

    private void Awake() {
        this.rend = this.GetComponent<SpriteRenderer>();
    }

    private void Update() {
        Vector3 tDir = (this.target == null) ? this.dir :
            (this.target.transform.position - this.transform.position);
        this.transform.position += tDir.normalized * this.speed * Time.deltaTime;
        if (this.flipX) this.rend.flipX = (tDir.x < 0);
        if (this.flipY) this.rend.flipY = (tDir.y < 0);
    }
    
    private void OnDrawGizmos() {
        Gizmos.color = Color.white;
        if(this.target) Gizmos.DrawLine(this.transform.position, this.target.transform.position);
    }
}