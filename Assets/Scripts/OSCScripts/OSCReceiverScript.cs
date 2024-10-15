using UnityEngine;
using extOSC;

public class OSCReceiverScript : MonoBehaviour
{
    // OSCReceiverコンポーネントへの参照
    public OSCReceiver Receiver;

    public void Test()
    {
        Debug.Log("OSCの通信を受け取ったよ");
    }
}
