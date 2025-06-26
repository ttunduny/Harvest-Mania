using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int currentLevel = 0;
    [SerializeField] private int maxLevel = 1;

    [SerializeField] private AudioSource sfx;
    [SerializeField] private AudioSource background;
    [SerializeField] private AudioClip collectSound;

    public static GameManager gameManagerInstance;

    //High Score Variables
    private float highScore = 0f;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private void Awake()
    {
        gameManagerInstance = this;
        DontDestroyOnLoad(this);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLevel = 0;
        PlayBackgroundMusic();
        UpdateHighScore();
    }


   
    public void StartGame()
    {
        int nextLevel = currentLevel + 1;

        if (nextLevel > maxLevel)
        {
            nextLevel = maxLevel;
        }

        currentLevel = nextLevel;
        SceneManager.LoadScene(nextLevel);

    }

    public void PlayBackgroundMusic()
    {
        background.Play();
    }

    public void PlayCollectionSound()
    {
        if (collectSound != null)
        {
            sfx.PlayOneShot(collectSound);
        }

    }

    //Store the New Highscore from the Levels when the user collects an Item
    public void SetHighScore(float score)
    {
        float currentHighScore = PlayerPrefs.GetFloat("highscore", 0f);
        if (score > currentHighScore)
        {
            PlayerPrefs.SetFloat("highscore", score);
        }
    }

    //Update the UI to display new highscore
    public void UpdateHighScore()
    {
        highScore = PlayerPrefs.GetFloat("highscore", 0f);
        highScoreText.text = highScore.ToString();
    }
}
