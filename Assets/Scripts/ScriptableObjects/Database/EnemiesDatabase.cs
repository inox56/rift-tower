using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "EnemiesDatabase", menuName = "Database/Enemies Database", order = 2)]
public class EnemiesDatabase : ScriptableObject
{
    [SerializeField] private EnemyMetaData[] enemyMetaData = new EnemyMetaData[0];

    public EnemyMetaData[] EnemyMetaData { get { return enemyMetaData; } }

    public EnemyMetaData getEnemyMetaAttributeById(int id)
    {
        foreach (var enemy in enemyMetaData)
        {
            if (enemy.Id == id) return enemy;
        }
        return null;
    }

    public EnemyMetaData getEnemyMetaAttributeByName(string name)
    {
        foreach (var enemy in enemyMetaData)
        {
            if (enemy.Name == name) return enemy;
        }
        return null;
    }

    public Enemy GetEnemyPrefabByID(int id)
    {
        foreach (EnemyMetaData entry in enemyMetaData)
        {
            if (entry.Id == id)
            {
                return entry.EnemyPrefab;
            }
        }
        return null;
    }
}