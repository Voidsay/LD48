using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaDisplay : MonoBehaviour
{
    [SerializeField]
    Slider disp;

    public Character cha;

    // Update is called once per frame
    void Update()
    {
        if (cha.stamina < cha.maxStamina && cha.stamina > 1)
        {
            disp.gameObject.SetActive(true);
            disp.value = cha.stamina;
        }
        else
        {
            disp.gameObject.SetActive(false);
        }
    }
}
