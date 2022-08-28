using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject reloadingText;
    [SerializeField] TMP_Text lifeTimetext;
    float lifetime = 0f;
    int seconds = 0;
    int minutes = 0;
    int hours = 0;

    public static Game GameInstance { get; private set; }
    public Player Player { get => player; set => player = value; }
    public GameObject ReloadingText { get => reloadingText; }

    void Awake()
    {
        if (GameInstance == null)
        {
            GameInstance = this;
        }
    }

    void Update()
    {
        Timer();
    }

    public void Timer()
    {
        lifetime += Time.deltaTime;
        //Debug.Log(lifetime.ToString());
        seconds = (int)(lifetime / 60);
       // Debug.Log("Seconds: " + seconds.ToString());

        minutes = (int)seconds / 60;
        Debug.Log("Minutes: " + minutes.ToString() + "Seconds: " + seconds.ToString());


        lifeTimetext.text = string.Format(CultureInfo.InvariantCulture,"{0:00:00:00}", hours, minutes, seconds);

    }
}
