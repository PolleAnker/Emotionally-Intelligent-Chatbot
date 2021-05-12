using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoboFriendManager : MonoBehaviour
{
    private string inputMessage;
    private string userName;

    public GameObject enterNameInterface;
    public GameObject interactionInterface;

    public GameObject roboFriendMessageField;
    private TextMeshProUGUI roboFriendSays;

    private bool helloName = false;

    void Start()
    {
        roboFriendSays = roboFriendMessageField.GetComponent<TextMeshProUGUI>();
    }  

    // Update is called once per frame
    void Update()
    {
        if(!string.IsNullOrEmpty(userName) && !helloName)
        {
            roboFriendSays.text = "Hello " + userName + "! How are you today?";
            helloName = true;
        }

    }

    public void SetUserName(string s)
    {
        userName = s;
        Debug.Log(userName);
    }

    public void ChangeToInteraction()
    {
        enterNameInterface.SetActive(false);
        interactionInterface.SetActive(true);
    }
}
