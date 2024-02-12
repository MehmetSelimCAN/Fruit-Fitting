using TMPro;
using UnityEngine;

public class RestrictionSO : ScriptableObject
{
    public string restrictionStr;
    [HideInInspector] public TextMeshProUGUI restrictionText;

    public virtual bool CheckRestriction()
    {
        return false;
    }
}
