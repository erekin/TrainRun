using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TitleManager : MonoBehaviour
{
    public int titleInFr, titleOutFr;
    public float titleCounter ,trainStartPos,trainEndPos ; //trainRepeatPos
    public GameObject title ,startButton, trainPrefab;
    public TextMeshProUGUI counter;

    GameObject trains;
        
    void Start()
    {
        //1�ڂ̗�ԍ쐬
        TrainSpawn();
    }    
    void Update()
    {�@
        //�J�E���^�[
        titleCounter = GameManager.Instance.counter;    //���� GameManager.Instance.counter�Ə����̖ʓ|�Ȃ̂ŕϐ��ɓ��ꂽ
        counter.text = titleCounter.ToString();

        //�^�C�g���\���֘A
        if (titleCounter > titleInFr)
        {
            TitleInsert(title);
        }
        /*if(titleCounter > titleOutFr)
        {
            TitleOut(title);
        }*/

        //��Ԃ̃��[�v
        if(trains.transform.position.x > trainEndPos)
        {
            trains.transform.position = new Vector3(trainStartPos, trains.transform.position.y, trains.transform.position.z);
        }

    }
    /// <summary>
    /// ��\����Ԃ̃^�C�g����\����Ԃɂ���
    /// </summary>
    /// <param name="title"></param>
    public void TitleInsert(GameObject title)
    {
        title.SetActive(true);
        startButton.SetActive(true);
    }
    /// <summary>
    /// �\����Ԃ̃^�C�g�����\���ɂ���i���ݎg�p���Ă��܂���j
    /// </summary>
    /// <param name="title"></param>
    public void TitleOut(GameObject title)
    {
        title.SetActive(false);
    }
    /// <summary>
    /// ��Ԃ𐶂ݏo��
    /// </summary>
    public void TrainSpawn()
    {
        trains = Instantiate(trainPrefab, new Vector3(trainStartPos, 1f, 0f), Quaternion.identity);
    }
}
