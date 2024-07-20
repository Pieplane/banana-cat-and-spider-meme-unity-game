using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI timerText;
    float elapsedTime;
    public float timeResult;
    public bool isRunning = false;
    public float maxTime = 300f; // Максимальное время в секундах (5 минут)

    private void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        StartTimer();
    }
    private void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= maxTime)
            {
                elapsedTime = maxTime;
                isRunning = false;
            }
            UpdateTimerDisplay();
            TimerDisplay(elapsedTime, out timeResult);
        }
    }

    public void StartTimer()
    {
        isRunning = true;
    }
    public void StopWatch()
    {
        isRunning = false;
    }
    private void ResetStopwatch()
    {
        elapsedTime = 0f;
        UpdateTimerDisplay();
    }
    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60F);
        int seconds = Mathf.FloorToInt(elapsedTime - minutes * 60);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = timeString;
    }
    public void TimerDisplay(float time, out float result)
    {
        result = time;
    }
}
