using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public enum Condition { Start, TriggerEnter2D, TriggerExit2D }
    public Condition condition;

    public enum Action { Load, UnLoad }
    public Action action;

    public LoadSceneMode mode;
    public string sceneName;
    public float delay;
    public Trigger trigger;
    
    private bool bExecuted;

    private void Awake() {
        switch (this.condition) {
            case Condition.TriggerEnter2D:
                this.trigger.OnEnter2D += Execute;
                break;
            case Condition.TriggerExit2D:
                this.trigger.OnExit2D += Execute;
                break;
        }
    }

    private void Start() {
        if (this.condition == Condition.Start) {
            this.Execute();
        }
    }
    
    private void Execute(Collider2D other) {
        this.Execute();
    }

    private void Execute() {
        if (!this.bExecuted) {
            this.StartCoroutine(this.ExecuteRoutine());
            this.bExecuted = true;
        }
    }

    private IEnumerator ExecuteRoutine() {
        yield return new WaitForSeconds(this.delay);
        switch (this.action) {
            case Action.Load:
                SceneManager.LoadSceneAsync(this.sceneName, this.mode);
                break;
            case Action.UnLoad:
                SceneManager.UnloadSceneAsync(this.sceneName);
                break;
        }
    }
}
