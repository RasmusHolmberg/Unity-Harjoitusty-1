using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

/* T‰m‰ skripti j‰rjest‰‰ GameOver ruudun.    */

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;

    void Start()
    {
        gameOverCanvas.SetActive(false); /* Game Over ruutu on Prototype 3 sceness‰ nimell‰ gameOverCanvas. 
                                        T‰ll‰ komennolla pidet‰‰n huoli ett‰ se on aina alussa pois p‰‰lt‰. */
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true); // T‰m‰ komento k‰ynnist‰‰ Game Over ruudun mutta se menee p‰‰lle vain kun PlayerControllerissa oleva ehto t‰yttyy.

    }


    // T‰m‰ komento on yhdistetty "Retry" nappiin Game Over ruudussa joten peli aloitetaan alusta kun pelaaja painaa sit‰
    public void RestartGame()
    {
        

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Pelin uudelleen aloittaminen.
        PlayerController playerController = FindObjectOfType<PlayerController>();
        // Komento painovoiman resetointia varten. Sen kanssa tuli useita ongelmia. N‰kyy enemm‰n PlayerControllerissa. 
        playerController.ResetGame();
        
        
    }

    // T‰m‰ komento on yhdistetty "Menu" nappiin Game Over ruudussa joten peli palaa alkuvalikkoon kun pelaaja painaa sit‰
    public void GoToMainMenu()
    {
        // Alkuvalikkoon palaaminen
        SceneManager.LoadScene("MainMenu");

        // Taas painovaoimaongelmia. Komento piti tehd‰ myˆs main menuun palatessa. 
        PlayerController playerController = FindObjectOfType<PlayerController>();
        playerController.ResetGame();
    }
}