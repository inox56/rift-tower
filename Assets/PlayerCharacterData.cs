using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterData : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int characterId = 11;

    public int GetCharacterId()
    {
        return characterId;
    }
}
