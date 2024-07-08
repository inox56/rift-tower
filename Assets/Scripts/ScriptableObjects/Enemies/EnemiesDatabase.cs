using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "EnemiesDatabase", menuName = "Database/Enemies Database", order = 2)]
public class EnemiesDatabase : ScriptableObject
{
    [SerializeField] private EnemyMetaAttributes[] enemyMetaAttributes = new EnemyMetaAttributes[0];

    public EnemyMetaAttributes[] EnemyMetaAttributes { get { return enemyMetaAttributes; } }

    public EnemyMetaAttributes getEnemyMetaAttributeById(int id)
    {
        foreach (var enemy in enemyMetaAttributes)
        {
            if (enemy.Id == id) return enemy;
        }
        return null;
    }

    public EnemyMetaAttributes getEnemyMetaAttributeByName(string name)
    {
        foreach (var enemy in enemyMetaAttributes)
        {
            if (enemy.Name == name) return enemy;
        }
        return null;
    }

    public Enemy GetEnemyPrefabByID(int id)
    {
        foreach (EnemyMetaAttributes entry in enemyMetaAttributes)
        {
            if (entry.Id == id)
            {
                return entry.EnemyPrefab;
            }
        }
        return null;
    }
}