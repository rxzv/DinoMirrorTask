using Mirror;
using UnityEngine;

/// <summary>
/// сетевая коммуникация
/// </summary>
public class PlayerChat : NetworkBehaviour
{
    private bool _isLocalPlayer;

    private void Start()
    {
        _isLocalPlayer = GetComponent<NetworkIdentity>().isLocalPlayer;
    }

    private void Update()
    {
        if (!_isLocalPlayer) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            string nickname = GetComponent<PlayerIdentity>().Nickname;
            CmdSendChatMessage($"Привет от {nickname}");
        }
    }

    [Command]
    private void CmdSendChatMessage(string message)
    {
        RpcShowMessage(message);
    }

    [ClientRpc]
    private void RpcShowMessage(string message)
    {
        Debug.Log($"[CHAT] {message}");
    }
}   