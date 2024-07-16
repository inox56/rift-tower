using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "CharacterMetaData", menuName = "MetaData/Character Meta Data", order = 1)]
public class CharacterMetaData : ScriptableObject
{
    [SerializeField] private int id = -1;
    [SerializeField] private new string name = "New name";
    [SerializeField] private Sprite icon;
    [SerializeField] private Image imcon;
    [SerializeField] private GameObject characterPrefab;
    [SerializeField] private bool isUnlocked = false;

    public int Id => id;
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