using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "AbilitiesMetaData", menuName = "MetaData/Ability Meta Data", order = 2)]
public class AbilityMetaData : ScriptableObject
{
    [SerializeField] private int id = -1;
    [SerializeField] private int characterId = -1;
    [SerializeField] private new string name = "New name";
    [SerializeField] private Sprite icon;
    [SerializeField] private Ability abilityPrefab;


    public int Id => id;
    public int CharacterId => characterId;
    public string Name => name;
    public Sprite Icon => icon;
    public Ability AbilityPrefab => abilityPrefab;

}