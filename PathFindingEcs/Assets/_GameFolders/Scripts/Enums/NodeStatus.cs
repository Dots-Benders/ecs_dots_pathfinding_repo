namespace PathFindingEcs.Enums
{
    public enum NodeStatus : byte
    {
        Empty = 0,
        Visual = 1,
        Neighbor = 2,
        Edge = 3,
        Building = 4,
        Wall = 5,
        Trap = 6
    }
}