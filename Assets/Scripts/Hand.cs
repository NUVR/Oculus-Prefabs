using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
    public enum State {
        EMPTY,
        TOUCHING
    };

    public OVRInput.Controller Controller = OVRInput.Controller.LTouch;
    public State mHandState = State.EMPTY;
    public Rigidbody AttachPoint = null;
    public bool IgnoreContactPoint = false;
    private Rigidbody mHeldObject;
    private FixedJoint mTempJoint;
    private Vector3 mOldVelocity;

    // Use this for initialization
    void Start() {
        if(AttachPoint == null) {
            AttachPoint = GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update() {
    }

    void OnTriggerEnter(Collider collider) {
        if(mHandState == State.EMPTY && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, Controller) < 0.5f) {
            GameObject temp = collider.gameObject;
            if(temp != null && temp.layer == LayerMask.NameToLayer("grabbable") && temp.GetComponent<Rigidbody>() != null) {
                mHeldObject = temp.GetComponent<Rigidbody>();
                mHandState = State.TOUCHING;
            }
        }
    }

    void OnTriggerExit(Collider collider) {
        if(collider.gameObject.layer == LayerMask.NameToLayer("grabbable")) {
            mHeldObject = null;
            mHandState = State.EMPTY;
        }
    }
}
