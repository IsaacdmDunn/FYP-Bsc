using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    public CharacterInfo info;
    public CastManager castManager;
    public Node topNode = null;
    public TalkNode talkNode = null;
    public WalktoNode walkToTalk = null;
    public Sequence walkToTalkSQNC = null;
    public Sequence walkToKillSQNC = null;
    public WalktoNode idleNode= null;
    public WalktoNode walkToKill= null;
    public KillNode killNode= null;
    bool willKill;

    private void Start()
    {
        ConstructBT();
    }

    void ConstructBT()
    {
        int killID = Random.Range(0, castManager.cast.Count-1);
        while (killID != info.id)
        {
            killID = Random.Range(0, castManager.cast.Count - 1);
        }
        willKill = false;
        info.angry = -1f;
        //info.relations[1] = -1f;
        if (info.angry < -0.9f)
        {
            willKill = true;
        }
        
        killNode = new KillNode(info, castManager.cast[killID], castManager, willKill);
        walkToKill = new WalktoNode(castManager.cast[killID].transform.position, info.gameObject.transform, false);
        walkToKillSQNC = new Sequence(new List<Node> { killNode });

        talkNode = new TalkNode(false, info, castManager); 
        walkToTalk = new WalktoNode(castManager.cast[1].transform.position, info.gameObject.transform, false);

        walkToTalkSQNC = new Sequence(new List<Node> { walkToTalk, talkNode });
        
        idleNode = new WalktoNode(new Vector3(Random.Range(-4, 5), Random.Range(-3, 3), 0), info.gameObject.transform, true);

        topNode = new Selector(new List<Node> { walkToKillSQNC, walkToTalkSQNC, idleNode });
        
    }

    int timer = 1000;
    private void Update()
    {
        if (info.angry > 0.9f)
        {
            willKill = false;
        }
        timer--;
        if (timer < 0)
        {
            ConstructBT();
        }
        topNode.Evaluate();

        
    }

}
