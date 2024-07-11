using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "BuildingsDatabase", menuName = "Database/Buildings Database", order = 1)]
public class BuildingsDatabase : ScriptableObject
{
    [SerializeField] private BuildingMetaData[] buildingMetaData = new BuildingMetaData[0];

    public BuildingMetaData[] BuildingMetaData { get { return buildingMetaData; } }

    public BuildingMetaData getBuildingMetaDataById(int id)
    {
        foreach (var building in buildingMetaData)
        {
            if (building.Id == id) return building;
        }
        return null;
    }

    public BuildingMetaData getEnemyMetaDataByName(string name)
    {
        foreach (var building in buildingMetaData)
        {
            if (building.Name == name) return building;
        }
        return null;
    }

    public GameObject GetBuildingPrefabByID(int id)
    {
        foreach (BuildingMetaData entry in buildingMetaData)
        {
            if (entry.Id == id)
            {
                return entry.BuildingPrefab;
            }
        }
        return null;
    }
}