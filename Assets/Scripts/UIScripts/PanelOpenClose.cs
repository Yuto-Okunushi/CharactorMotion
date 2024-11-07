using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpenClose : MonoBehaviour
{
    [SerializeField] GameObject optionPanel;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            optionPanel.SetActive(true);
        }
    }
    public void OpenOptionPanel()
    {
        optionPanel.SetActive(true);
    }
    public void CloseOptionPanel()
    {
        optionPanel.SetActive(false);
    }
}
