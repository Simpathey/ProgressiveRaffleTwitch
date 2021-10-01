using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using System;
using System.Linq;

public class DataManager : MonoBehaviour
{
    public Dictionary<string, int> data;
    string file = "ProgressiveRaffle.txt";

    public void NewSave(Dictionary<string, int> playerData)
    {
       //AAAAAAAAAHHHHHHHHHHHHHHHH
        var list = playerData.Select(x => new Tuple<string, int>(x.Key, x.Value)).ToList();
        //Code saves at this point to our text file 
        //List<KeyValuePair<string, int>> list = playerData.ToList();
        Debug.Log(list.GetType());
        string json = JsonUtility.ToJson(list);
        System.IO.File.WriteAllText(@"D:\SimpaGameBotData\ProgressiveRaffle.txt", json);
    }

    public Dictionary<string, int> Load()
    {
       data = new Dictionary<string, int>();
       string json = ReadFromFile(file);
       return JsonUtility.FromJson<Dictionary<string,int>>(json);
        //JsonUtility.FromJsonOverwrite(json, data);
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
