using UnityEngine;

[CreateAssetMenu(fileName = "Adjacent", menuName = "Restriction/Adjacent")]
public class AdjacentRestrictionSO : RestrictionSO
{
    [SerializeField] private ItemType itemType1, itemType2;

    public override bool CheckRestriction()
    {
        bool adjacent = false;
        for (int y = 0; y < Grid.Rows; y++)
        {
            for (int x = 0; x < Grid.Cols; x++)
            {
                if (Grid.Cells[x, y].Item?.ItemType == itemType1)
                {
                    adjacent = false;
                    if ((x > 0 && Grid.Cells[x - 1, y].Item?.ItemType == itemType2) ||
                        (y > 0 && Grid.Cells[x, y - 1].Item?.ItemType == itemType2) ||
                        (x < Grid.Cols - 1 && Grid.Cells[x + 1, y].Item?.ItemType == itemType2) ||
                        (y < Grid.Rows - 1 && Grid.Cells[x, y + 1].Item?.ItemType == itemType2))
                    {
                        adjacent = true;
                    }

                    if (!adjacent)
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }
}
