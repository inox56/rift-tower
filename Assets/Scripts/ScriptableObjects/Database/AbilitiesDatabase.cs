using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "AbilitiesDatabase", menuName = "Database/Abilities Database", order = 2)]
public class AbilitiesDatabase : ScriptableObject
{
    [SerializeField] private AbilityMetaData[] abilityMetaData = new AbilityMetaData[0];

    public AbilityMetaData[] AbilityMetaData { get { return AbilityMetaData; } }

    public AbilityMetaData getAbilityMetaAttributeById(int id)
    {
        foreach (var ability in abilityMetaData)
        {
            if (ability.Id == id) return ability;
        }
        return null;
    }

    public AbilityMetaData getAbilityMetaAttributeByName(string name)
    {
        foreach (var ability in abilityMetaData)
        {
            if (ability.Name == name) return ability;
        }
        return null;
    }

    public Ability GetAbilityPrefabByID(int id)
    {
        foreach (AbilityMetaData entry in abilityMetaData)
        {
            if (entry.Id == id)
            {
                return entry.AbilityPrefab;
            }
        }
        return null;
    }
}