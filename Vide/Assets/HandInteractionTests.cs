using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandInteractionTests : MonoBehaviour
{

    public enum TestResults{
        NotPlaying,
        NotCorrect,
        UnexpectedResult,
        CorrectlyFinished,

    };

    public static HandInteractionTests instance;

    [SerializeField] UnityAction action;
    [SerializeField] UnityEvent unityEvent;

    /// <summary>
    /// Singleton object maker
    /// </summary>
    private void Awake()
    {
        if (instance == null)
        {
            Debug.LogError("ANOTHER INSTANCE FOUND!!!!");
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this);
    }
    private void OnTriggerEnter(Collider other)
    {
        //action?.Invoke();
        unityEvent?.Invoke();
    }

    /// <summary>
    /// A result returner for the hand interaction objects
    /// </summary>
    /// <param name="interaction"></param>
    /// <returns></returns>
    [ContextMenu("Hand Interaction Test")] // Attribute for the dev to access or the unit tests
    public string HandInteractionTester(PlayerInteraction interaction)
    {

        var result = interaction.GetResults();

        if (!Application.isPlaying)
        {
            return "NOT CORRECT!" + TestResults.NotPlaying;
        }

        return "Returned = " + result.ToString();
    }
}
