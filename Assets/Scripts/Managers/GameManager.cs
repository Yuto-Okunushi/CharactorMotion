using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //instance生成
    public static GameManager instance = null;

    //==SCV数値受け渡し関連=========================================================
    public string questionContents;
    public float animationNumber;
    public int voiceNumber;
    public int pictureNumber;
    public string answerContents;
    //==============================================================================


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //==Getter=============================================================================

    //SCVデータ受け取り
    static public string GetQuestion()
    {
        return instance.questionContents;
    }

    static public float GetAnimation()
    {
        return instance.animationNumber;
    }

    static public int GetVoice()
    {
        return instance.voiceNumber;
    }

    static public int GetPicture()
    {
        return instance.pictureNumber;
    }

    static public string GetAnswer()
    {
        return instance.answerContents;
    }

    //==Setter=============================================================================

    //SCVデータ受け渡し
    static public void SetQuestion(string value)
    {
        instance.questionContents = value;
    }

    static public void SetAnimation(float value)
    {
        instance.animationNumber = value;
    }

    static public void SetVoice(int value)
    {
        instance.voiceNumber = value;
    }

    static public void SetPicture(int value)
    {
        instance.pictureNumber = value;
    }

    static public void SetAnswer(string value)
    {
        instance.answerContents = value;
    }
    
}
