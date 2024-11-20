namespace PathFindingEcs.Components
{
    public struct PathNodeData : System.IComparable<PathNodeData>
    {
        public NodeUnitData nodeUnitData;
        public NodeGridData nodeGridData;

        public int HeapIndex { get; set; }

        public int CompareTo(PathNodeData nodeToCompare)
        {
            float fCostMine = nodeUnitData.hCost + nodeUnitData.gCost;
            float fConstCompare = nodeToCompare.nodeUnitData.gCost + nodeToCompare.nodeUnitData.hCost;
            int compare = fCostMine.CompareTo(fConstCompare);

            if (compare == 0)
            {
                compare = nodeUnitData.hCost.CompareTo(nodeToCompare.nodeUnitData.hCost);
            }

            return -compare;
        }
    }
}