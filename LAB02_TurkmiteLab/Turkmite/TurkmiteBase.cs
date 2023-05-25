using OpenCvSharp;
using System;
namespace TurkMite
{
    abstract class TurkmiteBase
    {
        public Mat Image { get; }
        public abstract int PreferredIterationCount { get; }
        private int x;
        private int y;
        private int direction;  // 0 up, 1 right, 2 down, 3 left
        private Mat.Indexer<Vec3b> indexer;
        private readonly (int x, int y)[] delta = { (0, -1), (1, 0), (0, 1), (-1, 0) };
        private int deltaDir;
        public TurkmiteBase(Mat image)
        {
            Image = image;
            x = image.Cols / 2;
            y = image.Rows / 2;
            direction = 0;
            indexer = image.GetGenericIndexer<Vec3b>();
        }
        public void Step()
        {
            (indexer[y, x], deltaDir) = GetNextColorAndUpdateDirection(indexer[y, x]);
            PerformMove(deltaDir);
        }
        private void PerformMove(int deltaDir)
        {
            direction += deltaDir;
            direction = (direction + 4) % 4;
            x += delta[direction].x;
            y += delta[direction].y;
            x = Math.Min(Image.Cols - 1, Math.Max(0, x));
            y = Math.Min(Image.Cols - 1, Math.Max(0, y));
        }
        protected abstract (Vec3b newColor, int deltaDir) GetNextColorAndUpdateDirection(Vec3b currentColor);
    }
}