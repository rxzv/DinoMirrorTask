using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Отвечает за UI элементы
public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject _nicknamePanel;
    [SerializeField] private TMP_InputField _nicknameInput;
    [SerializeField] private Button _spawnBtn;

    public void ShowNicknamePanel()
    {
        _nicknamePanel.SetActive(true);
        _nicknameInput.text = PlayerPrefs.GetString("PlayerNick", "");
    }

    public void OnSpawnPlayerBtnClicked()
    {
        SaveNickname();
        NetworkClient.Ready();
        NetworkClient.AddPlayer();
        _nicknamePanel.SetActive(false);
    }
    
    public void SaveNickname()
    {
        string nickname = _nicknameInput.text;
        if (string.IsNullOrWhiteSpace(nickname))
            nickname = "Player" + Random.Range(1000, 9999);
        
        PlayerPrefs.SetString("PlayerNick", nickname);
    }
}