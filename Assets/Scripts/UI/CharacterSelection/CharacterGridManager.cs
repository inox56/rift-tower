using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterGridManager : MonoBehaviour
{
    [SerializeField] private List<CharacterCard> characterCardsList = new List<CharacterCard>();

    [SerializeField] private CharactersDatabase characterDatabase;

    
    public void ActivateCharacterCard()
    {
        Debug.Log(characterDatabase.CharacterMetaData.Length);
        for (int i = 0; i < characterDatabase.CharacterMetaData.Length; i++)
        {
            characterCardsList[i].SetImage(characterDatabase.CharacterMetaData[i].Imcon);
            characterCardsList[i].ActivateCard();
        }
    }

    public void Start()
    {
        ActivateCharacterCard();
    }

}
