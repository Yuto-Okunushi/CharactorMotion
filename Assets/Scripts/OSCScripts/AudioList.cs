using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioList : MonoBehaviour
{
    //�Đ�����I�[�f�B�I�̃��X�g�o�^
    public List<AudioClip> audioList = new List<AudioClip>();

    //�o�^�����I�[�f�B�I���A�^�b�`����I�[�f�B�I�\�[�X
    private AudioSource audioPlayer;


    // Start is called before the first frame update
    void Start()
    {
        //�I�[�f�B�I�\�[�X�R���|�[�l���g���擾
        audioPlayer = GetComponent<AudioSource>();
    }

    public void AudioSouceAttach(int audioNumber = 1)
    {
        //�Q�[���}�l�[�W���[�̐��l����
        audioNumber =  GameManager.GetVoice();
        //�A�^�b�`�����Q�[���I�u�W�F�N�g�̃I�[�f�B�I�\�[�X�Ƀ��X�g�̉����f�[�^���A�^�b�`
        audioPlayer.clip = audioList[audioNumber];
        //���X�g�ɂ���ԍ��̃{�C�X�f�[�^���Đ�
        audioPlayer.Play();
    }

}
