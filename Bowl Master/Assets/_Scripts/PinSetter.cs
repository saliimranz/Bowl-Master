using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PinSetter : MonoBehaviour
{
    public int lastStandingCount = -1;
    public Text standingDisplay;
    public float distanceToRaise = 90f;

    private bool ballEnterBox = false;
    private float lastChangeTime;
    private Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        standingDisplay.text = CountStanding().ToString();
        if (ballEnterBox)
        {
            checkStanding();
        }
    }

    void checkStanding()
    {
        int currentStanding = CountStanding();
        if(currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f;
        Debug.Log("There has been no change");
        if((Time.time - lastChangeTime) > settleTime)
        {
            pinsHaveSettled();
            ball.Resetting();
            Debug.Log("Resetting done");
        }
    }

    public void RaisePins()
    {
        //raise the pins above 40cm
        foreach (Pins pin in GameObject.FindObjectsOfType<Pins>())
        {
            if (pin.isStanding())
            { pin.transform.Translate(new Vector3(0, distanceToRaise, 0),Space.World); }
        }
    }
    public void LowerPins()
    {
        //lower the pins above 40cm
    }
    public void RenewPins()
    {
        //renew the pins above 40cm
    }
    void pinsHaveSettled()
    {
        lastStandingCount = -1; //indicates pins have settled , ball not back in box
        ballEnterBox = false;
        standingDisplay.color = Color.green;
    }

    int CountStanding()
    {
        int standing = 0;
        foreach(Pins pin in GameObject.FindObjectsOfType<Pins>())
        {
            if (pin.isStanding())
            {standing++;}
        }
        return standing;
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject thingLeft = other.gameObject;

        if (thingLeft.GetComponent<Pins>())
        {
            Destroy(thingLeft);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject thingHit = other.gameObject;

        if (thingHit.GetComponent<Ball>())
        {
            ballEnterBox = true;
            standingDisplay.color = Color.red;
        }
    }
}
