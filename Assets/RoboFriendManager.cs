using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoboFriendManager : MonoBehaviour
{
    private string inputMessage;
    private string userName;
    private string msgToRoboFriend;

    public GameObject currentFace;
    public GameObject[] faces;

    public GameObject enterNameInterface;
    public GameObject interactionInterface;

    public GameObject roboFriendMessageField;
    private TextMeshProUGUI roboFriendSays;

    public GameObject userSaidField;
    private TextMeshProUGUI userSaid;

    private bool helloName = false;

    private bool goodDay = false;
    private bool badDay = false;

    void Start()
    {
        roboFriendSays = roboFriendMessageField.GetComponent<TextMeshProUGUI>();
        userSaid = userSaidField.GetComponent<TextMeshProUGUI>();
        currentFace = faces[0];
    }  

    // Update is called once per frame
    void Update()
    {
        if(!string.IsNullOrEmpty(userName) && !helloName)
        {
            roboFriendSays.text = "Hello " + userName + "! How are you today?";
            helloName = true;
        }

        if(!string.IsNullOrEmpty(msgToRoboFriend))
        {
            if(msgToRoboFriend.Contains("good") || msgToRoboFriend.Contains("well") || msgToRoboFriend.Contains("not bad"))
            {
                currentFace.SetActive(false);
                faces[2].SetActive(true);
                currentFace = faces[2];
                roboFriendSays.text = "I'm so happy to hear that " + userName + "! Why are you good?";
                badDay = false;
                goodDay = true;
            }
            else if(msgToRoboFriend.Contains("bad") || msgToRoboFriend.Contains("not well") || msgToRoboFriend.Contains("not good"))
            {
                roboFriendSays.text = "I'm sorry to hear that " + userName + "! What's wrong?";
                currentFace.SetActive(false);
                faces[1].SetActive(true);
                currentFace = faces[1];
                goodDay = false;
                badDay = true;
            }
            else if(msgToRoboFriend.Contains("you are") && (msgToRoboFriend.Contains("stupid") || msgToRoboFriend.Contains("idiot")))
            {
                currentFace.SetActive(false);
                faces[3].SetActive(true);
                currentFace = faces[3];
                roboFriendSays.text = "Stop being so mean!";
            }
            else if (msgToRoboFriend.Contains("sorry"))
            {
                roboFriendSays.text = "That's okay " + userName + "!";
                currentFace.SetActive(false);
                faces[0].SetActive(true);
                currentFace = faces[0];
            }
            else if (goodDay && msgToRoboFriend.Contains("fun"))
            {
                currentFace.SetActive(false);
                faces[2].SetActive(true);
                currentFace = faces[2];
                roboFriendSays.text = "That sounds very nice " + userName + "!";
            }
            else
            {
                roboFriendSays.text = "I don't understand what you are saying " + userName + ", sorry!";
                currentFace.SetActive(false);
                faces[1].SetActive(true);
                currentFace = faces[1];
            }
        }

    }

    public void SetUserName(string s)
    {
        userName = s;
    }

    public void ChangeToInteraction()
    {
        enterNameInterface.SetActive(false);
        interactionInterface.SetActive(true);
    }

    public void TellRoboFriend(string s)
    {
        msgToRoboFriend = s;
        userSaid.text = msgToRoboFriend;
    }
}
