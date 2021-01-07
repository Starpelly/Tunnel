using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Tunnel tunnelScript;

    public Animator anim;
    public AudioClip cowbell;
    public AudioSource sfx;

    public Conductor ConductorScript;

    private void Start()
    {
        Animator anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("playertap");
            OnTap();
        }

        if (ConductorScript.missedBeat == true)
        {
            Miss();
            ConductorScript.missedBeat = false;
        }
    }

    public void OnTap()
    {
        if (ConductorScript.currentBeatTime > 0.50)
        {
            Debug.Log("Hit");
            ConductorScript.playerHit = true;
        }
        else
        {
            Miss();
            if (ConductorScript.canMiss == true)
            {
                ConductorScript.missedBeat = true;
            }
        }
    }

    public void Cowbell()
    {
        sfx.PlayOneShot(cowbell);
    }

    public void Miss()
    {
        if (ConductorScript.canMiss == true)
        {
            tunnelScript.OnMiss();
            //HE DONT MISS NIGGGAAAAA
            Debug.Log("Miss");
        }
    }
}
