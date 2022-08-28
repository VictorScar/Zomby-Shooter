using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScreen : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TMP_Text totalLifetimeText;
    [SerializeField] GameObject reloadingText;
    [SerializeField] TMP_Text lifeTimetext;
    [SerializeField] TMP_Text magazineCapacity;
    [SerializeField] TMP_Text healthText;
    StringBuilder stringBuilder;
    void Start()
    {

    }

    void Update()
    {

    }

    public StringBuilder ShowLifetime(int[] timeFormated)
    {
        stringBuilder = new StringBuilder("Время жизни: ");
        for (int i = 0; i < timeFormated.Length; i++)
        {
            int timePart = timeFormated[i];
            if (timePart == 60) timePart = 0;
            stringBuilder.Append(string.Format("{0:00}", timePart));
            if (i < timeFormated.Length - 1)
            {
                stringBuilder.Append(":");
            }
        }

        lifeTimetext.text = stringBuilder.ToString();
        return stringBuilder;
    }

    public void ShowQuantityCartridge(int quantityOfCartridges)
    {
        magazineCapacity.text = quantityOfCartridges + " / " + "%";
    }

    public void ShowHealth(float health)
    {
        if (health >= 0)
        {
            healthText.text = health.ToString() + " HP";
        }
        else healthText.text = "0";
    }

    public void ShowReloading(bool enabled)
    {
        reloadingText.SetActive(enabled);
    }

    public void ShowGameOverPanel(int[] totalLifeTime)
    {
        gameOverPanel.SetActive(true);
        totalLifetimeText.text = ShowLifetime(totalLifeTime).ToString();
    }
}
