using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class SortingLayerSetter : MonoBehaviour {

    public SpriteRenderer target;
    
	void Awake () {
        this.GetComponent<Renderer>().sortingLayerName = this.target.sortingLayerName;
        this.GetComponent<Renderer>().sortingOrder = this.target.sortingOrder;
	}
}
