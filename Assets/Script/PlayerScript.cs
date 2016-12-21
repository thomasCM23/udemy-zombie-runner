using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour {

    
    public Transform playerSpawnPoints;
    
    private bool reSpawnCheck = false;
    private bool lastToggle;
    private Transform[] spawnPoints;
    public GameObject LandingArea;
    public float health = 100;
    public Slider healthBar;

    
    void Start()
    {
        spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    void Update()
    {
        if(health <= 0)
        {
            Respawn();
            reSpawnCheck = false;
            UpdateHeathBar();
        }
        else
        {
            lastToggle = reSpawnCheck;
        }

    }
    void Respawn()
    {
        health = 100f;
        int index = Random.Range(1, spawnPoints.Length);
        transform.position = spawnPoints[index].transform.position;
    }
    void OnFindClearArea()
    {
        Invoke("DropFlare", 3f);
    }
    void DropFlare()
    {
        Vector3 postion = transform.position + new Vector3(0f, 1f, 0f);
        Instantiate(LandingArea, postion, Quaternion.identity);
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        EnemyScript enemy = hit.transform.GetComponent<EnemyScript>();
        if (enemy)
        {
            Damaged(enemy.Attack());
        }
        if(hit.transform.tag == "Water")
        {
            Damaged(100f);
        }
        if(hit.transform.GetComponent<Helicopter>())
        {
            SceneManager.LoadScene("Start");
        }
    }
    void Damaged(float amout)
    {
        health -= amout;
        UpdateHeathBar();
    }
    void UpdateHeathBar()
    {
        healthBar.value = health;
    }
}
