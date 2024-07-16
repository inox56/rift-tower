using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "CharactersDatabase", menuName = "Database/Characters Database", order = 1)]
public class CharactersDatabase : ScriptableObject
{
    [SerializeField] private CharacterMetaData[] characterMetaData = new CharacterMetaData[0];

    public CharacterMetaData[] CharacterMetaData { get { return characterMetaData; } }

    public CharacterMetaData getCharacterMetaDataById(int id)
    {
        foreach (var character in characterMetaData)
        {
            if (character.Id == id) return character;
        }
        return null;
    }

    public CharacterMetaData getCharacterMetaDataByName(string name)
    {
        foreach (var character in characterMetaData)
        {
            if (character.Name == name) return character;
        }
        return null;
    }

    public GameObject GetCharacterPrefabByID(int id)
    {
        foreach (CharacterMetaData entry in characterMetaData)
        {
            if (entry.Id == id)
            {
                return entry.CharacterPrefab;
            }
        }
        return null;
    }
}