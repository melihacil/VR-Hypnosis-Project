using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EyeInteractingSequence : MonoBehaviour
{
    public bool IsHovered { get; set; }

    [SerializeField] UnityEvent<GameObject> OnObjectHover;
    [SerializeField] private float m_expectedDuration;

    [SerializeField] private Material OnHoverActiveMaterial;
    [SerializeField] private Material OnHoverInactiveMaterial;
    [SerializeField] private bool shouldDestroy = false;


    private float _duration;
    private float _gazedDuration;
    private bool isGazed = false;
    private bool isDone = false;

    private MeshRenderer _meshRenderer;

    void Start() => _meshRenderer = GetComponent<MeshRenderer>();

    // Updateden fixed, coroutine veya unitaska alınmalı 
    private void Update()
    {
        _duration += Time.deltaTime;
        if (IsHovered)
        {
            _gazedDuration += Time.deltaTime;
            OnObjectHover?.Invoke(gameObject);
        }
        if (_duration >= m_expectedDuration && !isDone)
        {
            EndObjectSequence();
        }
    }

    private void OnDisable()
    {
        if (!isDone)
        {
            EndObjectSequence();

        }
    }

    private void EndObjectSequence()
    {
        isDone = true;
        SequenceData.instance.AddSequenceObject(_duration, _gazedDuration);
        Debug.Log(gameObject.name + " Player gazed = " + _gazedDuration + " Total expected time = " + m_expectedDuration);
        if (shouldDestroy)
            Destroy(this.gameObject);
    }
}
