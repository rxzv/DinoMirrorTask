using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField nicknameInput;

    public void SaveNickname()
    {
        PlayerPrefs.SetString("PlayerNick", nicknameInput.text);
    }
}