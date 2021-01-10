using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public Conductor ConductorScript;
    public Voice voice;
    public Stopwatch stopWatch;

    [Header("Tunnel")]
    public GameObject tunnel;
    public Animator tunnelAnim;
    public AudioSource music;
    public AudioLowPassFilter musicFilter;
    public SpriteRenderer girlArmLeft;
    public SpriteRenderer girlArmRight;
    public SpriteRenderer car;


    [Header("Sprites")]
    public Sprite girlBodyNormal;
    public Sprite girlArmLeftNormal;
    public Sprite girlArmRightNormal;
    public Sprite carNormal;

    public Animator girlBody;
    public Sprite girlArmLeftTunnel;
    public Sprite girlArmRightTunnel;
    public Sprite carDark;

    public Renderer backgrounds;
    public Material[] Materials;

    public bool barelyBeat = false;

    public int beatsToRandomize;
    public bool inTunnel = false;

    private void Update()
    {
        RandomTunnel();
        if (ConductorScript.onBeat == true)
        {
            switch (ConductorScript.songPosBeat)
            {
                case 2:
                    voice.One();
                    break;
                case 3:
                    voice.Two();
                    stopWatch.StartStopWatch();
                    break;
                case 4:
                    voice.One();
                    break;
                case 5:
                    voice.Two();
                    break;
                case 6:
                    voice.One();
                    break;
                case 7:
                    voice.Two();
                    break;
                case 8:
                    voice.One();
                    break;
                case 9:
                    voice.Two();
                    //ConductorScript.metronome = true;
                    break;

                case 25:
                    RandomTunnel();
                    break;
            }
        }
    }

    public void RandomTunnel()
    {
        if (ConductorScript.onBeat == true)
        {
            switch (ConductorScript.songPosBeat)
            {
                case 26:
                    SetTunnel();
                    break;
                case 28:
                    RandomBG();
                    break;
                case 31:
                    EndTunnel();
                    break;
                case 46:
                    SetTunnel();
                    break;
                case 48:
                    RandomBG();
                    break;
                case 51:
                    EndTunnel();
                    break;
                case 64:
                    SetTunnel();
                    break;
                case 66:
                    RandomBG();
                    break;
                case 68:
                    EndTunnel();
                    break;
            }
        }

        RandomTunnel2();
    }

    public void RandomTunnel2()
    {
        if (ConductorScript.onBeat == true)
        {
            switch (ConductorScript.songPosBeat)
            {
                case 76:
                    SetTunnel();
                    break;
                case 78:
                    RandomBG();
                    break;
                case 84:
                    EndTunnel();
                    break;
                case 96:
                    SetTunnel();
                    break;
                case 98:
                    RandomBG();
                    break;
                case 102:
                    EndTunnel();
                    break;
                case 114:
                    SetTunnel();
                    break;
                case 116:
                    RandomBG();
                    break;
                case 124:
                    EndTunnel();
                    break;
            }
        }
    }

    public void Barely()
    {
        barelyBeat = true;
        if (inTunnel == false)
        {
            girlBody.Play("girlbarely");
        }
        else
        {
            girlBody.Play("girlbarelytunnel");
        }
    }

    public void Hit()
    {
        barelyBeat = false;
        if (inTunnel == false)
        {
            girlBody.Play("girlbodyidle");
        }
        else
        {
            girlBody.Play("girlbodyidletunnel");
        }
    }

    public void SetTunnel()
    {
        inTunnel = true;
        tunnel.SetActive(true);
        //music.volume = 0.25f;
        StartCoroutine(StartFade(music, 0.2f, Random.Range(0,0.30f)));
        //music.volume = Random.Range(0, 0.30f);
        //musicFilter.enabled = true;

        if (barelyBeat == false)
        {
            girlBody.Play("girlbodyidletunnel");
        }
        else
        {
            girlBody.Play("girlbarelytunnel");
        }
        car.sprite = carDark;
        girlArmLeft.sprite = girlArmLeftTunnel;
        girlArmRight.sprite = girlArmRightTunnel;
    }

    public void EndTunnel()
    {
        inTunnel = false;
        tunnelAnim.Play("tunnelout");
        //tunnel.SetActive(false);
        musicFilter.enabled = false;
        StartCoroutine(StartFade(music, 0.2f, 1f));
        //music.volume = 1f;

        if (barelyBeat == false)
        {
            girlBody.Play("girlbodyidle");
        }
        else
        {
            girlBody.Play("girlbarely");
        }

        car.sprite = carNormal;
        girlArmLeft.sprite = girlArmLeftNormal;
        girlArmRight.sprite = girlArmRightNormal;
    }

    public void RandomBG()
    {
        backgrounds.material = Materials[Random.Range(0, Materials.Length)];
    }

    public IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
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
}
