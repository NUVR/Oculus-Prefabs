using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleButton : MonoBehaviour {
    public Light light;
    private bool pressing = false;
    private float[] limits;

    void Start() {
        limits = new float[2];
        limits[0] = this.transform.localPosition.x;
        limits[1] = this.transform.localPosition.x * 3 / 8;
    }

    float NormalizedDistance() {
        float x = this.transform.localPosition.x;
        return (limits[0] - x) / (limits[0] - limits[1]);
    }

    void FixedUpdate() {
        Vector3 position = this.transform.localPosition;
        if(pressing) {
            position.x = Mathf.Lerp(position.x, limits[1], 0.25f);
        }
        else {
            position.x = Mathf.Lerp(position.x, limits[0], 0.25f);
        }

        light.enabled = NormalizedDistance() < 0.7;
        this.transform.localPosition = position;
    }

    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.name.Contains("index3")) {
            pressing = true;
        }
    }

    void OnTriggerExit(Collider collider) {
        if(collider.gameObject.name.Contains("index3")) {
            pressing = false;
        }
    }
}
