
using System;
using System.Collections.Generic;
using System.Collections;
namespace Dijkstras
{
    class Graph
    {
        Dictionary<char, Dictionary<char, int>> vertices = new Dictionary<char, Dictionary<char, int>>();

        public void add_vertex(char name, Dictionary<char, int> edges)
        {
            vertices[name] = edges;
        }

        public List<char> shortest_path(char start, char finish)
        {
            var previous = new Dictionary<char, char>();
            var distances = new Dictionary<char, int>();
            var nodes = new List<char>();

            List<char> path = null;

            foreach (var vertex in vertices)
            {
                if (vertex.Key == start)
                {
                    distances[vertex.Key] = 0;
                }
                else
                {
                    distances[vertex.Key] = int.MaxValue;
                }

                nodes.Add(vertex.Key);
            }

            while (nodes.Count != 0)
            {
                nodes.Sort((x, y) => distances[x] - distances[y]);

                var smallest = nodes[0];
                nodes.Remove(smallest);

                if (smallest == finish)
                {
                    path = new List<char>();
                    while (previous.ContainsKey(smallest))
                    {
                        path.Add(smallest);
                        smallest = previous[smallest];
                    }

                    break;
                }

                if (distances[smallest] == int.MaxValue)
                {
                    break;
                }

                foreach (var neighbor in vertices[smallest])
                {
                    var alt = distances[smallest] + neighbor.Value;
                    if (alt < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = alt;
                        previous[neighbor.Key] = smallest;
                    }
                }
            }

            return path;
        }

        public void yolhesapla(ArrayList dizi)
        {
            int mesafe = 0;
            var tut = new Dictionary<char, int>();

            for (int i = 0; i < dizi.Count - 1; i++)
            {
                string bas1 = dizi[i].ToString();
                char bas = Convert.ToChar(bas1);
                string bas2 = dizi[i + 1].ToString();
                char son = Convert.ToChar(bas2);
                tut = vertices[bas];
                foreach (var key1 in tut)
                {
                    if (key1.Key == son)
                        mesafe += key1.Value;

                }
            }
            Console.WriteLine("mesafe=" + mesafe);

        }

        public void lambahesapla(ArrayList dizi)
        {
            char[] lambalar = { 'B', 'D', 'E', 'G', 'K', 'L' };
            char[] bas = new char[dizi.Count];
            for (int i = 0; i < bas.Length; i++)
            {
                string bas1 = dizi[i].ToString();
                bas[i] = Convert.ToChar(bas1);

            }
            for (int i = 0; i < bas.Length - 1; i++)
            {
                foreach (char lamba in lambalar)
                {
                    if (bas[i] == lamba)
                        Console.WriteLine(bas[i] + " lambalı kavşak " + bas[i + 1] + " yoluna doğru");
                }
            }




        }
    }

    class MainClass
    {




        public static void Main(string[] args)
        {
            Graph g = new Graph();
            g.add_vertex('A', new Dictionary<char, int>() { { 'B', 20 } });
            g.add_vertex('B', new Dictionary<char, int>() { { 'A', 20 }, { 'C', 10 }, { 'E', 30 }, { 'J', 90 }, { 'H', 50 } });
            g.add_vertex('C', new Dictionary<char, int>() { { 'B', 10 }, { 'D', 30 } });
            g.add_vertex('D', new Dictionary<char, int>() { { 'C', 30 }, { 'F', 60 }, { 'E', 50 } });
            g.add_vertex('E', new Dictionary<char, int>() { { 'D', 50 }, { 'F', 20 }, { 'G', 30 } });
            g.add_vertex('F', new Dictionary<char, int>() { { 'E', 20 }, { 'G', 40 }, { 'L', 100 } });
            g.add_vertex('G', new Dictionary<char, int>() { { 'B', 50 }, { 'J', 30 }, { 'L', 40 } });
            g.add_vertex('H', new Dictionary<char, int>() { { 'I', 90 } });
            g.add_vertex('I', new Dictionary<char, int>() { { 'H', 90 }, { 'J', 40 }, { 'K', 90 } });
            g.add_vertex('J', new Dictionary<char, int>() { { 'I', 40 }, { 'K', 40 }, { 'G', 30 } });
            g.add_vertex('K', new Dictionary<char, int>() { { 'M', 20 }, { 'L', 30 } });
            g.add_vertex('L', new Dictionary<char, int>() { { 'F', 100 }, { 'K', 30 } });
            g.add_vertex('M', new Dictionary<char, int>() { { 'K', 20 } });






            BB:
            Console.Write("Baslangıç: ");
            char baslangıc = Convert.ToChar(Console.ReadLine().ToUpper());
            Console.Write("Bitiş: ");
            char bitis = Convert.ToChar(Console.ReadLine().ToUpper());





            ArrayList dizi = new ArrayList();


            foreach (var item in g.shortest_path(baslangıc, bitis))
            {
                dizi.Add(item);
            }
            dizi.Add(baslangıc);
            Console.WriteLine("----BAŞLANGIÇ---");
            dizi.Reverse();
            foreach (var item in dizi)
            {
                Console.WriteLine(item + " ");
            }
            Console.WriteLine("----BİTİŞ-------");
            g.yolhesapla(dizi);
            g.lambahesapla(dizi);
            goto BB;
        }

    }

}
