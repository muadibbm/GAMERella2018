using UnityEngine;

public class Teleport : MonoBehaviour {

    public GameObject gObj;
    public Transform target;
    
	void Start () {
        this.gObj.transform.position = target.position;
	}
}