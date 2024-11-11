using System.Collections;
using UnityEngine;

public class RandomBlink : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer; //BlendShapeを持つSkinnedMeshRendererをアタッチ
    public int blinkBlendShapeIndex = 0; //瞬きのBlendShapeのインデックス
    public float minBlinkInterval = 2.0f; //瞬きの最小間隔
    public float maxBlinkInterval = 5.0f; //瞬きの最大間隔
    public float blinkSpeed = 0.1f; //瞬きのスピード（目の開閉にかかる時間）

    private float nextBlinkTime; //次に瞬きをする時間
    private bool isBlinking = false; //現在瞬きをしているかどうか

    void Start()
    {
        SetNextBlinkTime();
    }

    void Update()
    {
        if (!isBlinking && Time.time >= nextBlinkTime)
        {
            StartCoroutine(Blink());
        }
    }

    //ランダムな瞬き時間を設定
    void SetNextBlinkTime()
    {
        nextBlinkTime = Time.time + Random.Range(minBlinkInterval, maxBlinkInterval);
    }

    //瞬きを行うコルーチン
    IEnumerator Blink()
    {
        isBlinking = true;

        //目を閉じる（100%まで確実に閉じる）
        for (float weight = 0f; weight <= 100f; weight += blinkSpeed * 100f)
        {
            skinnedMeshRenderer.SetBlendShapeWeight(blinkBlendShapeIndex, Mathf.Clamp(weight, 0f, 100f));
            yield return null;
        }

        //少しの間目を閉じた状態を保持
        yield return new WaitForSeconds(0.1f);

        //目を開ける
        for (float weight = 100f; weight >= 0f; weight -= blinkSpeed * 100f)
        {
            skinnedMeshRenderer.SetBlendShapeWeight(blinkBlendShapeIndex, Mathf.Clamp(weight, 0f, 100f));
            yield return null;
        }

        //念のため、BlendShapeの値を0にリセット
        skinnedMeshRenderer.SetBlendShapeWeight(blinkBlendShapeIndex, 0f);

        isBlinking = false;
        SetNextBlinkTime();
    }
}
