using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    GameObject optionsMenu;
    [Header ("Main Settings Panels to Show and Hide")]
    public GameObject keybindPanel;
    public GameObject keyboardBinds;
    public GameObject controllerBinds;

    [Header ("Control Scheme Toggles (Buttons)")]
    public Button keyboardToggle;
    public Button controllerToggle;

    [Header("Color Scheme")]
    public Color buttonActiveColor;
    public Color buttonDeactiveColor;

    


    private void Start()
    {
        keybindPanel.SetActive(false);
        controllerBinds.SetActive(false);

        keyboardToggle.GetComponent<Image>().color = buttonActiveColor;
        
    }


    public void buttonActivate(GameObject buttonToActivate)
    {
        buttonToActivate.GetComponent<Image>().color = buttonActiveColor;

    }

    public void buttonDeactivate(GameObject buttonToDeactivate)
    {
        buttonToDeactivate.GetComponent<Image>().color = buttonDeactiveColor;
    }
}
