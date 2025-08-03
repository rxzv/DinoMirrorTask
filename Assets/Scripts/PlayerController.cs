using Mirror;
using TMPro;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 5f;
    private CharacterController characterController;

    [Header("Nickname")]
    [SyncVar(hook = nameof(OnNicknameChanged))] 
    public string nickname;
    [SerializeField] private TMP_Text nicknameText;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        
        if (isLocalPlayer)
        {
            string defaultNick = "Player" + Random.Range(1000, 9999);
            CmdSetNickname(PlayerPrefs.GetString("PlayerNick", defaultNick));
        }
    }

    [Command]
    private void CmdSetNickname(string newNickname)
    {
        nickname = newNickname;
    }

    private void OnNicknameChanged(string oldNick, string newNick)
    {
        nicknameText.text = newNick;
    }

    private void Update()
    {
        if (!isLocalPlayer) return;

        // Движение WASD
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        characterController.Move(move * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdSendChatMessage();
        }
    }

    [Command]
    private void CmdSendChatMessage()
    {
        RpcShowMessage($"Привет от {nickname}");
    }

    [ClientRpc]
    private void RpcShowMessage(string message)
    {
        Debug.Log(message);
    }
}