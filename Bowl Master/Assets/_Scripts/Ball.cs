using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool inPlay = false;
    private Rigidbody rigidBody;
    public Vector3 launchVelocity;
    private Vector3 ballStartPos;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        ballStartPos = transform.position;
    }

    public void Launch(Vector3 velocity)
    {
        inPlay = true;
        rigidBody.useGravity = true;
        rigidBody.velocity = velocity;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void Resetting()
    {
        inPlay = false;
        transform.position = ballStartPos;
        rigidBody.angularVelocity = Vector3.zero;
        rigidBody.useGravity = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
