using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text charInfoName;
    public Text emotionalInfoText;
    public Text dialogTxt;
    public List<string> dialog;
    public GameObject selectedCharacter;
    public GameObject prefabCharacter;
    

    public GameEvents events;

    public List<int> causedByChar;
    public List<int> affectedChar;
    public CastManager cast;
    [SerializeField] int eventID;

    public GameObject historyScreen;
    public Text historyScreenText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddCharacter()
    {
        GameObject go = Instantiate(prefabCharacter, new Vector3(0, 0, 0), Quaternion.identity);
        go.GetComponent<CharacterInfo>().cast = cast;
        go.GetComponent<CharacterHistory>().castManager = cast;
        cast.SetNewRelations(cast.cast.Count -1);
    }

    public void AddMemory()
    {
        selectedCharacter.GetComponent<CharacterInfo>().brain.Add(new Memory(events, eventID, 0, causedByChar, affectedChar, cast.cast));
        cast.cast[affectedChar[0]].isAlive = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        CharacterInfo info = selectedCharacter.GetComponent<CharacterInfo>();
        charInfoName.text = "Name:      " + info.name + "\n";
        charInfoName.text += "Likes\n";
        for (int i = 0; i < info.likes.Count; i++)
        {
            charInfoName.text += info.likes[i] + ", ";
        }
        charInfoName.text += "\nDislikes\n";
        for (int i = 0; i < info.dislikes.Count; i++)
        {
            charInfoName.text += info.dislikes[i] + ", ";
        }
        charInfoName.text += "\nTraits\n";
        for (int i = 0; i < info.traits.Count; i++)
        {
            charInfoName.text += info.traits[i] + ", ";
        }

        emotionalInfoText.text = "Happiness:     " + info.happiness.ToString() + "\n";
        emotionalInfoText.text += "Anger:         " + info.angry.ToString() + "\n";
        for (int i = 0; i < info.relations.Count; i++)
        {
            emotionalInfoText.text += cast.cast[i].name + ":      " + cast.cast[info.id].relations[i] + "\n";
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.tag == "Character")
            {
                selectedCharacter = hit.collider.gameObject;
            }
        }
        UpdateDialogTxt();
    }

    void UpdateDialogTxt()
    {
        dialogTxt.text = "\n";
        for (int i = dialog.Count -1; i > 0; i--)
        {
            dialogTxt.text += dialog[i] + "\n";
        }
    }

    void UpdateHistoryTxt()
    {
        historyScreenText.text = selectedCharacter.GetComponent<CharacterHistory>().historyScript;
    }

    public void HistoryOpen() {
        historyScreen.SetActive(true);
        UpdateHistoryTxt();
    }

    public void HistoryClose()
    {
        historyScreen.SetActive(false);
    }
}
