using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimeDilution : MonoBehaviour
{

    private float fixedDeltaTime;
    

    

    [Header("Set Slowmotion time")]
    public float slowMotionTargetTime;


    [SerializeField]
    private float maxTimeResource = 40f;
    public float timeResource;

    private bool isKeyPressed = false;
   
    void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
        timeResource = maxTimeResource;
    }

    void Update()
    {



        if (Input.GetButtonDown("Fire1") && timeResource > 0 && isKeyPressed == false)
        {

            Debug.Log("slow down time");

            slowTime();
            countDownTimer();
            isKeyPressed = true;
            return;



        }
        else if (Input.GetButtonDown("Fire1") && isKeyPressed == true)
        {
            Debug.Log("return to normal timescale");
            returnTime();
            countDownAdditive();
            isKeyPressed = false;

        }
        else if (timeResource < 0)
        {
            returnTime();
            countDownAdditive();
            isKeyPressed = false;
            

        }



    }
    public void slowTime()
    {
        Time.timeScale = slowMotionTargetTime;
    }
    public void returnTime()
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;

    }
    public void countDownTimer()
    {
        InvokeRepeating("resourceDrain", 1f, 0.1f);

        
    }
    public void resourceDrain()
    {
       timeResource -=10f;
        
        if (timeResource < 10)
        {
            CancelInvoke();
        }
    }
    public void countDownAdditive()
    {
        InvokeRepeating("resourceAdd", 1f, 0.1f);
    }
    public void resourceAdd()
    {
        timeResource += 0.2f;

        if (timeResource > 40)
        {
            CancelInvoke();
        }
    }
}
