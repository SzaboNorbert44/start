using OpenCvSharp;
using System;
namespace TurkMite
{
    class Turkmite
    {
        public Mat Image { get; }
        private int x;
        private int y;
        private int direction;  // 0 up, 1 right, 2 down, 3 left
        private Mat.Indexer<Vec3b> indexer;
        readonly Vec3b black = new(0, 0, 0);
        readonly Vec3b white = new(255, 255, 255);
        private readonly (int x, int y)[] delta =  { (0, -1), (1, 0), (0, 1), (-1, 0) };
        public Turkmite(Mat image)
        {
            Image = image;
            x = image.Cols / 2;
            y = image.Rows / 2;
            direction = 0;
            indexer = image.GetGenericIndexer<Vec3b>();
        }
        public void Step()
        {
            indexer[y, x] = GetNextColorAndUpdateDirection(indexer[y, x]);
            PerformMove();
        }
        private Vec3b GetNextColorAndUpdateDirection(Vec3b currentColor)
        {
            if (currentColor == black)
            {
                direction++;
                return white;
            }
            else
            {
                direction--;
                return black;
            }
        }
        private void PerformMove()
        {
            direction = (direction + 4) % 4;
            x += delta[direction].x;
            y += delta[direction].y;
            x = Math.Min(Image.Cols - 1, Math.Max(0, x));
            y = Math.Min(Image.Cols - 1, Math.Max(0, y));
        }
    }
}