using System;
using System.Collections.Generic;
using System.Linq;

namespace CaptureGoGame.Domian
{
    public class Point
    {
        private bool? _color;
        public bool? Color { 
            get => _color;
            set {
                    if (_color is not null)
                        throw new InvalidOperationException();
                        _color = value;
                } 
            }

        public int GetFreedomDegree(Point left, Point right, Point top, Point bottom) 
        {
            if (_color is null)
                return 4;

            var sides = new List<Point>
            {
                left,
                right,
                top,
                bottom
            };

            return sides.Count(s => s is not null && (s.Color is null || s.Color == _color));
        }
    }
}
