using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorConsole : MonoBehaviour {

    public GameObject[] doors;
    public string[] responses;
    public string[] validInput;
    public Text consoleText;
    public Text inputText;
    public int type;

    public void CommandInput()
    {
        string s = inputText.text;
        print(s);
        for(int i = 0; i < validInput.Length; i++)
        {
            if (validInput[i].Equals(s))
            {
                ExecuteCommand(i);
                inputText.text = null;
                break;
            }
            else
            {
                if(i == validInput.Length -1)
                {
                    //Print Error Message
                    print("ERROR");
                    consoleText.text = "Error, unknown command, use Console.Help();  for assistance.";
                    inputText.text = "";
                }
                else
                {
                    continue;
                }
            }
        }
    }

    public void ExecuteCommand(int i)
    {
        switch (i)
        {
            case 0:
                //Show Console List
                consoleText.text = responses[0];
                break;
            case 1:
                //Show console help
                consoleText.text = responses[1];
                break;
            case 2:
                //Open door 1
                consoleText.text = responses[2];
                switch (type)
                {
                    case 0:
                        doors[0].SetActive(false);
                        break;
                    case 1:
                        doors[0].GetComponent<MovingPlatform>().activated = true;
                        break;
                }             
                break;
            case 3:
                //Open door 2
                consoleText.text = responses[3];
                switch (type)
                {
                    case 0:
                        doors[1].SetActive(false);
                        break;
                    case 1:
                        doors[1].GetComponent<MovingPlatform>().activated = true;
                        break;
                }
                break;
        }
    }
}
