namespace SEM5_LR4.Painters
{
    public class PolygonPainter : LinePainter
    {    
        public void DrawPolygon()
        {
            if (Points.Count <= 1)
                return;

            var lastPointIndex = Points.Count - 1;

            for (int i = 0; i < lastPointIndex; i++)
            {
                DrawLine(Points[i], Points[i + 1]);
            }

            DrawLine(Points[0], Points[lastPointIndex]);
        }
    }
}
