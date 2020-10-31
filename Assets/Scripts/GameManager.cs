using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject npcPrefab;
    public GameObject npcHomePrefab;

    public Text scoreText;
    public Text livesText;
    public Text levelText;
    public Text highscoreText;

    public GameObject panelMenu;
    public GameObject panelPlay;
    public GameObject panelLevelCompleted;
    public GameObject panelGameOver;
    public GameObject [] levels;

    public static GameManager Instance { get; private set; }

    public enum State { MENU, INIT, PLAY, LEVELCOMPLETED, LOADLEVEL, GAMEOVER }
    State _state;

    GameObject _currentLife;
    GameObject _currentLevel;
    bool _isSwitchingState;

    private int _score;
    public int Score
    {
        get { return _score; }
        set { _score = value; 
            scoreText.text = "SCORE " + _score;
        }
    }
    
    private int _level;
    public int Level
    {
        get { return _level; }
        set { _level = value; 
            levelText.text = "Level " + _level;
        }
    }
    
    private int _lives;
    public int Lives
    {
        get { return _lives; }
        set { _lives = value; 
            livesText.text = "Vidas " + _lives;}
    }
    
    public void PlayClicked()
    {
        SwitchState(State.INIT);
    }
    void Start()
    {
        Instance = this;
        SwitchState(State.MENU);
        // PlayerPrefs.DeleteKey("highscore");
    }

    public void SwitchState(State newState, float delay = 0)
    {
        StartCoroutine(SwitchDelay(newState, delay));
    }

    IEnumerator SwitchDelay(State newState, float delay)
    {
        _isSwitchingState = true;
        yield return new WaitForSeconds(delay);
        EndState();
        _state = newState;
        BeginState(newState);
        _isSwitchingState = false;
    }

    void BeginState(State newState)
    {
        switch (newState)
        {
            case State.MENU:
                highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("highscore");
                panelMenu.SetActive(true);
                break;
            case State.INIT:
                panelPlay.SetActive(true);
                Score = 0;
                Level = 0;
                Lives = 3;
                if(_currentLevel != null)
                {
                    Destroy(_currentLevel);
                }
                SwitchState(State.LOADLEVEL);
                break;
            case State.PLAY:
                break;
            case State.LEVELCOMPLETED:
                Destroy(_currentLife);
                Destroy(_currentLevel);
                Level++;
                panelLevelCompleted.SetActive(true);
                SwitchState(State.LOADLEVEL);
                break;
            case State.LOADLEVEL:
                Instantiate(npcPrefab);
                Instantiate(npcHomePrefab);
                if(Level >= levels.Length)
                {
                    SwitchState(State.GAMEOVER);
                }
                else
                {
                    _currentLevel = Instantiate(levels[Level]);
                    SwitchState(State.PLAY);
                }
                break;
            case State.GAMEOVER:
                if (Score > PlayerPrefs.GetInt("highscore")) {
                    PlayerPrefs.SetInt("highscore", Score);
                }
                panelGameOver.SetActive(true);
                break;
        }
    }

    void Update()
    {
        switch (_state)
        {
            case State.MENU:
                break;
            case State.INIT:
                break;
            case State.PLAY:
                if(_currentLife == null)
                {
                    if(Lives < 0)
                    {
                        SwitchState(State.GAMEOVER);
                    }
                    // if(Lives > 0)
                    // {
                    //     _currentLife = Instantiate(playerPrefab);
                    // }
                    // else
                    // {
                    //     SwitchState(State.GAMEOVER);
                    // }
                }

                if(_currentLevel != null && _currentLevel.transform.childCount == 0 && !_isSwitchingState)
                {
                    SwitchState(State.LEVELCOMPLETED);
                }
                break;
            case State.LEVELCOMPLETED:
                break;
            case State.LOADLEVEL:
                break;
            case State.GAMEOVER:
                if(Input.anyKeyDown)
                {
                SwitchState(State.MENU); 
                }
                break;
        }
    }

    void EndState()
    {
        switch (_state)
        {
            case State.MENU:
                panelMenu.SetActive(false);
                break;
            case State.INIT:
                break;
            case State.PLAY:
                break;
            case State.LEVELCOMPLETED:
                panelLevelCompleted.SetActive(false);
                break;
            case State.LOADLEVEL:
                break;
            case State.GAMEOVER:
                panelPlay.SetActive(false);
                panelGameOver.SetActive(false);
                break;
        }

    }
}
