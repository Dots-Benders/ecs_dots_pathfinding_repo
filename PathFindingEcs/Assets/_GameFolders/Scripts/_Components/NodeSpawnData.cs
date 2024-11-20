using Unity.Entities;

namespace PathFindingEcs.Components
{
    public struct NodeSpawnData : IComponentData
    {
        public Entity EntityNode;
        public int Size;
    }
}