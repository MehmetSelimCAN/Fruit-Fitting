using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Grid Grid;
    [SerializeField] private Level1Data level1Data;
    [SerializeField] private TextMeshProUGUI restrictionTextPrefab;
    [SerializeField] private Transform restrictionTextParent;

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
        AddRestrictions();
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
        CheckRestrictions();
    }

    public void AddBanana()
    {
        Cell emptyCell = Grid.GetEmptyCell();
        emptyCell.InsertItem(ItemType.Banana);
        CheckRestrictions();
    }

    public void AddBlueberry()
    {
        Cell emptyCell = Grid.GetEmptyCell();
        emptyCell.InsertItem(ItemType.Blueberry);
        CheckRestrictions();
    }

    public void AddPear()
    {
        Cell emptyCell = Grid.GetEmptyCell();
        emptyCell.InsertItem(ItemType.Pear);
        CheckRestrictions();
    }

    private void AddRestrictions()
    {
        foreach (RestrictionSO restrictionSO in level1Data.restrictions.list)
        {
            restrictionSO.restrictionText = Instantiate(restrictionTextPrefab, restrictionTextParent);
            restrictionSO.restrictionText.SetText(restrictionSO.restrictionStr);
        }
    }

    private void CheckRestrictions()
    {
        foreach (RestrictionSO restrictionSO in level1Data.restrictions.list)
        {
            bool isRestrictionPassed = restrictionSO.CheckRestriction();
            if (!isRestrictionPassed)
            {
                restrictionSO.restrictionText.color = Color.red;
            }
            else
            {
                restrictionSO.restrictionText.color = Color.green;
            }
        }
    }
}
