using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour
{
    public AudioSource source;
    public float normalVolume;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Character.instance.dir.magnitude > 0.1f)
        {
            source.volume *= 0.98f;
        }
        else
        {
            if (source.volume < normalVolume)
            {
                source.volume += 0.005f;
            }
        }
    }
}
