using Mirror;
using UnityEngine;

/// <summary>
/// базовая сетевая сущность игрока
/// </summary>
[RequireComponent(typeof(NetworkIdentity))]
public class PlayerIdentity : NetworkBehaviour
{   
    [SyncVar(hook = nameof(OnNicknameChanged))] 
    private string _nickname = "Player";
    public string Nickname => _nickname;

    private PlayerNickname _nicknameDisplay;
    
    private void Start()
    {
        _nicknameDisplay = GetComponent<PlayerNickname>();
        
        if (isLocalPlayer)
        {
            string defaultNick = "Player" + Random.Range(1000, 9999);
            string savedNick = PlayerPrefs.GetString("PlayerNick", defaultNick);
            CmdSetNickname(savedNick);
        }
        else
        {
            OnNicknameChanged("", _nickname);
        }
    }
    
    [Command]
    private void CmdSetNickname(string newNickname)
    {
        _nickname = newNickname;
    }

    private void OnNicknameChanged(string _, string newNick)
    {
        if (_nicknameDisplay != null)
            _nicknameDisplay.UpdateNickname(newNick);
    }
}