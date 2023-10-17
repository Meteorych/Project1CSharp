using ConsoleApp1.Figures;
using ConsoleApp1.Vertex;

namespace ConsoleApp1.DataAccessLayer
{
    class DALParser
    {
        /// <summary>
        /// Create instance of figure
        /// </summary>
        public static List<Figure> CreateInstance(List<FigureJSON>? figures)
        {
            List<Figure> result = new();
            if (figures == null) 
            {
                return result;
            }
            foreach (FigureJSON figure in figures) 
            {
                //Converting of vertices
                Point[] vertices = new Point[figure.Vertices.Length];
                for (int i = 0; i < figure.Vertices.Length; i++)
                {
                    vertices[i] = new Point(figure.Vertices[i].Coordinates);
                }

                switch (figure.GetType().Name)
                {
                    //converting of figures
                    case "TriangleJSON":
                        result.Add(new Triangle(vertices, figure.LineColor, figure.FillColor));
                        break;
                    case "CircleJSON":
                        result.Add(new Circle(vertices, figure.LineColor, figure.FillColor));
                        break;
                    case "RectangularTriangleJSON":
                        result.Add(new RectangularTriangle(vertices, figure.LineColor, figure.FillColor));
                        break;
                    case "QudrangleJSON":
                        result.Add(new Quadrangle(vertices, figure.LineColor, figure.FillColor));
                        break;
                    default:
                        result.Add(new Square(vertices, figure.LineColor, figure.FillColor));
                        break;
                }
            }
            return result;
        }
        
        public static List<FigureJSON> FromInstanceToDal(List<Figure> figures)

        {
            List<FigureJSON> result = new();
            foreach (Figure figure in figures)
            {
                //Converting of vertices
                PointJSON[] vertices = new PointJSON[figure.Vertices.Length];
                for (int i = 0; i < figure.Vertices.Length; i++)
                {
                    vertices[i] = new PointJSON(figure.Vertices[i].Coordinates);
                }
                //converting of figures
                if (figure.GetType().Name == "Triangle")
                {
                    result.Add(new TriangleJSON(vertices, figure.LineColor, figure.FillColor));
                }
                else if (figure.GetType().Name == "CircleJSON")
                {
                    result.Add(new CircleJSON(vertices, figure.LineColor, figure.FillColor));
                }
                else if (figure.GetType().Name == "RectangularTriangleJSON")
                {
                    result.Add(new RectangularTriangleJSON(vertices, figure.LineColor, figure.FillColor));
                }
                else if (figure.GetType().Name == "QudrangleJSON")
                {
                    result.Add(new QuadrangleJSON(vertices, figure.LineColor, figure.FillColor));
                }
                else
                {
                    result.Add(new SquareJSON(vertices, figure.LineColor, figure.FillColor));
                }
            }
            return result;
        }
    }
}
