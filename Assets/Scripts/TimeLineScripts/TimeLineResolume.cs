using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;
using System.IO;
using UnityEngine.Playables;

[System.Serializable]
public class TimelineResolue : PlayableAsset
{
    public Animator animator;
    public string ipAddress = "127.0.0.1";
    public int port = 7000;
    public OSCTransmitter transmitter;
    public int DisplayChange;
    private TextAsset csvFile;
    private List<string[]> csvData = new List<string[]>();
    public bool IsMoving = false;

    // Playable�������ɓ��삷����e��ݒ�
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        // �V�K��PlayableBehaviour�𐶐�
        var playable = ScriptPlayable<TimelineResolueBehaviour>.Create(graph);

        // �f�[�^��PlayableBehaviour�ɓn��
        var behaviour = playable.GetBehaviour();
        behaviour.animator = animator;
        behaviour.transmitter = transmitter;
        behaviour.ipAddress = ipAddress;
        behaviour.port = port;
        behaviour.DisplayChange = DisplayChange;
        behaviour.csvData = LoadCsvData();

        return playable;
    }

    // CSV�t�@�C���̓ǂݍ��݃��\�b�h
    private List<string[]> LoadCsvData()
    {
        csvFile = Resources.Load("MotionController") as TextAsset;
        List<string[]> csvData = new List<string[]>();
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            csvData.Add(line.Split(','));
        }
        return csvData;
    }
}

public class TimelineResolueBehaviour : PlayableBehaviour
{
    public Animator animator;
    public OSCTransmitter transmitter;
    public string ipAddress;
    public int port;
    public int DisplayChange;
    public List<string[]> csvData;

    private bool IsMoving = false;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        // �����Ńt���[�����ƂɎ��s�������������L�q
        if (IsMoving)
        {
            float animgetnumber = GameManager.GetAnimation();
            animator.SetFloat("OSCFloatValue", animgetnumber);
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    public void ChangeAllLayers()
    {
        DisplayChange = GameManager.GetPicture();
        for (int layer = 1; layer <= 3; layer++)
        {
            ChangeColumn(layer, DisplayChange);
        }
    }

    public void ChangeColumn(int layerNumber, int columnNumber)
    {
        var message = new OSCMessage("/composition/layers/" + layerNumber + "/clips/" + columnNumber + "/connect");
        message.AddValue(OSCValue.Int(1));
        transmitter.Send(message);
    }
}
