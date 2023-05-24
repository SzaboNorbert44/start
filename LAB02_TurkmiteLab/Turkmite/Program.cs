﻿using OpenCvSharp;

namespace TurkMite
{
    class Program
    {
        static void Main()
        {
            Mat img = new Mat(200, 200, MatType.CV_8UC3, new Scalar(0, 0, 0));
            var turkmite = new Turkmite(img);
            for (int i = 0; i < 13000; i++)
            {
                turkmite.Step();
            }
            Cv2.ImShow("TurkMite", img);
            Cv2.WaitKey();
        }
    }
}