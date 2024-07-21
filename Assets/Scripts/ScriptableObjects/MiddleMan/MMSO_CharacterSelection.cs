using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSelectionMiddleManSO", menuName = "MiddleMan/MMSO_CharacterSelection", order = 1)]
public class MMSO_CharacterSelection : ScriptableObject
{
    // * Events
    public delegate void characterSelectionEventHandler(int attribute);
    public event characterSelectionEventHandler OnCharacterSelected;

    public void setCharacterIdEventCall(int characterId)
    {
        OnCharacterSelected?.Invoke(characterId);
    }

    public delegate void characterSelectionEventHandler_WAN(ulong clientId, int attribute);
    public event characterSelectionEventHandler_WAN OnCharacterSelected_WAN;

    public void setCharacterIdEventCall_WAN(ulong clientId, int characterId)
    {
        OnCharacterSelected_WAN?.Invoke(clientId, characterId);
    }
}
