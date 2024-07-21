using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class CharacterGridManager_WAN : NetworkBehaviour
{
    [SerializeField] private List<CharacterCard_WAN> characterCardsList = new List<CharacterCard_WAN>();
    [SerializeField] private CharactersDatabase characterDatabase;
    [SerializeField] private BuildingsDatabase buildingDatabase;
    

    [ServerRpc(RequireOwnership =false)]
    public void DisplayCharactersCardsServerRpc()
    {
        if(IsServer && IsOwner)
        {
            foreach (var player in NetworkManager.Singleton.ConnectedClients)
            {
                ActivateCharacterCardClientRpc(player.Key);
            }
        }
    }

    [ClientRpc]
    public void ActivateCharacterCardClientRpc(ulong clientId)
    {
        if(clientId == NetworkManager.Singleton.LocalClientId)
        {
            Debug.Log("test");
            for (int i = 0; i < characterDatabase.CharacterMetaData.Length; i++)
            {
                characterCardsList[i].SetImage(characterDatabase.CharacterMetaData[i].Imcon);
                characterCardsList[i].SetCharId(characterDatabase.CharacterMetaData[i].Id);
                if (!characterDatabase.CharacterMetaData[i].IsUnlocked)
                {
                    characterCardsList[i].GreyishIcon();
                }

                characterCardsList[i].ActivateCard();
            }
        }
    }

    public void Start()
    {
        DisplayCharactersCardsServerRpc();
    }


}
