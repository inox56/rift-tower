using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CharacterInfosSection_WAN : NetworkBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Image characterImage;
    [SerializeField] private TMP_Text CharacterName;
    [SerializeField] private Image ability1Image;
    [SerializeField] private TMP_Text ability1Text;
    [SerializeField] private Image ability2Image;
    [SerializeField] private TMP_Text ability2Text;

    [SerializeField] private CharactersDatabase characterDatabase;
    [SerializeField] private AbilitiesDatabase abilityDatabase;

    [SerializeField] private NetworkVariable<int> characterId;

    [SerializeField] public int CharacterId {
        get { return characterId.Value; }
        set { characterId.Value = value; }    
    }

    public void setCharacterId(int charId)
    {
        characterId.Value = charId;
    }

    public void LoadCharacterInfo(int charId)
    {
        var character = characterDatabase.getCharacterMetaDataById(charId);

        characterImage.sprite = character.Icon;
        CharacterName.text = character.name;
    }

    public void LoadAbiltiesInfos(int charId)
    {
        var character = characterDatabase.getCharacterMetaDataById(charId);
        var ability1 = abilityDatabase.getAbilityMetaAttributeById(character.Ability1Id);
        var ability2 = abilityDatabase.getAbilityMetaAttributeById(character.Ability2Id);

        ability1Image.sprite = ability1.Icon;
        ability1Text.text = ability1.name;

        ability2Image.sprite = ability2.Icon;
        ability2Text.text = ability2.name;

    }

    [ServerRpc]
    public void synchronizeCharacterServerRpc()
    {
        LoadCharacterInfo(characterId.Value);
        LoadAbiltiesInfos(characterId.Value);
        if(characterId.Value == 0)
        {
            synchronizeCharacterClientRpc();
        }
    }

    [ClientRpc]
    public void synchronizeCharacterClientRpc()
    {
        LoadCharacterInfo(characterId.Value);
        LoadAbiltiesInfos(characterId.Value);
    }
}
