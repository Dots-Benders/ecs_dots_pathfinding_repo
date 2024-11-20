using PathFindingEcs.Components;
using Unity.Entities;
using UnityEngine;

namespace PathFindingEcs.Authorings
{
    public class UnitNodeAuthoring : MonoBehaviour
    {
        class UnitNodeBaker : Baker<UnitNodeAuthoring>
        {
            public override void Bake(UnitNodeAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);

                AddComponent<UnitNodeTag>(entity);
                AddComponent<NodeGridData>(entity);
            }
        }
    }    
}