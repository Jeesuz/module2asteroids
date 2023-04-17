using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gameoverText;
    [SerializeField] TextMeshProUGUI respawnText;
    [SerializeField] TextMeshProUGUI respawnX;
    [SerializeField] Image livesTwo, livesOne, livesZero;
    [SerializeField] AudioSource gameoverAudio, bgMusic, respawnSound, playerExplode;
    public int lives = 3;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        if (gameoverText.enabled == true)
        {
            gameoverText.enabled = false;
        }
       
    }

    public void ShowGameover(Color color)
    {
        gameoverText.color = color;
        gameoverText.enabled = true;
        bgMusic.Stop();
        gameoverAudio.Play();
        
        if (color == Color.red)
        {
            playerExplode.Play();
        }
    }

    public void PlayRespawnSound()
    {
        respawnSound.Play();
    }
    public void ShowRespawn()
    {
        respawnText.enabled = true;
        playerExplode.Play();
        respawnX.enabled = true;
    }

    public void HideRespawn()
    {
        respawnText.enabled = false;
        respawnX.enabled = false;
    }
    public void UpdateScore(int scoreChange)
    {
        score += scoreChange;
        scoreText.text = score.ToString();
    }
    public void UpdateLives(int livesChange)
    {
        lives += livesChange;
    }
    // Update is called once per frame
    void Update()
    {
        if (lives == 2)
        {
            livesTwo.enabled = false;
        } else if ( lives == 1)
        {
            livesOne.enabled = false;
        } else if (lives == 0)
        {
            livesZero.enabled = false;
        }
        // Debug.Log(lives);
    }
}
