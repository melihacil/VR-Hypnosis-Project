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
    private GameObject _themePanel;
    [SerializeField]
    private GameObject _settingsPanel;
    [SerializeField]
    private GameObject _scenariosPanel;
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
    public TextMeshPro textOnOff;

    public ScorePanel panelInfo;

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

        versionText.text = $"Bitirme Projesi v{Application.version} \nUnity v{Application.unityVersion}";
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

    public void ChangeTextOpenStatus()
    {
        GameData.instance.isTextOn = !GameData.instance.isTextOn;
        if (textOnOff != null)
            textOnOff.text = GameData.instance.isTextOn ? "Kapa" : "A�";
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
        _themePanel.SetActive(!_themePanel.gameObject.activeSelf);
    }
    public void SwitchSettingPanels()
    {
        mainPanel.gameObject.SetActive(!mainPanel.gameObject.activeSelf);
        _settingsPanel.SetActive(!_settingsPanel.gameObject.activeSelf);
    }
    public void SwitchScenarioPanels()
    {
        mainPanel.gameObject.SetActive(!mainPanel.gameObject.activeSelf);
        _scenariosPanel.SetActive(!_scenariosPanel.gameObject.activeSelf);
    }
    public void SwitchThemePanels(GameObject obj)
    {
        mainPanel.gameObject.SetActive(!mainPanel.gameObject.activeSelf);
        obj.SetActive(!obj.activeSelf);
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

    public void ClosePanel()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }



    //---------------------------------------------------------------------------------
    // Button Events
    //---------------------------------------------------------------------------------
    public void ResetScenario() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    public void ExitGame() => Application.Quit();
    public void LoadScene(int scene) => SceneManager.LoadScene(scene);

    public void LoadScene(string scene) => SceneManager.LoadScene(scene);
}
