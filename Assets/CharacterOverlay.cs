using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CharacterOverlay : MonoBehaviour
{
    [SerializeField] private int currentX;
    [SerializeField] private int currentY;

    [SerializeField] private GameObject prefab;
    [SerializeField] private Image image;

    [SerializeField] private Sprite overlayP1;
    [SerializeField] private Sprite overlayP2;
    // Start is called before the first frame update
    void Start()
    {
        if (prefab.tag == "Player1")
        {
            image.sprite = overlayP1;
        }
        if (prefab.tag == "Player2")
        {
            image.sprite = overlayP2;
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("dsqdkd");
        }
    }

}
