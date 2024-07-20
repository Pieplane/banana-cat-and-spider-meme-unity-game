using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTime : MonoBehaviour
{
    public TextMeshProUGUI currentTimeString;
    public TextMeshProUGUI theBestTimeString;
    public Timer timer;

    float currentTime;
    float theBestTime;
    int buildIndex;

    private void Start()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
        currentTime = timer.timeResult;
        UpdateTimerDisplay(currentTime, currentTimeString);
        theBestTime = GetTheBestTime(buildIndex);
        theBestTime = Compared(currentTime, theBestTime, buildIndex);
        UpdateTimerDisplay(theBestTime, theBestTimeString);
    }
    private float GetTheBestTime(int index)
    {
        switch (index)
        {
            case 0:
                return 0;
            case 1:
                //return PlayerPrefs.GetFloat("TimeGame01", 0f);
                return Progress.Instance.PlayerInfo.TimeGame01;
            case 2:
                //return PlayerPrefs.GetFloat("TimeGame02", 0f);
                return Progress.Instance.PlayerInfo.TimeGame02;
            case 3:
                //return PlayerPrefs.GetFloat("TimeGame03", 0f);
                return Progress.Instance.PlayerInfo.TimeGame03;
            case 4:
                //return PlayerPrefs.GetFloat("TimeGame04", 0f);
                return Progress.Instance.PlayerInfo.TimeGame04;
            case 5:
                //return PlayerPrefs.GetFloat("TimeGame05", 0f);
                return Progress.Instance.PlayerInfo.TimeGame05;
            case 6:
                //return PlayerPrefs.GetFloat("TimeGame06", 0f);
                return Progress.Instance.PlayerInfo.TimeGame06;
            case 7:
                //return PlayerPrefs.GetFloat("TimeGame07", 0f);
                return Progress.Instance.PlayerInfo.TimeGame07;
            case 8:
                //return PlayerPrefs.GetFloat("TimeGame08", 0f);
                return Progress.Instance.PlayerInfo.TimeGame08;
            case 9:
                //return PlayerPrefs.GetFloat("TimeGame09", 0f);
                return Progress.Instance.PlayerInfo.TimeGame09;
            case 10:
                //return PlayerPrefs.GetFloat("TimeGame10", 0f);
                return Progress.Instance.PlayerInfo.TimeGame10;
            default:
                return 0;
        }
    }
    private void SaveTheBestTime(int index, float time)
    {
        switch (index)
        {
            case 0:
                break;
            case 1:
                //PlayerPrefs.SetFloat("TimeGame01", time);
                Progress.Instance.PlayerInfo.TimeGame01 = time;
                break;
            case 2:
                //PlayerPrefs.SetFloat("TimeGame02", time);
                Progress.Instance.PlayerInfo.TimeGame02 = time;
                break;
            case 3:
                //PlayerPrefs.SetFloat("TimeGame03", time);
                Progress.Instance.PlayerInfo.TimeGame03 = time;
                break;
            case 4:
                //PlayerPrefs.SetFloat("TimeGame04", time);
                Progress.Instance.PlayerInfo.TimeGame04 = time;
                break;
            case 5:
                //PlayerPrefs.SetFloat("TimeGame05", time);
                Progress.Instance.PlayerInfo.TimeGame05 = time;
                break;
            case 6:
                //PlayerPrefs.SetFloat("TimeGame06", time);
                Progress.Instance.PlayerInfo.TimeGame06 = time;
                break;
            case 7:
                //PlayerPrefs.SetFloat("TimeGame07", time);
                Progress.Instance.PlayerInfo.TimeGame07 = time;
                break;
            case 8:
                //PlayerPrefs.SetFloat("TimeGame08", time);
                Progress.Instance.PlayerInfo.TimeGame08 = time;
                break;
            case 9:
                //PlayerPrefs.SetFloat("TimeGame09", time);
                Progress.Instance.PlayerInfo.TimeGame09 = time;
                break;
            case 10:
                //PlayerPrefs.SetFloat("TimeGame10", time);
                Progress.Instance.PlayerInfo.TimeGame10 = time;
                break;
            default:
                break;
        }
    }
    private float Compared(float current, float best, int index)
    {
        if(current < best || best <= 0)
        {
            best = current;
            SaveTheBestTime(index, best);
            return best;
        }
        else
        {
            return best;
        }
    }
    private void UpdateTimerDisplay(float time, TextMeshProUGUI timeStringUpdate)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timeStringUpdate.text = timeString;
    }
}
