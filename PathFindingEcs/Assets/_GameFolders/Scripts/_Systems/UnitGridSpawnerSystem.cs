using PathFindingEcs.Components;
using PathFindingEcs.Enums;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace PathFindingEcs.Systems
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    [BurstCompile]
    public partial struct UnitGridSpawnerSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<EndInitializationEntityCommandBufferSystem.Singleton>();
            state.RequireForUpdate<NodeSpawnData>();
        }

        public void OnUpdate(ref SystemState state)
        {
            var entityCommandBuffer = SystemAPI.GetSingleton<EndInitializationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(state.WorldUnmanaged);

            foreach (var (nodeSpawnData, unitGridTag, constNodeGridData, entity) in SystemAPI
                         .Query<RefRW<NodeSpawnData>, RefRO<UnitGridTag>, RefRO<ConstNodeGridData>>()
                         .WithEntityAccess())
            {
                for (int i = 0; i < nodeSpawnData.ValueRO.Size; i++)
                {
                    for (int j = 0; j < nodeSpawnData.ValueRO.Size; j++)
                    {
                        var nodeEntity = entityCommandBuffer.Instantiate(nodeSpawnData.ValueRW.EntityNode);
                        float3 position = new float3(i * constNodeGridData.ValueRO.UnitFactorScale, 0,
                            j * constNodeGridData.ValueRO.UnitFactorScale);

                        position.x -= constNodeGridData.ValueRO.NodeOffset;
                        position.z -= constNodeGridData.ValueRO.NodeOffset;

                        entityCommandBuffer.SetComponent(nodeEntity, new NodeGridData()
                        {
                            Position = position,
                            NodeStatus = NodeStatus.Empty,
                            Index = new int2(i,j)
                        });
                    }
                }

                entityCommandBuffer.RemoveComponent<NodeSpawnData>(entity);
            }
        }
    }
}