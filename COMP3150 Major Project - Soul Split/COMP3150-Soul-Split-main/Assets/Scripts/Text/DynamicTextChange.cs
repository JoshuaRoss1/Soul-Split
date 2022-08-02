using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine;
using Febucci.UI;

public class DynamicTextChange : MonoBehaviour
{
    
    public enum TextToShow
    {
        Movement,
        Jump,
        Switch1,
        SingleSwitch,
        ToggleSwitch,
        PressurePlate,
        StillSoul,
        StillInfo,
        ProjectSoul,
        ProjectInfo,
        ShiftSoul,
        ShiftInfo,
        SoulAbsorb,
        SoulMaterialise,
        SoulSwap,
        Joke1,
        Joke2,
        Soul1,
        Soul2,
        None
    };


    PlayerInput controls;

    private string newText;
   // private float fadeTime = 6f;
    public GameObject targetText;
    public Canvas textCanvas;
    public Canvas endGameCanvas;

    //public Canvas welcomeCanvas;
    public bool triggerEnding;

    public TextToShow textToDisplay = TextToShow.Movement;

    private void Awake()
    {
        controls = GameObject.Find("Player").GetComponent<PlayerInput>();


        switch (textToDisplay)
        {
            case TextToShow.None:
                newText = "";
                return;

            case TextToShow.Movement:
                newText = "Use " + controls.actions["Movement"].bindings[1].effectivePath.Substring(11, 1).ToUpper().ToString() + " & " +
                            controls.actions["Movement"].bindings[2].effectivePath.Substring(11, 1).ToUpper().ToString()
                             + " or " + controls.actions["Movement"].bindings[3].effectivePath.Substring(10, 9).ToUpper().ToString()
                              + " to move Left and Right"; 
                return;

            case TextToShow.Jump:
                newText = "To Jump press " + controls.actions["Jump"].GetBindingDisplayString();
                return;

            case TextToShow.Switch1:
                newText = "Switches can be activated by touching them";
                return;

            case TextToShow.SingleSwitch:
                newText = "Single switches can only be activated once.";
                return;

            case TextToShow.ToggleSwitch:
                newText = "Toggle switches can be toggled on and off by repeatedly touching them";
                return;

            case TextToShow.PressurePlate:
                newText = "Pressure plates are activated by stepping on them. They deactivate by stepping off them.";
                return;

            case TextToShow.StillSoul:
                newText = "Souls can interact with switches and pressure plates the same way the player can. Press " + controls.actions["StillSoul"].bindings[1].ToDisplayString() + " or " +
                            controls.actions["StillSoul"].bindings[0].ToDisplayString() + " to Split a Still Soul";
                return;

            case TextToShow.ProjectSoul:
                newText = "To Project a Soul hold down " + controls.actions["ProjectSoul"].bindings[1].ToDisplayString() + " or " +
                            controls.actions["ProjectSoul"].bindings[0].ToDisplayString() + ". Aim with the Mouse or " + 
                             controls.actions["ProjectionAimController"].bindings[0].ToDisplayString() + " and let go to shoot the Soul";
                return;

            case TextToShow.ShiftSoul:
                newText = "Shifting Souls will follow each action that you do. Use this to your advantage. To Split a Shifting Soul press " + controls.actions["ShiftingSoul"].bindings[1].ToDisplayString() + " or " +
                            controls.actions["ShiftingSoul"].bindings[0].ToDisplayString();
                return;


            case TextToShow.SoulAbsorb:
                newText = "To Reabsorb a Soul, select it using " + controls.actions["ToggleSoul"].bindings[1].ToDisplayString() + " or DPad-" +
                            controls.actions["ToggleSoul"].bindings[0].effectivePath.Substring(15,5).ToUpper().ToString() + " and press " + controls.actions["SoulAbsorb"].bindings[1].ToDisplayString() 
                            + " or " + controls.actions["SoulAbsorb"].bindings[0].ToDisplayString();
                return;

            case TextToShow.SoulMaterialise:
                newText = "Materialising a selected Soul will make it solid, allowing it to be used as a platform. Press and hold " + controls.actions["SoulMaterialise"].bindings[1].ToDisplayString() 
                            + " or " + controls.actions["SoulMaterialise"].bindings[0].ToDisplayString() + " to Materialise the selected Soul.";
                return;

            case TextToShow.SoulSwap:
                newText = "Soul Swap swaps the position of you and the selected Soul. Press " + controls.actions["SoulSwap"].bindings[1].ToDisplayString() + " or " +
                            controls.actions["SoulSwap"].bindings[0].ToDisplayString() + " to swap positions with the selected Soul.";
                return;

            case TextToShow.Soul1:
                newText = "There are 3 different Soul types to use at your disposal: Still, Projected and Shifting.";
                return;

            case TextToShow.Soul2:
                newText = "Souls can interact with buttons in the same way the player can";
                return;

            case TextToShow.Joke1:
                newText = "There is nothing here Muahahahahahahaha (oR iS tHeRe?!?)";
                return;

            case TextToShow.Joke2:
                newText = "No there is actually nothing here, now get going with the level";
                return;
        }

    }

    private void Start()
    {
        
        
    }



    private void Update()
    {
        /*if (welcomeCanvas.gameObject.activeSelf == true)
        {
            targetText.GetComponent<TextAnimatorPlayer>().StopShowingText();
        }

        if (welcomeCanvas.gameObject.activeSelf == false)
        {
            targetText.GetComponent<TextAnimatorPlayer>().StartShowingText();
        }*/
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        targetText.GetComponent<TextMeshProUGUI>().text = newText;
        textCanvas.gameObject.SetActive(true);
        targetText.GetComponent<TextAnimatorPlayer>().StartShowingText();

        if (triggerEnding)
        {
            endGameCanvas.gameObject.SetActive(true);
            textCanvas.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //textCanvas.gameObject.SetActive(false);
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        targetText.GetComponent<TextAnimatorPlayer>().StopShowingText();
        //this.gameObject.SetActive(false);
    }

}
