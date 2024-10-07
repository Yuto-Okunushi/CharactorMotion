using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;

public class SendOSCResolume : MonoBehaviour
{
    public string ipAddress = "127.0.0.1";      //Resolume
    public int port = 7000;     //ResolumeのOSCポート番号
    public OSCTransmitter transmitter;      //OSCのTransmitter参照


    // Start is called before the first frame update
    void Start()
    {
        //初期化
        transmitter = gameObject.AddComponent<OSCTransmitter>();
        transmitter.RemoteHost = ipAddress;
        transmitter.RemotePort = port;
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
    public void ChangeAllLayers(int columnNumber)
    {
        Debug.Log("すべてのレイヤーのコラム: " + columnNumber + " に切り替え");

        // 例えば、レイヤーが1から3まであると仮定してそれぞれ切り替える
        for (int layer = 1; layer <= 3; layer++)
        {
            ChangeColumn(layer, columnNumber);
        }
    }
}
