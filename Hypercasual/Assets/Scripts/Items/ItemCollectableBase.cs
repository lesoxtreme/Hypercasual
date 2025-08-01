using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    
    public string compareTag = "Player";
    public ParticleSystem particleSystem;
    public float timeToHide = 3;
    public GameObject graphicItem;
    [Header("Sounds")]
    public AudioSource audioSource;

    private void Awake()
    {
        if(particleSystem != null) particleSystem.transform.SetParent(null);        
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.CompareTag(compareTag))
        {
            Collect();
            PlayerController.Instance.Bounce();
        }
    }

    protected virtual void HideItens()
    {
        if(graphicItem !=null) graphicItem.SetActive(false);
        Invoke("HideObject", timeToHide);
        Debug.Log("teste");
    }

    protected virtual void Collect()
    {
        HideItens();
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if(particleSystem != null) 
        {
            //particleSystem.transform.SetParent(null);
            particleSystem.Play();
        }

        if(audioSource != null) audioSource.Play();
    }
}
