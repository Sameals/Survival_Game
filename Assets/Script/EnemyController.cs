using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private AudioClip audioClip;
    NavMeshAgent agent;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(spawnEnemy());
       
    }

    private IEnumerator spawnEnemy()
    {
        yield return new WaitForSeconds(7f);
        Vector3 randomrangeobj = new Vector3(Random.Range(-54f, 54f), 0.5f, Random.Range(-65f, 65f));
        Instantiate(EnemyPrefab, randomrangeobj, Quaternion.identity);
        PlaySound(audioClip, Camera.main.transform.position);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameManager.Instance.gameover();
           
           // Destroy(Player);
            Debug.Log("player is dead");
            Time.timeScale = 0f;
        }
    }

    void Update()
    {
        agent.SetDestination(Player.transform.position);
        
    }
    private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }
}
