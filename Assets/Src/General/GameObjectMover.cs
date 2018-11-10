using UnityEngine;

public class GameObjectMover : MonoBehaviour {

    public GameObject target;
    public float speed;
    public Vector3 dir;

    private void Update() {
        Vector3 tDir = (this.target == null) ? this.dir :
            (this.target.transform.position - this.transform.position);
        this.transform.position += tDir.normalized * this.speed * Time.deltaTime;
    }
}