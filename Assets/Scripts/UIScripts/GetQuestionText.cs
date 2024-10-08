using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GetQuestionText : MonoBehaviour
{
    [SerializeField] Text questionText;
    [SerializeField] Text answerText;
    public string questioncontents;
    public string answerContens;

    private void Start()
    {
        //テキストコンポーネント取得
        GetComponent<Text>();
    }

    public void Update()
    {
        TextDisplay();
    }

    //SCVの内容を表示
    public void TextDisplay()
    {
        questioncontents = GameManager.GetQuestion();
        answerContens = GameManager.GetAnswer();
        questionText.text = questioncontents;
        answerText.text = answerContens;
    }
}
