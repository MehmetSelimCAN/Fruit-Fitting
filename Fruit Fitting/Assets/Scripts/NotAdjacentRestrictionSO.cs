using UnityEngine;

[CreateAssetMenu(fileName = "NotAdjacent", menuName = "Restriction/NotAdjacent")]
public class NotAdjacentRestrictionSO : RestrictionSO
{
    [SerializeField] private ItemType itemType1, itemType2;

    public override bool CheckRestriction(Grid grid)
    {
        Debug.Log("Not Adjacent");
        return false;
    }
}
