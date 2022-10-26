using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins : MonoBehaviour
{
    public float standingThreshold = 3f;
    public float distToRaise = 90f;

    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool isStanding()
    {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

        float tiltInX =Mathf.Abs(270 - rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        if(tiltInX < standingThreshold && tiltInZ < standingThreshold)
        {
            return true;
        }else {
            return false;
        }

    }
    public void RaiseIfStanding()
    {
        if (isStanding())
        {
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            rigidbody.useGravity = false;
            transform.Translate(new Vector3(0, distToRaise, 0), Space.World); }
    }

    public void Lower()
    {
        rigidbody.useGravity = true;
        rigidbody.constraints = RigidbodyConstraints.None;
        // transform.Translate(new Vector3(0, -distToRaise, 0), Space.World);

    }
}
