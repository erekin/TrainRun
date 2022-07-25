using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainManager : MonoBehaviour
{

    [SerializeField]
    private TrainManager trainManager;

    PlayerController playerCon;
    public GameObject player,startButton;
    public TextMeshProUGUI dotCounter,dotCounter2;

    void Start()
    {
        playerCon = player.GetComponent<PlayerController>();
        dotCounter2.text = trainManager.allDots.ToString("D2");
    }

    void Update()
    {
        dotCounter.text = playerCon.dotCount.ToString("D2");
    }
    public void OnStartButton()
    {
        trainManager.trainMode = TrainManager.Mode.MOVE;
        startButton.SetActive(false);
    }
    public void OnRetryButton()
    {
        SceneManager.LoadScene("Main");
    }
}
