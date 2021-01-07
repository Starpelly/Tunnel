﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Conductor : MonoBehaviour
{

    public float bpm = 120;
    public float secPerBeat;
    public float songPosition;
    public float songPositionInBeatsExact;
    private int songPositionInBeats;

    public float lastReportedBeat = 0f;

    public float dspSongTime;
    public float firstBeatOffset;
    public int bruh;
    public AudioSource musicSource;
    public AudioSource metronome_audioSrc;
    public float secPerRealBeat;

    public bool onBeat;

    public float songPosBeat;
    public float currentBeatTime;
    public bool missedBeat = false;
    public bool playerHit = false;

    private int timesQuarterBeat;

    public bool metronome = false;

    public float beatsPerLoop;
    public int completedLoops = 0;
    public float loopPositionInBeats;
    public float loopPositionInAnalog;
    public static Conductor instance;

    public AudioClip tunnel1, tunnelLoop;

    public bool onPlayerBeat;

    public bool canMiss = false;

    //private bool onBeat;

    //DELETE THESE COMMENTS

    public delegate void Beat();
    public static event Beat BeatEvent;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //Load the AudioSource attached to the Conductor GameObject
        musicSource.GetComponent<AudioSource>().loop = true;
        //Metronome
        //metronome_audioSrc.GetComponent<AudioSource>();
        //Calculate the number of seconds in each beat
        secPerRealBeat = 60f / bpm;
        secPerBeat = 15f / bpm;
        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;
        //Start the music
        //musicSource.time = 10f;
        //musicSource.Play();
    }

    void Update()
    {
        //determine how many seconds since the song started
        //songPosition = (float)(AudioSettings.dspTime - dspSongTime);
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);
        //determine how many beats since the song started
        songPositionInBeatsExact = songPosition / secPerBeat;
        songPositionInBeats = (int)songPositionInBeatsExact;
        ReportBeat();

       //if (songPosBeat >= (completedLoops + 1) * beatsPerLoop)
       //    completedLoops++;
       //loopPositionInAnalog = loopPositionInBeats / beatsPerLoop;

        //GameTimeline();

        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log(songPosBeat);
        }

        songPosBeat = (float)songPositionInBeats / 4;

        if (onBeat)
        {
            if (songPosBeat == 1)
            {
                StartCoroutine(playSound());
                //musicSource.Play();
            }
        }

        if (onBeat)
        {
            if (songPosBeat == 10.0)
            {
                canMiss = true;
            }
        }
    }

    void ReportBeat()
    {
        if (lastReportedBeat < songPositionInBeats)
        {
            onBeat = true;
            times += 1;
            currentBeatTime += 0.25f;
            missedBeat = false;
            if (currentBeatTime == 1.25f)
            {
                currentBeatTime = 0.25f;
                if (playerHit == false)
                {
                    if (canMiss == true)
                    {
                        missedBeat = true;
                    }
                }
                ResetCurrentBeat();
            }
            QuarterBeat();
            lastReportedBeat = songPositionInBeats;
        }
        else
        {
            onBeat = false;
        }
    }

    private int times;
    public void QuarterBeat()
    {
        if (times == 4)
        {
            times = 0;
            FullBeat();
        }
        //Debug.Log("beat");
        //songPosBeat += 0.25f; //DONT USE THIS IT COULD GO OUTTA SYNC
    }

    public void FullBeat()
    {
        //BeatEvent();
        //Debug.Log("beat");
        onPlayerBeat = true;
        if (metronome == true)
        {
            metronome_audioSrc.Play();
        }
    }

    IEnumerator playSound()
    {
        musicSource.clip = tunnel1;
        musicSource.Play();
        yield return new WaitForSeconds(musicSource.clip.length);
        musicSource.clip = tunnelLoop;
        musicSource.Play();
    }

    void ResetCurrentBeat()
    {
        playerHit = false;
    }
}