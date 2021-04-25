using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGuyAI : MonoBehaviour
{
    public MeshRenderer mesh;
    public Animator anim;

    public AudioSource source;
    public AudioClip clip;

    [SerializeField]
    Rigidbody rb;
    public float velocity = 0.5f;
    public float killdist = 2;

    public bool active;

    public string[] poses = { "FirstPose", "SecondPose", "ThirdPose" };

    void Start()
    {
        StartCoroutine(PoseSelect());
    }

    private bool killed;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!mesh.isVisible && !Variables.paused && active)
        {
            Vector3 temp = Character.instance.transform.position - transform.position;//Warning this is not exact on a slope!
            var ang1 = Vector3.Angle(temp, transform.forward);
            var ang2 = Vector3.Angle(temp, transform.right);

            transform.rotation *= Quaternion.Euler(0, ang1 * ang1 > 90 ? 1 : -1, 0);

            rb.MovePosition(Vector3.MoveTowards(transform.position, Character.instance.transform.position, velocity));
            float dist = Vector3.Distance(transform.position, Character.instance.transform.position);
            if (dist < killdist && !killed)
            {
                killed = true;
                Kill();
            }
        }
        else
        {
            if (active)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    IEnumerator PoseSelect()
    {
        while (true)
        {
            yield return new WaitUntil(() => !mesh.isVisible);
            anim.SetTrigger(poses[Random.Range(0, 3)]);
            if (active)
            {
                source.Play();
            }
            yield return new WaitUntil(() => mesh.isVisible);
        }
    }

    void OnCollisionEnter(Collision info)
    {
        if (info.collider.CompareTag("Axt"))
        {
            Kill();
        }
    }

    void Kill()
    {
        Debug.Log("kill");
        anim.SetTrigger("Kill");
        source.clip = clip;
        source.Play();

        //TODO kill the player
        DeathManager.instance.Death();
    }

    void OnTriggerEnter(Collider info)
    {
        if (info.CompareTag("Player"))
        {
            active = true;
            Debug.Log("awoken");
        }
    }
}
