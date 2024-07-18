using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLobbyPanel : MonoBehaviour
{
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
            panelTouchButton.SetActive(false);
            CharacterInfoPanel.SetActive(true);
            BuildPanel.SetActive(true);
            //ReadyPanel.SetActive(false);

            Debug.Log(" PlayerConfigurationManager.GetPlayerConfigs().Count" + PlayerConfigurationManager.Instance.GetPlayerConfigs()[playerIndex]);
            Debug.Log(" PlayerConfigurationManager.GetPlayerConfigs().Count" + pi.GetComponent<PlayerCharacterData>().GetCharacterId() );
           
        }
    }


}
