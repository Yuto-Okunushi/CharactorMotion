using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;
using System.IO;　//追加


public class SendOSCResolume : MonoBehaviour
{
    public Animator animator;       //アニメーターの参照


    public string ipAddress = "127.0.0.1";      //Resolume
    public int port = 7000;     //ResolumeのOSCポート番号
    public OSCTransmitter transmitter;      //OSCのTransmitter参照

    //画面切り替え変数
    public int DisplayChange;

    //CSV関連
    private TextAsset csvFile; // CSVファイル
    private List<string[]> csvData = new List<string[]>(); // CSVファイルの中身を入れるリスト

    public bool IsMoving = false;

    void Start()
    {
        //初期化
        transmitter = gameObject.AddComponent<OSCTransmitter>();
        transmitter.RemoteHost = ipAddress;
        transmitter.RemotePort = port;
        GetComponent<AudioSource>();        //オーディオソースコンポーネントを取得


        //SCV関連
        csvFile = Resources.Load("MotionController") as TextAsset; // ResourcesにあるCSVファイルを格納
        StringReader reader = new StringReader(csvFile.text); // TextAssetをStringReaderに変換

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine(); // 1行ずつ読み込む
            csvData.Add(line.Split(',')); // csvDataリストに追加する
        }

        
    }

    public void SendScvDate()
    {

        //SCVファイルの参照
        string questioncel = csvData[1][0];
        string animationcel = csvData[1][1];
        string voicecel = csvData[1][2];
        string picturecel = csvData[1][3];
        string answercel = csvData[1][4];

        //intに変換
        int animation = int.Parse(animationcel);
        int voice = int.Parse(voicecel);
        int picture = int.Parse(picturecel);

        //ゲームマネージャーへ受け渡し
        GameManager.SetQuestion(questioncel);
        GameManager.SetAnimation(animation);
        GameManager.SetVoice(voice);
        GameManager.SetPicture(picture);
        GameManager.SetAnswer(answercel);
        
    }

    public void SendScvDate2()
    {
        //SCVファイルの参照
        string questioncel = csvData[2][0];
        string animationcel = csvData[2][1];
        string voicecel = csvData[2][2];
        string picturecel = csvData[2][3];
        string answercel = csvData[2][4];


        //intに変換
        int voice = int.Parse(voicecel);
        int picture = int.Parse(picturecel);

        //floatに変換
        float animationnum = float.Parse(animationcel);

        //ゲームマネージャーからデータ受け渡し
        GameManager.SetQuestion(questioncel);
        GameManager.SetAnimation(animationnum);
        GameManager.SetVoice(voice);
        GameManager.SetPicture(picture);
        GameManager.SetAnswer(answercel);


    }

    public void ChangeColumn(int layerNumber, int columnNumber)
    {
        //OSCメッセージ作成
        var message = new OSCMessage("/composition/layers/" + layerNumber + "/clips/" + columnNumber + "/connect");
        message.AddValue(OSCValue.Int(1));
        //作成したメッセージを送信
        transmitter.Send(message);
    }

    // すべてのレイヤーのColumnを変更する
    public void ChangeAllLayers()
    {
        //ゲームマネージャーからデータ受け取り
        DisplayChange = GameManager.GetPicture();

        for (int layer = 1; layer <= 3; layer++)  //レイヤー番号を1から3に設定
        {
            ChangeColumn(layer, DisplayChange);   //各レイヤーに対して同じDisplayChangeを送る
        }
    }

    public void PlayAnimation()
    {
        IsMoving = true;
        
        if(IsMoving)
        {
            float animgetnumber = GameManager.GetAnimation();
            animator.SetFloat("OSCFloatValue", animgetnumber);
            animator.SetBool("IsMoving", true);  //ブレンドツリーを再生
            
        }
        else
        {
            animator.SetBool("isMoving", false);  //ブレンドツリーを無効にしてidleを再生
        }

    }

    public void FlugFalse()
    {
        IsMoving = false;
        animator.SetBool("IsMoving", false);  //ブレンドツリーを無効にしてidleを再生
    }

}
