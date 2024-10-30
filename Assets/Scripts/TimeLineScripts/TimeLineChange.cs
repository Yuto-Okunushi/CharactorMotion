using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineChange : MonoBehaviour
{
    [SerializeField] private PlayableDirector[] playableDirectors;

    private void Start()
    {
        // すべてのタイムラインを停止
        foreach (var director in playableDirectors)
        {
            director.Stop();
        }
    }

    public void Number1()
    {
        // 現在再生しているすべてのタイムラインを停止
        foreach (var director in playableDirectors)
        {
            director.Stop();
        }

        // 配列の0番目のタイムラインを再生
        if (playableDirectors.Length > 0)
        {
            playableDirectors[0].Play();
        }
    }
    public void Number2()
    {
        // 現在再生しているすべてのタイムラインを停止
        foreach (var director in playableDirectors)
        {
            director.Stop();
        }

        // 配列の0番目のタイムラインを再生
        if (playableDirectors.Length > 0)
        {
            playableDirectors[1].Play();
        }
    }
}
