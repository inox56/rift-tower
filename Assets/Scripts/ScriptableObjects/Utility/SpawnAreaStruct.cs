using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "SpawnAreaStruct", menuName = "Struct/Spawn Area Struct", order = 1)]
public class SpawnAreaStruct : ScriptableObject
{
    [SerializeField] private int id = -1;
    [SerializeField] private Vector2 topRightPoint;
    [SerializeField] private Vector2 topLeftPoint;
    [SerializeField] private Vector2 bottomeRightPoint;
    [SerializeField] private Vector2 bottomLeftPoint;


    public int Id => id;
    public Vector2 TopRightPoint => topRightPoint;
    public Vector2 TopLeftPoint => topLeftPoint;
    public Vector2 BottomeRightPoint => bottomeRightPoint;
    public Vector2 BottomLeftPoint => bottomLeftPoint;

}