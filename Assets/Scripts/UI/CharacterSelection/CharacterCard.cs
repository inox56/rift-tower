using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private int characterId;

    [SerializeField] private Color unlockColor;
    [SerializeField] private Color lockColor;

    [SerializeField] private GameObject player1Overlay;
    [SerializeField] private GameObject player2Overlay;

    [SerializeField] private Button button;

    [SerializeField] private bool isPlayer1Hovering = false;
   [SerializeField] private bool isPlayer2Hovering = false;

    public void SetImage(Image image)
    {
        icon = image;
    }

    public void SetDisabled()
    {
        player1Overlay.SetActive(false);
        player2Overlay.SetActive(false);
        button.interactable = false;
    }

    public void GreyishIcon()
    {
        icon.color = lockColor;
    }

    public void DisplayPlayer1Overlay()
    {
        player1Overlay.SetActive(true);
    }

    public void DisplayPlayer2Overlay()
    {
        player2Overlay.SetActive(true);
    }
    public void HidePlayer1Overlay()
    {
        player1Overlay.SetActive(true);
    }

    public void HidePlayer2Overlay()
    {
        player2Overlay.SetActive(true);
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
            DisplayPlayer1Overlay();
        }
        else if (eventData.pointerEnter.CompareTag("Player2"))
        {
            isPlayer2Hovering = true;
            DisplayPlayer2Overlay();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerEnter.CompareTag("Player1"))
        {
            isPlayer1Hovering = false;
            HidePlayer1Overlay();
        }
        else if (eventData.pointerEnter.CompareTag("Player2"))
        {
            isPlayer2Hovering = false;
            HidePlayer2Overlay();
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("selected");
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Debug.Log("deselected");
    }

}
