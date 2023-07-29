using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json;
using Points;
using Figures;

namespace JSON
{
    class json
    {
        
        public string vertices { get; set; }
        public Color fillColor { get; set; }
        public Color lineColor { get; set; }
        public string typeOfFigure { get; set; }
        public void JSONDump(Figure figure)
        {

        }

    }
}
