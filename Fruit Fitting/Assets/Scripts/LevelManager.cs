using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Grid Grid;
    [SerializeField] private Level1Data level1Data;
    [SerializeField] private RestrictionArea restrictionAreaPrefab;
    [SerializeField] private Transform restrictionAreaParent;

    [SerializeField] private NewFruitsPanel newFruitsPanel;

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
        AddNewFruits();
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
    }

    public void AddCoconut()
    {
        Cell emptyCell = Grid.GetEmptyCell();
        emptyCell.InsertItem(ItemType.Coconut);
    }

    public void AddPear()
    {
        Cell emptyCell = Grid.GetEmptyCell();
        emptyCell.InsertItem(ItemType.Pear);
    }

    private void AddRestrictions()
    {
        int restrictionNumber = 1;
        foreach (RestrictionSO restrictionSO in level1Data.restrictions.list)
        {
            restrictionSO.restrictionArea = Instantiate(restrictionAreaPrefab, restrictionAreaParent);
            restrictionSO.restrictionArea.SetText(restrictionNumber + ". " + restrictionSO.restrictionStr);
            restrictionNumber++;
        }
    }

    private void AddNewFruits()
    {
        newFruitsPanel.Show();
        newFruitsPanel.SetText(level1Data.newFruits.newFruitsStr);

        foreach (NewFruitSO newFruitSO in level1Data.newFruits.list)
        {
            for (int i = 0; i < newFruitSO.itemCount; i++)
            {
                NewFruitGO newFruitGO = newFruitsPanel.AddNewFruitGO();
                newFruitsPanel.ChangeButtonImage(newFruitGO, newFruitSO.itemType);
                newFruitGO.button.onClick.AddListener(() => NewFruitButtonClicked(newFruitGO, newFruitSO));
            }
        }
    }

    private void NewFruitButtonClicked(NewFruitGO newFruitGO, NewFruitSO newFruitSO)
    {
        AddFruit(newFruitSO.itemType);
        newFruitsPanel.DisableButtonImage(newFruitGO);
        newFruitsPanel.CheckAnyFruitRemain();
    }

    private void AddFruit(ItemType itemType)
    {
        Cell emptyCell = Grid.GetEmptyCell();
        emptyCell.InsertItem(itemType);
        CheckRestrictions();
    }

    private void CheckRestrictions()
    {
        foreach (RestrictionSO restrictionSO in level1Data.restrictions.list)
        {
            bool isRestrictionPassed = restrictionSO.CheckRestriction();
            restrictionSO.restrictionArea.UpdateArea(isRestrictionPassed);
        }
    }
}
