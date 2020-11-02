using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject npcPrefab;
    public Text scoreText;
    public Text highscoreText;

    public GameObject panelCover;
    public GameObject panelIntro1;
    public GameObject panelIntro2;
    public GameObject panelMenu;
    public GameObject panelPlay;
    public GameObject panelPause;
    public GameObject panelGameOver;

    public static GameManager Instance { get; private set; }

    public enum State { COVER, INTRO1, INTRO2, MENU, INIT, PLAY, PAUSE, GAMEOVER }
    State _state;

    private int _score;
    public int Score
    {
        get { return _score; }
        set { _score = value; 
            scoreText.text = "SCORE " + _score;
        }
    }

    
    public void PlayClicked()
    {
        SwitchState(State.INIT);
    }

    public void UnPauseClicked()
    {
        Time.timeScale = 1;
        SwitchState(State.PLAY);
    }

    public void GoToGameOver()
    {
        SwitchState(State.GAMEOVER);
    }

    public void GetToIntro1()
    {
        SwitchState(State.INTRO1);
    }

    public void GetToIntro2()
    {
        SwitchState(State.INTRO2);
    }

    public void GetToMenu()
    {
        SwitchState(State.MENU);
    }

    void Start()
    {
        Instance = this;
        SwitchState(State.COVER);
        // PlayerPrefs.DeleteKey("highscore");
    }

    public void SwitchState(State newState, float delay = 0)
    {
        StartCoroutine(SwitchDelay(newState, delay));
    }

    IEnumerator SwitchDelay(State newState, float delay)
    {
        yield return new WaitForSeconds(delay);
        EndState();
        _state = newState;
        BeginState(newState);
    }

    void BeginState(State newState)
    {
        switch (newState)
        {
            case State.COVER:
                Time.timeScale = 0;
                panelCover.SetActive(true);
                break;
            case State.INTRO1:
                panelIntro1.SetActive(true);
                break;
            case State.INTRO2:
                panelIntro2.SetActive(true);
                break;
            case State.MENU:
                highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("highscore");
                panelMenu.SetActive(true);
                break;
            case State.INIT:
                panelPlay.SetActive(true);
                Score = 0;
                SwitchState(State.PLAY);
                break;
            case State.PLAY:
                Time.timeScale = 1;
                break;
            case State.PAUSE:
                panelPause.SetActive(true);

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
            case State.COVER:
                if(Input.anyKeyDown)
                {
                    SwitchState(State.INTRO1);
                }
                break;
            case State.INTRO1:
                if(Input.anyKeyDown)
                {
                    SwitchState(State.INTRO2);
                }
                break;
            case State.INTRO2:
                if(Input.anyKeyDown)
                {
                    SwitchState(State.MENU);
                }
                break;
            case State.MENU:
                if(Input.anyKeyDown)
                {
                    SwitchState(State.INIT);
                }
                break;
            case State.INIT:
                break;
            case State.PLAY:
                if(Input.GetKeyDown(KeyCode.P))
                {
                    Time.timeScale = 0;
                    SwitchState(State.PAUSE);
                }
                if(playerPrefab == null)
                {
                    SwitchState(State.GAMEOVER);
                }
                break;
            case State.PAUSE:
                break;
            case State.GAMEOVER:
                if(Input.anyKeyDown)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                break;
        }
    }

    void EndState()
    {
        switch (_state)
        {
            case State.COVER:
                panelCover.SetActive(false);
                break;
            case State.INTRO1:
                panelIntro1.SetActive(false);
                break;
            case State.INTRO2:
                panelIntro2.SetActive(false);
                break;
            case State.MENU:
                panelMenu.SetActive(false);
                break;
            case State.INIT:
                break;
            case State.PAUSE:
                panelPause.SetActive(false);
                break;
            case State.PLAY:
                break;
            case State.GAMEOVER:
                panelPlay.SetActive(false);
                panelGameOver.SetActive(false);
                break;
        }

    }
}
