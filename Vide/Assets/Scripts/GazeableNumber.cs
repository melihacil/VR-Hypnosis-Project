using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeableNumber : MonoBehaviour, IGazeUpon
{
    
    
    [SerializeField] private  Animator m_numberAnimator;
    

    public void OnGaze()
    {
        m_numberAnimator.SetTrigger("");
    }

    public void NotGazingUpon()
    {

    }


}
