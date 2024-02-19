using UnityEngine;

[CreateAssetMenu(fileName = "NotInSameColumn", menuName = "Restriction/NotInSameColumn")]
public class NotInSameColumnRestrictionSO : RestrictionSO
{
    [SerializeField] private ItemType itemType1, itemType2;

    public override bool CheckRestriction()
    {
        for (int y = 0; y < Grid.Rows; y++)
        {
            for (int x = 0; x < Grid.Cols; x++)
            {
                if (Grid.Cells[x, y].Item?.ItemType == itemType1)
                {
                    for (int i = 0; i < Grid.Rows; i++)
                    {
                        if (Grid.Cells[x, i].Item?.ItemType == itemType2)
                        {
                            //In same column
                            return false;
                        }
                    }
                }
            }
        }

        //Not in same column
        return true;
    }
}
