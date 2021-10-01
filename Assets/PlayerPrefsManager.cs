using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetClientID(TMPro.TMP_InputField inputString)
    {
        if (inputString.text == null)
        {
            return;
        }
        string clientIDText = inputString.text;
        Debug.Log("clientID name saved");
        PlayerPrefs.SetString("ClientID", clientIDText);
    }
    public void SetClientSecret(TMPro.TMP_InputField inputString)
    {
        if (inputString.text == null)
        {
            return;
        }
        string clientSecretText = inputString.text;
        Debug.Log("client secret saved");
        PlayerPrefs.SetString("ClientSecret", clientSecretText);
    }
    public void SetBotAccessToken(TMPro.TMP_InputField inputString)
    {
        if (inputString.text == null)
        {
            return;
        }
        string botAccessText = inputString.text;
        Debug.Log("client secret saved");
        PlayerPrefs.SetString("BotAccessToken", botAccessText);
    }
    public void SetBotRefreshToken(TMPro.TMP_InputField inputString)
    {
        if (inputString.text == null)
        {
            return;
        }
        string botRefreshText = inputString.text;
        Debug.Log("client secret saved");
        PlayerPrefs.SetString("BotRefreshToken", botRefreshText);
    }
    public void SetChannelName(TMPro.TMP_InputField inputString)
    {
        string channelName = inputString.text;
        PlayerPrefs.SetString("ChannelName", channelName);
    }
    public void SetBotName(TMPro.TMP_InputField inputString)
    {
        string channelName = inputString.text;
        PlayerPrefs.SetString("BotName", channelName);
    }
    public string GetChannelName()
    {
        if (PlayerPrefs.HasKey("ChannelName"))
        {
            return PlayerPrefs.GetString("ChannelName");
        }
        else
        {
            return "";
        }
    }
    public string GetBotName()
    {
        if (PlayerPrefs.HasKey("BotName"))
        {
            return PlayerPrefs.GetString("BotName");
        }
        else
        {
            return "";
        }
    }
    public string GetClientID()
    {
        return PlayerPrefs.GetString("ClientID");
    }
    public string GetClientSecret()
    {
        return PlayerPrefs.GetString("ClientSecret");
    }
    public string GetBotAccessToken()
    {
        return PlayerPrefs.GetString("BotAccessToken");
    }
    public string GetBotRefreshToken()
    {
        return PlayerPrefs.GetString("BotRefreshToken");
    }
}
