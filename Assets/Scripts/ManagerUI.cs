using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    public static ManagerUI instance;
    public float timer = 0.0f;
    public int points = 0, lives = 3;

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

        }

    }
    public void TimeShow(float timer)
    {
        gameObject.transform.GetChild(0).GetComponentInChildren<TMPro.TextMeshProUGUI>().text =
            $"{Mathf.FloorToInt(timer / 60)}:{Mathf.FloorToInt(timer % 60).ToString("00")}";
    }
    public void PlayerStatsShow(int lives, int points)
    {
        gameObject.transform.GetChild(1).GetComponentInChildren<TMPro.TextMeshProUGUI>().text =
            $"Points: {points}\nLives: {lives}";
    }
}
