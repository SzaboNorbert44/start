using OpenCvSharp;
namespace TurkMite
{
    class OriginalTurkmite : TurkmiteBase
    {
        readonly Vec3b black = new(0, 0, 0);
        readonly Vec3b white = new(255, 255, 255);
        public OriginalTurkmite(Mat image) : base(image)
        {
        }
        protected override (Vec3b newColor, int deltaDir) GetNextColorAndUpdateDirection(Vec3b currentColor)
        {
            return (currentColor == black) ? (white, 1) : (black, -1);
        }
    }
}