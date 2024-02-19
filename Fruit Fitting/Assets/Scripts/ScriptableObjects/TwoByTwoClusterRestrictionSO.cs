using UnityEngine;

[CreateAssetMenu(fileName = "TwoByTwoCluster", menuName = "Restriction/Two By Two Cluster")]
public class TwoByTwoClusterRestrictionSO : RestrictionSO
{
    [SerializeField] private ItemType itemType1;

    public override bool CheckRestriction()
    {
        for (int y = 0; y < Grid.Rows; y++)
        {
            for (int x = 0; x < Grid.Cols; x++)
            {
                if (Grid.Cells[x, y].Item?.ItemType == itemType1 &&
                    x < Grid.Cols - 1 && Grid.Cells[x + 1, y].Item?.ItemType == itemType1 &&
                    y < Grid.Rows - 1 && Grid.Cells[x, y + 1].Item?.ItemType == itemType1 &&
                    x < Grid.Cols - 1 && y < Grid.Rows - 1 && Grid.Cells[x + 1, y + 1].Item?.ItemType == itemType1)
                {
                    //Cluster
                    return true;
                }
            }
        }
        //Not Cluster
        return false;
    }
}
