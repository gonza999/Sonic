using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBar : MonoBehaviour
{
    public Image speedBarImage;
    public Rigidbody2D playerRB2d;
    private void Update()
    {
        speedBarImage.fillAmount =Mathf.Abs( playerRB2d.velocity.x )/ Player.instance.speedMax;
        speedBarImage.color = new Color(speedBarImage.color.r,1-speedBarImage.fillAmount, speedBarImage.color.b);
    }
}
