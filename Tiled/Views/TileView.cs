using System;
using System.Collections.Generic;
using FFImageLoading.Forms;
using FFImageLoading.Transformations;
using FFImageLoading.Work;

namespace Tiled.Views
{
    public class TileView : CachedImage
    {
        private int _maxPos;

        public TileView(int xPos, int yPos, int maxPos, int tileSize)
        {
            _maxPos = maxPos;
            this.DownsampleToViewSize = true;
            this.Transformations = new List<ITransformation>();
            this.WidthRequest = tileSize;
            this.HeightRequest = tileSize;

            if (xPos == 0 && yPos == 0)
            {
                this.Transformations.Add(new CornersTransformation(Constants.CORNER_RADIUS, CornerTransformType.TopLeftRounded));
            }
            else if (xPos == maxPos - 1 && yPos == 0)
            {
                this.Transformations.Add(new CornersTransformation(Constants.CORNER_RADIUS, CornerTransformType.TopRightRounded));
            }
            else if (xPos == 0 && yPos == maxPos - 1)
            {
                this.Transformations.Add(new CornersTransformation(Constants.CORNER_RADIUS, CornerTransformType.BottomLeftRounded));
            }
            else if (xPos == maxPos - 1 && yPos == maxPos - 1)
            {
                this.Transformations.Add(new CornersTransformation(Constants.CORNER_RADIUS, CornerTransformType.BottomRightRounded));
            }

            this.Transformations.Add(new CropTransformation(maxPos, CalculateOffset(xPos), CalculateOffset(yPos)));
        }

        private double CalculateOffset(int index)
        {
            double tileSize = 1 / (double)_maxPos;

            double minimumValue = _maxPos % 2 == 0 ?
                CalculateMinimumEvenGridOffset(tileSize) :
                CalculateMinimumUnevenGridOffset();

            return minimumValue + index * tileSize;
        }

        private double CalculateMinimumUnevenGridOffset()
        {
            return -((int)Math.Floor((double)_maxPos / 2) / (double)_maxPos);
        }

        private double CalculateMinimumEvenGridOffset(double tileSize)
        {
            double evenTileSizeCorrection = tileSize / 2;
            return -((_maxPos - 1) * evenTileSizeCorrection);
        }
    }
}
