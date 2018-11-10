using System.Collections;
using UnityEngine;

public class GameObjectEnabler : MonoBehaviour {

    public enum Condition { Start, TriggerEnter2D, TriggerExit2D }
    public Condition condition;

    public enum Action { Enable, Disable }
    public Action action;

    public float delay;
    public GameObject[] gameObjects;
    public Component[] components;
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
        for(int i=0; i < this.gameObjects.Length; i++) {
            this.gameObjects[i].SetActive(this.action == Action.Enable);
        }
        System.Type type;
        for (int i = 0; i < this.components.Length; i++) {
            type = this.components[i].GetType().BaseType;
            if (type == typeof(MonoBehaviour)) {
                (this.components[i] as MonoBehaviour).enabled = (this.action == Action.Enable);
            }
        }
    }
}