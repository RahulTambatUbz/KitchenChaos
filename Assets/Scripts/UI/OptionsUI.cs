using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance { get; private set; }
    [SerializeField] private Button soundEffectsButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button moveUPButton;
    [SerializeField] private Button moveDownButton;
    [SerializeField] private Button moveLeftButton;
    [SerializeField] private Button moveRightButton;
    [SerializeField] private Button interactButton;
    [SerializeField] private Button interactAlternateButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] TextMeshProUGUI soundEffectsText;
    [SerializeField] TextMeshProUGUI musicText;
    [SerializeField] TextMeshProUGUI moveUPText;
    [SerializeField] TextMeshProUGUI moveDownText;
    [SerializeField] TextMeshProUGUI moveLeftText;
    [SerializeField] TextMeshProUGUI moveRightText;
    [SerializeField] TextMeshProUGUI InteractText;
    [SerializeField] TextMeshProUGUI InteractAlternateText;
    [SerializeField] TextMeshProUGUI PauseText;
    [SerializeField] private Transform pressToRebindKeyUI;


    private void Awake()
    {
        Instance = this;
        soundEffectsButton.onClick.AddListener(() =>
            {
                SoundManager.Instance.ChangeVolume();
                UpdateVisuals();

            });
        musicButton.onClick.AddListener(() =>
            {
                MusicManager.Instance.ChangeVolume();
                UpdateVisuals();
               
            });
        
        closeButton.onClick.AddListener(() =>
            {
                Hide();
            });

        moveUPButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInputs.Binding.Move_UP);
            
        });

        moveDownButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInputs.Binding.Move_Down);

        });
        moveRightButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInputs.Binding.Move_Right);

        });
        moveLeftButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInputs.Binding.Move_Left);

        });
        interactButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInputs.Binding.Interact);

        });
        interactAlternateButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInputs.Binding.InteractAlternate);

        });
        pauseButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInputs.Binding.Pause);

        });
    }
    private void Start()
    {
        GameManager.Instance.OnGameUnpause += GameManager_OnGameUnpause;
        UpdateVisuals();
        Hide();
        HidePressToRebindKey();
    }

    private void GameManager_OnGameUnpause(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void UpdateVisuals()
    {
        soundEffectsText.text = "Sound Effects :" + Mathf.Round(SoundManager.Instance.GetVolume() * 10f);
        musicText.text = "Music :"+ Mathf.Round(MusicManager.Instance.GetVolume() * 10f);
        moveUPText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Move_UP);
        moveDownText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Move_Down);
        moveLeftText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Move_Left);
        moveRightText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Move_Right);
        InteractText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Interact);
        InteractAlternateText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.InteractAlternate);
        PauseText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Pause);
    }

    public  void Show()
    {

        gameObject.SetActive(true);

    }

    public void Hide()
    {

        gameObject.SetActive(false);
    } 
    
    public  void ShowPressToRebindKey()
    {

        pressToRebindKeyUI.gameObject.SetActive(true);

    }

    public void HidePressToRebindKey()
    {

        pressToRebindKeyUI.gameObject.SetActive(false);
    }

    private void RebindBinding(GameInputs.Binding binding)
    {
        ShowPressToRebindKey();
        GameInputs.Instance.RebindBinding(binding, () =>
         {

             HidePressToRebindKey();
             UpdateVisuals();
         });

    }
}



