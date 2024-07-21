using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLobbyPanel : MonoBehaviour
{
    [SerializeField] private int panelId;
    [SerializeField] private int playerIndex;

    [SerializeField] private GameObject panelTouchButton;
    [SerializeField] private GameObject CharacterInfoPanel;
    [SerializeField] private GameObject BuildPanel;
    [SerializeField] private GameObject ReadyPanel;

    // Start is called before the first frame update
    public void HandlePlayerJoin(PlayerInput pi)
    {
        if (pi.playerIndex == playerIndex)
        {
            DeativateSection(panelTouchButton);
            ActivateSection(CharacterInfoPanel);
            ActivateSection(BuildPanel);
            //ReadyPanel.SetActive(false);

            Debug.Log(" PlayerConfigurationManager.GetPlayerConfigs().Count" + PlayerConfigurationManager.Instance.GetPlayerConfigs()[playerIndex]);
            Debug.Log(" PlayerConfigurationManager.GetPlayerConfigs().Count" + pi.GetComponent<PlayerCharacterData>().GetCharacterId() );
           
        }
    }

    public void ActivateSection(GameObject go)
    {
        go.SetActive(true);
    }
    public void DeativateSection(GameObject go)
    {
        go.SetActive(false);
    }

    public void SetPlayerIndex(int index)
    {
        playerIndex = index;
    }
}
