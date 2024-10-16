using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioList : MonoBehaviour
{
    //再生するオーディオのリスト登録
    public List<AudioClip> audioList = new List<AudioClip>();

    //登録したオーディオをアタッチするオーディオソース
    private AudioSource audioPlayer;


    // Start is called before the first frame update
    void Start()
    {
        //オーディオソースコンポーネントを取得
        audioPlayer = GetComponent<AudioSource>();
    }

    public void AudioSouceAttach(int audioNumber = 1)
    {
        //ゲームマネージャーの数値を代入
        audioNumber =  GameManager.GetVoice();
        //アタッチしたゲームオブジェクトのオーディオソースにリストの音声データをアタッチ
        audioPlayer.clip = audioList[audioNumber];
        //リストにある番号のボイスデータを再生
        audioPlayer.Play();
    }

}
