using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public bool canRestart = false;

    [Header("Sounds")]
    public AudioClip carStopSnd, gameEndSnd, advanceSnd;

    [Header("Sound Manager")]
    public AudioSource sfx;
    public AudioSource wind;

    [Header("Animations")]
    public GameObject gameOverObj;
    public Animator gameOver;
    public GameObject clickToRestart;
    public GameObject fadeOutObj;
    public Animator fadeOut;

    private void Start()
    {
        fadeOutObj.SetActive(true);
    }

    public void Update()
    {
        if (canRestart == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                sfx.PlayOneShot(advanceSnd);
                clickToRestart.SetActive(false);
                fadeOut.Play("fadeout");
                //fadeOut.speed = -1;
                //fadeOutObj.SetActive(true);
                StartCoroutine(WaitBeforeFade());
            }
        }
    }

    public void CarStopSound()
    {
        //Debug.Log("Car Stop");
        sfx.PlayOneShot(carStopSnd);
    }

    public void GameOverScreen()
    {
        wind.enabled = false;
        sfx.PlayOneShot(gameEndSnd);
        gameOverObj.SetActive(true);
    }

    public void AdvanceRestart()
    {
        clickToRestart.SetActive(true);
        canRestart = true;
    }

    IEnumerator WaitBeforeFade()
    {
        yield return new WaitForSeconds(0.9f);
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
}
