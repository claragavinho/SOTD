using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Discomfortmeter : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    
    public void SetMaxDiscomfort(int discomfort)
    {
        slider.maxValue = discomfort;
        slider.value = 3;
    }

    public void SetDiscomfort(int discomfort)
    {
        slider.value = discomfort;
    }
}
