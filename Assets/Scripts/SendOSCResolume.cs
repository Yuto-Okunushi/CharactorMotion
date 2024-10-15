using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;
using System.IO;　//追加


public class SendOSCResolume : MonoBehaviour
{
    public string ipAddress = "127.0.0.1";      //Resolume
    public int port = 7000;     //ResolumeのOSCポート番号
    public OSCTransmitter transmitter;      //OSCのTransmitter参照

    //画面切り替え変数
    public int DisplayChange;

    //CSV関連
    private TextAsset csvFile; // CSVファイル
    private List<string[]> csvData = new List<string[]>(); // CSVファイルの中身を入れるリスト

    // Start is called before the first frame update
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

        for (int i = 0; i < csvData.Count; i++) // csvDataリストの条件を満たす値の数（全て）
        {
            // データの表示
            Debug.Log("質問内容：" + csvData[i][0] + ", Animation：" + csvData[i][1] + ", Voice: " + csvData[i][2] + "picture: " + csvData[i][3]);
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
        Debug.Log("ボタンが押された");
        //OSCメッセージ作成
        var message = new OSCMessage("/composition/layers/" + layerNumber + "/clips/" + columnNumber + "/connect");
        //作成したメッセージを送信
        transmitter.Send(message);
    }

    // すべてのレイヤーのColumnを変更する
    public void ChangeAllLayers()
    {
        Debug.Log("すべてのレイヤーのコラム: " + DisplayChange + " に切り替え");

        DisplayChange = GameManager.GetPicture();

        // 例えば、レイヤーが1から3まであると仮定してそれぞれ切り替える
        for (int layer = 1; layer <= 3; layer++)
        {
            ChangeColumn(layer, DisplayChange);
        }
    }

    
}
