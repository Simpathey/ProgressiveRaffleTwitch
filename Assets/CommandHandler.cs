using UnityEngine;
using TwitchLib.Client.Events;
using System.Collections.Generic;
using System;

public class CommandHandler : MonoBehaviour
{
    public DataManager dataManager;
    public TwitchClient twitchClient;
    public Dictionary<string, int> playerWeightedJSON = new Dictionary<string, int>();
    public List<string> currentRaffle = new List<string>();
    public List<string> playerNames = new List<string>();
    bool raffleOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        playerWeightedJSON = dataManager.Load();
    }

    public void FilterCommand(OnChatCommandReceivedArgs e)
    {
        if (!raffleOpen)  return; 
        
        if (e.Command.CommandText == "me")
        {
            string displayName = e.Command.ChatMessage.DisplayName;
             if (!playerNames.Contains(displayName))
            {
                if (playerWeightedJSON.ContainsKey(displayName))
                {
                    IncrimentPlayerInJSON(displayName);
                }
                else
                {
                    AddPlayerToJSON(displayName);
                }
                AddPlayerToRaffle(displayName);
            }
        }
        
    }

    private void AddPlayerToRaffle(string displayName)
    {

            for (int i = 0; i < playerWeightedJSON[displayName]; i++)
            {
                currentRaffle.Add(displayName);
            }
            playerNames.Add(displayName);

    }

    public void ChooseWinner()
    {
        twitchClient.SendChatMessage(currentRaffle[UnityEngine.Random.Range(0, currentRaffle.Count)] + " You are the Winner!!!" );
    }

    public void ResetDrawing()
    {
        playerNames.Clear();
        currentRaffle.Clear();
    }

    public void AddPlayerToJSON(string displayName)
    {
        playerWeightedJSON.Add(displayName, 1);
        dataManager.NewSave(playerWeightedJSON);
    }
    public void IncrimentPlayerInJSON(string displayName)
    {
        playerWeightedJSON[displayName] ++;
        dataManager.NewSave(playerWeightedJSON);
    }
    public void OpenRaffle()
    {
        twitchClient.SendChatMessage("Raffle is now open type !me to join");
        raffleOpen = true;
    }
    public void CloseRaffle()
    {
        twitchClient.SendChatMessage("Raffle is now closed!");
        raffleOpen = false;
    }

}
