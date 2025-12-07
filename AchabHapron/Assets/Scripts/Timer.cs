using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;

    [SerializeField] float remainingTimeInSeconds;

    public GameObject Victoire;
    public GameObject Objectif;
    public GameObject Viseur;
    public GameObject TimerText;

    void Update()
    {
        if (remainingTimeInSeconds > 0)
            remainingTimeInSeconds -= Time.deltaTime;

        if (remainingTimeInSeconds < 0)
        {
            remainingTimeInSeconds = 0;
            timerText.color = Color.red;
            Victoire.SetActive(true);
            Objectif.SetActive(false);
            Viseur.SetActive(false);
            TimerText.SetActive(false);
        }
        int minutes = Mathf.FloorToInt(remainingTimeInSeconds / 60);
        int secondes = Mathf.FloorToInt(remainingTimeInSeconds % 60);

        timerText.text = "Temps restant : " + string.Format("{0:00}:{1:00}", minutes, secondes);
    }
}
