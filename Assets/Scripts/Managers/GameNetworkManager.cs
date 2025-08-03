using Mirror;
using UnityEngine;

/// <summary>
/// кастомный сетевой менеджер
/// отвечает за запуск хоста/клиента и управление сетевым окружением
/// </summary>
public class GameNetworkManager : NetworkManager
{
    [SerializeField] private UIManager _uiManager;
    public override void OnClientConnect()
    {
        _uiManager.ShowNicknamePanel();
    }
    
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        GameObject player = Instantiate(playerPrefab);
        NetworkServer.AddPlayerForConnection(conn, player);
    }
}
