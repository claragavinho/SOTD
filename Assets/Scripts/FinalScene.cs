using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScene : MonoBehaviour
{
    [SerializeField]
    Dialogue[] _endingDialogue;

    public GameManager gameMngr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeEndings(int endingRef)
    {
        if (gameMngr.currentDiscomfort == 0)
        {

        }
    }
}
