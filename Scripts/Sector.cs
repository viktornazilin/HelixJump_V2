using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour
{
    public bool IsGood = true;
    public Material GoodMaterial;
    public Material BadMaterial;
    public int count;
    public Game Game;

    public GameObject dustPuff;
    private ParticleSystem dustParticle;

    private void Awake()
    {
        Renderer sectorRender = GetComponent<Renderer>();
        sectorRender.sharedMaterial = IsGood ? GoodMaterial : BadMaterial;
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (!collision.collider.TryGetComponent(out Player player)) return;
            Vector3 normal = -collision.contacts[0].normal.normalized;
            float dot = Vector3.Dot(normal, Vector3.up);

            if (dot < 0.5)
            {
                return;
            }

            if (IsGood)
            { 
                player.Bounce();
                GameObject dustObject = Instantiate(dustPuff, this.transform.position, this.transform.rotation) as GameObject;
                dustParticle = dustObject.GetComponent<ParticleSystem>();

            }
            else
            {
                player.Die();
            }
    }

   
}
