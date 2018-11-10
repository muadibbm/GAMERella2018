﻿using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ParallaxManager : MonoBehaviour {

    public float backgroundSize; // the horizontal extent of what the camera can see

    [System.Serializable]
    public class Layer {
        public float speed;
        public float offset;
        public bool slide = true;
        public bool loop = true;
        public Transform[] elements;

        [HideInInspector]
        public bool foldOut = false;

        public int currentFirst = 0; // index of the element located at far left
        public int currentLast; // index of the element located at far right
    }

    public Layer[] layers = new Layer[1];

    private float prevPosX;

    private void Start() {
        for (int i = 0; i < this.layers.Length; i++) {
            this.layers[i].currentLast = this.layers[i].elements.Length - 1;
        }
        this.prevPosX = this.transform.position.x;
    }

    private void Update() {
        //this.transform.Translate(Vector3.right * Time.deltaTime * 10f);
        if (this.transform.position.x != this.prevPosX) {
            this.SlideLayers();
            this.LoopLayers();
        }
        this.prevPosX = this.transform.position.x;
    }

    private void SlideLayers() {
        Vector3 pos;
        for (int i = 0; i < this.layers.Length; i++) {
            for (int j = 0; j < this.layers[i].elements.Length; j++) {
                if (this.layers[i].slide) {
                    pos = this.layers[i].elements[j].position;
                    pos.x += (this.prevPosX - this.transform.position.x) * this.layers[i].speed;
                    this.layers[i].elements[j].position = pos;
                }
            }
        }
    }

    private void LoopLayers() {
        Vector3 currentFirstPos, currentLastPos;
        for (int i = 0; i < this.layers.Length; i++) {
            if (this.layers[i].loop) {
                currentFirstPos = this.layers[i].elements[this.layers[i].currentFirst].position;
                currentLastPos = this.layers[i].elements[this.layers[i].currentLast].position;
                if (Mathf.Abs(currentLastPos.x - this.transform.position.x) < this.backgroundSize) {
                    this.layers[i].elements[this.layers[i].currentFirst].position = currentLastPos + Vector3.right * this.layers[i].offset;
                    this.layers[i].currentLast = this.layers[i].currentFirst;
                    this.layers[i].currentFirst++;
                    if (this.layers[i].currentFirst == this.layers[i].elements.Length) this.layers[i].currentFirst = 0;
                } else if (Mathf.Abs(currentFirstPos.x - this.transform.position.x) < this.backgroundSize) {
                    this.layers[i].elements[this.layers[i].currentLast].position = currentFirstPos - Vector3.right * this.layers[i].offset;
                    this.layers[i].currentFirst = this.layers[i].currentLast;
                    this.layers[i].currentLast--;
                    if (this.layers[i].currentLast == -1) this.layers[i].currentLast = this.layers[i].elements.Length - 1;
                }
            }
        }
    }
}