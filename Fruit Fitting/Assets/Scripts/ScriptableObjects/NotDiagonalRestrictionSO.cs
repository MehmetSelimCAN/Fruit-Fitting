using UnityEngine;

[CreateAssetMenu(fileName = "NotDiagonal", menuName = "Restriction/NotDiagonal")]
public class NotDiagonalRestrictionSO : RestrictionSO
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
                    if (x > 0 && y > 0 && Grid.Cells[x - 1, y - 1].Item?.ItemType == itemType2 ||
                        x != Grid.Cols - 1 && y > 0 && Grid.Cells[x + 1, y - 1].Item?.ItemType == itemType2 ||
                        x > 0 && y != Grid.Rows - 1 && Grid.Cells[x - 1, y + 1].Item?.ItemType == itemType2 ||
                        x != Grid.Cols - 1 && y != Grid.Rows - 1 && Grid.Cells[x + 1, y + 1].Item?.ItemType == itemType2)
                    {
                        //Diagonal
                        return false;
                    }
                }
            }
        }
        //Not diagonal
        return true;
    }
}
