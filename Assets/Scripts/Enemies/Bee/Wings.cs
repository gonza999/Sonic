using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wings : MonoBehaviour
{
    public GameObject wingsFly;
    public GameObject fire;
    public GameObject wingsIdle;
    public Animator beeAnimator;

    private void Update()
    {
        if (beeAnimator.GetBool("Fly"))
        {
            wingsFly.SetActive(true);
            wingsIdle.SetActive(false);
            fire.SetActive(true);
        }
        else
        {
            wingsFly.SetActive(false);
            fire.SetActive(false);
            wingsIdle.SetActive(true);
        }
    }
}
