    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int maxComfort = 6;
    public int currentDiscomfort;

    public Discomfortmeter discomfortmeter;

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
