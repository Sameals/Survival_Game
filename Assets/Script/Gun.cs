using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Transform cam;
    [SerializeField] private float range = 50f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private AudioClip audioClip;

    private void Awake()
    {
        cam = Camera.main.transform;
    }
    public void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.position,cam.forward,out hit, range))
        {
            if(hit.collider.GetComponent<Damageable>() !=null)
            {
                hit.collider.GetComponent<Damageable>().TakeDamage(damage,hit.point,hit.normal);
            }
        }
        muzzleFlash.Play();
        PlaySound(audioClip,Camera.main.transform.position);
    }
    private void PlaySound(AudioClip audioClip,Vector3 position,float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }
    
}
