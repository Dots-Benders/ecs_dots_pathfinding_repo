using PathFindingEcs.Components;
using PathFindingEcs.Enums;
using Unity.Entities;
using UnityEngine;

namespace PathFindingEcs.Editors
{
    //[DisableAutoCreation]
    public partial struct DrawDebugLineSystemForUnit : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (nodeData, tag) in SystemAPI.Query<RefRO<NodeGridData>, RefRO<UnitNodeTag>>())
            {
                var position = nodeData.ValueRO.Position;

                DrawExtensions.DrawSquare(position, 0.49f, ChangeColorForMapGrid(nodeData.ValueRO));
                DrawExtensions.DrawSquare(position, 0.39f, ChangeColorForMapGrid(nodeData.ValueRO));
                DrawExtensions.DrawSquare(position, 0.29f, ChangeColorForMapGrid(nodeData.ValueRO));
                DrawExtensions.DrawSquare(position, 0.19f, ChangeColorForMapGrid(nodeData.ValueRO));
                DrawExtensions.DrawSquare(position, 0.09f, ChangeColorForMapGrid(nodeData.ValueRO));
            }
        }

        private Color ChangeColorForMapGrid(NodeGridData nodeData)
        {
            Color color = default;
            switch (nodeData.NodeStatus)
            {
                case NodeStatus.Empty:
                    color = new Color(0f, 1f, 0f, 0.39f);
                    break;
                case NodeStatus.Building:
                    color = new Color(1f, 0f, 0f, 0.39f);
                    break;
                case NodeStatus.Neighbor:
                    color = new Color(0f, 0f, 1f, 0.39f);
                    break;
                case NodeStatus.Visual:
                    color = new Color(0.53f, 1f, 0.5f, 0.39f);
                    break;
                case NodeStatus.Edge:
                    color = new Color(0.99f, 1f, 0.11f, 0.39f);
                    break;
            }

            return color;
        }
    }
}