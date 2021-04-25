using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    public Text text;
    public float dispTime = 5;

    void OnEnable()
    {
        instance = this;
    }


    public void Disp(string str)
    {
        CancelInvoke("Remove");
        text.text = str;
        Invoke("Remove", dispTime);
    }

    public void Remove()
    {
        text.text = string.Empty;
    }
}
