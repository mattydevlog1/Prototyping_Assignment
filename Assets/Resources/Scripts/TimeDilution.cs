using System.Collections;
using System.Collections.Generic;
using Adobe.Substance.Runtime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimeDilution : MonoBehaviour
{

    public enum TimeState { Normal, Return, Slowed }

    [SerializeField] private TimeState timeState;


    private float fixedDeltaTime;

    private bool onoff = false;


    [Header("Set Slowmotion time")]
    public float slowMotionTargetTime;


    [SerializeField]
    private float maxTimeResource = 10f;
    public float timeResource;


    private bool timeCircleActive = false;

    public GameObject timeCircle;
    public GameObject player;

    public AudioClip timeSlowedDown;

    public TimeDilutionBar timeDilutionBar;


    void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
        timeResource = maxTimeResource;

    }

    void Update()
    {
        
        timeDilutionBar.SetTime((float)timeResource);


        switch (timeState)
        {

            case TimeState.Normal:
                returnTime();
                break;

            case TimeState.Return:
                returnTime();
                resourceAdd();
                break;

            case TimeState.Slowed:
                slowTime();
                resourceDrain();
                TimeCircleSpawner();
                break;

        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button3) && timeResource > 0)
        {
            onoff = !onoff; // toggles onoff at each click

            if (onoff)
            {
                print("left");
                timeState = TimeState.Slowed;


            }
            else
            {
                print("right");
                timeState = TimeState.Normal;
            }

            //   if (Input.GetKeyDown(KeyCode.T) && timeResource > 0 && timeState == TimeState.Normal)
            {
                //     Debug.Log("Slowing down Time");
                //    timeState = TimeState.Slowed;


            }
            // if (Input.GetKeyDown(KeyCode.T) && timeResource < 0 && timeState == TimeState.Slowed)
            {
                //    Debug.Log("Returned by input");
                //    timeState = TimeState.Return;
            }




        }



    }
    public void slowTime()
    {
        Debug.Log("slowing time: from void slowtime");
        Time.timeScale = slowMotionTargetTime;


    }
    public void returnTime()
    {
        Debug.Log("returning time: from void returntime");
        timeCircleActive = false;
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;


    }

    public void resourceDrain()
    {
        Debug.Log("draining");

        timeResource -= Time.fixedDeltaTime;

        if (timeResource < 0)
        {

            timeState = TimeState.Return;

        }
    }

    public void resourceAdd()
    {
        Debug.Log("restoring");

        timeResource += Time.fixedDeltaTime;

        if (timeResource > 10)
        {

            timeState = TimeState.Normal;
        }
    }

    public void TimeCircleSpawner()
    {
        if (timeCircleActive == false)
        {
            timeCircleActive = true;
            AudioSource.PlayClipAtPoint(timeSlowedDown, transform.position);
            Instantiate(timeCircle, player.transform);

        }
    }
}
