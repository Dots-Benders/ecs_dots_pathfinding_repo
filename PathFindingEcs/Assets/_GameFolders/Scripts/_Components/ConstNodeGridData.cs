using PathFindingEcs.Enums;
using Unity.Entities;
using Unity.Mathematics;

namespace PathFindingEcs.Components
{
    public struct ConstNodeGridData : IComponentData
    {
        public float NodeOffset;
        public float UnitFactorScale;
        public int UnitNodeSizeFactor;
        public int UnitSize;
        public int UnitGridWalkableStepOffset;
    }
}