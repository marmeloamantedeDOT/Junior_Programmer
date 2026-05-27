using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager5 : MonoBehaviour
{
    public List<GameObject> targets;

    private float spawnRate = 1.0f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    private int score;

    public bool isGameActive;

    public Button restartButton;

    public GameObject titleScreen;

    void Start()
    {
        
    }
    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;

        UpdateScore(0);

        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

        StartCoroutine(SpawnTarget());
        titleScreen.SetActive(false);

        spawnRate /= difficulty;
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, targets.Count);

            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;

        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);

        restartButton.gameObject.SetActive(true);

        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}