using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] UIScreen uIScreen;
    bool isGameOver;
    float lifetime = 0f;
    int seconds = 0;
    int minutes = 0;
    int hours = 0;
    int[] timeFormated = new int[3];

    public static Game GameInstance { get; private set; }
    public Player Player { get => player; set => player = value; }
    public int[] TimeFormated { get => timeFormated; }
    public UIScreen UIScreen { get => uIScreen; private set => uIScreen = value; }

    void Awake()
    {
        if (GameInstance == null)
        {
            GameInstance = this;
        }
        DontDestroyOnLoad(gameObject);
        isGameOver = false;
        player.OnPlayerDie += GameOver;
    }

    void Update()
    {
        if (!isGameOver)
        {
            UIScreen.ShowLifetime(Timer());
            UIScreen.ShowHealth(player.Health);
        }
        
    }

    public int[] Timer()
    {
        lifetime += Time.deltaTime;
        if (lifetime >= 1)
        {
            seconds++;
            lifetime = 0;
            TimeFormated[2] = seconds;
        }

        if (seconds == 60)
        {
            minutes++;
            seconds = 0;
            TimeFormated[1] = minutes;
        }

        if (minutes == 60)
        {
            hours++;
            minutes = 0;
            TimeFormated[0] = hours;

        }

        return TimeFormated;
    }

    public void GameOver()
    {
        uIScreen.ShowGameOverPanel(timeFormated);
        isGameOver=true;
    }
}
