using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AdjacentToFourUnique", menuName = "Restriction/Adjacent To Four Unique")]
public class AdjacentToFourUniqueRestrictionSO : RestrictionSO
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
                    if (x > 0 && Grid.Cells[x - 1, y].Item != null)
                    {
                        itemTypes.Add(Grid.Cells[x - 1, y].Item.ItemType);
                    }

                    if (x != Grid.Cols - 1 && Grid.Cells[x + 1, y].Item != null)
                    {
                        itemTypes.Add(Grid.Cells[x + 1, y].Item.ItemType);
                    }

                    if (y != Grid.Rows - 1 && Grid.Cells[x, y + 1].Item != null)
                    {
                        itemTypes.Add(Grid.Cells[x, y + 1].Item.ItemType);
                    }

                    if (y > 0 && Grid.Cells[x, y - 1].Item != null)
                    {
                        itemTypes.Add(Grid.Cells[x, y - 1].Item.ItemType);
                    }

                    if (itemTypes.Count < 4)
                    {
                        return false;
                    }
                }
            }
        }

        return itemTypes.Count > 3;
    }
}
