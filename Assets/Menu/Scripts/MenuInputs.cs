using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInputs : MonoBehaviour
{
    [SerializeField]
    GameObject menu;
    [SerializeField]
    GameObject pasued;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (Time.timeScale == 0 && menu.active)
            {
                
                menu.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                Debug.Log(GameObject.Find("Menu"));
                pasued.SetActive(false);
                menu.SetActive(true);
                Time.timeScale = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && !menu.active)
        {
            if (Time.timeScale == 0)
            {
                pasued.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                pasued.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
