using UnityEngine;

public class RestrictionSO : ScriptableObject
{
    public string restrictionStr;
    [HideInInspector] public RestrictionArea restrictionArea;

    public virtual bool CheckRestriction()
    {
        return false;
    }
}
