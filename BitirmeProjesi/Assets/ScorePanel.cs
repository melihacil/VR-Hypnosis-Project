using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScorePanel : MonoBehaviour
{

   [SerializeField] private TextMeshPro[] _scoreTexts;

    public void UpdateScoreTexts(string[] texts)
    {
       for (int i = 0; i < texts.Length; i++)
        {
            //Format things here
            _scoreTexts[i].text = texts[i];
        }
        Debug.Log("Texts Updated");
    }
}
