using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float BounceSpeed;
    public Rigidbody Rigidbody;
    public Platform CurrentPlatform;

    public Material deadMaterial;
    float timeToWait = 20.0f;

    public Game Game;
    public MenuController MenuController;

    public void ReachFinish()
    {
        Game.OnPlayerReachFinish();
        Rigidbody.velocity = Vector3.zero;
        //MenuController.YouWin();
    }

    public void Bounce()
    {
        Rigidbody.velocity = new Vector3(0,BounceSpeed, 0);
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }

    public void Die()
    {
        Renderer playerRender = GetComponent<Renderer>();
        playerRender.sharedMaterial = deadMaterial;
        Game.OnPlayedDied();
        Rigidbody.velocity = Vector3.zero;
        //StartCoroutine(Waiting(timeToWait));
        //MenuController.YouLose();
        //StopCoroutine(Waiting(timeToWait)); 
    }

    IEnumerator Waiting(float value)
    {        
        yield return new WaitForSeconds(value);
    }
}
