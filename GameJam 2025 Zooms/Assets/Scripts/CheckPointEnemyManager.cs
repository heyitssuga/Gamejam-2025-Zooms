using System;
using UnityEngine;

public class CheckPointEnemyManager : MonoBehaviour
{
    [Header("FirstCheckPoint")]
    [SerializeField] private GameObject[] firstCheckPointEnemies;
    [Header("SecondCheckPoint")]
    [SerializeField] private GameObject[] secondCheckPointEnemies;
    [Header("ThirdCheckPoint")]
    [SerializeField] private GameObject[] thirdCheckPointEnemies;
    [Header("PlayerStuff")]
    [SerializeField] private GameObject player;
    [SerializeField] private CameraMovementScript cameraMovement;

    private int enemyCount;
    private Vector3 playerPos;

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
                playerPos = player.transform.position;
                foreach (GameObject enemy in firstCheckPointEnemies)
                {
                    checkPoint1Done = true;
                    Instantiate(enemy, new Vector3(200, rnd.Next(0,10), 0), Quaternion.identity);
                    Debug.Log("Enemy spawned at : " + enemy.transform.position);
                    enemy.GetComponent<GroundEnemy>().moveSpeed = rnd.Next(3, 4);
                }
                break;
            case 2:
                playerPos = player.transform.position;
                foreach (GameObject enemy in secondCheckPointEnemies)
                {
                    checkPoint2Done = true;
                    Instantiate(enemy);
                    enemy.SetActive(true);
                    enemy.transform.position = playerPos + new Vector3(40f, 0f, 0f);
                    enemy.GetComponent<GroundEnemy>().moveSpeed = rnd.Next(3, 4);
                }
                break;
            case 3:
                playerPos = player.transform.position;
                foreach (GameObject enemy in thirdCheckPointEnemies)
                {
                    checkPoint3Done = true;
                    Instantiate(enemy);
                    enemy.SetActive(true);
                    enemy.transform.position = playerPos + new Vector3(40f, 0f, 0f);
                    enemy.GetComponent<GroundEnemy>().moveSpeed = rnd.Next(3, 4);
                }
                break;
        }
    }
}
