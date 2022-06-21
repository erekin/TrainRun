using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public int titleInFr, titleOutFr;
    public float titleCounter;                  //trainRepeatPos,trainStartPos,trainEndPos 
    public GameObject title ,startButton ;       //trainPrefab
    public TextMeshProUGUI counter;

    GameObject trains;
        
    void Start()
    {
        //1個目の列車作成
        //TrainSpawn();
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

        //列車のループ
        /*if(trains.transform.position.x > trainEndPos)
        {
            trains.transform.position = new Vector3(trainStartPos, trains.transform.position.y, trains.transform.position.z);
        }*/

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
    /// 列車を生み出す
    /// </summary>
    /*public void TrainSpawn()
    {
        trains = Instantiate(trainPrefab, new Vector3(trainStartPos, 1f, 0f), Quaternion.identity);
    }*/
    /// <summary>
    /// Startボタン押下処理
    /// </summary>
    public void OnStarttButton()
    {
        SceneManager.LoadScene("Main");
    }
}
