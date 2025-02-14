using uLipSync;
using UnityEngine;

public class LipSyncBlendShapeController : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public AudioClip audioClip;
    private AudioSource audioSource;
    private uLipSyncContext lipSyncContext;

    // BlendShapeのインデックス
    private int aBlendShapeIndex = 0;
    private int iBlendShapeIndex = 1;
    private int uBlendShapeIndex = 2;
    private int eBlendShapeIndex = 3;
    private int oBlendShapeIndex = 4;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        lipSyncContext = gameObject.AddComponent<uLipSyncContext>();
        lipSyncContext.audioSource = audioSource;

        audioSource.clip = audioClip;
    }

    public void PlayAudio()
    {
        audioSource.Play();
        lipSyncContext.StartLipSync(audioSource);
    }

    void Update()
    {
        // 各音素に応じたBlendShapeの制御
        float aWeight = lipSyncContext.GetPhonemeWeight(uLipSyncPhoneme.A);
        float iWeight = lipSyncContext.GetPhonemeWeight(uLipSyncPhoneme.I);
        float uWeight = lipSyncContext.GetPhonemeWeight(uLipSyncPhoneme.U);
        float eWeight = lipSyncContext.GetPhonemeWeight(uLipSyncPhoneme.E);
        float oWeight = lipSyncContext.GetPhonemeWeight(uLipSyncPhoneme.O);

        skinnedMeshRenderer.SetBlendShapeWeight(aBlendShapeIndex, aWeight * 100);
        skinnedMeshRenderer.SetBlendShapeWeight(iBlendShapeIndex, iWeight * 100);
        skinnedMeshRenderer.SetBlendShapeWeight(uBlendShapeIndex, uWeight * 100);
        skinnedMeshRenderer.SetBlendShapeWeight(eBlendShapeIndex, eWeight * 100);
        skinnedMeshRenderer.SetBlendShapeWeight(oBlendShapeIndex, oWeight * 100);
    }
}
