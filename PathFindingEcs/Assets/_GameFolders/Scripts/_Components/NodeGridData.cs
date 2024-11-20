using PathFindingEcs.Enums;
using Unity.Entities;
using Unity.Mathematics;

namespace PathFindingEcs.Components
{
    public struct NodeGridData : IComponentData
    {
        public NodeStatus NodeStatus; // node un tipi
        public int BuildingID;
        public float3 Position; // node un gercek pozisyonu
        public int2 MidPoint; // Binanin gercek pozisyonu
        public int2 Index; 
        public int Scale;
        public int DamageableId;
    }
}