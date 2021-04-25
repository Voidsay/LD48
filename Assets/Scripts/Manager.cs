using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject menu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            menu.SetActive(!menu.activeSelf);
        }
        Variables.paused = menu.activeSelf;

        //TODO make less of a mess
        if (menu.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void CloseUI(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void OpenUI(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void Reset(GameObject obj)
    {
        DeathManager.instance.Death();
        CloseUI(obj);
    }
}
