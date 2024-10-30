using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineChange : MonoBehaviour
{
    [SerializeField] private PlayableDirector[] playableDirectors;

    private void Start()
    {
        // ���ׂẴ^�C�����C�����~
        foreach (var director in playableDirectors)
        {
            director.Stop();
        }
    }

    public void Number1()
    {
        // ���ݍĐ����Ă��邷�ׂẴ^�C�����C�����~
        foreach (var director in playableDirectors)
        {
            director.Stop();
        }

        // �z���0�Ԗڂ̃^�C�����C�����Đ�
        if (playableDirectors.Length > 0)
        {
            playableDirectors[0].Play();
        }
    }
    public void Number2()
    {
        // ���ݍĐ����Ă��邷�ׂẴ^�C�����C�����~
        foreach (var director in playableDirectors)
        {
            director.Stop();
        }

        // �z���0�Ԗڂ̃^�C�����C�����Đ�
        if (playableDirectors.Length > 0)
        {
            playableDirectors[1].Play();
        }
    }
}
