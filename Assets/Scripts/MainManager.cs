using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainManager : MonoBehaviour
{
    public GameObject trainManagerObj;
    TrainManager trainManager;
    PlayerController playerCon;
    public GameObject player,StartButton;
    public TextMeshProUGUI dotCounter;

    void Start()
    {
        trainManager = trainManagerObj.GetComponent<TrainManager>();
        playerCon = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        dotCounter.text = playerCon.dotCount.ToString("D3");
    }
    public void OnStartButton()
    {
        trainManager.trainMode = TrainManager.Mode.MOVE;
        StartButton.SetActive(false);
    }
    public void OnRetryButton()
    {
        SceneManager.LoadScene("Main");
    }
    /*public void PlayerSpawn()
    {
        player.SetActive(true);
    }*/
}
