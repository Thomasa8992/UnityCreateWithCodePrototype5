using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    private int score;

    private float spawnRate = 1.0f;

    public bool isGameActive;

    public GameObject startScreen;

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget() {
        while(isGameActive) {
            yield return new WaitForSeconds(spawnRate);

            var targetIndex = Random.Range(0, targets.Count);
            Instantiate(targets[targetIndex]);
        }
    }

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = $"Score: {score}";
    }

    public void GameOver() {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame() {
        startScreen.SetActive(false);

        isGameActive = true;
        StartCoroutine(SpawnTarget());

        score = 0;
    }
}
