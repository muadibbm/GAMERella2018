using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

    private List<Interactable> interactingObjs = new List<Interactable>(1);
    private PlayerController player;

    private Interactable currentInteractable = null;

    private void Awake() {
        this.player = this.GetComponentInParent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        interactingObjs.Add(other.GetComponent<Interactable>());
    }

    private void OnTriggerExit2D(Collider2D other) {
        interactingObjs.Remove(other.GetComponent<Interactable>());
    }

    // returns the first interactable object
    private Interactable GetInteractable() {
        return (this.interactingObjs.Count == 0) ? null : this.interactingObjs[0];
    }

    private void Update() {
        if(this.currentInteractable == null && this.player.GetController().buttonInteractDown) {
            this.currentInteractable = this.GetInteractable();
            if(this.currentInteractable != null && this.currentInteractable.player == null) {
                this.currentInteractable.player = this.player;
            } else {
                this.currentInteractable = null;
            }
        }
    }

    public void Uninteract() {
        this.currentInteractable.player = null;
        this.currentInteractable = null;
    }
}
