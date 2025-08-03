using Mirror;
using UnityEngine;

public class CubeSpawner : NetworkBehaviour
{
    [SerializeField] private GameObject cubePrefab;

    private void Update()
    {
        if (!isLocalPlayer) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            CmdSpawnCube();
        }
    }

    [Command]
    private void CmdSpawnCube()
    {
        Vector3 spawnPos = transform.position + transform.forward * 2;
        GameObject cube = Instantiate(cubePrefab, spawnPos, Quaternion.identity);
        NetworkServer.Spawn(cube);
    }
}