using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Restriction List", menuName = "Restriction/Restriction List")]
public class RestrictionListSO : ScriptableObject
{
    public List<RestrictionSO> list;
}
