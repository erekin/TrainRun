using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public int titleInFr, titleOutFr;
    public float titleCounter;                  
    public GameObject title ,startButton ;      
    public TextMeshProUGUI counter;
    void Start()
    {
       
    }    
    void Update()
    {　
        //カウンター
        titleCounter = GameManager.Instance.counter;    //毎回 GameManager.Instance.counterと書くの面倒なので変数に入れた
        counter.text = titleCounter.ToString();

        //タイトル表示関連
        if (titleCounter > titleInFr)
        {
            TitleInsert(title);
        }
    }
    /// <summary>
    /// 非表示状態のタイトルを表示状態にする
    /// </summary>
    /// <param name="title"></param>
    public void TitleInsert(GameObject title)
    {
        title.SetActive(true);
        startButton.SetActive(true);
    }
    /// <summary>
    /// Startボタン押下処理
    /// </summary>
    public void OnStarttButton()
    {
        SceneManager.LoadScene("Main");
    }
}
