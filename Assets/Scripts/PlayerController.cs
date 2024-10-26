using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource PlayerAudio;
    public AudioSource cameraAudio;  // laiton musiikin skriptiin niin saan sen loppumaan kun peli on ohi. 
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public ParticleSystem jumpParticle; // Lis�sin viel� partikkelit hypp��mist� varten. 
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce = 10;
    public float gravityModifier = 1;
    public bool isOnGround = true;
    public bool gameOver = false;

    private GameManager gameManager;

    // Komento painovoiman resetoinnille.
    private Vector3 originalGravity;

    // Start is called before the first frame update
    void Start()
    {


        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        PlayerAudio = GetComponent<AudioSource>();

        // Painovoiman kanssa s��t��. Pitk��n. Ongelma oli, ett� aina kun peli aloitettiin alusta joko Game Over ruudusta. Tai main menusta niin painovoiman arvo nousi. 
        originalGravity = Physics.gravity;

        Physics.gravity = originalGravity * gravityModifier;

        cameraAudio = Camera.main.GetComponent<AudioSource>(); // Etsin kameran AudioSourcen eli musiikin 

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // GameManager Game Over ruutua varten. 



    }

    // Update is called once per frame
    void Update()
    {
        // Hyppy. ja sen ��ni� ja partikkeleita. Kun Space n�pp�int� painetaan ja pelaa ja ei ole ilmassa, JA ei ole Game Over niin rivit suoritetaan. 
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpParticle.Play();
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            PlayerAudio.PlayOneShot(jumpSound, 1.0f);



        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;

            if (!gameOver)
            {
                dirtParticle.Play();
            }

        }
        // Game Over tapahtumia. T�rm�ys ��net jne. 
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            // joskus k�vi niin, ett� t�rm�ys ��ni ja visuaaliefektit tapahtuivat useaan kertaan. olettaen ett� hahmo t�rm�si samaan esteeseen kahdesti
            // korjasin niin, ett� ��net ja efektit voivat tapahtua vain kun peli EI ole Game Over tilassa. 
            if (!gameOver)
            {
                Debug.Log("Game Over!");
                gameOver = true;

                // Lis�sin my�s komennon joka lopettaa musiikin kun peli on ohi
                cameraAudio.Stop();

                // Animaatiot
                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);

                
                explosionParticle.Play();
                dirtParticle.Stop();
                PlayerAudio.PlayOneShot(crashSound, 1.0f);

                // Game Over ruutu otetaan k�ytt��n gameManager skriptist�. 
                gameManager.GameOver();



            }
        }

    }

    public void ResetGame()
    {
        // PAINOVOIMA. T�h�n komentoon viitataan GameManagerissa niin painovoima palaa aina alkuper�iseen arvoonsa kun peli aloitetaan alusta. 
        Physics.gravity = originalGravity;

        
    }

}
