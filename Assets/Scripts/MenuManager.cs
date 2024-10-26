using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour

    // Yksinkertainen komento pelin aloittamiselle. Kun pelaaja painaa Play nappia niin peli lataa scenen "Prototype 3" joka on se itse peli.
{
    public void StartGame()
    {

        SceneManager.LoadScene("Prototype 3");

    }    

    public void Options()
    {


    }

    // Visuaalinen näkymä siitä, että Quit nappi toimii. 
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit!");

    }

}
