using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioList : MonoBehaviour
{
    //�Đ�����I�[�f�B�I�̃��X�g�o�^
    public List<AudioSource> audiolist = new List<AudioSource>();
    // Start is called before the first frame update
    void Start()
    {
        //�I�[�f�B�I�\�[�X�R���|�[�l���g���擾
        GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
