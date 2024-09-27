    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int maxComfort = 6;
    public int currentDiscomfort;

    public Discomfortmeter discomfortmeter;
    private void Awake()
    {
        DontDestroyOnLoad(this); //will keep the object on the scene when the scene loads
    }

    private void Start()
    {
        currentDiscomfort = maxComfort;
        discomfortmeter.SetDiscomfort(3);
    }
    public void MakeUncomfortable()
    {
        currentDiscomfort++;

        discomfortmeter.SetDiscomfort(currentDiscomfort);
    }
    public void MakeComfortable()
    {
        currentDiscomfort--;
        discomfortmeter.SetDiscomfort(currentDiscomfort);
    }
}
