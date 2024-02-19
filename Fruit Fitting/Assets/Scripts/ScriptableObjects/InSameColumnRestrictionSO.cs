using UnityEngine;

[CreateAssetMenu(fileName = "InSameColumn", menuName = "Restriction/InSameColumn")]
public class InSameColumnRestrictionSO : RestrictionSO
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
                    for (int i = 0; i < Grid.Rows; i++)
                    {
                        if (Grid.Cells[x, i].Item?.ItemType == itemType2)
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

        return itemType2Found;
    }
}
