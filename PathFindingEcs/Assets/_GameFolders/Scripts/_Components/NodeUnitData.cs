using Unity.Mathematics;

namespace PathFindingEcs.Components
{
    public struct NodeUnitData
    {
        public float gCost;
        public float hCost;
        public int2 parentIndex;
    }
}