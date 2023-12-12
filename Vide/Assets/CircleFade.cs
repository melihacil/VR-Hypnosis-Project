using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFade : MonoBehaviour
{
    [Range(0.01f, 10f)]
    [SerializeField] private float m_startScale;

    [Range(1f, 20f), SerializeField] float m_endScale;
    [SerializeField] private float m_duration = 4f;

    [SerializeField] private Transform m_targetTransform;
    bool isScaling = false;

    void Start()
    {
        if (m_targetTransform.Equals(null))
        {
            m_targetTransform = transform;
        }
    }


    [ContextMenu("Test Scale Fading")]
    public void StartCircleFade()
    {
        StartCoroutine(FadeRoutine(m_duration));
    }

    IEnumerator FadeRoutine(float duration)
    {
        if (isScaling) yield break;
        isScaling = true;


        float counter = 0.0f;

        Vector3 startScale = m_targetTransform.localScale;
        Vector3 endScale = new Vector3(m_targetTransform.localScale.x + m_endScale,
            m_targetTransform.localScale.y,
            m_targetTransform.localScale.z + m_endScale);

        while (counter < duration)
        {

            counter += Time.deltaTime;

            m_targetTransform.localScale = Vector3.Lerp(startScale, endScale, counter / duration);
            yield return null;
        }

        isScaling = false;
    }
}
