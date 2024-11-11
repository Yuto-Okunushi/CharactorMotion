using System.Collections;
using UnityEngine;

public class RandomBlink : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer; //BlendShape������SkinnedMeshRenderer���A�^�b�`
    public int blinkBlendShapeIndex = 0; //�u����BlendShape�̃C���f�b�N�X
    public float minBlinkInterval = 2.0f; //�u���̍ŏ��Ԋu
    public float maxBlinkInterval = 5.0f; //�u���̍ő�Ԋu
    public float blinkSpeed = 0.1f; //�u���̃X�s�[�h�i�ڂ̊J�ɂ����鎞�ԁj

    private float nextBlinkTime; //���ɏu�������鎞��
    private bool isBlinking = false; //���ݏu�������Ă��邩�ǂ���

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

    //�����_���ȏu�����Ԃ�ݒ�
    void SetNextBlinkTime()
    {
        nextBlinkTime = Time.time + Random.Range(minBlinkInterval, maxBlinkInterval);
    }

    //�u�����s���R���[�`��
    IEnumerator Blink()
    {
        isBlinking = true;

        //�ڂ����i100%�܂Ŋm���ɕ���j
        for (float weight = 0f; weight <= 100f; weight += blinkSpeed * 100f)
        {
            skinnedMeshRenderer.SetBlendShapeWeight(blinkBlendShapeIndex, Mathf.Clamp(weight, 0f, 100f));
            yield return null;
        }

        //�����̊Ԗڂ������Ԃ�ێ�
        yield return new WaitForSeconds(0.1f);

        //�ڂ��J����
        for (float weight = 100f; weight >= 0f; weight -= blinkSpeed * 100f)
        {
            skinnedMeshRenderer.SetBlendShapeWeight(blinkBlendShapeIndex, Mathf.Clamp(weight, 0f, 100f));
            yield return null;
        }

        //�O�̂��߁ABlendShape�̒l��0�Ƀ��Z�b�g
        skinnedMeshRenderer.SetBlendShapeWeight(blinkBlendShapeIndex, 0f);

        isBlinking = false;
        SetNextBlinkTime();
    }
}
