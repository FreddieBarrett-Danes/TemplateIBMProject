using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInteraction : MonoBehaviour
{
    private GameObject player;
    private GameObject minigameHolder;
    private GameObject level;

    public GameObject[] enemies;
    public GameObject chosenMinigame;

    private GameController gameController;
    private int minigameCount;

    public bool completedMinigame = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        minigameHolder = GameObject.FindGameObjectWithTag("Minigames");
        level = GameObject.FindGameObjectWithTag("Level");
        gameController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>();
    }
    private void OnTriggerStay(Collider other)
    {
        if(other == player.GetComponent<CapsuleCollider>() && Input.GetKeyDown(KeyCode.E))
        {
            if (!completedMinigame)
            {
                minigameCount = minigameHolder.transform.childCount;
                int randomMinigame = Mathf.RoundToInt(Random.Range(0, minigameCount - 1));
                chosenMinigame = minigameHolder.transform.GetChild(randomMinigame).gameObject;

                if (!chosenMinigame.active)
                {
                    gameController.inMinigame = true;

                }
            }
            else
            {
                foreach (GameObject enemy in enemies)
                {
                    Destroy(enemy);
                }
                enemies = null;
                completedMinigame = false;
            }

        }
    }
}
