using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public AudioSource audioSource;
    private bool isActive = true;
    public Game Game;

    public GameObject platformPuff;
    public GameObject FinishPuff; 
    private ParticleSystem platformParticle;
    private ParticleSystem FinishParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Game.UpdateScore();
            player.CurrentPlatform = this;
        }

        if (gameObject.tag == "Finish")
        {
            GameObject particleObject = Instantiate(FinishPuff, this.transform.position, this.transform.rotation) as GameObject;
            FinishParticle = particleObject.GetComponent<ParticleSystem>();
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if (other.TryGetComponent(out Player player))
        {
            audioSource.Play();
            GameObject particleObject = Instantiate(platformPuff, this.transform.position, this.transform.rotation) as GameObject;
            platformParticle = particleObject.GetComponent<ParticleSystem>();
            isActive = false;
            GetComponent<Collider>().enabled = false;
        }
    }

    private void Update() 
    {
        if (isActive == false)
        {
           if (!audioSource.isPlaying)
            {
               Destroy(gameObject); 
            } 
        }
    }
}
