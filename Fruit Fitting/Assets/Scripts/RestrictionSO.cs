using UnityEngine;

public class RestrictionSO : ScriptableObject
{
    public string restrictionStr;
    [HideInInspector] public RestrictionArea restrictionArea;
    protected bool isNewFruitRestriction;
    public bool IsNewFruitRestriction { get { return isNewFruitRestriction; } }

    public virtual bool CheckRestriction()
    {
        return false;
    }
}
