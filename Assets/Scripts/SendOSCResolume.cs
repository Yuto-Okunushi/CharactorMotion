using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;
using System.IO;�@//�ǉ�


public class SendOSCResolume : MonoBehaviour
{
    public string ipAddress = "127.0.0.1";      //Resolume
    public int port = 7000;     //Resolume��OSC�|�[�g�ԍ�
    public OSCTransmitter transmitter;      //OSC��Transmitter�Q��

    //��ʐ؂�ւ��ϐ�
    public int DisplayChange;

    //CSV�֘A
    private TextAsset csvFile; // CSV�t�@�C��
    private List<string[]> csvData = new List<string[]>(); // CSV�t�@�C���̒��g�����郊�X�g

    // Start is called before the first frame update
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

        for (int i = 0; i < csvData.Count; i++) // csvData���X�g�̏����𖞂����l�̐��i�S�āj
        {
            // �f�[�^�̕\��
            Debug.Log("������e�F" + csvData[i][0] + ", Animation�F" + csvData[i][1] + ", Voice: " + csvData[i][2] + "picture: " + csvData[i][3]);
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
        int animation = int.Parse(animationcel);
        int voice = int.Parse(voicecel);
        int picture = int.Parse(picturecel);


        GameManager.SetQuestion(questioncel);
        GameManager.SetAnimation(animation);
        GameManager.SetVoice(voice);
        GameManager.SetPicture(picture);
        GameManager.SetAnswer(answercel);


    }

    public void ChangeColumn(int layerNumber, int columnNumber)
    {
        Debug.Log("�{�^���������ꂽ");
        //OSC���b�Z�[�W�쐬
        var message = new OSCMessage("/composition/layers/" + layerNumber + "/clips/" + columnNumber + "/connect");
        //�쐬�������b�Z�[�W�𑗐M
        transmitter.Send(message);
    }

    // ���ׂẴ��C���[��Column��ύX����
    public void ChangeAllLayers()
    {
        Debug.Log("���ׂẴ��C���[�̃R����: " + DisplayChange + " �ɐ؂�ւ�");

        DisplayChange = GameManager.GetPicture();

        // �Ⴆ�΁A���C���[��1����3�܂ł���Ɖ��肵�Ă��ꂼ��؂�ւ���
        for (int layer = 1; layer <= 3; layer++)
        {
            ChangeColumn(layer, DisplayChange);
        }
    }

    
}
