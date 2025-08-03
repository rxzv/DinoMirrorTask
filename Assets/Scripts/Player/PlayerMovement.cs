using Mirror;
using UnityEngine;

/// <summary>
/// Управление движением
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : NetworkBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 10f;
    
    private CharacterController _controller;
    private PlayerAnimation _playerAnimation;
    private bool _isLocalPlayer;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _isLocalPlayer = GetComponent<NetworkIdentity>().isLocalPlayer;
    }

    private void Update()
    {
        if (!_isLocalPlayer) return;
        PlayerMover();
    }

    private void PlayerMover()
    {
        Vector3 moveDirection = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
        );

        if (moveDirection.magnitude > 0.1f)
        {
            // Поворот в сторону движения
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                _rotationSpeed * Time.deltaTime
            );

            // Движение
            Vector3 moveVector = moveDirection * _moveSpeed;
            _controller?.Move(moveVector * Time.deltaTime);
        }
        
        _playerAnimation?.SetMovementState(moveDirection.magnitude > 0.1f);
    }
}