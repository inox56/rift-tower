using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerLobbyPanel_WAN : NetworkBehaviour
{
    [SerializeField] private int panelId;
    [SerializeField] private ulong playerIndex; 

    [SerializeField] private GameObject panelTouchButton;
    [SerializeField] private GameObject characterInfoPanel;
    [SerializeField] private GameObject BuildPanel;
    [SerializeField] private GameObject ReadyPanel;

    [SerializeField] private MMSO_CharacterSelection characterSelectionMMSO;

    public GameObject CharacterInfoPanel => characterInfoPanel;

    public void Start()
    {
        characterSelectionMMSO.OnCharacterSelected_WAN += CharacterChange;
    }

    public void UnhideCharacterPanel()
    {
        panelTouchButton.SetActive(false);
        characterInfoPanel.SetActive(true);
        BuildPanel.SetActive(true);
    }
    public void HideCharacterPanel()
    {
        panelTouchButton.SetActive(false);
        characterInfoPanel.SetActive(true);
        BuildPanel.SetActive(true);
    }

    public void ActivateSection(GameObject go)
    {
        go.SetActive(true);
    }
    public void DeativateSection(GameObject go)
    {
        go.SetActive(false);
    }

    public void SetPlayerIndex(ulong index)
    {
        playerIndex = index;
    }


    public void CharacterChange(ulong clientId, int charId)
    {
        if(clientId == playerIndex)
        {
            ChangeCaracterSectionServerRpc(charId);
        }
    }

    [ServerRpc(RequireOwnership =false)]
    public void ChangeCaracterSectionServerRpc(int charId)
    {
        characterInfoPanel.ConvertTo<CharacterInfosSection_WAN>().setCharacterId(charId);
        characterInfoPanel.ConvertTo<CharacterInfosSection_WAN>().LoadCharacterInfo(charId);
        characterInfoPanel.ConvertTo<CharacterInfosSection_WAN>().LoadAbiltiesInfos(charId);

        ChangeCaracterSectionClientRpc(charId);
    }


    [ClientRpc]
    public void ChangeCaracterSectionClientRpc(int charId)
    {
        characterInfoPanel.ConvertTo<CharacterInfosSection_WAN>().LoadCharacterInfo(charId);
        characterInfoPanel.ConvertTo<CharacterInfosSection_WAN>().LoadAbiltiesInfos(charId);
    }





}
