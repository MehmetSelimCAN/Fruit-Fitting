using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fruit List", menuName = "New Fruit/New Fruit List")]
public class NewFruitListSO : ScriptableObject
{
    public string newFruitsStr;
    public List<NewFruitSO> list;
}
