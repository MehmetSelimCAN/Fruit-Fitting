using UnityEngine;

[CreateAssetMenu(fileName = "NotInSameRow", menuName = "Restriction/NotInSameRow")]
public class NotInSameRowRestrictionSO : RestrictionSO
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
                    for (int i = 0; i < Grid.Cols; i++)
                    {
                        if (Grid.Cells[i, y].Item?.ItemType == itemType2)
                        {
                            //In same row
                            return false;
                        }
                    }
                }
            }
        }

        //Not in same row
        return true;
    }
}
