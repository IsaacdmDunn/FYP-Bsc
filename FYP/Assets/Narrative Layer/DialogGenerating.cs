using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogGenerator 
{
    public enum DialogType
    {
        Chat = 0, flirt, argue, compliment, insult, like, dislike, mope
    }
    public CastManager castManager;
    public int char1ID;
    int char2ID;
    List<int> possibleDialogTypesWeights = new List<int>();
    public void PickPerson(int charID, int charID2)
    {
        char2ID = charID;
    }

    public void PickRandomPerson()
    {
        char2ID = Random.Range(0, castManager.cast.Count-1);
        while (char1ID == char2ID)
        {
            char2ID = Random.Range(0, castManager.cast.Count-1);
        }
    }


    public void CreateDialog()
    {
        possibleDialogTypesWeights.Clear();
        int totalWeights=0;

        for (int i = 0; i < 8; i++)
        {
            possibleDialogTypesWeights.Add(10);
        }
        //decide dialog weights based on emotion
        if (castManager.cast[char1ID].angry > 0.5f)
        {
            possibleDialogTypesWeights[(int)DialogType.argue] += 10;
            possibleDialogTypesWeights[(int)DialogType.insult] += 10;
            possibleDialogTypesWeights[(int)DialogType.dislike] += 50;
            possibleDialogTypesWeights[(int)DialogType.flirt] = 0;
        }
        else if(castManager.cast[char1ID].happiness >= 0.5f)
        {
            possibleDialogTypesWeights[(int)DialogType.Chat] += 20;
            possibleDialogTypesWeights[(int)DialogType.compliment] += 20;
            possibleDialogTypesWeights[(int)DialogType.like] += 50;
            possibleDialogTypesWeights[(int)DialogType.flirt] += 20;
            possibleDialogTypesWeights[(int)DialogType.mope] =0;
        }
        else if(castManager.cast[char1ID].happiness < 0.5f)
        {
            possibleDialogTypesWeights[2] += 10;
            possibleDialogTypesWeights[(int)DialogType.mope] += 50;
            possibleDialogTypesWeights[(int)DialogType.dislike] += 10;
        }

        //decide dialog weights based on traits
        for (int i = 0; i < castManager.cast[char1ID].traits.Count; i++)
        {
            if (castManager.cast[char1ID].traits.Contains(Trait.traitType.abrasive))
            {
                possibleDialogTypesWeights[(int)DialogType.insult] += 40;
            }
            else if (castManager.cast[char1ID].traits.Contains(Trait.traitType.kind))
            {
                possibleDialogTypesWeights[(int)DialogType.insult] -= 20;
            }
        }

        if (castManager.cast[char1ID].dislikes.Count == 0)
        {
            possibleDialogTypesWeights[(int)DialogType.dislike] = 0;
        }
        if (castManager.cast[char1ID].likes.Count == 0)
        {
            possibleDialogTypesWeights[(int)DialogType.like] = 0;
        }

        //normallises negative weights to zero and adds all weights together
        for (int i = 0; i < possibleDialogTypesWeights.Count; i++)
        {
            if (possibleDialogTypesWeights[i] < 0)
            {
                possibleDialogTypesWeights[i] = 0;
            }
            totalWeights += possibleDialogTypesWeights[i];
        }
        int choice = WeightedRandomGenerator(possibleDialogTypesWeights, totalWeights);
        ChooseDialog(choice);

    }

    void ChooseDialog(int choice)
    {
        switch (choice)
        {
            case 0:
                ChatDialog();
                break;
            case 1:
                FlirtDialog();
                break;
            case 2:
                ArgueDialog();
                break;
            case 3:
                ComplimentDialog();
                break;
            case 4:
                InsultDialog();
                break;
            case 5:
                int randLike = Random.Range(0, castManager.cast[char1ID].likes.Count);
                LikeDialog(castManager.cast[char1ID].likes[randLike]);
                break;
            case 6:
                int randDislike = Random.Range(0, castManager.cast[char1ID].dislikes.Count);
                DislikeDialog(castManager.cast[char1ID].dislikes[randDislike]);   
                break;
            case 7:
                MopeDialog();
                break;

            default:
                break;
        }
    }

    void ChatDialog()
    {
        castManager.cast[char2ID].dialogGen.ListenToDialog(DialogType.Chat, (Likes.likeType)1000, (Likes.likeType)1000, char1ID, char2ID);
        castManager.cast[char1ID].SendDialogMessage(castManager.cast[char1ID].name + " Says:  Hey " + castManager.cast[char2ID].name + " Nice weather we're having.");
    }

    void FlirtDialog()
    {
        castManager.cast[char2ID].dialogGen.ListenToDialog(DialogType.flirt, (Likes.likeType)1000, (Likes.likeType)1000, char1ID, char2ID);
        castManager.cast[char1ID].SendDialogMessage(castManager.cast[char1ID].name + " Says:   hi " + castManager.cast[char2ID].name  + " ;).");
    }

    void ArgueDialog()
    {
        castManager.cast[char2ID].dialogGen.ListenToDialog(DialogType.argue, (Likes.likeType)1000, (Likes.likeType)1000, char1ID, char2ID);
        castManager.cast[char1ID].SendDialogMessage(castManager.cast[char1ID].name + " Says:  " + castManager.cast[char2ID].name + " what is wrong with you?!?");
    }
    void ComplimentDialog()
    {
        castManager.cast[char2ID].dialogGen.ListenToDialog(DialogType.compliment, (Likes.likeType)1000, (Likes.likeType)1000, char1ID, char2ID);
        castManager.cast[char1ID].SendDialogMessage(castManager.cast[char1ID].name + " Says:  Hey " + castManager.cast[char2ID].name + " looking great.");
    }
    void MopeDialog()
    {
        castManager.cast[char2ID].dialogGen.ListenToDialog(DialogType.mope, (Likes.likeType)1000, (Likes.likeType)1000, char1ID, char2ID);
        castManager.cast[char1ID].SendDialogMessage(castManager.cast[char1ID].name + " Says:   its life... i guess");
    }
    public void InsultDialog()
    {
        castManager.cast[char2ID].dialogGen.ListenToDialog(DialogType.insult, (Likes.likeType)1000, (Likes.likeType)1000, char1ID, char2ID);
        castManager.cast[char1ID].SendDialogMessage(castManager.cast[char1ID].name + " Says: wow " + castManager.cast[char2ID].name + " you're a moron");
    }
    void LikeDialog(Likes.likeType like)
    {
        castManager.cast[char2ID].dialogGen.ListenToDialog((DialogType)1000, like, (Likes.likeType)1000, char1ID, char2ID);
        castManager.cast[char1ID].SendDialogMessage(castManager.cast[char1ID].name + " Says:  I really like " + like);
    }
    void DislikeDialog(Likes.likeType dislike)
    {
        castManager.cast[char2ID].dialogGen.ListenToDialog((DialogType)1000, (Likes.likeType)1000, dislike, char1ID, char2ID);
        castManager.cast[char1ID].SendDialogMessage(castManager.cast[char1ID].name + " Says:  I really dont't like " + dislike);
    }

    public void ListenToDialog(DialogType dialogType, Likes.likeType liked, Likes.likeType dislikes, int charID, int thisCharID)
    {
        char1ID = thisCharID;
        char2ID = charID;
        if (liked != (Likes.likeType)1000)
        {
            if (castManager.cast[thisCharID].likes.Contains(liked))
            {
                castManager.cast[thisCharID].relations[charID] += 0.05f;
            }
            else
            {
                castManager.cast[thisCharID].relations[charID] -= 0.05f;
            }
        }
        else if (dislikes != (Likes.likeType)1000)
        {
            if (castManager.cast[thisCharID].likes.Contains(liked))
            {
                castManager.cast[thisCharID].relations[charID] -= 0.05f;
            }
            else
            {
                castManager.cast[thisCharID].relations[charID] += 0.05f;
            }
        }
        else
        {
            DialogReaction(dialogType);
        }
        
        int rand = Random.Range(0,3);
        if (rand < 2)
        {
            CreateDialog();
        }
        
    }

    int WeightedRandomGenerator(List<int> weights, int totalWeights)
    {
        int rand = Random.Range(0, totalWeights);
        for (int i = 0; i < weights.Count; i++)
        {
            if (rand < weights[i])
            {
                return i;
            }
            rand = rand - weights[i];
        }
        return 0;
    }

    void DialogReaction(DialogType dialogType)
    {
        switch (dialogType)
        {
            case DialogType.Chat:
                castManager.cast[char1ID].relations[char2ID] += 0.05f;
                break;
            case DialogType.flirt:
                if (castManager.cast[char1ID].relations[char2ID] > 0.9f)
                {
                    castManager.cast[char1ID].relations[char2ID] += 0.1f;
                }
                break;
            case DialogType.argue:
                castManager.cast[char1ID].relations[char2ID] -= 0.1f;
                castManager.cast[char1ID].angry += 0.2f;
                castManager.cast[char2ID].angry += 0.2f;
                break;
            case DialogType.compliment:
                castManager.cast[char1ID].relations[char2ID] += 0.05f;
                castManager.cast[char2ID].happiness += 0.1f;
                break;
            case DialogType.insult:
                castManager.cast[char1ID].relations[char2ID] -= 0.05f;
                castManager.cast[char2ID].happiness -= 0.2f;
                castManager.cast[char2ID].angry += 0.2f;
                break;
            case DialogType.mope:
                castManager.cast[char2ID].happiness -= 0.1f;
                break;
        }
    }
}




