using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CharacterSelectionManager_WAN : NetworkBehaviour
{
    [SerializeField] private GameObject PanelP1;
    [SerializeField] private GameObject PanelP2;

    private Dictionary<int, ulong> playersIdList;

    [SerializeField] private MMSO_PlayerConnection_WAN playersConnectionMMSO;

    public override void OnNetworkSpawn()
    {
       /* if (IsClient)
        {
            CharacterMetaAttribute[] allCharacters = charactersDatabase.getAllCharacterMetaAttribute();

            foreach (var character in allCharacters)
            {
                var selectbuttonInstance = Instantiate(characterButtonPrefab, charactersHolder);
                selectbuttonInstance.SetCharacter(this, character);
            }
            players.OnListChanged += HandlePlayerStateChanged;
        }*/
        if (IsServer)
        {
            NetworkManager.Singleton.OnClientConnectedCallback += OnPlayerJoin;
            NetworkManager.Singleton.OnClientDisconnectCallback += OnPlayerLeft;



            playersIdList = new Dictionary<int, ulong>()
            {
                { 1, 123456789UL },
                { 2, 123456789UL }
            };

            foreach (NetworkClient client in NetworkManager.Singleton.ConnectedClientsList)
            {
                OnPlayerJoin(client.ClientId);
            }
        }
    }
    public void OnPlayerJoin(ulong id)
    {
        foreach (var key in new List<int>(playersIdList.Keys))
        {
            if (playersIdList[key] == 123456789UL)
            {
                // Stocker le ulong par défaut si la valeur est 0
                playersIdList[key] = id;
                changePanelPlayerIdServerRpc(key, id);
                return;
            }
        }
    }

    public void OnPlayerLeft(ulong id)
    {
        foreach (var kvp in playersIdList)
        {
            if (kvp.Value == id)
            {
                // Modifier la valeur associée à la clé trouvée
                playersIdList[kvp.Key] = 123456789UL;
                changePanelPlayerIdServerRpc(kvp.Key, 123456789UL);
            }
        }
    }

    [ServerRpc]
    public void changePanelPlayerIdServerRpc(int i, ulong id)
    {
        if (IsServer)
        {
            if (i == 1)
            {
                PanelP1.ConvertTo<PlayerLobbyPanel_WAN>().SetPlayerIndex(id);
                if(id == 123456789UL)
                {
                    PanelP1.ConvertTo<PlayerLobbyPanel_WAN>().HideCharacterPanel();
                }
                else
                {
                    PanelP1.ConvertTo<PlayerLobbyPanel_WAN>().UnhideCharacterPanel();
                }
            }

            if (i == 2)
            {
                PanelP2.ConvertTo<PlayerLobbyPanel_WAN>().SetPlayerIndex(id);
                if (id == 123456789UL)
                {
                    PanelP2.ConvertTo<PlayerLobbyPanel_WAN>().HideCharacterPanel();
                }
                else
                {
                    PanelP2.ConvertTo<PlayerLobbyPanel_WAN>().UnhideCharacterPanel();
                    PanelP1.ConvertTo<PlayerLobbyPanel_WAN>().CharacterInfoPanel.ConvertTo<CharacterInfosSection_WAN>().synchronizeCharacterServerRpc();
                }
            }
            changePanelPlayerIdClientRpc(i, id);
        }
    }

    [ClientRpc]
    public void changePanelPlayerIdClientRpc(int i, ulong id)
    {
        if (!IsServer )
        {
            if (i == 1)
            {
                PanelP1.ConvertTo<PlayerLobbyPanel_WAN>().SetPlayerIndex(id);
            }

            if (i == 2)
            {
                PanelP2.ConvertTo<PlayerLobbyPanel_WAN>().SetPlayerIndex(id);
            }
        }
    }



}
