using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioList : MonoBehaviour
{
    //再生するオーディオのリスト登録
    public List<AudioSource> audiolist = new List<AudioSource>();
    // Start is called before the first frame update
    void Start()
    {
        //オーディオソースコンポーネントを取得
        GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
