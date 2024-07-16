using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCard : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private int characterId;

    [SerializeField] private Color unlockColor;
    [SerializeField] private Color lockColor;

    [SerializeField] private GameObject player1Overlay;
    [SerializeField] private GameObject player2Overlay;

    [SerializeField] private Button button;

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

}
