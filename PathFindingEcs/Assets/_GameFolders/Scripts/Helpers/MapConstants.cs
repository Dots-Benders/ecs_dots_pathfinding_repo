namespace PathFindingEcs.Helpers
{
    public class MapConstants
    {
        // Map scale : MxM
        public const int MapSize = 66;
        public const int WarZoneMapSize = 74;

        // How many nodes should a unit node be divided into for Units?
        public const int UnitNodeSizeFactor = 2;


        // "UnitNodeSizeFactor" degerinden buyuk olmamali. Aksi halde o alan disina tasar.
        public const int UnitGridWalkableStepOffset = 1;


        // onceki hali buydu --> (2f / MapConstants.UnitNodeSizeFactor - ((1f / MapConstants.UnitNodeSizeFactor) / 2) * 3);
        public const float MapOffset = 0.5f / UnitNodeSizeFactor;
        public const int WarZoneMapOffset = 8;
    }
}