
using UnityEngine;

public class Bootstrap : MonoBehaviour {

    public static Bootstrap instance = null;

    public GameInput gameInput;

    void Awake() {
        if (instance == null) instance = this;
        if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        // initialize all required game system components
        this.gameInput = new GameInput();
    }

    void Update() {
        this.gameInput.Update();
    }

    private void OnDestroy() {
        if (instance == this) {
            PersistentReset.Reset();
        }
    }
}
