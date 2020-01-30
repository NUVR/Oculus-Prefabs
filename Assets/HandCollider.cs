using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollider : MonoBehaviour
{
    public OvrAvatar avatar;

    private bool isAttached = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttached)
        {
            Transform rightIndexTransform = avatar.GetHandTransform(OvrAvatar.HandType.Right, OvrAvatar.HandJoint.IndexTip);
            if (rightIndexTransform != null)
            {
                gameObject.transform.SetParent(rightIndexTransform);
                gameObject.transform.localPosition = Vector3.zero;
                gameObject.transform.localRotation = Quaternion.identity;
                isAttached = true;
            }
        }
    }
}
