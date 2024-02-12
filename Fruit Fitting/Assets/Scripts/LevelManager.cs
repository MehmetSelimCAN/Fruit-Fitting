using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Grid Grid;
    [SerializeField] private Level1Data level1Data;
    [SerializeField] TextMeshProUGUI denemeText;

    private void OnDisable()
    {
        EventManager.CellMovedEvent -= CheckRestrictions;
    }

    private void OnEnable()
    {
        EventManager.CellMovedEvent += CheckRestrictions;
    }

    public void PrepareGame()
    {
        PrepareGrid();
    }

    private void PrepareGrid()
    {
        Grid.Rows = level1Data.Rows;
        Grid.Cols = level1Data.Cols;
        Grid.CellsBackground = new CellBackground[Grid.Cols, Grid.Rows];
        Grid.Cells = new Cell[Grid.Cols, Grid.Rows];
        Grid.Prepare();
    }

    public void AddApple()
    {
        Cell emptyCell = Grid.GetEmptyCell();
        emptyCell.InsertItem(ItemType.Apple);
    }

    public void AddBanana()
    {
        Cell emptyCell = Grid.GetEmptyCell();
        emptyCell.InsertItem(ItemType.Banana);
        denemeText.SetText(level1Data.restrictions.list[0].restrictionStr);
    }

    private void CheckRestrictions()
    {
        foreach (RestrictionSO restrictionSO in level1Data.restrictions.list)
        {
            bool isRestrictionPassed = restrictionSO.CheckRestriction();
            if (!isRestrictionPassed)
            {
                denemeText.color = Color.red;
            }
            else
            {
                denemeText.color = Color.green;
            }
        }
    }
}
