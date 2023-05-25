using System;
using UnityEngine;
using UnityEngine.UI;

/* Start game menu */
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Text _lastGameDurationText;

    private ILoader _loader;
    private void Awake()
    {
        _startButton.onClick.AddListener(OnStartButtonPressed);
    }
    
    public void Congigure(ILoader loaderPersistance)
    {
        _loader = loaderPersistance;
    }

    private void OnEnable()
    {
        LoadLastDuration();
    }

    private void LoadLastDuration()
    {
        var gameDuration = _loader.LoadData();
        var time = TimeSpan.FromSeconds(gameDuration);
        _lastGameDurationText.text = FormatTimer(time);
    }

    private String FormatTimer(TimeSpan time)
    {
        return time.ToString(@"mm\:ss");
    }

    private void OnStartButtonPressed()
    {
        GameEventListener.Instance.OnStartGame();
        gameObject.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameObject.SetActive(true);
    }
}
