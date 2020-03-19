using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    private Player player;

    private Animator playerAnimator;

    public Transform enemySpawn;
    [SerializeField] private GameObject enemyPrefab;
    private GameObject enemy;

    [SerializeField] private float enemySpawnTimer;
    [SerializeField] private float enemyTimerWaitTime;

    public bool isTimerSet;

    public static Game_Manager instance;


    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        playerAnimator = player.GetComponent<Animator>();
        enemySpawn = GameObject.Find("EnemySpawn").GetComponent<Transform>();
        isTimerSet = false;
        enemy = null;
    }

    void Update()
    {
        if (!isTimerSet)
        {
            Debug.Log("isTimerSet = false");
            SetEnemyTimer();
        }
        else
        {
            if (Time.time >= enemySpawnTimer + enemyTimerWaitTime && !enemy)
            {
                enemy = Instantiate(enemyPrefab, enemySpawn.position, enemySpawn.rotation);
            }
        }
    }

    private void SetEnemyTimer()
    {
        enemySpawnTimer = Time.time;
        isTimerSet = true;
        Debug.Log("isTimerSet = true");
    }

    public void ChangeAnimation()
    {
        switch (player.weaponType)
        {
            case 0:
                playerAnimator.SetInteger("Weapon Type", 0);
                break;
            case 1:
                playerAnimator.SetInteger("Weapon Type", 1);
                break;
            case 2:
                playerAnimator.SetInteger("Weapon Type", 2);
                break;
            case 3:
                playerAnimator.SetInteger("Weapon Type", 1);
                break;
        }
    }

}
