using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public float lifeTime = 1f;
    public int hitScore = 10;
    public float missGhostLife = 0.1f;
    public float wrongGhostLife = 0.08f;
    public float regenLife = 0.1f;

    public float startTime = 3f;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void AddScore()
    {
        score += hitScore;
        UIManager.instance.UpdateScoreText();
    }

    public void MissGhost()
    {
        lifeTime -= missGhostLife;
    }

    public void HitWrongGhost()
    {
        lifeTime -= wrongGhostLife;
    }

    public void WinGame()
    {
        SceneManager.LoadScene(0);
    }

    public void LoseGame()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        //lifeTime = Mathf.MoveTowards(lifeTime, 1f, regenLife * Time.deltaTime);
        UIManager.instance.UpdateLifetimeBar();

        if(lifeTime <= 0)
        {
            LoseGame();
        }
    }
}
