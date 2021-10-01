using UnityEngine;
using TwitchLib.Unity;
using TwitchLib.Client.Models;
using TwitchLib.Client.Events;

public class TwitchClient : MonoBehaviour
{
    public Client client;
    public TwitchAPI twitchAPI;
    public PlayerPrefsManager playerPrefsManager;
    public CommandHandler commandHandler;
    //  public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        ConnectClient();
    }

    public void ConnectClient()
    {
        Debug.Log("client is attempting to connect");
        Application.runInBackground = true;

        ConnectionCredentials creds = new ConnectionCredentials(playerPrefsManager.GetBotName(), playerPrefsManager.GetBotAccessToken()); //BOT NAME
        client = new Client();
        client.Initialize(creds, playerPrefsManager.GetChannelName());

        //subscribe to events
        client.OnChatCommandReceived += CommandMessageReceived;
        client.OnConnected += ClientConnected;

        client.Connect();
    }

    private void ClientConnected(object sender, OnConnectedArgs e)
    {
        Debug.Log("CLIENT CONNECTED");
        Debug.Log(e.BotUsername);
        Debug.Log(e.AutoJoinChannel);
        Debug.Log(client.JoinedChannels.Count);
        twitchAPI.APIConnection();
    }

    private void CommandMessageReceived(object sender, OnChatCommandReceivedArgs e)
    {
        commandHandler.FilterCommand(e);
    }

    public void SendChatMessage(string messege)
    {
        client.SendMessage(playerPrefsManager.GetChannelName(),messege);
    }
}
