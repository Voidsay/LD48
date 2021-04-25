using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static Character instance;
    public Rigidbody rb;

    public float velocity = 0.1f;
    public float runSpeed = 1f;

    public float stamina = 100f;
    public float maxStamina = 100f;
    public float exhaust = 1f;
    public float gain = 0.1f;

    public AudioSource source;

    void Start()
    {
        instance = this;
    }

    public Vector3 dir;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Variables.paused)
        {
            dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            if (dir.magnitude > 0)
            {
                if (!source.isPlaying)
                {
                     source.pitch = Random.Range(0.9f, 1f);
                    source.Play();
                }
                float vel = velocity;
                if (Input.GetButton("Fire3") && stamina > 0)
                {
                    vel += runSpeed;
                    stamina -= exhaust;
                }
                rb.MovePosition(transform.position + transform.rotation * dir * vel);
            }
            else
            {
                if (stamina < maxStamina)
                {
                    stamina += gain;
                }
            }
        }
    }
}
