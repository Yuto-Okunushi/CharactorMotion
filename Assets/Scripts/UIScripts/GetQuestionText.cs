using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GetQuestionText : MonoBehaviour
{
    //��ʂɕ\������e�L�X�g�A�^�b�`
    [SerializeField] Text questionText;
    [SerializeField] Text answerText;
    public string questionContents;
    public string answerContens;


    private void Start()
    {
        //�e�L�X�g�R���|�[�l���g�擾
        GetComponent<Text>();
    }

    public void Update()
    {
        TextDisplay();
    }

    //SCV�̓��e��\��
    public void TextDisplay()
    {
        //�Q�[���}�l�[�W���[����f�[�^���󂯎��
        questionContents = GameManager.GetQuestion();
        answerContens = GameManager.GetAnswer();
        questionText.text = questionContents;
        answerText.text = answerContens;
    }
}
