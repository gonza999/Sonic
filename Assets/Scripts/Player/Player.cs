using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public float life = 2;
    public float speed =2;
    public float speedGrowth = 1;
    public float speedMax=15;
    public float forceJump = 5;
    public float speedDefault;
    public bool invencibility = false;
    public float timeToInvencibility = 2f;
    private float timeInvencibility=0;
    public Shake shake;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        Invencibility();
    }
    public void CameraShake()
    {
        StartCoroutine(shake.Shaking());
    }
    private void Invencibility()
    {
        if (invencibility)
        {
            timeInvencibility += Time.deltaTime;
            if (timeInvencibility >= timeToInvencibility)
            {
                invencibility = false;
            }
        }
    }

    private void Start()
    {
        speedDefault = speed;
    }
}
