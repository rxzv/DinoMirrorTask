using Mirror;
using UnityEngine;
/// <summary>
/// управление анимациями
/// </summary>
[RequireComponent(typeof(NetworkAnimator))]
public class PlayerAnimation : NetworkBehaviour
{
    private Animator _animator;
    
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetMovementState(bool isMoving)
    {
        _animator.SetBool(IsRunning, isMoving);
    }
}