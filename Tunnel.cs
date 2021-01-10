using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel : MonoBehaviour
{

    [Header("Scripts")]
    public Player player;
    public Conductor ConductorScript;
    public Events eventScript;


    [Header("Everything Else")]
    public AudioSource song;
    public Background background;
    public Background tunnel;
    public Stopwatch stopwatch;

    [Header("Animations")]
    public Animator animGame;
    public Animator girlArmsAnim;
    public Animator girlAnim;

    [Header("Sprites")]
    public SpriteRenderer girl;
    public Sprite girlBarely;

    [Header("Sounds")]
    public AudioClip carStopSnd, gameEndSnd;
    public AudioSource sfx;

    public bool miss = false;

    public void OnMiss()
    {
        ConductorScript.canCount = false;
        stopwatch.isOn = false;
        if (eventScript.inTunnel == false)
        {
            animGame.Play("GameMiss");
        }
        else
        {
            animGame.Play("GameMissTunnel");
        }
        girlArmsAnim.speed = 0;
        girlAnim.enabled = false;
        miss = true;
        background.enabled = false;
        tunnel.enabled = false;
        player.canInput = false;
    }

    public void Update()
    {
        if (miss == true)
        {
            StartCoroutine(WaitBeforeFade());
        }
    }

    public IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume, float waitTime)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

    IEnumerator WaitBeforeFade()
    {
        yield return new WaitForSeconds(2.4f);
        StartCoroutine(StartFade(song, 0.2f, 0, 2));
        yield return new WaitForSeconds(0.8f);
        miss = false;
    }
}
