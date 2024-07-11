using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "BuildingMetaData", menuName = "MetaData/Building Meta Data", order = 1)]
public class BuildingMetaData : ScriptableObject
{
    [SerializeField] private int id = -1;
    [SerializeField] private new string name = "New name";
    [SerializeField] private Sprite icon;
    [SerializeField] private GameObject buildingPrefab;
    [SerializeField] private int maxInstancesAmount;

    public int Id => id;
    public string Name => name;
    public Sprite Icon => icon;
    public GameObject BuildingPrefab => buildingPrefab;
    public int MaxInstancesAmount => maxInstancesAmount;

}