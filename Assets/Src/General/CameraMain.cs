using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : MonoBehaviour {

    public Camera main;
    public Camera camera_earthborn;
    public Camera camera_starborn;
    public float minDist;

    private void LateUpdate() {
        //float ceX = this.camera_earthborn.transform.position.x;
        //float csX = this.camera_starborn.transform.position.x;
        //bool bWithinRange = Mathf.Abs(ceX - csX) > this.minDist;
        //Vector3 pos = this.main.transform.position;
        //pos.x = (csX > ceX) ? ceX : csX + Mathf.Abs(ceX - csX) / 2f;
        //this.main.transform.position = pos;
        //this.main.enabled = !bWithinRange;
        //this.camera_earthborn.enabled = camera_starborn.enabled = bWithinRange;
    }
}
