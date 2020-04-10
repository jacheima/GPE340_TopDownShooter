using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game_Manager : MonoBehaviour
{
    [Header("Player Attributes")]
    public int playerLives = 3;
    [SerializeField] private Image life1;
    [SerializeField] private Image life2;
    [SerializeField] private Image life3;
    public CameraController cameraController;
    private Player player;
    private Animator playerAnimator;
    public Keybinding keyBindManager;

    [Header("Player Shooting Attributes")]
    public Image ammoFill;
    public Text currentMag;
    public Text magMax;

    [Header("Pistol Attributes")]
    public float pistolMagMax = 40;
    public float pistolCurrentMag;
    public bool pistolEquiped;
    public Image pistolIcon;

    [Header("Machine Gun Attributes")]
    public float machineGunMagMax = 160;
    public float machineGunCurrentMag;
    public bool machineGunEquipped;
    public Image machineGunIcon;

    [Header("Enemy Attributes")]
    public Transform enemySpawn;
    [SerializeField] private GameObject enemyPrefab;
    private GameObject enemy;
    [SerializeField] private float enemySpawnTimer;
    [SerializeField] private float enemyTimerWaitTime;
    public bool isTimerSet;

    [Header("Weighted Drops Attributes")]
    public GameObject[] itemDrops;
    public List<GameObject> weightedDrops;
    public int healthDropWeight;
    public int machineGunDropsWeight;
    public int pistolDropsWeight;
    public int noDropWeight;
    private int healthDropsIndex = 0;
    private int machineGunDropsIndex = 1;
    private int pistolDropsIndex = 2;
    private int noDropIndex = 3;

    [Header("Game State Attributes")]
    public GameObject gameOver;
    public bool pausedGame;
    public GameObject pauseMenu;
    public GameObject optionsMenu;

    [Header("Options Menus Attributes")]
    public GameObject controlsMenu;
    public GameObject videoMenu;
    public GameObject audioMenu;


    public EnemyManager enemyManager;
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
        gameOver.SetActive(false);
        machineGunCurrentMag = machineGunMagMax;
        pistolCurrentMag = pistolMagMax;
        pausedGame = false;
        pauseMenu.SetActive(false);
        for(int i = 0; i < healthDropWeight; i++)
        {
            weightedDrops.Add(itemDrops[healthDropsIndex]);
        }
        for (int i = 0; i < machineGunDropsWeight; i++)
        {
            weightedDrops.Add(itemDrops[machineGunDropsIndex]);
        }
        for (int i = 0; i < pistolDropsWeight; i++)
        {
            weightedDrops.Add(itemDrops[pistolDropsIndex]);
        }
        for (int i = 0; i < noDropWeight; i++)
        {
            weightedDrops.Add(itemDrops[noDropIndex]);
        }

        optionsMenu.SetActive(false);

        

    }

    void Update()
    {
        if(machineGunEquipped)
        {
            float ammoPercent = machineGunCurrentMag / machineGunMagMax;
            ammoFill.fillAmount = ammoPercent;
            currentMag.text = "" + machineGunCurrentMag;
            magMax.text = "" + machineGunMagMax;
            machineGunIcon.enabled = true;
        }
        else
        {
            machineGunIcon.enabled = false;
        }

        if(pistolEquiped)
        {
            float pistolAmmoPercent = pistolCurrentMag / pistolMagMax;
            ammoFill.fillAmount = pistolAmmoPercent;
            currentMag.text = "" + pistolCurrentMag;
            magMax.text = "" + pistolMagMax;
            pistolIcon.enabled = true;
        }
        else
        {
            pistolIcon.enabled = false;
        }

        if(playerLives == 3)
        {
            life1.enabled = true;
            life2.enabled = true;
            life3.enabled = true;
        }
        else if (playerLives == 2)
        {
            life1.enabled = false;
            life2.enabled = true;
            life3.enabled = true;
        }
        else if (playerLives == 1)
        {
            life1.enabled = false;
            life2.enabled = false;
            life3.enabled = true;
        }
        else if(playerLives == 0)
        {
            life1.enabled = false;
            life2.enabled = false;
            life3.enabled = false;
            EndGame();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausedGame == false)
            {
                PauseGame();
            }
            else
            {
                UnpauseGame();
            }
        }


    }

    public void PauseGame()
    {
        pausedGame = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        
    }

    public void UnpauseGame()
    {
        pausedGame = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        
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

    public void EndGame()
    {
        gameOver.SetActive(true);
        Application.Quit();
        
    }

    public void OpenOptionsMenu()
    {
        optionsMenu.SetActive(true);
    }

    public void CloseOptionsMenu()
    {
        optionsMenu.SetActive(false);
    }

    public void DropItem(GameObject spawnLocation)
    {
        int item = Random.Range(0, weightedDrops.Count);
        Instantiate(weightedDrops[item], spawnLocation.transform.position, spawnLocation.transform.rotation);
    }

    public void OpenControlOptions()
    {
        controlsMenu.SetActive(true);
        videoMenu.SetActive(false);
        audioMenu.SetActive(false);
    }

    public void OpenVideoOptions()
    {
        controlsMenu.SetActive(false);
        videoMenu.SetActive(true);
        audioMenu.SetActive(false);
    }

    public void OpenAudioOptions()
    {
        controlsMenu.SetActive(false);
        videoMenu.SetActive(false);
        audioMenu.SetActive(true);
    }
}
