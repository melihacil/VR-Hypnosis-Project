using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Transform mainPanel;

    [SerializeField]
    private Transform scenarioPanel;

    [SerializeField]
    private Transform themePanel;

    [SerializeField]
    private PokeInteractable scenarioListButton;

    [SerializeField]
    private Transform languagePanel;

    [SerializeField]
    private InteractableUnityEventWrapper turkish;
    [SerializeField]
    private InteractableUnityEventWrapper english;
    [SerializeField]
    private TMP_Text versionText;

    [SerializeField]
    private bool isInitialClose;

    private ObjectAlignment _alignment;
    private bool _isMenuActive;
    //private OVRInteractorController _interactorController;



    //---------------------------------------------------------------------------------
    private void Start()
    {
        //_interactorController = Manager.Controller.GetController<OVRInteractorController>();

        // Can be done in serializefield
        TryGetComponent(out _alignment);

        //// Set Language Panel Buttons Events
        //turkish.WhenSelect.AddListener(() => Manager.Localization.SetLanguage(Language.Turkish));
        //english.WhenSelect.AddListener(() => Manager.Localization.SetLanguage(Language.English));

        if (isInitialClose)
            gameObject.SetActive(false);

        versionText.text = $"Bitirme Projesi V {Application.version}";
    }


    //---------------------------------------------------------------------------------
    public void SetActive(bool value)
    {
        _isMenuActive = value;
    }


    //---------------------------------------------------------------------------------
    private void Open()
    {
        if (_alignment != null)
            _alignment.UpdatePositionImmediately();

        //Return Default View
        ResetPanels();

        //_interactorController.SetAllInteractorWithBackup(false);
        //_interactorController.SetInteractor(OVRActionType.Poke, true);
    }

    [ContextMenu("TestMenu Button")]
    public void SwitchPanels()
    {
        mainPanel.gameObject.SetActive(!mainPanel.gameObject.activeSelf);
        scenarioPanel.gameObject.SetActive(!scenarioPanel.gameObject.activeSelf);
    }

    public void SwitchThemePanels()
    {
        mainPanel.gameObject.SetActive(!mainPanel.gameObject.activeSelf);
        themePanel.gameObject.SetActive(!scenarioPanel.gameObject.activeSelf);
    }

    //---------------------------------------------------------------------------------
    public void ResetPanels()
    {
        ////Return Default View
        //HandInfoPanel handInfoPanel = Manager.Canvas.GetPanel<HandInfoPanel>();
        //if (handInfoPanel != null) handInfoPanel.SetScrollPosition();
        //gameObject.SetActive(true);
        //mainPanel.SetActive(true);
        //languagePanel.SetActive(false);
    }


    //---------------------------------------------------------------------------------
    private void Close()
    {
        gameObject.SetActive(false);

        //_interactorController.LoadInteractorFromBackup();
    }


    //---------------------------------------------------------------------------------
    // Button Events
    //---------------------------------------------------------------------------------
    public void ResetScenario() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    public void ExitGame() => Application.Quit();
    public void LoadScene(string scene) => SceneManager.LoadScene(scene);
}
