using OpenCvSharp;
namespace TurkMite
{
    class ThreeColorTurkmite : TurkmiteBase
    {
        readonly Vec3b black = new(0, 0, 0);
        readonly Vec3b white = new(255, 255, 255);
        readonly Vec3b red = new(0, 0, 255);
        public override int PreferredIterationCount { get; }
        public ThreeColorTurkmite(Mat image) : base(image)
        {
            PreferredIterationCount = 500000;
        }
        protected override (Vec3b newColor, int deltaDir) GetNextColorAndUpdateDirection(Vec3b currentColor)
        {
            if (currentColor == black)
                return (white, 1);
            else if (currentColor == white)
                return (red, -1);
            else
                return (black, -1);
        }
    }
}