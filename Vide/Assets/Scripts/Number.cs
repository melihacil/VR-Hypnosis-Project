using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour, IGazeUpon
{
    [SerializeField] private Animator m_animator;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }


    private void StartNumberAnimation ()
    {
        m_animator.SetTrigger("StartAnim");
    }
    private bool m_checked = false;
    public void OnGaze()
    {
        if (m_checked)
            return;
        m_checked = true;
        
    }
    private void OnEnable()
    {
        Invoke(nameof(StartNumberAnimation), 0.2f);
    }

    public void ChangeNumber()
    {
        NumberAnimation.Instance.NumberAnimations();
    }

    public void NotGazingUpon()
    {
     //   throw new System.NotImplementedException();
    }
}
