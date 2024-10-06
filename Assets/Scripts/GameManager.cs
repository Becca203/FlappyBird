using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public pajaro player;

    public Text scoreText;

    public GameObject playButton;

    public GameObject gameOver;

    public AudioSource PointUp;
    public AudioSource Die;

    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        Pause();
    }
    private void Start()
    {
        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void GameOver()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);
        Die.Play(); 
        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        PointUp.Play(); 
    }

}