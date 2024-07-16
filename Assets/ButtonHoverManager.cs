using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHoverManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image image1; // Assign in the Inspector
    public Image image2; // Assign in the Inspector

    private bool isPlayer1Hovering = false;
    private bool isPlayer2Hovering = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerEnter.CompareTag("Player1"))
        {
            isPlayer1Hovering = true;
            ShowImage1();
        }
        else if (eventData.pointerEnter.CompareTag("Player2"))
        {
            isPlayer2Hovering = true;
            ShowImage2();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerEnter.CompareTag("Player1"))
        {
            isPlayer1Hovering = false;
            HideImage1();
        }
        else if (eventData.pointerEnter.CompareTag("Player2"))
        {
            isPlayer2Hovering = false;
            HideImage2();
        }
    }

    private void ShowImage1()
    {
        image1.gameObject.SetActive(true);
        image2.gameObject.SetActive(false);
    }

    private void ShowImage2()
    {
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(true);
    }

    private void HideImage1()
    {
        image1.gameObject.SetActive(false);
    }

    private void HideImage2()
    {
        image2.gameObject.SetActive(false);
    }
}
