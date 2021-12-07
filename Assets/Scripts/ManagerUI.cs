using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    public static ManagerUI instance;
    public float timer = 0.0f;
    public int points = 0, lives = 3;
    [SerializeField] private GameObject timerText;
    [SerializeField] private GameObject pointText;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject pasued;
    [SerializeField] GameObject victory;
    [SerializeField] GameObject deafeat;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        timer += Time.deltaTime;
        TimeShow(timer);
        PlayerStatsShow(lives, points);
        if(lives==0)
        {
            DefeatScreen();
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (Time.timeScale == 0 && menu.active)
            {
                Cursor.visible = false;
                menu.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                Cursor.visible = true;
                Debug.Log(GameObject.Find("Menu"));
                pasued.SetActive(false);
                menu.SetActive(true);
                Time.timeScale = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.P) && !menu.active)
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
    public void TimeShow(float timer)
    {
        timerText.GetComponentInChildren<TMPro.TextMeshProUGUI>().text =
            $"{Mathf.FloorToInt(timer / 60)}:{Mathf.FloorToInt(timer % 60).ToString("00")}";
    }
    public void PlayerStatsShow(int lives, int points)
    {
       pointText.GetComponentInChildren<TMPro.TextMeshProUGUI>().text =
            $"Points: {points}\nLives: {lives}";
    }
    public void VictoryScreen()
    {
        victory.SetActive(true);
        Debug.Log("You are a winner! :D");

    }
    public void DefeatScreen()
    {
        deafeat.SetActive(true);
        Debug.Log("You lose");
    }
}
