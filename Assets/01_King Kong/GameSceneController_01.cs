using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneController_01 : MonoBehaviour
{
    public Text gameText;

    public PlayerController_01 Player;

    public GameObject enemyPrefab;
    public GameObject enemySpawnPoint;

    public float enemySpawnDuration = 3.0f;

    private float enemyTimer;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        enemyTimer -= Time.deltaTime;
        if(enemyTimer <= 0)
        {
            enemyTimer = enemySpawnDuration;

            GameObject enmyObject = Instantiate(enemyPrefab);
            enmyObject.transform.SetParent(this.transform);
            enmyObject.transform.position=enemySpawnPoint.transform.position;
        }

        if (Player == null)
        {
            gameText.text = "Game Over Press R to Restart";
        }

        if (Time.timeScale == 0)
        {
            gameText.text = "You Win Press R to Restart";
        }

        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
