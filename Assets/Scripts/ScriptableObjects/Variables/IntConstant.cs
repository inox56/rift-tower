using System;
using UnityEngine;


[CreateAssetMenu(fileName = "IntConstant", menuName = "VarTypes/IntConstant", order = 1)]
public class IntConstant : ScriptableObject
{
    [SerializeField] private int value;
    public int Value
    {
        get { return value; }
    }
}