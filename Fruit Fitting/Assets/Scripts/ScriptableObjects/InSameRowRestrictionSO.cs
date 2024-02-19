using UnityEngine;

[CreateAssetMenu(fileName = "InSameRow", menuName = "Restriction/InSameRow")]
public class InSameRowRestrictionSO : RestrictionSO
{
    [SerializeField] private ItemType itemType1, itemType2;

    public override bool CheckRestriction()
    {
        bool itemType2Found = false;
        for (int y = 0; y < Grid.Rows; y++)
        {
            for (int x = 0; x < Grid.Cols; x++)
            {
                if (Grid.Cells[x, y].Item?.ItemType == itemType1)
                {
                    itemType2Found = false;
                    for (int i = 0; i < Grid.Cols; i++)
                    {
                        if (Grid.Cells[i, y].Item?.ItemType == itemType2)
                        {
                            itemType2Found = true;
                        }
                    }

                    if (!itemType2Found)
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }
}
