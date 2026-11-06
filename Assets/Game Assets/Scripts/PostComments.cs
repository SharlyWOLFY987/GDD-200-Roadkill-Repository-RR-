using UnityEngine;
using TMPro;

public class PostComments : MonoBehaviour
{
    //comment text boxes in unity
    //TODO: create commentManager parent (attach this script to it) and put the text boxes inside
    public TMP_Text comment1;
    public TMP_Text comment2;
    public TMP_Text comment3;

    public TMP_Text username1;
    public TMP_Text username2;
    public TMP_Text username3;

    public string[] usernames =
    {

    };

    //list of 'correct' commments
    //TODO: add more
    public string[] correctComments =
    {
        "That's so cool!",
        "Great picture",
        "That's exactly what I've seen",
        "You're so lucky you found that!",
        "So creepy!",
        "So jealous!",

    };

    //list of 'incorrect' comments
    //TODO: add more
    public string[] incorrectComments =
    {
        "Are you sure that's right?",
        "That doesn't match what I've seen",
        "I don't think that's correct",
        "Did you mean to tag it like that?",
        "Is this a serious post?",
        "What is that even supposed to be??",

    };

    //sets the comments in unity to the correct typing
    //TODO: have Chuck add on his side a call to set: commentManager.ShowComments(true/false) true=correct after post is made
    public void ShowComments(bool isCorrect)
    {
        string[] comments;

        if (isCorrect)
        {
            comments = correctComments;
        }
        else
        {
            comments = incorrectComments;
        }

        comment1.text = comments[Random.Range(0, comments.Length)];
        comment2.text = comments[Random.Range(0, comments.Length)];
        comment3.text = comments[Random.Range(0, comments.Length)];
    }

    //TODO: add in a check to prevent dup comments

}
