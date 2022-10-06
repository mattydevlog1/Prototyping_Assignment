using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;


    public float highScore;


    public TMP_Text m_TextComponent;
    public TMP_Text timeKeeper;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("SwitchManager is returning null");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        //  timeKeeper.text = GameObject.Find("Ellen").GetComponent<TimeDilution>().timeResource.ToString("0");
        //  GameObject.Find("Ellen").GetComponent<Player>().playerCurrentHp.ToString("0");


        m_TextComponent.text = highScore.ToString("0");

        GameObject.Find("Ellen").GetComponent<Player>().playerCurrentHp.ToString("0");
    }
    public void timeUpdate()
    {

    }

    public void AddScore(float Addscore)
    {
        Addscore += highScore;
    }


}
