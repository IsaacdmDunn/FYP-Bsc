using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    
    public string name;
    public int id;
    public int health = 100;
    //traits list
    public List<Likes.likeType> likes;
    public List<Likes.likeType> dislikes;
    public List<Trait.traitType> traits;
    public float happiness = 1.0f;
    public float angry = 0.0f; 
    public List<float> relations;
    public List<Likes.likeType> uniqueLikes;
    public List<Trait.traitType> uniqueTraits;
    public bool isAlive = true;
    public bool isMentallyStable = true;
    enum firstNames {John=0,Dave,Katie,Pauline,Mohammad,Greg, Boris,Ashley,Jackie,Kevin };
    enum lastNames { Jackson=0, White, Black, Rose, Hobbs, Dunn, Harris, North, Anderson}

    public List<Memory> brain;
    public CastManager cast;
    public List<int> causedBy = new List<int>();
    public List<int> affected = new List<int>();

    public DialogGenerator dialogGen = new DialogGenerator();
    public int randomEventPicker;
    public void Start()
    {
        randomEventPicker = Random.Range(0, 1000000);
        frame = Random.Range(0, 3000);

        id = cast.cast.Count;
        dialogGen.char1ID = id;
        dialogGen.castManager = cast;
        cast.cast.Add(this);

        happiness = 1f;
        angry = 0f;

        firstNames fname = (firstNames)Random.Range(0, 9);
        lastNames lname = (lastNames)Random.Range(0, 8);
        name = fname.ToString() + " " + lname.ToString();
        cast.cast[id].gameObject.GetComponent<CharacterHistory>().castManager = cast;
        cast.cast[id].gameObject.GetComponent<CharacterHistory>().SetLifeEvents(id);
        //for (int i = 0; i < 4; i++)
        //{
        //    Likes.likeType _like = (Likes.likeType)i;
        //    uniqueLikes.Add(_like);
        //}
        //for (int i = 0; i < 4; i++)
        //{
        //    Trait.traitType _trait = (Trait.traitType)i;
        //    uniqueTraits.Add(_trait);
        //}


        //for (int i = 0; i < 2; i++)
        //{
        //    Likes.likeType _like = uniqueLikes[Random.Range(0, uniqueLikes.Count)];
        //    likes.Add(_like);
        //    uniqueLikes.Remove(_like);
        //}
        //for (int i = 0; i < 2; i++)
        //{
        //    Likes.likeType _dislike = uniqueLikes[Random.Range(0, uniqueLikes.Count)];
        //    dislikes.Add(_dislike);
        //    uniqueLikes.Remove(_dislike);
        //}
        //for (int i = 0; i < 2; i++)
        //{
        //    Trait.traitType _trait = uniqueTraits[Random.Range(0, uniqueTraits.Count)];
        //    traits.Add(_trait);
        //    uniqueTraits.Remove(_trait);
        //}

        //coroutine to delay initialisation of traits so that other characters can initialise
        {
            StartCoroutine(LateStart(1));
        }

        IEnumerator LateStart(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            cast.SetInitialRelations(id);
        }

        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Jobs>().type == Jobs.taskType.kill && isAlive)
        {
            //    if (collision.gameObject.GetComponent<Jobs>().tasks[0].type == Task.taskType.attack || collision.gameObject.GetComponent<Jobs>().tasks[0].type == Task.taskType.kill)
            //    {
            for (int i = 0; i < cast.cast.Count; i++)
            {


                causedBy.Add(collision.gameObject.GetComponent<CharacterInfo>().id);
                affected.Add(id);

                Memory memToAdd = new Memory(null, 0, 0, null, null, null);
                memToAdd.affectedChar = affected;
                memToAdd.causedByChar = causedBy;
                memToAdd.cast = cast.cast;
                memToAdd.timeStamp = 0;
                memToAdd.id = 1;
                memToAdd.precon = null;
                //GameObject go = Instantiate(memToAdd.gameObject);
                for (int j = 0; j < cast.cast.Count; j++)
                {
                    if (j != affected[0] && j != causedBy[0] && isAlive)
                    {
                        cast.cast[j].brain.Add(memToAdd);

                    }

                }
                isAlive = false;
            }
        }
        //}
    }


    int frame;

    private void Update()
    {
        //change for job system in behaviour trees
        if (frame == 3000)
        {
            
            frame = 0;

            dialogGen.castManager = cast;
            dialogGen.PickRandomPerson();
            dialogGen.CreateDialog();

            for (int i = 0; i < relations.Count; i++)
            {
                if (relations[i] > 1f)
                {
                    relations[i] = 1f;
                }
                else if (relations[i] < -1f)
                {
                    relations[i] = -1f;
                }

                
            }
        }
        frame++;

        //checks for mental break
        if (happiness < 0.1f && isMentallyStable == true)
        {
            
            affected.Add(Random.Range(0, cast.cast.Count-1));
            causedBy.Add(id);
            gameObject.GetComponent<CharacterInfo>().brain.Add(new Memory(null, 5, 0, causedBy, affected, cast.cast));
            isMentallyStable = false;
            affected = new List<int>();
            causedBy = new List<int>();
        }
        randomEventPicker--;
       
        if (randomEventPicker == -1)
        {
            randomEventPicker = Random.Range(0, 1000000);
            //Debug.Log("jahijdhaijhdai");
            LoveTriangle(id);
        }
    }

    public void SendDialogMessage(string dialog)
    {
        FindObjectOfType<UI>().dialog.Add(dialog);
    }



    void LoveTriangle(int characterID)
    {

        int loveInterest1 = Random.Range(0, cast.cast.Count);
        int loveInterest2 = Random.Range(0, cast.cast.Count);

        while (loveInterest1 == characterID || loveInterest1 == loveInterest2)
        {
            loveInterest1 = Random.Range(0, cast.cast.Count);
        }
        while (loveInterest2 == characterID || loveInterest1 == loveInterest2)
        {
            loveInterest2 = Random.Range(0, cast.cast.Count);
        }
        //for (int i = 0; i < cast.cast[characterID].relations.Count; i++)
        //{
        //    if (i == characterID)
        //    {
        //        continue;
        //    }
        //    if (cast.cast[characterID].relations[i] > cast.cast[characterID].relations[loveInterest1])
        //    {
        //        if (cast.cast[i].relations[characterID] > 0.5f)
        //        {
        //            i = loveInterest1;
        //            precon1 = true;
        //        }

        //    }
        //    else if (cast.cast[characterID].relations[i] > cast.cast[characterID].relations[loveInterest2] && cast.cast[characterID].relations[i] < cast.cast[characterID].relations[loveInterest1])
        //    {
        //        if (cast.cast[i].relations[characterID] > 0.5f)
        //        {
        //            loveInterest1 = loveInterest2;
        //            i = loveInterest1;
        //            precon2 = true;
        //        }
        //    }
        //    else if (cast.cast[characterID].relations[i] > cast.cast[characterID].relations[loveInterest2])
        //    {
        //        if (cast.cast[i].relations[characterID] > 0.5f)
        //        {
        //            i = loveInterest2;
        //            precon2 = true;
        //        }
        //    }
        //}

            affected.Add(loveInterest1);
            affected.Add(loveInterest2);
            causedBy.Add(characterID);
            cast.cast[characterID].GetComponent<CharacterInfo>().brain.Add(new Memory(null, 2, 0, causedBy, affected, cast.cast));
            affected = new List<int>();
            causedBy = new List<int>();
        

    }

}
