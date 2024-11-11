using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;
using System.IO;�@//�ǉ�


public class SendOSCResolume : MonoBehaviour
{
    public Animator animator;       //�A�j���[�^�[�̎Q��


    public string ipAddress = "127.0.0.1";      //Resolume
    public int port = 7000;     //Resolume��OSC�|�[�g�ԍ�
    public OSCTransmitter transmitter;      //OSC��Transmitter�Q��

    //��ʐ؂�ւ��ϐ�
    public int DisplayChange;

    //CSV�֘A
    private TextAsset csvFile; // CSV�t�@�C��
    private List<string[]> csvData = new List<string[]>(); // CSV�t�@�C���̒��g�����郊�X�g

    public bool IsMoving = false;

    void Start()
    {
        //������
        transmitter = gameObject.AddComponent<OSCTransmitter>();
        transmitter.RemoteHost = ipAddress;
        transmitter.RemotePort = port;
        GetComponent<AudioSource>();        //�I�[�f�B�I�\�[�X�R���|�[�l���g���擾


        //SCV�֘A
        csvFile = Resources.Load("MotionController") as TextAsset; // Resources�ɂ���CSV�t�@�C�����i�[
        StringReader reader = new StringReader(csvFile.text); // TextAsset��StringReader�ɕϊ�

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine(); // 1�s���ǂݍ���
            csvData.Add(line.Split(',')); // csvData���X�g�ɒǉ�����
        }

        
    }

    public void SendScvDate()
    {

        //SCV�t�@�C���̎Q��
        string questioncel = csvData[1][0];
        string animationcel = csvData[1][1];
        string voicecel = csvData[1][2];
        string picturecel = csvData[1][3];
        string answercel = csvData[1][4];

        //int�ɕϊ�
        int animation = int.Parse(animationcel);
        int voice = int.Parse(voicecel);
        int picture = int.Parse(picturecel);

        //�Q�[���}�l�[�W���[�֎󂯓n��
        GameManager.SetQuestion(questioncel);
        GameManager.SetAnimation(animation);
        GameManager.SetVoice(voice);
        GameManager.SetPicture(picture);
        GameManager.SetAnswer(answercel);
        
    }

    public void SendScvDate2()
    {
        //SCV�t�@�C���̎Q��
        string questioncel = csvData[2][0];
        string animationcel = csvData[2][1];
        string voicecel = csvData[2][2];
        string picturecel = csvData[2][3];
        string answercel = csvData[2][4];


        //int�ɕϊ�
        int voice = int.Parse(voicecel);
        int picture = int.Parse(picturecel);

        //float�ɕϊ�
        float animationnum = float.Parse(animationcel);

        //�Q�[���}�l�[�W���[����f�[�^�󂯓n��
        GameManager.SetQuestion(questioncel);
        GameManager.SetAnimation(animationnum);
        GameManager.SetVoice(voice);
        GameManager.SetPicture(picture);
        GameManager.SetAnswer(answercel);


    }

    public void ChangeColumn(int layerNumber, int columnNumber)
    {
        //OSC���b�Z�[�W�쐬
        var message = new OSCMessage("/composition/layers/" + layerNumber + "/clips/" + columnNumber + "/connect");
        message.AddValue(OSCValue.Int(1));
        //�쐬�������b�Z�[�W�𑗐M
        transmitter.Send(message);
    }

    // ���ׂẴ��C���[��Column��ύX����
    public void ChangeAllLayers()
    {
        //�Q�[���}�l�[�W���[����f�[�^�󂯎��
        DisplayChange = GameManager.GetPicture();

        for (int layer = 1; layer <= 3; layer++)  //���C���[�ԍ���1����3�ɐݒ�
        {
            ChangeColumn(layer, DisplayChange);   //�e���C���[�ɑ΂��ē���DisplayChange�𑗂�
        }
    }

    public void PlayAnimation()
    {
        IsMoving = true;
        
        if(IsMoving)
        {
            float animgetnumber = GameManager.GetAnimation();
            animator.SetFloat("OSCFloatValue", animgetnumber);
            animator.SetBool("IsMoving", true);  //�u�����h�c���[���Đ�
            
        }
        else
        {
            animator.SetBool("isMoving", false);  //�u�����h�c���[�𖳌��ɂ���idle���Đ�
        }

    }

    public void FlugFalse()
    {
        IsMoving = false;
        animator.SetBool("IsMoving", false);  //�u�����h�c���[�𖳌��ɂ���idle���Đ�
    }

}
