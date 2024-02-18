using UnityEngine;

[CreateAssetMenu(fileName = "AtLeastOneInCorner", menuName = "Restriction/AtLeastOneInCorner")]
public class AtLeastOneInCornerRestrictionSO : RestrictionSO
{
    [SerializeField] private ItemType itemType1;

    public override bool CheckRestriction()
    {
        if (Grid.Cells[Grid.Cols - 1, Grid.Rows - 1].Item?.ItemType == itemType1 ||
            Grid.Cells[0, Grid.Rows - 1].Item?.ItemType == itemType1 ||
            Grid.Cells[Grid.Cols - 1, 0].Item?.ItemType == itemType1 ||
            Grid.Cells[0, 0].Item?.ItemType == itemType1) 
        {
            Debug.Log("In Corner");
            return true;
        }

        Debug.Log("Not In Corner");
        return false;
    }
}
