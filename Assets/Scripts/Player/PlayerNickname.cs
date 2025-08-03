using TMPro;
using UnityEngine;

/// <summary>
/// отображение ника над игроком
/// </summary>
public class PlayerNickname : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float _verticalOffset = 2f;
    
    [Header("Dependencies")]
    [SerializeField] private TMP_Text _nicknameText;

    private Transform _playerTransform;

    private void Awake()
    {
        _playerTransform = transform;
        if (_nicknameText == null)
            Debug.LogError("TMP_Text не назначен в PlayerNickname!");
    }

    private void Update()
    {
        if (Camera.main == null || _nicknameText == null) return;
        
        _nicknameText.transform.position = _playerTransform.position + Vector3.up * _verticalOffset;
        _nicknameText.transform.rotation = Quaternion.LookRotation(
            _nicknameText.transform.position - Camera.main.transform.position
        );
    }
    public void UpdateNickname(string nickname)
    {
        if (_nicknameText != null) _nicknameText.text = nickname;
    }
}