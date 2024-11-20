using PathFindingEcs.Components;
using PathFindingEcs.Helpers;
using Unity.Entities;
using UnityEngine;

namespace PathFindingEcs.Authorings
{
    public class UnitGridAuthoring : MonoBehaviour
    {
        public int Size = 66;
        public GameObject Prefab;
        public bool IsUpdated;

        class UnitGridBaker : Baker<UnitGridAuthoring>
        {
            public override void Bake(UnitGridAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);

                AddComponent<UnitGridTag>(entity);
                // AddBuffer<BuildingAddGridInputBuffer>(entity);
                // AddBuffer<BuildingRemoveGridInputBuffer>(entity);
                // AddComponent<CleanUnitNodesTag>(entity);

                AddComponent<NodeGridUpdateData>(entity, new()
                {
                    IsBuildingDestroy = authoring.IsUpdated
                });

                AddComponent(entity, new NodeSpawnData()
                {
                    Size = authoring.Size * MapConstants.UnitNodeSizeFactor,
                    EntityNode = GetEntity(authoring.Prefab, TransformUsageFlags.None)
                });

                AddComponent(entity, new ConstNodeGridData()
                {
                    NodeOffset = MapConstants.MapOffset,
                    UnitFactorScale = 1f / MapConstants.UnitNodeSizeFactor,
                    UnitSize = MapConstants.MapSize * MapConstants.UnitNodeSizeFactor,
                    UnitNodeSizeFactor = MapConstants.UnitNodeSizeFactor,
                    UnitGridWalkableStepOffset = MapConstants.UnitGridWalkableStepOffset
                });
            }
        }
    }   
}