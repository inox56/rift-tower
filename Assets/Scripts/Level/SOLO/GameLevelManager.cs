using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameLevelManager : MonoBehaviour
{
    [SerializeField] private List<Transform> targetList = new List<Transform>();
    [SerializeField] private List<Sprite> spawnAreaList = new List<Sprite>();

    public Transform GetTarget()
    {
        int index = Random.Range(0, targetList.Count);

        return targetList[index];
    }

    public int ChooseSpawnArea()
    {
        int index = Random.Range(0, spawnAreaList.Count);
        return index;
    }

    public List<float> GetSpawnArea()
    {
        int i = ChooseSpawnArea();
        Sprite sprite = spawnAreaList[i];
        Bounds bounds = sprite.bounds;

        List<float> vector2 = new List<float>
        {
            bounds.min.x,
            bounds.max.x,
            bounds.min.y,
            bounds.max.y
        };
        return vector2;
    }                           

}
