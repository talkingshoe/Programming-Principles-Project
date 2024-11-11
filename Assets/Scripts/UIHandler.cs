using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class UIHandler : MonoBehaviour
{
    [SerializeField] TMP_Text playerNameInput;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SetPlayerName()
    {
        PlayerDataHandle.instance.playerName = playerNameInput.text;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
