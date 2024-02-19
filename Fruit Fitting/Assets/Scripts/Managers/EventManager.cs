using System;

public static class EventManager
{
    public static Action<Cell, Cell> CellSwapEvent;
    public static void SwapCell(Cell firstCell, Cell secondCell) => CellSwapEvent?.Invoke(firstCell, secondCell);

    public static Action CellMovedEvent;
    public static void CellMoved() => CellMovedEvent?.Invoke();

    public static Action RestrictionAreaUpdatedEvent;
    public static void RestrictionAreaUpdated() => RestrictionAreaUpdatedEvent?.Invoke();

    public static Action GameStartedEvent;
    public static void GameStarted() => GameStartedEvent?.Invoke();

    public static Action GameFinishedEvent;
    public static void GameFinished() => GameFinishedEvent?.Invoke();

    public static Action BackToMenuEvent;
    public static void BackToMenu() => BackToMenuEvent?.Invoke();
}