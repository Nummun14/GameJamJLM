using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logicScript : MonoBehaviour
{
    public SoundManger soundManger;
    public Text scoreText;
    private int score = 0;
    public GameObject GameOverScreen;
    
    void Start() {
        soundManger = GameObject.FindGameObjectWithTag("audio").GetComponent<SoundManger>();
    }
    void Update() {}

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver(){
        GameOverScreen.SetActive(true);
        soundManger.playSFX(soundManger.deathSound);
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
}
