using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public Dictionary<string, bool> collectedCoins;
    public int[] coinsArray = new int[79];

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        collectedCoins = LoadDictionary(80); // Инициализация collectedCoins при загрузке
        //coinsArray = LoadArray();
        DontDestroyOnLoad(gameObject);
    }
    //private void FixedUpdate()
    //{
    //    foreach (var item in collectedCoins)
    //    {
    //        Debug.Log(item.Key + " " + item.Value);
    //    }
    //}

    public void CollectCoin(string coinName)
    {
        if (collectedCoins.ContainsKey(coinName))
        {

            //collectedCoins[coinName] = !collectedCoins[coinName]; // Инвертирование текущего значения
            collectedCoins[coinName] = true;
            //if (collectedCoins[coinName] == false)
            //{
            //    collectedCoins[coinName] = true;
            //}
            SaveCoins(); // Сохранение изменений при обновлении значения монеты
            Debug.Log($"Coin Manager coin name{coinName} + {collectedCoins[coinName]}");
        }
        else
        {
            //collectedCoins.Add(coinName, true); // Добавление новой монеты
            //SaveCoins(); // Сохранение изменений при добавлении новой монеты
            Debug.Log("Добавлена новая монета");
        }
        //if (coinsArray[int.Parse(coinName)] == 0)
        //{
        //    coinsArray[int.Parse(coinName)] = 1;
        //    SaveCoins();
        //}
        //else
        //{
        //    Debug.Log("Добавлена новая монета");
        //}
    }

    public void SaveCoins()
    {
        SaveDictionary(collectedCoins); // Сохранение словаря
        //Progress.Instance.Save();
        //SaveArray(coinsArray);
    }
    //public void SaveArray(int[] array)
    //{
    //    for (int i = 0; i < array.Length; i++)
    //    {
    //        Progress.Instance.PlayerInfo.IntsCoins[i] = array[i];
    //    }
    //}
    public void SaveDictionary(Dictionary<string, bool> dict)
    {
        foreach (var pair in dict)
        {
            PlayerPrefs.SetInt(pair.Key, pair.Value ? 1 : 0);
            int value = pair.Value ? 1 : 0;
            //Progress.Instance.PlayerInfo.IntsCoins[int.Parse(pair.Key)] = value;
            //int value = Progress.Instance.PlayerInfo.intsCoins[int.Parse(pair.Key)];
        }
    }
    //public int[] LoadArray()
    //{
    //    int[] ints = new int[79];
    //    for (int i = 0; i < ints.Length; i++)
    //    {
    //        ints[i] = Progress.Instance.PlayerInfo.IntsCoins[i];
    //    }
    //    return ints;
    //}

    public Dictionary<string, bool> LoadDictionary(int count)
    {
        Dictionary<string, bool> loadedDict = new Dictionary<string, bool>();

        for (int i = 0; i < count; i++)
        {
            string dictKey = i.ToString();
            int value = PlayerPrefs.GetInt(dictKey, 0); // Загружаем сохраненное значение из PlayerPrefs
            //int value = Progress.Instance.PlayerInfo.IntsCoins[i];
            bool boolValue = value == 1 ? true : false;
            loadedDict.Add(dictKey, boolValue);
        }

        return loadedDict;
    }
}
