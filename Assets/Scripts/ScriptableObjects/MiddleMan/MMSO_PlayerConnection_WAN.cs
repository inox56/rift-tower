using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConnectionMiddleManSO", menuName = "MiddleMan/MMSO_PlayerConnection_WAN", order = 2)]
public class MMSO_PlayerConnection_WAN : ScriptableObject
{
    // * Events
    public delegate void PlayerConnectionEventHandler(ulong clientId);
    public event PlayerConnectionEventHandler OnPlayerConnected;
    public event PlayerConnectionEventHandler OnPlayerDeconnected;

    /*public delegate void PlayerInitiateEventHandler(ulong clientId);
    public event PlayerInitiateEventHandler OnPlayerInitiate;
    */
    public void PlayerConnectionEventCall(ulong clientId)
    {
        OnPlayerConnected?.Invoke(clientId);
    }
    public void PlayerDeconnectionEventCall(ulong clientId)
    {
        OnPlayerDeconnected?.Invoke(clientId);
    }

    /* public void PlayerInitiateEventCall(ulong clientId)
     {
         OnPlayerInitiate?.Invoke(clientId);
     }*/
}