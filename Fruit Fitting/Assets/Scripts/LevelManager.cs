using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Grid Grid;
    [SerializeField] private Level1Data level1Data;
    [SerializeField] private TextMeshProUGUI restrictionTextPrefab;
    [SerializeField] private Transform restrictionTextParent;

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

    public void AddBlueberry()
    {
        Cell emptyCell = Grid.GetEmptyCell();
        emptyCell.InsertItem(ItemType.Blueberry);
    }

    public void AddPear()
    {
        Cell emptyCell = Grid.GetEmptyCell();
        emptyCell.InsertItem(ItemType.Pear);
    }

    private void AddRestrictions()
    {
        foreach (RestrictionSO restrictionSO in level1Data.restrictions.list)
        {
            restrictionSO.restrictionText = Instantiate(restrictionTextPrefab, restrictionTextParent);
            restrictionSO.restrictionText.SetText(restrictionSO.restrictionStr);
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
