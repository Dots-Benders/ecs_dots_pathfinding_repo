using Unity.Entities;

namespace PathFindingEcs.Components
{
    public struct NodeGridUpdateData : IComponentData
    {
        public bool IsBuildingDestroy;
    }
}