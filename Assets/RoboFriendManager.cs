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
            if(msgToRoboFriend.Contains("good"))
            {
                currentFace.SetActive(false);
                faces[2].SetActive(true);
                currentFace = faces[2];
                roboFriendSays.text = "I'm so happy to hear that " + userName + "! Why are you good?";
            }
            if(msgToRoboFriend.Contains("bad"))
            {
                roboFriendSays.text = "I'm sorry to hear that " + userName + "! What's wrong?";
                currentFace.SetActive(false);
                faces[1].SetActive(true);
                currentFace = faces[1];
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
