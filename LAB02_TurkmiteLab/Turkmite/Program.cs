﻿using OpenCvSharp;
namespace TurkMite
{
    class Program
    {
        static void Main()
        {
            Mat img = new Mat(200, 200, MatType.CV_8UC3, new Scalar(0, 0, 0));
            var turkmite = new OriginalTurkmite(img);
            //var turkmite = new ThreeColorTurkmite(img);
            for (int i = 0; i < turkmite.PreferredIterationCount; i++)
            {
                turkmite.Step();
            }
            Cv2.ImShow("TurkMite", img);
            Cv2.WaitKey();
        }
    }
}