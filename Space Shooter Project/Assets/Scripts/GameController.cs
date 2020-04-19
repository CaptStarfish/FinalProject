using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioSource musicSource;


    public Text ScoreText;
    public Text RestartText;
    public Text GameOverText;
    public Text winText;
    public Text hardText;
    public int score;
    private bool gameOver;
    private bool restart;
    public bool hardMode;

   

    

    void Start()
    {
        gameOver = false;
        restart = false;
        RestartText.text = "";
        GameOverText.text = "";
        winText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());
        hardMode = false;
        hardText.text = "Press H to enable hard mode!";
        
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            hardMode = true;
            HardMode();
        }
    }

    


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3
                (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                RestartText.text = "Press Q for restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 100)
        {
            winText.text = "You win! Game created by Allyson Pyle.";
            gameOver = true;
            restart = true;
            musicSource.Stop();
            musicSource.clip = musicClipOne;
            musicSource.Play();
        }
    }

    public void GameOver ()
    {
        GameOverText.text = "Game Over";
        gameOver = true;
        restart = true;
        musicSource.Stop();
        musicSource.clip = musicClipTwo;
        musicSource.Play();
    }

    public void HardMode ()
    {
        hazardCount = hazardCount + 5;
        waveWait = waveWait / 2;
        hardText.text = "Hard Mode Enabled";
        

    }

}
