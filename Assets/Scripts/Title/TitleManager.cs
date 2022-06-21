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
    {�@
        //�J�E���^�[
        titleCounter = GameManager.Instance.counter;    //���� GameManager.Instance.counter�Ə����̖ʓ|�Ȃ̂ŕϐ��ɓ��ꂽ
        counter.text = titleCounter.ToString();

        //�^�C�g���\���֘A
        if (titleCounter > titleInFr)
        {
            TitleInsert(title);
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
    /// Start�{�^����������
    /// </summary>
    public void OnStarttButton()
    {
        SceneManager.LoadScene("Main");
    }
}
