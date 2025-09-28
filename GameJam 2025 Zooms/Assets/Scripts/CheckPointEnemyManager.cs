using System;
using UnityEngine;

public class CheckPointEnemyManager : MonoBehaviour
{
    [Header("FirstCheckPoint")]
    [SerializeField] private GameObject[] firstCheckPointEnemies;
    [SerializeField] private GameObject[] firstCheckPointSpawns;
    [Header("SecondCheckPoint")]
    [SerializeField] private GameObject[] secondCheckPointEnemies;
    [SerializeField] private GameObject[] secondCheckPointSpawns;
    [Header("ThirdCheckPoint")]
    [SerializeField] private GameObject[] thirdCheckPointEnemies;
    [SerializeField] private GameObject[] thirdCheckPointSpawns;
    [Header("PlayerStuff")]
    [SerializeField] private GameObject player;
    [SerializeField] private CameraMovementScript cameraMovement;

    private int enemyCount;

    public bool checkPoint1Done = false;
    public bool checkPoint2Done = false;
    public bool checkPoint3Done = false;
    private System.Random rnd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rnd = new System.Random();   
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if(enemyCount == 0)
        {
            cameraMovement.isOnCheckPoint = false;
        } else
        {
            cameraMovement.isOnCheckPoint = true;
        }
    }

    public void PlayerEnterCheckPoint(int checkPointNumber)
    {
        Debug.Log("Player entered CheckPoint " + checkPointNumber);
        switch (checkPointNumber)
        {
            case 1:

                for(int i = 0; i < firstCheckPointEnemies.Length; i++)
                {
                    GameObject enemy = firstCheckPointEnemies[i]; 
                    Vector3 spawnPos = firstCheckPointSpawns[i].transform.position;
                    checkPoint1Done = true;
                    Instantiate(enemy, spawnPos, Quaternion.identity);
                    enemy.GetComponent<GroundEnemy>().moveSpeed = rnd.Next(3, 4);
                    enemy.GetComponent<GroundEnemy>().hp = 3;
                }
                    
                break;
            case 2:
                for (int i = 0; i < secondCheckPointEnemies.Length; i++)
                {
                    GameObject enemy = secondCheckPointEnemies[i];
                    Vector3 spawnPos = secondCheckPointSpawns[i].transform.position;
                    checkPoint2Done = true;
                    Instantiate(enemy, spawnPos, Quaternion.identity);
                    enemy.GetComponent<GroundEnemy>().moveSpeed = rnd.Next(3, 4);
                    enemy.GetComponent<GroundEnemy>().hp = 3;
                }
                break;
            case 3:
                for (int i = 0; i < thirdCheckPointEnemies.Length; i++)
                {
                    GameObject enemy = thirdCheckPointEnemies[i];
                    Vector3 spawnPos = thirdCheckPointSpawns[i].transform.position;
                    checkPoint3Done = true;
                    Instantiate(enemy, spawnPos, Quaternion.identity);
                    enemy.GetComponent<GroundEnemy>().moveSpeed = rnd.Next(3, 4);
                    enemy.GetComponent<GroundEnemy>().hp = 3;
                }
                break;
        }
    }
}
