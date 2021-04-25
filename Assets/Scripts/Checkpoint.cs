using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int index;

    void OnTriggerEnter(Collider info)
    {
        if (info.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Checkpoint", index);
            PlayerPrefs.Save();
            Debug.Log("checkpoint saved");
        }
    }
}
