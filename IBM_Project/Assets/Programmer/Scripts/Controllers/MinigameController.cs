using Unity.VisualScripting;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    //bools to check game status

    public bool quizComplete = false;

    private ReadTSV rTSV;

    public GameObject mazeMinigame;

    public GameObject chosenMinigame;

    private GameController gameController;

    public bool completedMinigame = false;
    public bool completedQuiz = false;
    // Start is called before the first frame update
    void Start()
    {
        rTSV = GameObject.FindGameObjectWithTag("QuizMaster").GetComponent<ReadTSV>();
        //mazeMinigame = GameObject.FindGameObjectWithTag("Maze");
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    public void StartMazeMinigame()
    {
        chosenMinigame = mazeMinigame;
        if (!completedQuiz)
        {
            if (!chosenMinigame.activeSelf)
            {
                mazeMinigame.SetActive(true);
                gameController.inMinigame = true;
            }
        }
    }
    public void StartQuiz(int numberofQuestions)
    {
        if (!completedQuiz)
        {
            rTSV.questionsInARow = numberofQuestions;
            rTSV.find = true;
            gameController.inMinigame = true;
        }
    }
}
