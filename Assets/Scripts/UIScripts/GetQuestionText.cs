using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GetQuestionText : MonoBehaviour
{
    //画面に表示するテキストアタッチ
    [SerializeField] Text questionText;
    [SerializeField] Text answerText;
    public string questionContents;
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
        //ゲームマネージャーからデータを受け取り
        questionContents = GameManager.GetQuestion();
        answerContens = GameManager.GetAnswer();
        questionText.text = questionContents;
        answerText.text = answerContens;
    }
}
