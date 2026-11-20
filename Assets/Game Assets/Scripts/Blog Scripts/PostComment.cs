using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class PostComment : MonoBehaviour
{
    private bool commentsGenerated = false;
    //comment text boxes in unity
    //TODO: create commentManager parent (attach this script to it) and put the text boxes inside
    //public TMP_Text comment1; //verified comment
    public TMP_Text verComment;
    public TMP_Text comment2;
    public TMP_Text comment3;

    //TODO: finish username class and figure out pfps?
    //public TMP_Text username1; //verified username
    public TMP_Text verUsername;
    public TMP_Text username2;
    public TMP_Text username3;

    public string[] usernames =
    {
        "Mikeydude()",
        "I'mNotaReference:(",
        "RedisSUSuuu",
        "SpicyNugget&&",
        "CorpseFan^^",
        "Silklong8**",
        "JasterGaster178",
        "MutantMutt%34",
        "Dudie984#",
        "SuspicousBotto**(",
        "HybridMonster6#1",
        "ljagjsid21",
        "Knight44",
        "PapyrusLOVESYOU!!",
        "DreadSpot&^",
        "IlikePork23",
        "OrangeHat7^%"

    };

    public string[] verUsernames =
    {
        "PaigeArtist56",
        "CharlieMcDuck",
        "OvertheBenjies",
        "Hershal'sChocolate",
        "Calilovesharks",
        "ChuckChuck00",
        "MattisFantastic^^",
        "SharkFan23",
        "AdrainANDNoir:)",
        "ChrisISBACK!2$",
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

    public string[] deermanCorrect =
    {
        "I've seen similar things from the Deer Man! Keep looking for more deer-like evidence.",
        "Looks like some good Deer Man evidence! Try finding more like that.",
        "You're right, that's definetly the Deer Man."
    };

    public string[] deermanIncorrect = //on hold temp. leaning to looking image (cause of fake evidence)
    {
        "That doesn't seem quite right, I've seen similar evidence for the Deer Man instead.",
        "This looks more like it belongs to the Deer Man"
    };

    public string[] entCorrect =
    {
        "I've seen similar things from the Ent! Keep looking for more tree-like evidence.",
        "Looks like some good Ent evidence! Try finding more like this.",
        "You're right, that's definetly the Ent."
    };

    public string[] entIncorrect = //on hold temp.
    {
        "That doesn't seem quite right, I've seen similar evidence for the Ent instead.",
        "This looks more like it belongs to the Ent"
    };

    public string[] roadkillCorrect =
    {
        "This is definetly a strange picture, try finding some more like this.", //strange
        "I've never seen anything like this, do we have a new creature?", //new
        "This doesn't fit any of the known creatures from this area, keeping looking for more like that.", //known
        "This is new, I wonder if we've missed a creature." //new
    };

    public string[] roadkillIncorrect = //on hold temp.
    {
        "I don't know what that is but it seems like something important",
    };

    //sets the comments in unity to the correct typing
    //TODO: get the incorrect and corrects working properly!

    public void ShowComment(bool isCorrect)
    {
        if (commentsGenerated)
        {
            return;
        }

        commentsGenerated = true;

        string[] comments;

        if (isCorrect)
        {
            comments = correctComments;
        }
        else
        {
            comments = incorrectComments;
        }

        List<string> availableComments = new List<string>(comments);
        List<string> availableUsernames = new List<string>(usernames);
        List<string> availableVerUsernames = new List<string>(verUsernames);

        //comment1.text = GetRandomComment(availableComments);
        //verComment.text = GetRandomVerComment();
        comment2.text = GetRandomComment(availableComments);
        comment3.text = GetRandomComment(availableComments);

        //username1.text = GetRandomUsername(availableUsernames);
        verUsername.text = GetRandomVerUsername(availableVerUsernames);
        username2.text = GetRandomUsername(availableUsernames);
        username3.text = GetRandomUsername(availableUsernames);

        //verUsername.text = "Verified";
        //username2.text = "Normal 1";
        //username3.text = "Normal 2";
    }

    string GetRandomComment(List<string> comments)
    {
        int randomNumber = Random.Range(0, comments.Count);

        string selectedComment = comments[randomNumber];

        comments.RemoveAt(randomNumber);

        return selectedComment;
    }

    string GetRandomUsername(List<string> usernames)
    {
        int randomNumber = Random.Range(0, usernames.Count);

        string selectedUsername = usernames[randomNumber];

        usernames.RemoveAt(randomNumber);

        return selectedUsername;
    }

    string GetRandomVerUsername(List<string> verUsernames)
    {
        int randomNumber2 = Random.Range(0, verUsernames.Count);

        string selectedVerUsername = verUsernames[randomNumber2];

        verUsernames.RemoveAt(randomNumber2);

        return selectedVerUsername;
    }

    public void ResetComments()
    {
        commentsGenerated = false;
    }

}
