using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenuController : MonoBehaviour
{

    [SerializeField] private GameObject m_textObj;
    [SerializeField] TextMeshPro m_Text;
    // Start is called before the first frame update
    void Start()
    {
        if (GameData.instance != null)
        {
            m_textObj.SetActive(GameData.instance.isTextOn);
            Debug.LogError("Changing Text");
        }
        else
        {
            Debug.LogError("No game data found");
        }
        m_Text.text = m_textObj.activeSelf ? "Kapa" : "A�";
    }


    public void ChangeActiveText()
    {
        m_textObj.SetActive(!m_textObj.activeSelf);

        if (GameData.instance != null)
        {
            GameData.instance.isTextOn = m_textObj.activeSelf;
        }
        m_Text.text = m_textObj.activeSelf ? "Kapa" : "A�";

    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
