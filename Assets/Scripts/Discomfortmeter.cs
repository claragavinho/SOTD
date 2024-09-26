using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Discomfortmeter : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); //will keep the object on the scene when the scene loads
    }

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
