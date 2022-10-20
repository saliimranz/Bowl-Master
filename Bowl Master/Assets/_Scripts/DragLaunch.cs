using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour
{
    private Ball ball;

    Vector3 dragStart, dragEnd;
    float startTime, endTime;
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Ball>();
    }

    public void MoveStart(int val)
    {
        if( ! ball.inPlay)
        {
            ball.transform.Translate(new Vector3(val, 0, 0));
        }    
    }

    public void DragStart()
    {
        //capture time and pos of dragStart
        dragStart = Input.mousePosition;
        startTime = Time.time;
    }
     public void DragEnd()
    {
        dragEnd = Input.mousePosition;
        endTime = Time.time;
        // launch the ball

        float dragDuration = endTime - startTime;
        float LaunchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
        float LaunchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

        Vector3 launchVelocity = new Vector3(LaunchSpeedX, 0, LaunchSpeedZ);
        ball.Launch(launchVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
