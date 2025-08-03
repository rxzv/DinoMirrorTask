using Mirror;
using UnityEngine;

/// <summary>
/// спавн объектов
/// </summary>
public class PlayerSpawner : NetworkBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _spawnablePrefab;
    
    [Header("Settings")]
    [SerializeField] private float _spawnDistance = 2f;
    
    private bool _isLocalPlayer;

    private void Start()
    {
        _isLocalPlayer = GetComponent<NetworkIdentity>().isLocalPlayer;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!_isLocalPlayer) return;
            Vector3 spawnPosition = transform.position + transform.forward * _spawnDistance;
            CmdSpawnObject(spawnPosition, Quaternion.identity);
        }
    }

    [Command]
    private void CmdSpawnObject(Vector3 position, Quaternion rotation)
    {
        GameObject newObject = Instantiate(_spawnablePrefab, position, rotation);
        NetworkServer.Spawn(newObject);
    }
}