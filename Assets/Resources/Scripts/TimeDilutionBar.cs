using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDilutionBar : MonoBehaviour
{
    [SerializeField] private Slider sliderTimeDilution;
    
    public void SetMaxTime(float time)
    {
        sliderTimeDilution.maxValue = time;
        sliderTimeDilution.value = time;
    }
    public void SetTime(float time)
    {
        sliderTimeDilution.value = time;
    }
}
