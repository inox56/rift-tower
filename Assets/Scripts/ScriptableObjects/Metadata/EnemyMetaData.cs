using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "EnemiesMetaData", menuName = "MetaData/Enemy Meta Data", order = 2)]
public class EnemyMetaData : ScriptableObject
{
    [SerializeField] private int id = -1;
    [SerializeField] private new string name = "New name";
    [SerializeField] private Sprite icon;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private int instancesAmount;


    public int Id => id;
    public string Name => name;
    public Sprite Icon => icon;
    public Enemy EnemyPrefab => enemyPrefab;
    public int InstancesAmount => instancesAmount;

}