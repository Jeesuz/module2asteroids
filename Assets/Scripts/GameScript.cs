using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    [SerializeField] GameObject playerShip;
    [SerializeField] GameObject player;
    bool playerDead = false;
    bool gameWon = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetButtonDown("Fire3") && playerDead && UIManager.instance.lives > 0)
        {
            player = Instantiate(playerShip);
            UIManager.instance.HideRespawn();
            UIManager.instance.PlayRespawnSound();
            UIManager.instance.UpdateLives(-1);
            playerDead = false;
        }

        if (gameWon == false)
        {
            if (GameObject.FindWithTag("BigAsteroid") == null 
            && GameObject.FindWithTag("SmallAsteroid") == null)
            {
                UIManager.instance.ShowGameover(Color.green);
                gameWon = true;
            }
        }

        if (!player)
        {
            playerDead = true;
        }
    }
}
