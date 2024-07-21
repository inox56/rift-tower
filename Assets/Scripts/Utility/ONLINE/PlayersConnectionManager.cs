using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.VisualScripting;
using System.Linq;

public class PlayersConnectionManager : MonoBehaviour
{
    [SerializeField] ushort maxPlayer = 2;
    public Dictionary<ulong, GameObject> playersList = new Dictionary<ulong, GameObject>();
    [SerializeField] public List<ulong> playersClientId = new List<ulong>();

    [SerializeField] private MMSO_PlayerConnection_WAN playerConnectionManager;
    public static PlayersConnectionManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject); // Optionnel, pour persister entre les scènes
        }
    }

    private void Start()
    {
        // S'abonner aux événements de connexion et de déconnexion
        NetworkManager.Singleton.OnClientConnectedCallback += PlayerConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback += PlayerDisconnected;

    }

    private void OnDisable()
    {
        // Se désabonner pour éviter des références erronées
        if (NetworkManager.Singleton == null) return;

        NetworkManager.Singleton.OnClientConnectedCallback -= PlayerConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback -= PlayerDisconnected;
    }

    private void PlayerConnected(ulong clientId)
    {
        if (NetworkManager.Singleton.IsServer)
        {
            Debug.Log("Nombre de client" + NetworkManager.Singleton.ConnectedClients.Count);
            if (NetworkManager.Singleton.ConnectedClients.Count > maxPlayer)
            {
                NetworkManager.Singleton.DisconnectClient(clientId);
            }
            else { 
                // if player not in List
                if (!playersList.ContainsKey(clientId))
                {
                    playersList.Add(clientId, NetworkManager.Singleton.ConnectedClients[clientId].PlayerObject.ConvertTo<GameObject>());
                    //playersList[clientId].GetComponentInParent<PlayersLogic_WAN>().netId.Value = clientId;
                }
                else
                {
                    playersList[clientId] = NetworkManager.Singleton.ConnectedClients[clientId].PlayerObject.ConvertTo<GameObject>();
                    //playersList[clientId].GetComponentInParent<PlayersLogic_WAN>().netId.Value = clientId;
                }
                // if player not in List
                if (!playersClientId.Contains(clientId))
                {
                    playersClientId.Add(clientId);
                }

                playerConnectionManager.PlayerConnectionEventCall(clientId);
            }
        }
    }

    private void PlayerDisconnected(ulong clientId)
    {
        if (NetworkManager.Singleton.IsServer)
        {
            Debug.Log($"Joueur déconnectd : {clientId}");
            playersList.Remove(clientId);

            playersClientId.Remove(clientId);

            playerConnectionManager.PlayerDeconnectionEventCall(clientId);
        }
    }

    public GameObject GetPlayerPrefab(ulong clientId)
    {
        if (playersList.TryGetValue(clientId, out GameObject playerPrefab))
        {
            return playerPrefab;
        }
        else
        {
            Debug.LogError($"Aucun prefab de joueur trouvé pour l'ID client : {clientId}");
            return null;
        }
    }
}
