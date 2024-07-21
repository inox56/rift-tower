using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterCard_WAN : NetworkBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private int characterId;

    [SerializeField] private Color unlockColor;
    [SerializeField] private Color lockColor;

    [SerializeField] private Button button;

    [SerializeField] private MMSO_CharacterSelection mmso_characterSelection;

    [SerializeField] private bool isPlayer1Hovering = false;
    [SerializeField] private bool isPlayer2Hovering = false;

    public void SetImage(Image image)
    {
        icon.sprite =  image.sprite;
    }
    public void SetCharId(int charId)
    {
        characterId = charId;
    }


    public void SetDisabled()
    {
        button.interactable = false;
    }

    public void GreyishIcon()
    {
        icon.color = lockColor;
    }


    public void ActivateCard()
    {
        this.gameObject.SetActive(true);
    }

    public void DeactivateCard()
    {
        this.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerEnter.CompareTag("Player1"))
        {
            isPlayer1Hovering = true;
        }
        else if (eventData.pointerEnter.CompareTag("Player2"))
        {
            isPlayer2Hovering = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerEnter.CompareTag("Player1"))
        {
            isPlayer1Hovering = false;
        }
        else if (eventData.pointerEnter.CompareTag("Player2"))
        {
            isPlayer2Hovering = false;
        }
    }

    public void SelectionCharacter()
    {
        ulong clientId = NetworkManager.Singleton.LocalClientId;
        mmso_characterSelection.setCharacterIdEventCall_WAN(clientId, characterId);
    }

}
