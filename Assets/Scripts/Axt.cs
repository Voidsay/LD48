using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axt : MonoBehaviour
{
    public Animator axt;
    public bool cooldown;
    public float coolTime = 2f;
    public AudioSource source;
    public AudioSource source2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !cooldown && !Variables.paused)
        {
            source2.Play();
            axt.gameObject.SetActive(true);
            axt.SetTrigger("Swing");
            cooldown = true;
            Invoke("Cooldown", coolTime);
        }
    }

    void Cooldown()
    {
        cooldown = false;
        played = false;
    }

    public bool played;
    void OnCollisionEnter()
    {
        if (cooldown && !source.isPlaying && !played)
        {
            played = true;
            source.pitch = Random.Range(0.9f, 1.1f);
            source.Play();
        }
    }
}
