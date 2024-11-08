using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutContllor : MonoBehaviour
{
    [SerializeField] GameObject miraiKomachi;
    [SerializeField] GameObject fadeOutPanel;
    //オブジェクト表示メソッド
    public void ShowKomachi()
    {
        miraiKomachi.SetActive(true);
    }

    //オブジェクト非表示メソッド
    public void CloseKomachi()
    {
        miraiKomachi.SetActive(false);
    }
    public void FadeOutObjectFalse()
    {
        fadeOutPanel.SetActive(false);
    }

}
