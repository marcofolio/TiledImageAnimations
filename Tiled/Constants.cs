using System;
namespace Tiled
{
    public static class Constants
    {
        public const int CORNER_RADIUS = 5;
        
        public const int MIN_TILE_SIZE = 30;
        public const int MAX_TILE_SIZE = 60;
        public const int DEFAULT_TILE_SIZE = 50;

        public const int MIN_TILE_COUNT = 2;
        public const int MAX_TILE_COUNT = 10;
        public const int DEFAULT_TILE_COUNT = 5;

        public const string MC_TOPIC_TILE_SIZE_UPDATED = "TileSizeUpdated";
        public const string MC_TOPIC_TILE_COUNT_UPDATED = "TileCountUpdated";
        public const string MC_TOPIC_ANIMATION_STYLE_UPDATED = "AnimationStyleUpdated";
    }
}
