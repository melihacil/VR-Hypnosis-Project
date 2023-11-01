using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberAnimation : MonoBehaviour
{


    public static NumberAnimation Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    [SerializeField] private List<GameObject> m_NumberObj;


    [ContextMenu("Number Anim Play")]
    public void StartAnimations()
    {
        if (m_NumberObj.Count ==0)
        {
            return;
        }
        m_NumberObj[0].SetActive(true);
    }


    int m_Turn = 0;


    [ContextMenu("Number Anim Test")]
    public void NumberAnimations()
    {
        if (m_Turn.Equals( m_NumberObj.Count - 1))
        {
            m_NumberObj[m_Turn].SetActive(false);
            m_Turn = 0;
            return;
        }
        m_Turn++;
        //m_NumberObj.RemoveAt(0);
        m_NumberObj[m_Turn].SetActive(true);
        m_NumberObj[m_Turn - 1].SetActive(false);

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(""))
        {
            //
            return;
        }

        // other code
    }
}
