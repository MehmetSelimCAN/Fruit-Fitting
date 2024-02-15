using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fruit", menuName = "Restriction/New Fruit")]
public class NewFruitRestrictionSO : RestrictionSO
{
    public List<NewFruitSO> list;

    public NewFruitRestrictionSO()
    {
        isNewFruitRestriction = true;
    }

    public override bool CheckRestriction()
    {
        bool anyFruitRemain = restrictionArea.NewFruitsPanel.CheckAnyFruitRemain();
        return !anyFruitRemain;
    }
}
