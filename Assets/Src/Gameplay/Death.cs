using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(Trigger))]
public class Death : MonoBehaviour {

    public Transform player;
    public float minDistToKeep;
    public float speedCatchup;
    public float speedNormal;

    private void Awake() {
        this.GetComponent<Trigger>().OnEnter2D += End;
    }

    private void Update() {
        float speed = (this.player.position.x > this.transform.position.x + this.minDistToKeep) ? 
            this.speedCatchup : this.speedNormal;
        this.transform.position += Vector3.right * speed * Time.deltaTime;
    }

    private void End(Collider2D other) {
        // TODO : death animation / fade
        SceneManager.LoadScene(0);
    }
}
