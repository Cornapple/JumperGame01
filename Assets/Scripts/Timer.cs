using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public PlayerStats playerStats;

    [SerializeField] float remainingTime;  
    public Image timerBar;

    public float maxTime;

    public GameObject waterDrop;
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            SceneManager.LoadSceneAsync(1);
        }

        remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);



        timerBar.fillAmount = Mathf.Clamp(remainingTime / maxTime, 0, 1);
    }


}
