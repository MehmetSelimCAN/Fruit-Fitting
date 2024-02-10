using System;

public static class EventManager
{
    public static Action<Cell, Cell> CellSwapEvent;
    public static void SwapCell(Cell firstCell, Cell secondCell) => CellSwapEvent?.Invoke(firstCell, secondCell);
}