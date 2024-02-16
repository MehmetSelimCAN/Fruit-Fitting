using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Data List", menuName = "Level/Level Data List")]
public class LevelDataListSO : ScriptableObject
{
    public List<LevelDataSO> list;
}
