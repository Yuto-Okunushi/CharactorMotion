using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInContllor : MonoBehaviour
{
    [SerializeField] GameObject fadeInPanel;
    [SerializeField] GameObject miraiKomachi;
    public Animator anim;
    private string sceneToLoad; // 読み込むシーン名を保持する変数

    public void GoNormalScene()
    {
        fadeInPanel.SetActive(true);
        anim.SetBool("IsChange", true);
        sceneToLoad = "NormalScene";
    }

    public void GoTimelineScene()
    {
        fadeInPanel.SetActive(true);
        anim.SetBool("IsChange", true);
        sceneToLoad = "TimelineScene";
    }

    public void GoTitleScene()
    {
        fadeInPanel.SetActive(true);
        anim.SetBool("IsChange", true);
        sceneToLoad = "TitleScene";
    }

    public void CloseKomachi()
    {
        miraiKomachi.SetActive(false);
    }
    //アニメーションの終わりにシーンを変化させる
    public void OnFadeInComplete()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
