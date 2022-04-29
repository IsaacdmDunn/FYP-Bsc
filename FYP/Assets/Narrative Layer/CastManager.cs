using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastManager : MonoBehaviour
{
    [SerializeField]public List<CharacterInfo> cast;


    public void SetInitialRelations(int characterID)
    {
        
        for (int i = 0; i < cast.Count; i++)
        {
            float initialRelationValue = 0;
            if ((cast[i].traits.Contains((Trait.traitType)1) && cast[characterID].traits.Contains((Trait.traitType)4))
                || (cast[i].traits.Contains((Trait.traitType)4) && cast[characterID].traits.Contains((Trait.traitType)1)))//vengful vs forgiving
            {
                initialRelationValue -= 0.2f;
            }
            if ((cast[i].traits.Contains((Trait.traitType)0) && cast[characterID].traits.Contains((Trait.traitType)3))
                || (cast[i].traits.Contains((Trait.traitType)3) && cast[characterID].traits.Contains((Trait.traitType)0)))//abrasive vs sensitive
            {
                initialRelationValue -= 0.2f;
            }
            cast[characterID].relations.Add(initialRelationValue);
        }
        //cast[characterID].relations
    }

    public void SetNewRelations(int characterID)
    {
        for (int i = 0; i < cast.Count; i++)
        {
            float initialRelationValue = 0;
            if ((cast[i].traits.Contains((Trait.traitType)1) && cast[characterID].traits.Contains((Trait.traitType)4))
                || (cast[i].traits.Contains((Trait.traitType)4) && cast[characterID].traits.Contains((Trait.traitType)1)))//vengful vs forgiving
            {
                initialRelationValue -= 0.2f;
            }
            if ((cast[i].traits.Contains((Trait.traitType)0) && cast[characterID].traits.Contains((Trait.traitType)3))
                || (cast[i].traits.Contains((Trait.traitType)3) && cast[characterID].traits.Contains((Trait.traitType)0)))//abrasive vs sensitive
            {
                initialRelationValue -= 0.2f;
            }
            cast[i].relations.Add(initialRelationValue);
        }
    }
}
