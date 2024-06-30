using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationClass : MonoBehaviour
{
    [SerializeField] Animation _AnimationClipControl;
    [SerializeField] AnimationClip _AnimationClip;
    [SerializeField] bool _IsPlaying = false;

    // Update is called once per frame
    void Update()
    {
        if (_IsPlaying)
            _AnimationClipControl.Stop();
    }

    void AnimationTest()
    {
       // this.runInEditMode = true;
        _AnimationClipControl.clip = _AnimationClip;
        _AnimationClipControl.Play();
    }
}
