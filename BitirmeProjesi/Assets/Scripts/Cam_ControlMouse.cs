using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cam_ControlMouse : MonoBehaviour
{
    // Start is called before the first frame update



    [SerializeField] private float m_sensitivity;
    [SerializeField] private Camera m_camera;

    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    float rotationX = 0;

    private bool m_AndroidBuild;
    private bool m_WindowsBuild;



    private void Awake()
    {
        m_camera = GetComponent<Camera>();
        
    }


    private void Start()
    {

#if UNITY_STANDALONE_WIN 
        m_AndroidBuild = false;
        m_WindowsBuild = true;
        Cursor.visible = true;
#elif UNITY_ANDROID
        m_AndroidBuild = false;
        m_WindowsBuild = true;
        Cursor.visible = false;

#else
        Debug.Log("Unsupported Platform");
#endif

        if (m_WindowsBuild)
        {
            WindowsSettings();
        }
        else
        {
            AndroidSettings();
        }
        
    }

    Vector2 rotation;

    // Update is called once per frame
    void Update()
    {
        //float rotateHorizontal = Input.GetAxis();
        //float rotateVertical = Input.GetAxis();
        ////transform.RotateAround(transform.position, -Vector3.up, rotateHorizontal * m_sensitivity); //use transform.Rotate(-transform.up * rotateHorizontal * sensitivity) instead if you dont want the camera to rotate around the player
        ////transform.RotateAround(Vector3.zero, transform.right, rotateVertical * m_sensitivity); // again, use transform.Rotate(transform.right * rotateVertical * sensitivity) if you don't want the camera to rotate around the player



        //rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        //rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        //m_camera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        ////transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

        rotation.x += Input.GetAxis("Mouse X") * m_sensitivity;
        rotation.y += Input.GetAxis("Mouse Y") * m_sensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -lookXLimit, lookXLimit);
        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

        transform.localRotation = xQuat * yQuat;




    }

    void TestEmpty()
    {
        LoadScene("");
        StartCoroutine(nameof(LoadSceneAsync));
    }

    void AndroidSettings()
    {
        
    }

    void WindowsSettings()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void LoadScene(string sceneName)
    {
        // Directly load the scene
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            Debug.Log("Loading Screen Code will be here");
            yield return null;
        }
    }
}
