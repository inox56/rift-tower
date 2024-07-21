using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "CharacterMetaData", menuName = "MetaData/Character Meta Data", order = 1)]
public class CharacterMetaData : ScriptableObject
{
    [SerializeField] private int id = -1;
    [SerializeField] private List<int> abilitiesId;
    [SerializeField] private int ability1Id = -1;
    [SerializeField] private int ability2Id = -1;
    [SerializeField] private new string name = "New name";
    [SerializeField] private Sprite icon;
    [SerializeField] private Image imcon;
    [SerializeField] private GameObject characterPrefab;
    [SerializeField] private bool isUnlocked = false;

    public int Id => id;
    public List<int> AbilitiesId => abilitiesId;
    public int Ability1Id => ability1Id;
    public int Ability2Id => ability2Id;
    public string Name => name;
    public Sprite Icon => icon;
    public Image Imcon => imcon;
    public GameObject CharacterPrefab => characterPrefab;
    public bool IsUnlocked => isUnlocked;

    public void Unlock()
    {
        isUnlocked = true;
    }

}