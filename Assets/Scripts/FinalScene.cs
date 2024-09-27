using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScene : MonoBehaviour
{
    [SerializeField]
    GameObject _goodEnding;

    [SerializeField]
    GameObject _neutralEnding;

    [SerializeField]
    GameObject _badEnding;

    [SerializeField]
    GameManager _gameMngr;

    private void Awake()
    {
        _goodEnding.SetActive(false);
        _neutralEnding.SetActive(false);
        _badEnding.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        ChangeEndings();
    }

    public void ChangeEndings()
    {
        if (_gameMngr.currentDiscomfort == 0)
        {
            _goodEnding.SetActive(true);
        }
        else if (_gameMngr.currentDiscomfort == 6)
        {
            _badEnding.SetActive(true);
        }
        else 
        { 
            _neutralEnding.SetActive(true);
        }
    }
}
