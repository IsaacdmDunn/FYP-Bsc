using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public List<int> causedByChar;
    public List<int> affectedChar;
    public CastManager cast;
    public int eventTimeStep;
    public int longestTime=10000;
    public Memory memToAdd;

    public void Start()
    {
        
    }
    void CheckMemory()
    {
        if (eventTimeStep == 5)
        {
            eventTimeStep = 0;

            longestTime = 10000;

            //check each characters memory
            //for (int i = 0; i < cast.cast.Count; i++)
            //{
            //    if (cast.cast[i].isAlive)
            //    {
            //        for (int j = 0; j < cast.cast[i].brain.Count; j++)
            //        {
            //            if (cast.cast[i].brain[j].timeStamp < longestTime)
            //            {
            //                longestTime = cast.cast[i].brain[j].timeStamp;
            //            }
            //        }
            //    }
            //}


            //picks event based on timestamp
            for (int i = 0; i < cast.cast.Count; i++)
            {

                for (int j = 0; j < cast.cast[i].brain.Count; j++)
                {
                    if (cast.cast[i].isAlive)
                    {
                        switch (cast.cast[i].brain[j].id)
                        {
                            case 1: //murder
                                causedByChar.Add(cast.cast[i].brain[j].causedByChar[0]);
                                affectedChar.Add(cast.cast[i].brain[j].affectedChar[0]);

                                
                                MurderRememberPrecondition(i, j);
                                break;
                            case 2:
                                causedByChar.Add(cast.cast[i].brain[j].causedByChar[0]);
                                affectedChar.Add(cast.cast[i].brain[j].affectedChar[0]);
                                affectedChar.Add(cast.cast[i].brain[j].affectedChar[1]);
                                LoveTriReactionPrecon(cast.cast[i].brain[j].causedByChar[0], cast.cast[i].brain[j].affectedChar[0], cast.cast[i].brain[j].affectedChar[1], j);
                                break;
                            case 3:
                                causedByChar.Add(cast.cast[i].brain[j].causedByChar[0]);
                                affectedChar.Add(cast.cast[i].brain[j].affectedChar[0]);
                                affectedChar.Add(cast.cast[i].brain[j].affectedChar[1]);
                                LoveTriConclusion(cast.cast[i].brain[j].causedByChar[0], cast.cast[i].brain[j].affectedChar[0], cast.cast[i].brain[j].affectedChar[1], j);
                                break;
                            case 4:
                                break;
                            case 5:
                                causedByChar.Add(cast.cast[i].brain[j].causedByChar[0]);
                                affectedChar.Add(cast.cast[i].brain[j].affectedChar[0]);
                                MentalBreakPrecon(causedByChar[0], j);
                                break;
                        }
                        break;
                    }
                }
            }
            affectedChar.Clear();
            causedByChar.Clear();
        }
    }
    private void Update()
    {

        if (Random.Range(0, 600) == 10) // randomly increases timestep to allow for events to transpire at certain times
        {
            eventTimeStep++;
            CheckMemory();
        }
    }

   

    public void LoveTriReactionPrecon(int mainChar, int loveInterest1, int loveInterest2, int memID)
    {
        bool isFighting = false;
        if (cast.cast[loveInterest1].traits.Contains((Trait.traitType)5))
        {
            Debug.Log("You can't have them I love them!");
            cast.cast[loveInterest1].angry += 0.5f;
            cast.cast[loveInterest1].happiness -= 0.5f;
            cast.cast[loveInterest1].relations[loveInterest2] -= 0.7f;
            isFighting = true;
        }
        else if (cast.cast[loveInterest1].traits.Contains((Trait.traitType)5))
        {
            Debug.Log("You can't have them I love them!");
            cast.cast[loveInterest2].angry += 0.5f;
            cast.cast[loveInterest2].happiness -= 0.5f;
            cast.cast[loveInterest2].relations[loveInterest1] -= 0.7f;
            isFighting = true;
        }
        causedByChar.Add(mainChar);
        affectedChar.Add(loveInterest1);
        affectedChar.Add(loveInterest2);
        cast.cast[mainChar].brain.RemoveAt(memID);
        if (isFighting)
        {
            cast.cast[mainChar].GetComponent<CharacterInfo>().brain.Add(new Memory(this, 3, 0, causedByChar, affectedChar, cast.cast));
        }

    }

    public void LoveTriConclusion(int mainChar, int loveInterest1, int loveInterest2, int memID)
    {
        if (cast.cast[mainChar].traits.Contains(Trait.traitType.sensitive))
        {
            Debug.Log("I cant take it i dont want either of you, im sorry!");
            cast.cast[loveInterest1].relations[mainChar] -= 0.3f;
            cast.cast[loveInterest2].relations[mainChar] -= 0.3f;
            cast.cast[mainChar].relations[loveInterest1] -= 0.3f;
            cast.cast[mainChar].relations[loveInterest2] -= 0.3f;
            cast.cast[loveInterest1].relations[loveInterest2] += 0.5f;
            cast.cast[loveInterest2].relations[loveInterest1] += 0.5f;
        }
        else 
        {
            int finalLoveInterest = 0;
            int rejectLoveInterest = 0;
            int randLoveInt = Random.Range(0, 1);
            if (randLoveInt == 0)
            {
                finalLoveInterest = loveInterest1;
                rejectLoveInterest = loveInterest2;
            }
            else
            {
                finalLoveInterest = loveInterest2;
                rejectLoveInterest = loveInterest1;
            }
            Debug.Log("Im sorry " + cast.cast[rejectLoveInterest].name + " I love " + cast.cast[finalLoveInterest].name);
            cast.cast[finalLoveInterest].relations[mainChar] += 0.5f;
            cast.cast[mainChar].relations[finalLoveInterest] += 0.5f;
            cast.cast[rejectLoveInterest].relations[mainChar] -= 0.5f;
            cast.cast[rejectLoveInterest].relations[rejectLoveInterest] -= 0.5f;
        }
        cast.cast[mainChar].brain.RemoveAt(memID);
    }

    public void MurderRememberPrecondition(int characterID, int memoryID)
    {
        if (cast.cast[characterID].brain[memoryID].cast[causedByChar[0]].isAlive)
        {

            //if cast member is vengeful
            if (cast.cast[characterID].traits.Contains((Trait.traitType)1))
            {
                Debug.Log(cast.cast[characterID].name + " says " + cast.cast[causedByChar[0]].name + " you killed " + cast.cast[affectedChar[0]].name + " prepare to die.");
                cast.cast[characterID].GetComponentInParent<Jobs>().tasks.Add(new Task(cast.cast[causedByChar[0]].transform.position, Task.taskType.kill, cast.cast[causedByChar[0]]));
                //add kill character to jobs list
                //change emotional state
            }
            else
            {
                Debug.Log(cast.cast[characterID].name + " says " + cast.cast[causedByChar[0]].name + " you killed " + cast.cast[affectedChar[0]].name + " how could you");
            }
        }
        cast.cast[characterID].brain.RemoveAt(memoryID);
        
    }
    
    public void MentalBreakPrecon(int affectedID, int memoryID) 
    {
        int targetID = 0;
        for (int i = 0; i < cast.cast.Count; i++)
        {
            if (cast.cast[affectedID].relations[i] < cast.cast[affectedID].relations[targetID] && i != affectedID)
            {
                targetID = i;
            }
        }
        List<int> weights = new List<int>();
        int totalWeight = 0;
        weights.Add(10);//kill
        weights.Add(30);//attack
        weights.Add(60);//insult
        totalWeight += 100;
        //kill
        if (cast.cast[affectedID].traits.Contains((Trait.traitType)5) && cast.cast[affectedID].angry > 0.8f)
        {
            totalWeight += 50;
            weights[0] += 50;

        }
                //fight
        else if (cast.cast[affectedID].traits.Contains((Trait.traitType)5))
        {
            totalWeight += 50;
            weights[1] += 50;

        }
        //insult barrage
        else if (cast.cast[affectedID].traits.Contains((Trait.traitType)1))
        {
            totalWeight += 100;
            weights[2] += 100;

            
        }
        

        switch (WeightedRandomGenerator(weights, totalWeight))
        {
            case 0:
                Debug.Log("MENTAL BREAK:  murder");
                cast.cast[0].SendDialogMessage(cast.cast[0].name + " says " + cast.cast[targetID].name + "! I'M GOING TO KILL YOU!!!!");
                cast.cast[affectedID].GetComponentInParent<Jobs>().tasks.Add(new Task(cast.cast[targetID].transform.position, Task.taskType.kill, cast.cast[targetID]));

                break;
            case 1:
                Debug.Log("MENTAL BREAK:  fight");
                cast.cast[0].SendDialogMessage(cast.cast[0].name + " says " + cast.cast[targetID].name + "! Looking for a smack are ya?");
                cast.cast[affectedID].GetComponentInParent<Jobs>().tasks.Add(new Task(cast.cast[targetID].transform.position, Task.taskType.attack, cast.cast[targetID]));

                break;
            case 2:
                Debug.Log("MENTAL BREAK:  insult spree");
                cast.cast[affectedID].dialogGen.PickRandomPerson();
                cast.cast[affectedID].dialogGen.InsultDialog();
                cast.cast[affectedID].dialogGen.InsultDialog();
                cast.cast[affectedID].dialogGen.InsultDialog();
                break;
            default:
                break;
        }
        cast.cast[affectedID].brain.RemoveAt(memoryID);
        cast.cast[affectedID].happiness = 0.5f;
        cast.cast[affectedID].angry = 0.5f;
        cast.cast[affectedID].isMentallyStable = true;
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
}


