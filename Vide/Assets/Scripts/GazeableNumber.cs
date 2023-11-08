using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeableNumber : MonoBehaviour, IGazeUpon
{
    
    
    [SerializeField] private  Animator m_numberAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnGaze()
    {
        m_numberAnimator.SetTrigger("");
    }

    public void NotGazingUpon()
    {

    }


}
