using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Trigger))]
public class Death : MonoBehaviour {

    private void Awake() {
        this.GetComponent<Trigger>().OnEnter2D += End;
    }

    private void End(Collider2D other) {
        // TODO : death animation / fade
        SceneManager.LoadScene(0);
    }
}
