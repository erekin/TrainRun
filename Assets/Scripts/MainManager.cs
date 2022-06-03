using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainManager : MonoBehaviour
{
    public float mainCounter ,trainStartPos,trainEndPos ; 
    public GameObject trainPrefab;
    public TextMeshProUGUI counter;

    GameObject trains;
        
    void Start()
    {
        //1�ڂ̗�ԍ쐬
        TrainSpawn();
    }    
    void Update()
    {
        //�J�E���^�[
        mainCounter = GameManager.Instance.counter;    //���� GameManager.Instance.counter�Ə����̖ʓ|�Ȃ̂ŕϐ��ɓ��ꂽ
        counter.text = mainCounter.ToString();

        //��Ԃ̃��[�v
        if(trains.transform.position.x > trainEndPos)
        {
            trains.transform.position = new Vector3(trainStartPos, trains.transform.position.y, trains.transform.position.z);
        }

    }
    /// <summary>
    /// ��Ԃ𐶂ݏo��
    /// </summary>
    public void TrainSpawn()
    {
        trains = Instantiate(trainPrefab, new Vector3(trainStartPos, 1f, 0f), Quaternion.identity);
    }
}
