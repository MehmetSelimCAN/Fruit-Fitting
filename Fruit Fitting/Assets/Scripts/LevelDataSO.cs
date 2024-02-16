using UnityEngine;

[CreateAssetMenu(fileName = "Level Data", menuName = "Level/Level Data")]
public class LevelDataSO : ScriptableObject
{
    public int Rows;
    public int Cols;
    public RestrictionListSO restrictions;
}