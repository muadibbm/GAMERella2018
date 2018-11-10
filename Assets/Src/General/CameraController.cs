using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float trackingSpeed;
    public Transform trackingTarget;

    private void Update() {
        Vector3 targetPos = this.trackingTarget.position;
        Vector3 selfPos = this.transform.position;
        targetPos.z = selfPos.z;
        if (Mathf.Abs(targetPos.magnitude - selfPos.magnitude) > 0.1f) {
            selfPos += (targetPos - selfPos) * this.trackingSpeed * Time.deltaTime;
        }
        this.transform.position = selfPos;
    }
}
