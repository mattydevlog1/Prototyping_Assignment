using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DamageSystem : MonoBehaviour
{
    [SerializeField]
    private float maxHP;

    [SerializeField]
    private float damageShot;

    [SerializeField]
    private float currentHP;

    [SerializeField]
    private GameObject target;

    void Start()
    {
        maxHP = currentHP;
    }


    void Update()
    {
        if (target == null)
        {
            currentHP -= damageShot;
        }
    }
}