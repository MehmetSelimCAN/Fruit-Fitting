using UnityEngine;

[CreateAssetMenu(fileName = "New Fruit", menuName = "New Fruit/New Fruit")]
public class NewFruitSO : ScriptableObject
{
    public ItemType itemType;
    public int itemCount;
}