using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class PostComment : MonoBehaviour
{
    //comment text boxes in unity
    //TODO: create commentManager parent (attach this script to it) and put the text boxes inside
    public TMP_Text comment1;
    public TMP_Text comment2;
    public TMP_Text comment3;

    //TODO: finish username class and figure out pfps?
    //public TMP_Text username1;
    //public TMP_Text username2;
    //public TMP_Text username3;

    //public string[] usernames =
    //{

    //};

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
    //TODO: get the incorrect and corrects working properly!

    void Start()
    {
        ShowComment();
    }

    public void ShowComment() //bool isCorrect
    {
        //string[] comments;

        //if (isCorrect)
        //{
        //    comments = correctComments;
        //}
        //else
        //{
        //    comments = incorrectComments;
        //}

        List<string> availableComments = new List<string>(correctComments); //comments

        comment1.text = GetRandomComment(availableComments);
        comment2.text = GetRandomComment(availableComments);
        comment3.text = GetRandomComment(availableComments);
    }

    string GetRandomComment(List<string> correctComments) //change all 'correctComments to comments
    {
        int randomNumber = Random.Range(0, correctComments.Count);

        string selectedComment = correctComments[randomNumber];

        correctComments.RemoveAt(randomNumber);

        return selectedComment;
    }

}
