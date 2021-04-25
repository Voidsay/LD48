using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [TextArea]
    public string text;
    public bool selfdestruct;
    public GameObject spawn;

    void OnTriggerEnter(Collider info)
    {
        if (info.CompareTag("Player"))
        {
            DialogManager.instance.Disp(text);
            if (spawn != null)
            {
                spawn.SetActive(true);
            }
            if (selfdestruct)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
