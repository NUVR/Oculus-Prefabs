using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSwitch : MonoBehaviour {
    public Light light;
    private bool switchOn = false;

    void OnTriggerStay(Collider collider) {
        Debug.Log(collider.gameObject.name);
        if(collider.gameObject.name.Contains("index3")) {
            if(switchOn) {
                switchOn = false;
            }
            else {
                switchOn = true;
            }
        }
    }
}
