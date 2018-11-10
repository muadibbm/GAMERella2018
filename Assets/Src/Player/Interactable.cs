using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Interactable : MonoBehaviour {

    public PlayerController player; // the player this obj is interacting with
}
