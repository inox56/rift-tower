using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CharacterGridManager : MonoBehaviour
{
    [SerializeField] private List<CharacterCard> characterCardsList = new List<CharacterCard>();
    [SerializeField] private Vector2[] arr1;
    [SerializeField] private Dictionary<string, Vector2> dic = new Dictionary<string, Vector2>();
    [SerializeField] private CharactersDatabase characterDatabase;
    [SerializeField] private int maxX;
    [SerializeField] private int maxY;


    public void Initiate()
    {
        arr1 = new Vector2[characterCardsList.Count];
    }
    public void ActivateCharacterCard()
    {
        Debug.Log(characterDatabase.CharacterMetaData.Length);
        for (int i = 0; i < characterDatabase.CharacterMetaData.Length; i++)
        {
            characterCardsList[i].SetImage(characterDatabase.CharacterMetaData[i].Imcon);
            characterCardsList[i].SetCharId(characterDatabase.CharacterMetaData[i].Id);
            characterCardsList[i].ActivateCard();
        }

        StartCoroutine(CoWaitForPosition());
    }

    IEnumerator CoWaitForPosition()
    {
        yield return new WaitForSeconds(0.1f);
        int currentX = 0;
        int currentY = 0;

        for (int i = 0; i < characterCardsList.Count; i++)
        {
            string result = currentX.ToString() + currentY.ToString();
            dic.Add(result, characterCardsList[i].gameObject.transform.position);
            Debug.Log(dic.Values);
            currentX++;
            if (currentX == maxX)
            {
                currentY++;
                currentX = 0;
            }

        }
    }

    public void Start()
    {
        Initiate();
        ActivateCharacterCard();
    }

    public void FillDictionnaray()
    {




    }



}
