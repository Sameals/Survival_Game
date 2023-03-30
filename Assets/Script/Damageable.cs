using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField]float currentHealth;
    [SerializeField] int points = 20;

    [SerializeField] GameObject hitEffect;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(float damage,Vector3 hitPos,Vector3 hitNormal)
    {
        Instantiate(hitEffect, hitPos, Quaternion.LookRotation(hitNormal));
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            GameManager.Instance.UpdateScore(points);
            Die();
        }
    }
    void Die()
    {
        Debug.Log(name + "destroyed");
        Destroy(gameObject);
    }
    
}
