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

    private void Start()
    {
        if (NumberAnimation.Instance.PlayerTransform != null)
            transform.LookAt(NumberAnimation.Instance.PlayerTransform.position);
        else
            Debug.Log("Player Transform is null");
    }
    public void NotGazingUpon()
    {

    }
    private bool m_checked = false;
    public void OnGaze()
    {
        if (m_checked)
            return;

        m_checked = true;
        m_animator.SetTrigger("StartAnim");
    }

    public void ChangeNumber()
    {
        NumberAnimation.Instance.NumberAnimations();
    }
}
