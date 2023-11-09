using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaze_Manager : MonoBehaviour
{

    [SerializeField] private Camera m_playerCamera;

    [SerializeField] private GameObject m_lastGazedUpon;
    public GameObject LastGazedUpon { get { return m_lastGazedUpon; } }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckGaze();
    }


    void CheckGaze()
    {

        if (m_lastGazedUpon)
        {
            //m_lastGazedUpon.SendMessage("NotRequired", SendMessageOptions.DontRequireReceiver);
        }


        Ray newRay = new Ray(m_playerCamera.transform.position, m_playerCamera.transform.rotation * Vector3.forward);



        RaycastHit newHit;

        Debug.DrawRay(m_playerCamera.transform.position, m_playerCamera.transform.rotation * Vector3.forward, Color.red);
        if (Physics.Raycast(newRay, out newHit, Mathf.Infinity))
        {
            Debug.Log("");
            m_lastGazedUpon = newHit.transform.gameObject;

            m_lastGazedUpon.SendMessage("OnGaze", SendMessageOptions.DontRequireReceiver);
        }



    }
}
