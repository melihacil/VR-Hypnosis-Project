using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HypnoseSoundTextController : MonoBehaviour
{

    AudioSource m_AudioSource;
    [SerializeField] TextMeshProUGUI m_TextMeshPro;
    [SerializeField] private string[] m_sceneAudioTexts;
    [SerializeField] private AudioClip[] m_sceneAudioDirections;
    int m_stepIndex = 0;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }


    [ContextMenu("Test Audio and Text Update")]
    public void UpdateAudioAndText()
    {
        if (GameData.instance != null)
        {
            Debug.Log("Getting Test Data");
        }
        else
            Debug.Log("No Game Data");

        if (m_stepIndex.Equals(m_sceneAudioTexts.Length))
            return;

        m_AudioSource.Stop();

        m_AudioSource.clip = m_sceneAudioDirections[m_stepIndex];
        m_TextMeshPro.text = m_sceneAudioTexts[m_stepIndex];

        m_AudioSource.Play();
        m_stepIndex++;

    }
}
