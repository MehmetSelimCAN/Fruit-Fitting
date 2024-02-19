using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Grid Grid;
    [SerializeField] private LevelDataListSO levelDatas;
    private LevelDataSO currentLevelDataSO;

    [SerializeField] private RestrictionArea restrictionAreaPrefab;
    [SerializeField] private Transform restrictionAreaParent;
    private List<RestrictionSO> currentRestrictions = new List<RestrictionSO>();

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
        int levelNumber = PlayerPrefsManager.GetLastLevelNumber();
        currentLevelDataSO = levelDatas.list[levelNumber - 1];
        PrepareGrid();
        AddNewRestriction();
    }

    private void PrepareGrid()
    {
        Grid.Rows = currentLevelDataSO.Rows;
        Grid.Cols = currentLevelDataSO.Cols;
        Grid.CellsBackground = new CellBackground[Grid.Cols, Grid.Rows];
        Grid.Cells = new Cell[Grid.Cols, Grid.Rows];
        Grid.Prepare();
    }

    private void AddNewRestriction()
    {
        int restrictionNumber = currentRestrictions.Count;
        RestrictionSO newRestrictionSO = currentLevelDataSO.restrictions.list[restrictionNumber];
        newRestrictionSO.restrictionArea = Instantiate(restrictionAreaPrefab, restrictionAreaParent);
        newRestrictionSO.restrictionArea.SetText((restrictionNumber + 1) + ". " + newRestrictionSO.restrictionStr);

        if (newRestrictionSO.IsNewFruitRestriction)
        {
            InitializeNewFruitsPanel(newRestrictionSO);
        }

        currentRestrictions.Add(newRestrictionSO);
        CheckRestrictions();
    }

    private void InitializeNewFruitsPanel(RestrictionSO restrictionSO)
    {
        NewFruitRestrictionSO newFruitRestrictionSO = (NewFruitRestrictionSO)restrictionSO;
        newFruitRestrictionSO.restrictionArea.EnlargeArea();
        NewFruitsPanel newFruitsPanel = newFruitRestrictionSO.restrictionArea.InstantiateNewFruitsPanel();

        foreach (NewFruitSO newFruitSO in newFruitRestrictionSO.list)
        {
            for (int i = 0; i < newFruitSO.itemCount; i++)
            {
                NewFruitGO newFruitGO = newFruitsPanel.AddNewFruitGO();
                newFruitsPanel.ChangeButtonImage(newFruitGO, newFruitSO.itemType);
                newFruitGO.button.onClick.AddListener(() => NewFruitButtonClicked(newFruitsPanel, newFruitGO, newFruitSO));
            }
        }
    }

    private void NewFruitButtonClicked(NewFruitsPanel newFruitsPanel, NewFruitGO newFruitGO, NewFruitSO newFruitSO)
    {
        newFruitsPanel.DisableButtonImage(newFruitGO);
        newFruitsPanel.CheckAnyFruitRemain();
        AddFruit(newFruitSO.itemType);
    }

    private void AddFruit(ItemType itemType)
    {
        Cell emptyCell = Grid.GetEmptyCell();
        emptyCell.InsertItem(itemType);
        CheckRestrictions();
    }

    private void CheckRestrictions()
    {
        bool allCurrentRestrictionsPassed = true;
        foreach (RestrictionSO restrictionSO in currentRestrictions)
        {
            bool isRestrictionPassed = restrictionSO.CheckRestriction();
            restrictionSO.restrictionArea.UpdateBackground(isRestrictionPassed);

            if (!isRestrictionPassed)
            {
                allCurrentRestrictionsPassed = false;
            }
        }

        if (allCurrentRestrictionsPassed)
        {
            if (currentRestrictions.Count == currentLevelDataSO.restrictions.list.Count)
            {
                PlayerPrefsManager.IncreaseLastLevelNumber();
                EventManager.GameFinished();
            }
            else
            {
                AddNewRestriction();
            }
        }
    }
}
