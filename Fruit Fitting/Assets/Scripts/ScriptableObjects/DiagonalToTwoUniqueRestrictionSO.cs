using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DiagonalToTwoUnique", menuName = "Restriction/DiagonalToTwoUnique")]
public class DiagonalToTwoUniqueRestrictionSO : RestrictionSO
{
    [SerializeField] private ItemType itemType1;

    public override bool CheckRestriction()
    {
        HashSet<ItemType> itemTypes = new HashSet<ItemType>();
        for (int y = 0; y < Grid.Rows; y++)
        {
            for (int x = 0; x < Grid.Cols; x++)
            {
                if (Grid.Cells[x, y].Item?.ItemType == itemType1)
                {
                    itemTypes.Clear();
                    if (x > 0 && y > 0 && Grid.Cells[x - 1, y - 1].Item != null)
                    {
                        itemTypes.Add(Grid.Cells[x - 1, y - 1].Item.ItemType);
                    }
                    
                    if (x != Grid.Cols - 1 && y > 0 && Grid.Cells[x + 1, y - 1].Item != null)
                    {
                        itemTypes.Add(Grid.Cells[x + 1, y - 1].Item.ItemType);
                    }

                    if (x > 0 && y != Grid.Rows - 1 && Grid.Cells[x - 1, y + 1].Item != null)
                    {
                        itemTypes.Add(Grid.Cells[x - 1, y + 1].Item.ItemType);
                    }

                    if (x != Grid.Cols - 1 && y != Grid.Cols - 1 && Grid.Cells[x + 1, y + 1].Item != null)
                    {
                        itemTypes.Add(Grid.Cells[x + 1, y + 1].Item.ItemType);
                    }

                    if (itemTypes.Count < 2)
                    {
                        return false;
                    }
                }
            }
        }

        return itemTypes.Count > 1;
    }
}
