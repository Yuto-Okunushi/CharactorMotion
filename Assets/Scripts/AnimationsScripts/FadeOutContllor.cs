using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutContllor : MonoBehaviour
{
    [SerializeField] GameObject miraiKomachi;
    [SerializeField] GameObject fadeOutPanel;
    //�I�u�W�F�N�g�\�����\�b�h
    public void ShowKomachi()
    {
        miraiKomachi.SetActive(true);
    }

    //�I�u�W�F�N�g��\�����\�b�h
    public void CloseKomachi()
    {
        miraiKomachi.SetActive(false);
    }
    public void FadeOutObjectFalse()
    {
        fadeOutPanel.SetActive(false);
    }

}
