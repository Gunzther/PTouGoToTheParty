using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileModeManager : MonoBehaviour
{
    public GameObject mobileButtons;

    Toggle toggle;

    private void Awake()
    {
        toggle = transform.GetComponent<Toggle>();
    }

    public void OpenMobileControl()
    {
        if (toggle.isOn)
        {
            mobileButtons.SetActive(true);
        }
        else
        {
            mobileButtons.SetActive(false);
        }
    }
}
