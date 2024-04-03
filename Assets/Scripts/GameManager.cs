using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int healthPoints;
    public int scorePoints = 0;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI pointsText;

    public GameObject winScreen;
    public GameObject looseScreen;

    public bool GameGoing = true;

    public AudioClip winClaps;
    public AudioClip looseBonk;
    void Start()
    {
        healthText.text = healthPoints.ToString();
        pointsText.text = scorePoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddPoints(int points)
    {
        scorePoints += points;
        pointsText.text = scorePoints.ToString();
    }

    public void BallLoose()
    {
        healthPoints--;
        healthText.text = healthPoints.ToString();
        if (healthPoints <= 0)
        {
            GameLoose();
        }
    }

    public void GameLoose()
    {
        print("Loose");
        looseScreen.active = true;
        GameGoing = false;
        AudioManager.Play(looseBonk, 1, 1);
    }

    public void GameWin()
    {
        print("Win");
        winScreen.active = true;
        GameGoing = false;
        AudioManager.Play(winClaps, 1, 1);
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
