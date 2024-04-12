using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHoldSequence : MonoBehaviour
{
    [SerializeField] private float m_expectedDuration;
    private float _duration;
    private float _gazedDuration;

    bool isGazed = false;


    private void Start()
    {
    }

    // Updateden fixed, coroutine veya unitaska alınmalı 
    private void Update()
    {
        _duration += Time.deltaTime;
        if (isGazed)
        {
            _gazedDuration += Time.deltaTime;
        }
        if (_duration >= m_expectedDuration)
        {
            EndObjectSequence();
        }
    }

    private void EndObjectSequence()
    {
        SequenceData.instance.AddSequenceObject(_duration, _gazedDuration, isGazed);
        Debug.Log(gameObject.name + " Player gazed = " + _gazedDuration + " Total expected time = " + m_expectedDuration);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand")) {
            isGazed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            isGazed = false;
        }
    }
}
