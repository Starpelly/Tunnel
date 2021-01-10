using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stopwatch : MonoBehaviour
{
    public Text timer;
    public float time;
    float msec;
    float sec;
    float min;

    public bool isOn;


    private void Start()
    {
        //StartCoroutine(StopWatch());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //Debug.Log("Bruh");
        }
    }

    public void StartStopWatch()
    {
        StartCoroutine(StopWatch());
    }

    public IEnumerator StopWatch()
    {
        while(true)
        {
            if (isOn == true)
            {
                time += Time.deltaTime;
            }
            msec = (int)((time - (int)time) * 100);
            sec = (int)(time % 60);
            min = (int)(time / 60 % 60);

            timer.text = string.Format("{0:00}{1:00}{2:00}", min,sec,msec) + ("m");

            yield return null;
        }
    }
}
