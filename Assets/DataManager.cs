using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;
using Newtonsoft.Json;

public class DataManager : MonoBehaviour
{
    public Dictionary<string, int> data;
    string file = "ProgressiveRaffle.txt";

    public void NewSave(Dictionary<string, int> playerData)
    {
        //string json = JsonConvert.SerializeObject(playerData, Formatting.Indented);
        //System.IO.File.WriteAllText(@"D:\SimpaGameBotData\ProgressiveRaffle.txt", json);
    }

    public Dictionary<string, int> Load()
    {
       data = new Dictionary<string, int>();
       string json = ReadFromFile(file);
        return data;
    }

    private string ReadFromFile(string fileName)
    {
        string path = @"D:\SimpaGameBotData\ProgressiveRaffle.txt";
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
        {
            Debug.LogWarning("File not Found");
            return "";
        }
    }
}
