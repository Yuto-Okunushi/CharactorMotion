using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //instance����
    public static GameManager instance = null;

    //==SCV���l�󂯓n���֘A=========================================================
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

    //SCV�f�[�^�󂯎��
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

    //SCV�f�[�^�󂯓n��
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
