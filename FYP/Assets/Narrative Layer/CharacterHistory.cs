using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHistory : MonoBehaviour
{
    public CastManager castManager;
    int newCharactersBacklogSize = 5;

    enum EarlyLifeEvents
    {
        dogAttack = 1, catAttack, roughChildhood, farmChild, richKid, antiSocial, sheltered, parentsMurdered, caringParents
    }
    enum RecentEvents
    {
        successfulMiner  = 1, successfulFarmer, farmingAccident, mineCaveIn, recluse, 
    }

    enum FollowUpEvents
    {
        dogSave = 1, urgeForCity, loseOfRich, outOfShell, comingToTermsWithDeadParents,
    }

    List<RecentEvents> recentEvents = new List<RecentEvents>();
    List<EarlyLifeEvents> earlyLifeEvents = new List<EarlyLifeEvents>();
    List<FollowUpEvents> followUpEvents = new List<FollowUpEvents>();

    public string historyScript;

    private void Start()
    {
        
    }

    public void SetLifeEvents(int characterID)
    {
        Debug.Log(castManager.cast[characterID].name + " Life Started out with");
        historyScript += castManager.cast[characterID].name + " Life Started out with";



        for (int i = 1; i < 10; i++)
        {
            earlyLifeEvents.Add((EarlyLifeEvents)i);
        }
        for (int i = 1; i < 5; i++)
        {
            recentEvents.Add((RecentEvents)i);
        }

        for (int i = 0; i < 2; i++)
        {
            
            EarlyLifeEvents randEarly = (EarlyLifeEvents)Random.Range(1, earlyLifeEvents.Count);
            if (i == 1)
            {
                Debug.Log(castManager.cast[characterID].name + " Then later on in their early years they also were");
                historyScript += (castManager.cast[characterID].name + " Then later on in their early years they also were");
            }
            switch (randEarly)
            {
                case EarlyLifeEvents.dogAttack:
                    Debug.Log(" a dog attack which horrifically scarred their arm which caused " + castManager.cast[characterID].name + " to be resentful to all dogs");
                    historyScript += " a dog attack which horrifically scarred their arm which caused " + castManager.cast[characterID].name + " to be resentful to all dogs\n";
                    castManager.cast[characterID].dislikes.Add(Likes.likeType.dogs);
                    earlyLifeEvents.Remove(EarlyLifeEvents.dogAttack);
                    followUpEvents.Add(FollowUpEvents.dogSave);
                    break;
                case EarlyLifeEvents.catAttack:
                    Debug.Log(" a cat hissing at them, being young " + castManager.cast[characterID].name + " was freaked out by this interaction and now despises all cats");
                    historyScript += " a cat hissing at them, being young " + castManager.cast[characterID].name + " was freaked out by this interaction and now despises all cats\n";
                    castManager.cast[characterID].dislikes.Add(Likes.likeType.cats);
                    earlyLifeEvents.Remove(EarlyLifeEvents.catAttack);
                    break;
                case EarlyLifeEvents.roughChildhood:
                    Debug.Log(" a poor upbringing from negletful parents made " + castManager.cast[characterID].name +
                        " a troubled child, lashing out at others and inflicting cruelty on others as their parents did to them");
                    historyScript += " a poor upbringing from negletful parents made " + castManager.cast[characterID].name +
                        " a troubled child, lashing out at others and inflicting cruelty on others as their parents did to them \n";
                    castManager.cast[characterID].traits.Add(Trait.traitType.agressive);
                    castManager.cast[characterID].traits.Add(Trait.traitType.abrasive);
                    earlyLifeEvents.Remove(EarlyLifeEvents.roughChildhood);
                    break;
                case EarlyLifeEvents.farmChild:
                    Debug.Log(" being a country bumpkin growing up made " + castManager.cast[characterID].name + " grow up doing various chores around their parents farm");
                    historyScript += " being a country bumpkin growing up made " + castManager.cast[characterID].name + " grow up doing various chores around their parents farm\n";
                    earlyLifeEvents.Remove(EarlyLifeEvents.farmChild);
                    followUpEvents.Add(FollowUpEvents.urgeForCity);
                    break;
                case EarlyLifeEvents.richKid:
                    Debug.Log(" a cushy upbringing with their parents being from the wealthy elite " + castManager.cast[characterID].name + " lived a life of luxury");
                    historyScript += " a cushy upbringing with their parents being from the wealthy elite " + castManager.cast[characterID].name + " lived a life of luxury\n";
                    castManager.cast[characterID].dislikes.Add(Likes.likeType.farming);
                    castManager.cast[characterID].dislikes.Add(Likes.likeType.mining);
                    castManager.cast[characterID].traits.Add(Trait.traitType.lazy);
                    earlyLifeEvents.Remove(EarlyLifeEvents.richKid);
                    followUpEvents.Add(FollowUpEvents.loseOfRich);
                    break;
                case EarlyLifeEvents.antiSocial:
                    Debug.Log(" an awkard upbringing with " + castManager.cast[characterID].name + " stuggling to tackle the nuances of social life");
                    historyScript += " an awkard upbringing with " + castManager.cast[characterID].name + " stuggling to tackle the nuances of social life\n";
                    castManager.cast[characterID].traits.Add(Trait.traitType.abrasive);
                    earlyLifeEvents.Remove(EarlyLifeEvents.antiSocial);
                    followUpEvents.Add(FollowUpEvents.outOfShell);
                    break;
                case EarlyLifeEvents.sheltered:
                    Debug.Log(" plenty of innocence with " + castManager.cast[characterID].name + "'s parents taking care to shelter them");
                    historyScript += " plenty of innocence with " + castManager.cast[characterID].name + "'s parents taking care to shelter them\n";
                    castManager.cast[characterID].traits.Add(Trait.traitType.forgiving);
                    earlyLifeEvents.Remove(EarlyLifeEvents.sheltered);
                    followUpEvents.Add(FollowUpEvents.outOfShell);
                    break;
                case EarlyLifeEvents.parentsMurdered:
                    Debug.Log(" the tragic death of " + castManager.cast[characterID].name + "'s parents after a robbery gone wrong.");
                    historyScript += " the tragic death of " + castManager.cast[characterID].name + "'s parents after a robbery gone wrong.";
                    castManager.cast[characterID].traits.Add(Trait.traitType.vengeful);
                    earlyLifeEvents.Remove(EarlyLifeEvents.parentsMurdered);
                    followUpEvents.Add(FollowUpEvents.comingToTermsWithDeadParents);
                    break;
                case EarlyLifeEvents.caringParents:
                    Debug.Log(" very loving parents doing anything to help " + castManager.cast[characterID].name + "and nurture them");
                    historyScript += " very loving parents doing anything to help " + castManager.cast[characterID].name + "and nurture them\n";
                    castManager.cast[characterID].traits.Add(Trait.traitType.kind);
                    earlyLifeEvents.Remove(EarlyLifeEvents.caringParents);
                    break;
                default:
                    break;
            }
        }
        Debug.Log(castManager.cast[characterID].name + " during their adult years ");
        historyScript += castManager.cast[characterID].name + " during their adult years ";


        RecentEvents randRecent = (RecentEvents)Random.Range(1, recentEvents.Count);
        switch (randRecent)
        {
            case RecentEvents.successfulMiner:
                recentEvents.Remove(RecentEvents.successfulMiner);
                castManager.cast[characterID].likes.Remove(Likes.likeType.mining);
                castManager.cast[characterID].likes.Add(Likes.likeType.mining);
                Debug.Log(" became a successful miner and throughly enjoyed deep deep beneath the earth");
                historyScript += " became a successful miner and throughly enjoyed deep deep beneath the earth\n";
                break;
            case RecentEvents.successfulFarmer:
                Debug.Log(" was a successful farmer tilling crops for many years living the life of their forefathers");
                historyScript += " was a successful farmer tilling crops for many years living the life of their forefathers \n";
                recentEvents.Remove(RecentEvents.successfulFarmer);

                castManager.cast[characterID].likes.Remove(Likes.likeType.farming);
                castManager.cast[characterID].likes.Add(Likes.likeType.farming);
                break;
            case RecentEvents.farmingAccident:
                Debug.Log(" they were hit by a tractor which made them grow to dispise farming");
                historyScript += " they were hit by a tractor which made them grow to dispise farming \n";
                recentEvents.Remove(RecentEvents.farmingAccident);

                castManager.cast[characterID].likes.Remove(Likes.likeType.farming);
                castManager.cast[characterID].dislikes.Remove(Likes.likeType.farming);
                castManager.cast[characterID].dislikes.Add(Likes.likeType.farming);
                break;
            case RecentEvents.mineCaveIn:
                Debug.Log(" suffered a cave in while working in the mines. the resulting PTSD made them afraid to go anywhere near the underground");
                historyScript += " suffered a cave in while working in the mines. the resulting PTSD made them afraid to go anywhere near the underground \n";
                recentEvents.Remove(RecentEvents.mineCaveIn);
                castManager.cast[characterID].likes.Remove(Likes.likeType.mining);
                castManager.cast[characterID].dislikes.Remove(Likes.likeType.mining);
                castManager.cast[characterID].dislikes.Add(Likes.likeType.mining);
                break;
            case RecentEvents.recluse:
                recentEvents.Remove(RecentEvents.recluse);
                Debug.Log(" they became a social recluse rarely talking to anyone");
                historyScript += " they became a social recluse rarely talking to anyone \n";
                break;
            default:
                break;
        }
        Debug.Log(castManager.cast[characterID].name + " at some point in their lives their past confroted them after");
        historyScript += " at some point in their lives their past confroted them after \n";
        FollowUpEvents randFollowUpEvents = (FollowUpEvents)Random.Range(1, followUpEvents.Count);
        switch (randFollowUpEvents)
        {
            case CharacterHistory.FollowUpEvents.dogSave:
                Debug.Log(" was saved by a dog after almost drowning which they then learned to forgive and grew to love dogs");
                historyScript += " was saved by a dog after almost drowning which they then learned to forgive and grew to love dogs \n";
                castManager.cast[characterID].dislikes.Remove(Likes.likeType.dogs);
                castManager.cast[characterID].likes.Remove(Likes.likeType.dogs);
                castManager.cast[characterID].likes.Add(Likes.likeType.dogs);
                followUpEvents.Remove(FollowUpEvents.dogSave);
                break;
            case CharacterHistory.FollowUpEvents.urgeForCity:
                Debug.Log(" was seeing pictures of the city and life out of the countryside gave " + castManager.cast[characterID].name + " a sense of wanderlust wanting to go to the city");
                historyScript += " was seeing pictures of the city and life out of the countryside gave " + castManager.cast[characterID].name + " a sense of wanderlust wanting to go to the city \n";
                castManager.cast[characterID].likes.Remove(Likes.likeType.farming);
                castManager.cast[characterID].dislikes.Remove(Likes.likeType.farming);
                castManager.cast[characterID].dislikes.Add(Likes.likeType.farming);
                followUpEvents.Remove(FollowUpEvents.urgeForCity);
                break;            
            case CharacterHistory.FollowUpEvents.loseOfRich:
                Debug.Log(" " + castManager.cast[characterID].name + "'s parents lost all their savings in various ponzi schemes and crypto scams forcing them to give up the life of luxury and in the process teaching them the value of hard work");
                historyScript += "'s parents lost all their savings in various ponzi schemes and crypto scams forcing them to give up the life of luxury and in the process teaching them the value of hard work \n";
                castManager.cast[characterID].traits.Remove(Trait.traitType.lazy);
                followUpEvents.Remove(FollowUpEvents.loseOfRich);
                break;            
            case CharacterHistory.FollowUpEvents.outOfShell:
                Debug.Log(" began to come out of their shell and was able to talk and engage with a close knit group of freinds");
                historyScript += " began to come out of their shell and was able to talk and engage with a close knit group of freinds \n";
                castManager.cast[characterID].traits.Remove(Trait.traitType.abrasive);
                followUpEvents.Remove(FollowUpEvents.outOfShell);
                break;            
            case CharacterHistory.FollowUpEvents.comingToTermsWithDeadParents:
                Debug.Log(" they slowly lost their will for vengence and learned to honour their memory as they wouldnt want their kid to be a murderer so " + castManager.cast[characterID].name + " slowly began to forgive");

                historyScript += " they slowly lost their will for vengence and learned to honour their memory as they wouldnt want their kid to be a murderer so " + castManager.cast[characterID].name + " slowly began to forgive \n"; 
                castManager.cast[characterID].traits.Remove(Trait.traitType.vengeful);
                castManager.cast[characterID].traits.Remove(Trait.traitType.forgiving);
                castManager.cast[characterID].traits.Add(Trait.traitType.forgiving);
                followUpEvents.Remove(FollowUpEvents.comingToTermsWithDeadParents);
                break;
            default:
                break;
        }
    }


    
}
