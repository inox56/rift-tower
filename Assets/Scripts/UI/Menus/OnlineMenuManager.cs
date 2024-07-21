using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class OnlineMenuManager : MonoBehaviour
{
    // Start is called before the first frame update

    private string gameSceneName; // Nom de votre sc�ne de lobby ou de jeu

    public void StartHost()
    {
        // D�marrer le serveur et devenir l'h�te
        NetworkManager.Singleton.StartHost();
        GameSceneManager.Instance.ChangeSceneInNetworkGame("LocalSelection_WAN");
    }

    public void StartClient()
    {
        // D�marrer en tant que client
        /*var transport = NetworkManager.Singleton.gameObject.GetComponent<Unity.Netcode.Transports.UTP.UnityTransport>();
        string serverAddress = "127.0.0.1";
        ushort serverPort = 7778;
        transport.SetConnectionData(serverAddress, serverPort); // Utilisez le port appropri�*/
        Debug.Log("client!");
        NetworkManager.Singleton.StartClient();
    }
}
