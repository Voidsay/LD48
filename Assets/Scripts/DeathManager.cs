using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public Transform player;
    public Transform[] checkpoints;

    public static DeathManager instance;

    public AudioClip[] death;
    public Animator blood;

#if UNITY_EDITOR
    public int overr;
#endif

    void OnEnable()
    {
#if UNITY_EDITOR
        //PlayerPrefs.SetInt("Checkpoint", overr);
        PlayerPrefs.Save();
#endif

        instance = this;
        player.position = checkpoints[PlayerPrefs.GetInt("Checkpoint", 0)].position;
        player.rotation = checkpoints[PlayerPrefs.GetInt("Checkpoint", 0)].rotation;
    }

    public bool inProgress;
    public void Death()
    {
        if (!inProgress)
        {
            inProgress = true;
            StartCoroutine(Dieing());
        }
    }

    IEnumerator Dieing()
    {
        Character.instance.source.Stop();
        Character.instance.source.clip = death[Random.Range(0, death.Length)];
        Character.instance.source.Play();
        Character.instance.velocity = 0;
        Character.instance.runSpeed = 0;
        blood.enabled = true;
        yield return new WaitUntil(() => !Character.instance.source.isPlaying);
        yield return new WaitForSeconds(2);
        yield return new WaitUntil(() => !Variables.paused);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
