using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameData : MonoBehaviour
{

    public bool isTextOn = false;
    public bool isFullRun = false;
    public TextMeshPro textOnOff;
    public static GameData instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("GameData found destroying this");
            Destroy(this.gameObject);
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeTextStatus()
    {
        isTextOn = !isTextOn;
        if (textOnOff != null) 
            textOnOff.text = isTextOn ? "Kapa" : "Aç";
    }

    public void StartFullRun()
    {
        isFullRun = true; 
    }
    


}
