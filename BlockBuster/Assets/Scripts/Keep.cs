using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Keep : MonoBehaviour
{
    public static bool OversizedBall;
    public static float PlayerSpeed = 1.0f;
    public static int pColor;

    public Toggle Size;
    public Slider playerSpeed;
    public Dropdown sColor;

    public void Sleep()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Big (bool newValue)
    {
        OversizedBall = newValue;
    }

    public void ChangeColor()
    {
        switch (sColor.value)
        {
            case 1:
            pColor = 1;
            break;
            case 2:
            pColor = 2;
            break;
            case 3:
            pColor = 3;
            break;
            default:
            pColor = 1;
            break;
        }
    }

    public void SetPlayerSpeed()
    {
        PlayerSpeed = playerSpeed.value;
    }

}
