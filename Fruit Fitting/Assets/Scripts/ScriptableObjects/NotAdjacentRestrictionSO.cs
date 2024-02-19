using UnityEngine;

[CreateAssetMenu(fileName = "NotAdjacent", menuName = "Restriction/NotAdjacent")]
public class NotAdjacentRestrictionSO : RestrictionSO
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
                    if (x > 0 && Grid.Cells[x - 1, y].Item?.ItemType == itemType2 ||
                        y > 0 && Grid.Cells[x, y - 1].Item?.ItemType == itemType2 ||
                        x != Grid.Cols - 1 && Grid.Cells[x + 1, y].Item?.ItemType == itemType2 ||
                        y != Grid.Rows - 1 && Grid.Cells[x, y + 1].Item?.ItemType == itemType2)
                    {
                        //Adjacent
                        return false;
                    }
                }
            }
        }

        //Not adjacent
        return true;
    }
}
