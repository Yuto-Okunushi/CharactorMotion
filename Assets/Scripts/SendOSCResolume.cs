using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;

public class SendOSCResolume : MonoBehaviour
{
    public string ipAddress = "127.0.0.1";      //Resolume
    public int port = 7000;     //Resolume��OSC�|�[�g�ԍ�
    public OSCTransmitter transmitter;      //OSC��Transmitter�Q��


    // Start is called before the first frame update
    void Start()
    {
        //������
        transmitter = gameObject.AddComponent<OSCTransmitter>();
        transmitter.RemoteHost = ipAddress;
        transmitter.RemotePort = port;
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
    public void ChangeAllLayers(int columnNumber)
    {
        Debug.Log("���ׂẴ��C���[�̃R����: " + columnNumber + " �ɐ؂�ւ�");

        // �Ⴆ�΁A���C���[��1����3�܂ł���Ɖ��肵�Ă��ꂼ��؂�ւ���
        for (int layer = 1; layer <= 3; layer++)
        {
            ChangeColumn(layer, columnNumber);
        }
    }
}
