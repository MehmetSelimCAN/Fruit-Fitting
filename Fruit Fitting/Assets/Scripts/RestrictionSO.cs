using UnityEngine;

public class RestrictionSO : ScriptableObject
{
    public string restrictionStr;

    public virtual bool CheckRestriction(Grid grid)
    {
        return false;
    }
}
