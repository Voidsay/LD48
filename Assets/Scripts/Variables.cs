using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : ScriptableObject
{
    public static float MS = PlayerPrefs.GetFloat("MS", 1); //mouse sensetivity

    public static int InvMX = PlayerPrefs.GetInt("InvX", 1);
    public static int InvMY = PlayerPrefs.GetInt("InvY", 1);

    public static bool paused = false;

}
