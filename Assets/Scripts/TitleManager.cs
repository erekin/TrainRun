using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TitleManager : MonoBehaviour
{
    public int titleInFr, titleOutFr;
    public float titleCounter , trainRepeatPos;
    public GameObject title , trainPrefab;
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
        if(trains.transform.position.x > trainRepeatPos)
        {
            Destroy(trains.gameObject);
            TrainSpawn();
        }

    }
    /// <summary>
    /// ��\����Ԃ̃^�C�g����\����Ԃɂ���
    /// </summary>
    /// <param name="title"></param>
    public void TitleInsert(GameObject title)
    {
        title.SetActive(true);
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
        trains = Instantiate(trainPrefab, new Vector3(-80f, 1f, 0f), Quaternion.identity);
    }
}
