using System.ComponentModel.Design;
using System.IO.Enumeration;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

namespace _23DH114301
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Buoi7 buoi3 = new Buoi7();
            buoi3.Bai4();


        }


    }
}
public class Buoi1
{
    static int[] degree, DegreeOut, DegreeIn;
    static int[,] V_arrayMatrix;
    static int n;
    static List<List<int>> v_ListMatrix3;
    private static int m;
    private static int[,] V_arrayMatrix4;
    private static int[] v_degress;

    public void Bai1()
    {
        string input = "U:\\THToandothi\\AdjecencyMatrix.INP";
        string output = "U:\\THToandothi\\AdjecencyMatrix.OUT";
        ReadMatrix(input);
        DegreesofVertices();
        Writefile(output);
    }

    static void ReadMatrix(string file)
    {
        if (!File.Exists(file))//debug
        {
            Console.WriteLine("file is not exit");
            Console.ReadKey();
        }



        else
        {
            string[] lines = File.ReadAllLines(file);       // số đỉnh của đồ thị
            n = Convert.ToInt32(lines[0]);
            V_arrayMatrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                //đọc dòng tiếp theo
                string[] row = lines[i + 1].Split(' ');
                for (int j = 0; j < n; j++)
                {
                    //đọc theo line (row)
                    V_arrayMatrix[i, j] = Convert.ToInt32(row[j]);

                }


            }
        }

        //for (int i = 0; i < n; i++)
        //{
        //    Console.WriteLine();
        //    for (int j = 0; j < n; j++)
        //    {
        //        Console.Write(V_arrayMatrix[i, j]);

        //    }

        //}
    }
    static void DegreesofVertices()
    {
        degree = new int[n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                degree[i] += V_arrayMatrix[i, j];

            }

        }
        //for (int i = 0; i < n; i++)
        //{
        //    Console.Write(degree[i] + " ");

        //}
    }
    public static void Writefile(string Out_file)
    {
        using (StreamWriter writer = new StreamWriter(Out_file))
        {
            //dòng đầu ghi số đỉnh
            writer.WriteLine(n);
            //chỉ bậc của từng đỉnh
            for (int i = 0; i < n; i++) { writer.Write(degree[i] + " "); }


        }
    }

    public void Bai2()
    {

        string input2 = "U:\\THToandothi\\BacVaoRa.INP";
        string output2 = "U:\\THToandothi\\BacVaoRa.OUT";
        DegreesofVertices();
        ReadMatrix(input2);
        DegreeInOut();
        Write2(output2);
    }
    public static void ReadMatrix2(string file)
    {
        string[] lines = File.ReadAllLines(file);
        if (!File.Exists(file))
        {
            Console.WriteLine("file is not exit");
        }
        // số đỉnh của đồ thị
        n = Convert.ToInt32(lines[0]);
        V_arrayMatrix = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            string[] row = lines[i + 1].Split(' ');
            for (int j = 0; j < n; j++)
            {
                V_arrayMatrix[i, j] = Convert.ToInt32(row[j]);

            }


        }
        //for (int i = 0; i < n; i++)
        //{
        //    Console.WriteLine();
        //    for (int j = 0; j < n; j++)
        //    {
        //        Console.Write(V_arrayMatrix[i, j]);

        //    }

        //}
    }
    public static void DegreeInOut()
    {
        DegreeIn = new int[n];
        DegreeOut = new int[n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (V_arrayMatrix[i, j] == 1)
                {
                    DegreeIn[j]++;
                    DegreeOut[i]++;
                }
            }
        }
    }
    public static void Write2(string Outfile)
    {
        using (StreamWriter writer = new StreamWriter(Outfile))
        {
            writer.WriteLine(n);
            for (int i = 0; i < n; i++)
            {
                writer.WriteLine($"{DegreeIn[i]} {DegreeOut[i]}");
            };
        }
    }
    public void Bai3()
    {
        string input = "U:\\THToandothi\\AdjecencyList.INP";
        string output = "U:\\THToandothi\\AdjecencyList.OUT";
        ReadMatrix3(input);
        CountDegress3();
        Writefile34(output);
    }
    static void ReadMatrix3(string file)
    {
        string[] line = File.ReadAllLines(file);
        if (!File.Exists(file))
        {
            Console.WriteLine("error read matrix bai 3");

        }
        v_ListMatrix3 = new List<List<int>>();
        //so đỉnh của đồ thị
        n = int.Parse(line[0]);
        for (int i = 0; i < n; i++)
        {
            if (i + 1 < line.Length)
            {
                string[] v_row_canhke = line[i + 1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                List<int> v_list = new List<int>();
                foreach (string canhke in v_row_canhke)
                {
                    v_list.Add(Convert.ToInt32(canhke));

                }
                v_ListMatrix3.Add(v_list);
            }
            else
            {
                v_ListMatrix3.Add(new List<int>());//đỉnh cô lập
            }
        }

    }
    static void CountDegress3()
    {
        //tính bậc từng đỉnh
        v_degress = new int[n];
        for (int i = 0; i < n; i++)
        {
            v_degress[i] = v_ListMatrix3[i].Count;//bậc bằng số lượng đỉnh kề

        }
    }
    static void Writefile34(string output)
    {
        using (StreamWriter writer = new StreamWriter(output))
        {
            //đỉnh
            writer.WriteLine(n);
            //chỉ bậc từng đỉnh
            writer.WriteLine(string.Join(" ", v_degress));

        }
        Console.WriteLine("successfull");
    }
    public void Bai4()
    {
        string input = "U:\\THToandothi\\EdgeList.INP";
        string output = "U:\\THToandothi\\EdgeList.OUT";
        ReadMatrix4(input);
        CountDegress();
        Writefile4(output);
    }
    static void ReadMatrix4(string input)
    {
        string[] lines = File.ReadAllLines(input);
        //dòng đầu tiên là số canh và số đỉnh
        string[] firstLine = lines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        n = int.Parse(firstLine[0]);
        m = int.Parse(firstLine[1]);
        //tạo mảng để lưu
        V_arrayMatrix4 = new int[m, 2];
        //dòng tiếp theo chứa danh sách cạnh
        for (int i = 0; i < m; i++)
        {
            string[] v_edge = lines[i + 1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            V_arrayMatrix4[i, 0] = int.Parse(v_edge[0]);
            V_arrayMatrix4[i, 1] = int.Parse(v_edge[1]);
        }




    }
    static void CountDegress()
    {
        //hàm tính bậc của các đỉnh
        v_degress = new int[n];
        for (int i = 0; i < V_arrayMatrix4.GetLength(0); i++)
        {
            int u = V_arrayMatrix4[i, 0] - 1;//array 5 đỉnh 0..4
            int v = V_arrayMatrix4[i, 1] - 1;
            v_degress[u]++;
            v_degress[v]++;
        }
    }
    public static void Writefile4(string Out_file)
    {
        using (StreamWriter writer = new StreamWriter(Out_file))
        {
            //dòng đầu ghi số đỉnh
            writer.WriteLine(n);
            //chỉ bậc của từng đỉnh
            for (int i = 0; i < n; i++) { writer.Write(v_degress[i] + " "); }


        }
    }
}
public class Buoi2
{
    static int[,] V_arrayMatrix1;
    static List<int> Vout_adjacencyList1;
    static List<List<int>> V_arrayMatrix2;
    static int[,] Vout_listedge2;
    static List<List<int>> v_listMatrix2;
    static List<CEdge> v_edges2;
    static int[,] V_arrayMatrix3;
    static int[] Node3;
    static int v_storageCount3 = 0; //biến đếm số lượng bồn chứa
    static List<int>[] vout_Graph4;
    static List<int>[] v_adjList4;
    static int[,] v_arrayMatrix5;
    static double v_AvgEdge;
    static int v_Maxedge;
    static int n, m;

    private Dictionary<int, List<int>> adjacencyList;


    public void Bai1()
    {
        string input = "U:\\THToandothi\\Canh2Ke.INP";
        string output = "U:\\THToandothi\\Canh2Ke.OUT";
        ReadMatrix(input);
        Writefile(output);
    }

    private void ReadMatrix(string inputFile)
    {
        var lines = File.ReadAllLines(inputFile);
        var firstLine = lines[0].Split();
        n = int.Parse(firstLine[0]);
        m = int.Parse(firstLine[1]);

        adjacencyList = new Dictionary<int, List<int>>();
        for (int i = 1; i <= n; i++)
            adjacencyList[i] = new List<int>();

        for (int i = 1; i <= m; i++)
        {
            var edge = lines[i].Split().Select(int.Parse).ToArray();
            adjacencyList[edge[0]].Add(edge[1]);
            adjacencyList[edge[1]].Add(edge[0]);
        }
    }

    private void Writefile(string outputFile)
    {
        using (var writer = new StreamWriter(outputFile))
        {
            writer.WriteLine(n);
            for (int i = 1; i <= n; i++)
            {
                adjacencyList[i].Sort();
                writer.WriteLine(string.Join(" ", adjacencyList[i]));
            }
        }
    }
    public void Bai2()
    {
        string input = "U:\\THToandothi\\Ke2Canh.INP";
        string output = "U:\\THToandothi\\Ke2Canh.OUT";
        ReadMatrix2(input);
        ChuyenSangDanhSachCanh();
        Writefile2(output);
    }

    private static void ReadMatrix2(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("Lỗi: Không thể đọc file danh sách kề.");
            return;
        }

        string[] lines = File.ReadAllLines(file);
        n = int.Parse(lines[0]);
        v_listMatrix2 = new List<List<int>>();

        for (int i = 1; i <= n; i++)
        {
            if (i < lines.Length)
            {
                string[] neighbors = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                List<int> adjacencyList = neighbors.Select(int.Parse).ToList();
                v_listMatrix2.Add(adjacencyList);
            }
            else
            {
                v_listMatrix2.Add(new List<int>()); // Đỉnh cô lập
            }
        }
    }

    class CEdge
    {
        public int u { get; set; }
        public int v { get; set; }

        public CEdge(int u, int v)
        {
            this.u = u;
            this.v = v;
        }
    }

    private static void ChuyenSangDanhSachCanh()
    {
        v_edges2 = new List<CEdge>();
        HashSet<string> v_seenEdges = new HashSet<string>();

        for (int u = 0; u < n; u++)
        {
            foreach (int v in v_listMatrix2[u])
            {
                if (u + 1 < v) // Chỉ xét cạnh theo một chiều để tránh trùng lặp
                {
                    string edgeKey = $"{u + 1}-{v}";
                    if (!v_seenEdges.Contains(edgeKey))
                    {
                        v_edges2.Add(new CEdge(u + 1, v));
                        v_seenEdges.Add(edgeKey);
                    }
                }
            }
        }
    }

    private static void Writefile2(string outputFile)
    {
        v_edges2.Sort((a, b) =>
        {
            if (a.u == b.u) return a.v.CompareTo(b.v);
            return a.u.CompareTo(b.u);
        });

        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            writer.WriteLine($"{n} {v_edges2.Count}");
            foreach (var edge in v_edges2)
            {
                writer.WriteLine($"{edge.u} {edge.v}");
            }
        }
        Console.WriteLine("Chuyển đổi thành công!");
    }



    private static int[,] adjacencyMatrix;
    private static int nodeCount;
    private static List<int> sinkNodes;

    public void Bai3()
    {
        string inputFile = "U:\\THToandothi\\BonChua.INP";
        string outputFile = "U:\\THToandothi\\BonChua.OUT";
        ReadMatrix3(inputFile);
        IdentifySinkNodes();
        WriteToFile(outputFile);
    }

    private static void ReadMatrix3(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("Error: Unable to read file BonChua.INP.");
            return;
        }

        string[] lines = File.ReadAllLines(file);
        nodeCount = int.Parse(lines[0]);
        adjacencyMatrix = new int[nodeCount, nodeCount];

        for (int i = 0; i < nodeCount; i++)
        {
            string[] row = lines[i + 1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < nodeCount; j++)
            {
                adjacencyMatrix[i, j] = int.Parse(row[j]);
            }
        }
    }

    private static void IdentifySinkNodes()
    {
        sinkNodes = new List<int>();

        for (int i = 0; i < nodeCount; i++)
        {
            bool hasOutgoingEdge = false;
            for (int j = 0; j < nodeCount; j++)
            {
                if (adjacencyMatrix[i, j] == 1)
                {
                    hasOutgoingEdge = true;
                    break;
                }
            }
            if (!hasOutgoingEdge) // No outgoing edges
            {
                sinkNodes.Add(i + 1); // Nodes are numbered from 1
            }
        }
    }

    private static void WriteToFile(string outputFile)
    {
        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            writer.WriteLine(sinkNodes.Count);
            if (sinkNodes.Count > 0)
            {
                writer.WriteLine(string.Join(" ", sinkNodes));
            }
        }
        Console.WriteLine("Results have been written to BonChua.OUT");
    }

    public void Bai4()
    {
        string inFile = "U:\\THToandothi\\DSKe2Canh.INP";
        string outFile = "U:\\THToandothi\\DSKe2Canh.OUT";
        ReadMatrix4(inFile);
        TrainsposedGraph4();
        WriteFile4(outFile);
    }

    static void ReadMatrix4(string infile)
    {
        string[] Lines = File.ReadAllLines(infile);
        n = int.Parse(Lines[0]); // Read the number of nodes
        v_adjList4 = new List<int>[n + 1];

        for (int i = 1; i <= n; i++)
        {
            v_adjList4[i] = new List<int>();
            if (!string.IsNullOrWhiteSpace(Lines[i]))
            {
                string[] parts = Lines[i].Split();
                foreach (string part in parts)
                {
                    v_adjList4[i].Add(int.Parse(part));
                }
            }
        }
    }

    public static void TrainsposedGraph4()
    {
        vout_Graph4 = new List<int>[n + 1];

        for (int i = 1; i <= n; i++)
        {
            vout_Graph4[i] = new List<int>();
        }

        for (int u = 1; u <= n; u++)
        {
            foreach (int v in v_adjList4[u])
            {
                vout_Graph4[v].Add(u); // Reverse the edge
            }
        }

        for (int u = 1; u <= n; u++)
        {
            vout_Graph4[u].Sort();
        }
    }

    public static void WriteFile4(string outfile)
    {
        using (StreamWriter sw = new StreamWriter(outfile))
        {
            sw.WriteLine(n);
            for (int i = 1; i <= n; i++)
            {
                sw.WriteLine(string.Join(" ", vout_Graph4[i]));
            }
        }
        Console.WriteLine("successfully");
    }

    public void Bai5()
    {
        string inFile = "U:\\THToandothi\\TrungBinhCanh.INP";
        string outFile = "U:\\THToandothi\\TrungBinhCanh.OUT";
        ReadMatrix5(inFile);
        AvgEdge5();
        WriteFile5(outFile);
    }

    static void ReadMatrix5(string infile)
    {
        string[] lines = File.ReadAllLines(infile);
        // Số đỉnh n và số cạnh m
        string[] firstline = lines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        n = int.Parse(firstline[0]);
        m = int.Parse(firstline[1]);

        // Các dòng tiếp theo chứa danh sách cạnh
        v_arrayMatrix5 = new int[m + 1, 3];
        for (int i = 1; i <= m; i++)
        {
            string[] v_edge = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            v_arrayMatrix5[i, 0] = int.Parse(v_edge[0]);
            v_arrayMatrix5[i, 1] = int.Parse(v_edge[1]);
            v_arrayMatrix5[i, 2] = int.Parse(v_edge[2]);
        }
    }

    static void AvgEdge5()
    {
        // Hàm tính giá trị trung bình cạnh và tìm cạnh có trọng số lớn nhất
        v_AvgEdge = 0;
        v_Maxedge = 0;
        for (int i = 1; i <= m; i++)
        {
            v_AvgEdge += v_arrayMatrix5[i, 2];
            if (v_Maxedge < v_arrayMatrix5[i, 2])
            {
                v_Maxedge = v_arrayMatrix5[i, 2];
            }
        }
        v_AvgEdge = (double)v_AvgEdge / m;  // Đảm bảo chia cho m là số thực
    }

    public static void WriteFile5(string outfile)
    {
        using (StreamWriter sw = new StreamWriter(outfile))
        {
            sw.WriteLine(v_AvgEdge.ToString("F2"));  // Đảm bảo định dạng với 2 chữ số thập phân

            // Đếm số lượng cạnh có độ dài lớn nhất
            int countMaxEdge = 0;
            List<string> maxEdges = new List<string>();
            for (int i = 1; i <= m; i++)
            {
                if (v_arrayMatrix5[i, 2] == v_Maxedge)
                {
                    countMaxEdge++;
                    maxEdges.Add(string.Join(" ", v_arrayMatrix5[i, 0], v_arrayMatrix5[i, 1], v_arrayMatrix5[i, 2]));
                }
            }

            // In ra số lượng các cạnh có độ dài lớn nhất
            sw.WriteLine(countMaxEdge);

            // In ra các cạnh có độ dài lớn nhất
            foreach (var edge in maxEdges)
            {
                sw.WriteLine(edge);
            }
        }
        Console.WriteLine("Successfully written to file.");
    }

}
public class Buoi3
{
    static int n, m, s, x, y;
    static List<int>[] v_adjList;
    static List<int> v_result1;
    static int[] v_parent2;
    static bool v_result3;
    static bool[] v_visited;//đánh dấu là đã thăm
    private static List<int> v_result;
    private static List<int> v_path;
    private static bool[] v_visited4;
    private static int[] v_parent;

    public void Bai1()
    {
        ReadMatrix1("U:\\THToandothi\\BFS.INP");
        BreadthfirstSearch1();
        writeFile1("U:\\THToandothi\\BFS.OUT");
    }


    public void BreadthfirstSearch1()
    {
        Queue<int> v_queue1 = new Queue<int>();
        HashSet<int> v_visited = new HashSet<int>();
        v_result1 = new List<int>();
        //thêm s vào hàng đợi
        v_queue1.Enqueue(s);
        //thêm s vào danh sách ghé thăm 
        v_visited.Add(s);
        while (v_queue1.Count > 0)
        {
            //lấy giá trị trong hàng đợi ra
            int v_current = v_queue1.Dequeue();
            //lưu đỉnh vào danh sách kết quả, nhưng không thêm đỉnh Startnode
            if (v_current != s)
            {
                v_result1.Add(v_current);
            }
            //duyệt đỉnh kề của đỉnh lấy từ queue ra 
            foreach (int ke in v_adjList[v_current])
            {
                //nếu đỉnh kề đã duyệt thì bỏ qua
                if (!v_visited.Contains(ke))
                {
                    //thêm đỉnh kề vào hàng đợi và danh sách đã thêm
                    v_queue1.Enqueue(ke);
                    v_visited.Add(ke);
                }
            }
        }

    }  //có thể viết nhầm
       // xử lý DFS bằng stack

    //void Process_DepthFirstSearch1()
    //{
    //    v_visited = new bool[n + 1];
    //    v_result = new List<int>();
    //    Stack<int> v_stack = new Stack<int>();
    //    v_stack.Push(s);
    //    v_visited[s] = true;
    //    while (v_stack.Count > 0)
    //    {
    //        int node = v_stack.Pop();
    //        //không thêm điỉnh s vào kết quả
    //        if (node != s)
    //        {
    //            v_result.Add(node);
    //        }
    //        //Duyệt danh sách keerr từ lớn đến nhỏ để đảm bảo DFS đi theo thứ tự nhỏ trước
    //        //có thể đảo lại từ lớn đến nhỏ
    //        for (int j = v_adjList[node].Count - 1; j >= 0; j--)
    //        {
    //            int neighbor = v_adjList[node][j];
    //            if (!v_visited[neighbor])
    //            {
    //                v_stack.Push(neighbor);
    //                v_visited[neighbor] = true;
    //            }
    //        }
    //    }

    //}
    static void ReadMatrix1(string infile)
    {
        if (!File.Exists(infile))
        {
            Console.WriteLine("File does not exist.");
            return;
        }

        string[] lines = File.ReadAllLines(infile);
        if (lines.Length == 0)
        {
            Console.WriteLine("File is empty.");
            return;
        }

        // Đọc dòng đầu tiên để lấy số đỉnh và nút bắt đầu
        string[] firstLine = lines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (firstLine.Length < 2)
        {
            Console.WriteLine("Invalid file format.");
            return;
        }

        n = Convert.ToInt32(firstLine[0]); // số đỉnh
        s = Convert.ToInt32(firstLine[1]); // starting Node

        v_adjList = new List<int>[n + 1];

        for (int i = 1; i <= n; i++)
        {
            v_adjList[i] = new List<int>();
            if (!string.IsNullOrWhiteSpace(lines[i]))
            {
                string[] parts = lines[i].Split();
                foreach (string part in parts)
                {
                    v_adjList[i].Add(int.Parse(part));
                }
            }
        }

    }

    static void writeFile1(string outfile)
    {
        //File.WriteAllText(FileSystemName, string.Join(" ", v_result1));
        using (StreamWriter writer = new StreamWriter(outfile))
        {
            writer.WriteLine(v_result1.Count);
            //chi tiết kết quả
            writer.WriteLine(string.Join(" ", v_result1));

        }
    }
    public void Bai2()
    {
        string input = "U:\\THToandothi\\TimDuong.INP";
        string output = "U:\\THToandothi\\TimDuong.OUT";
        ReadMatrix2(input);
        BreadthFirstsearch2();
        writeFile2(output);


    }
    static void ReadMatrix2(string input)
    {
        // read inputed information
        string[] lines = File.ReadAllLines(input);
        //line 0  là đỉnh và startnode(s)
        string[] Firstline = lines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        n = int.Parse(Firstline[0]);// số đỉnh
        x = int.Parse(Firstline[1]);// startnode
        y = int.Parse(Firstline[2]);// startnode

        v_adjList = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            v_adjList[i] = new List<int>();
            if (!string.IsNullOrWhiteSpace(lines[i]))
            {
                string[] parts = lines[i].Split();
                foreach (string part in parts)
                {
                    v_adjList[i].Add(int.Parse(part));

                }
            }
        }

    }
    static void BreadthFirstsearch2()
    {
        Queue<int> v_queue = new Queue<int>();
        bool[] v_visited = new bool[n + 1];
        v_parent2 = new int[n + 1];
        //khởi tạo
        for (int i = 1; i <= n; i++)
        {
            v_parent2[i] = -1;//ko có cha
            v_visited[i] = false;

        }
        //bắt đầu BFS từ đỉnh x
        v_queue.Enqueue(x);
        v_visited[x] = true;
        v_parent2[x] = -1;//đỉnh xuất phát không có cha

        //BFS
        while (v_queue.Count > 0)
        {
            int u = v_queue.Dequeue();
            foreach (int v in v_adjList[u])//duyệt các đỉnh kề u
            {
                if (!v_visited[v])
                {
                    v_queue.Enqueue(v);
                    v_visited[v] = true;
                    v_parent2[v] = u;//gán cha của v là u

                    //nếu tìm thấy v dừng BFS
                    if (v == y)
                    {
                        return;
                    }
                }
            }

        }
    }
    //tìm đường đi bằng DFS sử dụng stack
    static void Path_DepthFirstSearch2()
    {
        Stack<int> stack = new Stack<int>();
        v_parent = new int[n + 1];
        v_visited = new bool[n + 1];
        v_path = new List<int>();
        stack.Push(x);
        v_visited[x] = true;
        v_parent[x] = -1;//đỉnh đầu tiên không có cha
        // làm rỗng đường đi giữa 2 đỉnh
        v_path.Clear();
        while (stack.Count > 0)
        {
            int u = stack.Pop();
            if (u == y)//nếu tìm được đỉnh đích

            {
                // dựng đường đi từ y về x
                int current = y;
                while (current != -1)//truy ngược đỉnh cha để lấy đường đi chính xác
                {
                    v_path.Add(current);
                    current = v_parent[current];
                }
                v_path.Reverse();
                return;
            }
            // kiểm tra đỉnh đã check chưa và duyệt kế của nó
            foreach (int v in v_adjList[u])
            {
                if (!v_visited[v])
                {
                    v_visited[v] = true;
                    stack.Push(v);
                    v_parent[v] = u;//lưu lại đường đi
                }
            }
        }
    }
    static void writeFile2(string output)
    {
        int current = y;
        if (v_parent2[current] != -1)//nếu ko có cha thì không liên thông
        {
            using (StreamWriter sw = new StreamWriter(output))
            {
                List<int> path = new List<int>();
                //lập duyệt mảng v_parrent2
                while (current != -1)
                {
                    //thêm đỉnh đã duyệt vào đường đi
                    path.Add(current);
                    //duy chuyển đến đỉnh kề tiếp theo trong v_parent2
                    current = v_parent2[current];

                }
                path.Reverse();//đảo ngược để có đường đi dúng thứ tự
                sw.WriteLine(path.Count);
                sw.WriteLine(string.Join(" ", path));

            }
            Console.WriteLine("successful");
        }
        else { Console.WriteLine("can'n not found"); }
    }
    public void Bai3()
    {
        string input = "U:\\THToandothi\\LienThong.INP";
        string output = "U:\\THToandothi\\LienThong.OUT";
        ReadMatrix3(input);
        GraphConnected3();
        writeFile3(output);
    }
    static void ReadMatrix3(string input)
    {
        //Đọc tất cả các dòng của mảng file
        string[] lines = File.ReadAllLines(input);
        //Số đỉnh của đồ thị
        n = int.Parse(lines[0]);
        v_adjList = new List<int>[n + 1];

        for (int i = 1; i <= n; i++)
        {
            v_adjList[i] = new List<int>();
            if (!string.IsNullOrWhiteSpace(lines[i]))
            {
                string[] parts = lines[i].Split();
                foreach (string part in parts)
                {
                    v_adjList[i].Add(int.Parse(part));
                }

            }
        }
    }
    static bool GraphConnected3()
    {
        //mảng đánh dấu các đỉnh đã duyệt
        bool[] visited = new bool[n + 1];
        int startNode = -1;

        //hàng đợi cho bfs
        Queue<int> queue = new Queue<int>();
        startNode = 1;
        //them  dinh 1 vao queue
        queue.Enqueue(startNode);
        visited[startNode] = true;
        //nếu queue còn thì lập
        while (queue.Count > 0)
        {
            //đọc queue vào u
            int u = queue.Dequeue();
            //duyệt đỉnh kế của u
            foreach (int v in v_adjList[u])
            {
                if (!visited[v])//neu đỉnh kề của u chưa duyệt thì duyệt
                {
                    visited[v] = true;// đánh dấu đã duyệt
                    queue.Enqueue(v);
                }
            }

        }
        //kiểm tra xem tất cả các đỉnh có cạnh  được duyệt qua chưa
        for (int i = 1; i <= n; i++)
        {
            if (!visited[i])//nếu 1 đỉnh chưa được duyệt nghĩa là không liên thông
            {
                visited[i] = false;
            }


        }
        return true;
    }
    static void writeFile3(string outfile)
    {
        File.WriteAllText(outfile, v_result3 ? "YES" : "NO");
        Console.WriteLine(string.Join(" ", "write file 3", v_result3 ? "YES" : "NO"));
    }

    public void Bai4()
    {
        string input = "U:\\THToandothi\\DemLienThong.INP";
        string output = "U:\\THToandothi\\DemLienThong.OUT";
        ReadMatrix3(input);

        writeFile4(output, CountConectedComponent());
    }
    static int CountConectedComponent()
    {
        v_visited4 = new bool[n + 1];//khởi tạo mảng đã đánh dấu
        int count = 0;
        // duyệt từng đỉnh
        for (int i = 1; i <= n; i++)
        {
            if (!v_visited4[i])
            {
                BFS(i);//gọi bfs duyệt toàn bộ miền liên thông
                count++;//tăng số miền liên thông
            }

        }
        return count;
    }
    static void BFS(int start)
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
        v_visited4[start] = true;
        while (queue.Count > 0)
        {
            int u = queue.Dequeue();
            foreach (int v in v_adjList[u])
            {
                if (!v_visited4[v])
                {
                    v_visited4[v] = true;
                    queue.Enqueue(v);
                }
            }
        }


    }
    static void writeFile4(string output, int count)
    {
        File.WriteAllText(output, count.ToString());
    }


}
public class Buoi4
{
    static int n, m, s, x, y;
    static List<int>[] v_adjList;//khởi tạo 1 mảng các danh sách list
    static List<int> v_result1;
    static int[] v_parent2;
    static bool v_result3;
    static bool[] v_visited;//đánh dấu là đã thăm
    private static List<int> v_result;
    private static List<int> v_path;
    private static bool[] v_visited4;
    private static int[] v_parent;
    public void Bai1()
    {
        ReadMatrix1("U:\\THToandothi\\DFS.INP");
        Process_DepthFirstSearch1();
        writeFile1("U:\\THToandothi\\DFS.OUT");
    }



    // xử lý DFS bằng stack

    //void Process_DepthFirstSearch1()
    //{
    //    v_visited = new bool[n + 1];
    //    v_result = new List<int>();
    //    Stack<int> v_stack = new Stack<int>();
    //    v_stack.Push(s);
    //    v_visited[s] = true;
    //    while (v_stack.Count > 0)
    //    {
    //        int node = v_stack.Pop();
    //        //không thêm điỉnh s vào kết quả
    //        if (node != s)
    //        {
    //            v_result.Add(node);
    //        }
    //        //Duyệt danh sách keerr từ lớn đến nhỏ để đảm bảo DFS đi theo thứ tự nhỏ trước
    //        //có thể đảo lại từ lớn đến nhỏ
    //        for (int j = v_adjList[node].Count - 1; j >= 0; j--)
    //        {
    //            int neighbor = v_adjList[node][j];
    //            if (!v_visited[neighbor])
    //            {
    //                v_stack.Push(neighbor);
    //                v_visited[neighbor] = true;
    //            }
    //        }
    //    }

    //}
    static void ReadMatrix1(string infile)
    {
        if (!File.Exists(infile))
        {
            Console.WriteLine("File does not exist.");
            return;
        }

        string[] lines = File.ReadAllLines(infile);
        if (lines.Length == 0)
        {
            Console.WriteLine("File is empty.");
            return;
        }

        // Đọc dòng đầu tiên để lấy số đỉnh và nút bắt đầu
        string[] firstLine = lines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (firstLine.Length < 2)
        {
            Console.WriteLine("Invalid file format.");
            return;
        }

        n = Convert.ToInt32(firstLine[0]); // số đỉnh
        s = Convert.ToInt32(firstLine[1]); // starting Node

        v_adjList = new List<int>[n + 1];

        for (int i = 1; i <= n; i++)
        {
            v_adjList[i] = new List<int>();
            if (!string.IsNullOrWhiteSpace(lines[i]))
            {
                string[] parts = lines[i].Split();
                foreach (string part in parts)
                {
                    v_adjList[i].Add(int.Parse(part));
                }
            }
        }

    }

    static void Process_DepthFirstSearch1()
    {
        if (s < 1 || s > n)
        {
            Console.WriteLine("Invalid start node.");
            return;
        }

        v_visited = new bool[n + 1];
        v_result = new List<int>();
        Stack<int> v_stack = new Stack<int>();

        v_stack.Push(s);
        v_visited[s] = true;

        while (v_stack.Count > 0)
        {
            int node = v_stack.Pop();
            //không thêm điỉnh s vào kết quả
            if (node != s)
            {
                v_result.Add(node);
            }
            //Duyệt danh sách keerr từ lớn đến nhỏ để đảm bảo DFS đi theo thứ tự nhỏ trước
            //có thể đảo lại từ lớn đến nhỏ

            if (v_adjList[node] != null)// nếu ko bỏ trường hợp null thì sẽ bị lỗi ko tồn tại object
            {
                for (int j = v_adjList[node].Count - 1; j >= 0; j--)
                {
                    int neighbor = v_adjList[node][j]; //lấy phần tử thứ j tại chỉ much node
                    if (!v_visited[neighbor])
                    {
                        v_stack.Push(neighbor);
                        v_visited[neighbor] = true;
                    }
                }
            }
        }
    }

    static void writeFile1(string outfile)
    {
        //File.WriteAllText(FileSystemName, string.Join(" ", v_result1));
        using (StreamWriter writer = new StreamWriter(outfile))
        {
            writer.WriteLine(v_result.Count);
            //chi tiết kết quả
            writer.WriteLine(string.Join(" ", v_result));

        }
    }
    public void Bai2()
    {
        string input = "U:\\THToandothi\\TimDuongDFS.INP";
        string output = "U:\\THToandothi\\TimDuongDFS.OUT";
        ReadMatrix2(input);
        Path_DepthFirstSearch2();
        writeFile2(output);


    }
    static void ReadMatrix2(string input)
    {
        // read inputed information
        string[] lines = File.ReadAllLines(input);
        //line 0  là đỉnh và startnode(s)
        string[] Firstline = lines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        n = int.Parse(Firstline[0]);// số đỉnh
        x = int.Parse(Firstline[1]);// startnode
        y = int.Parse(Firstline[2]);// startnode

        v_adjList = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            v_adjList[i] = new List<int>();
            if (!string.IsNullOrWhiteSpace(lines[i]))
            {
                string[] parts = lines[i].Split();
                foreach (string part in parts)
                {
                    v_adjList[i].Add(int.Parse(part));

                }
            }
        }

    }
    //tìm đường đi bằng DFS sử dụng stack
    static void Path_DepthFirstSearch2()
    {
        Stack<int> stack = new Stack<int>();
        v_parent = new int[n + 1];
        v_visited = new bool[n + 1];
        v_path = new List<int>();
        stack.Push(x);
        v_visited[x] = true;
        v_parent[x] = -1;//đỉnh đầu tiên không có cha
        // làm rỗng đường đi giữa 2 đỉnh
        v_path.Clear();
        while (stack.Count > 0)
        {
            int u = stack.Pop();
            if (u == y)//nếu tìm được đỉnh đích

            {
                // dựng đường đi từ y về x
                int current = y;
                while (current != -1)//truy ngược đỉnh cha để lấy đường đi chính xác
                {
                    v_path.Add(current);
                    current = v_parent[current];
                }
                v_path.Reverse();
                return;
            }
            // kiểm tra đỉnh đã check chưa và duyệt kế của nó
            foreach (int v in v_adjList[u])
            {
                if (!v_visited[v])
                {
                    v_visited[v] = true;
                    stack.Push(v);
                    v_parent[v] = u;//lưu lại đường đi
                }
            }
        }
    }
    static void writeFile2(string output)
    {
        using (StreamWriter sw = new StreamWriter(output))
        {
            if (v_path.Count == 0)
            {
                sw.WriteLine(0);
            }
            else
            {
                sw.WriteLine(v_path.Count);
                sw.WriteLine(string.Join(" ", v_path));

            }

        }
    }
}
public class Buoi5
{
    static int n, m, s, x, y;
    private static int[,] v_dist3;
    private static int t;
    private static List<(int, int)>[] v_MatrixGraph;
    const int INF = int.MaxValue;
    static int[] v_dist;
    private static int[] v_parent;
    private static bool[] v_visited;

    public void Bai1()
    {
        string input = "U:\\THToandothi\\Dijkstra.INP";
        string output = "U:\\THToandothi\\Dijkstra.OUT";
        ReadMatrix1(input);
        Dijkstral_SortedSet();
        WriteFile1(output);

    }
    static void ReadMatrix1(string input)
    {
        //Đọc dữ liệu file đầu vào
        string[] lines = File.ReadAllLines(input);

        string[] Firstline = lines[0].Split();

        n = int.Parse(Firstline[0]);
        m = int.Parse(Firstline[1]);
        s = int.Parse(Firstline[2]);
        t = int.Parse(Firstline[3]);

        //khởi tại ma trận mới 
        v_MatrixGraph = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            v_MatrixGraph[i] = new List<(int, int)>();
        }
        for (int i = 1; i <= m; i++)
        {
            string[] edge = lines[i].Split();
            int u = int.Parse(edge[0]);//đỉnh u
            int v = int.Parse(edge[1]);//đỉnh v
            int w = int.Parse(edge[2]);//trọng số

            v_MatrixGraph[u].Add((v, w));//đỉnh v kề u có trọng số w
            v_MatrixGraph[v].Add((u, w));//đỉnh u kề v có trọng số w



        }

    }
    static void Dijkstral_SortedSet()
    {
        v_dist = new int[n + 1];
        v_parent = new int[n + 1];
        v_visited = new bool[n + 1];
        for (int i = 1; i <= n; i++)
        {
            v_dist[i] = INF;//  vẽ cực
            v_parent[i] = -1;//chưa có đường đi

        }
        v_dist[s] = 0;
        var v_pq = new SortedSet<(int, int)>();
        v_pq.Add((0, s));


        while (v_pq.Count > 0)
        {
            var (du, u) = v_pq.Min;//lấy giá trị nhỏ nhất
            v_pq.Remove(v_pq.Min);//delete

            if (v_visited[u]) continue;// nếu trưa thì bỏ qua các dòng lệnh dưới
            v_visited[u] = true;
            foreach (var (v, w) in v_MatrixGraph[u])
            {
                if (v_dist[u] + w < v_dist[v])//tìm đường đi mới,trong số mới nhỏ hơn tổng đã lưu 
                {
                    v_dist[v] = v_dist[u] + w;
                    v_parent[v] = u;//tạo mắc xích mới
                    v_pq.Add((v_dist[v], v));// thêm vào hàng đợi ưu tiên là khoảng cách
                }

            }

        }
    }
    static void WriteFile1(string ouput)
    {
        using (StreamWriter writer = new StreamWriter(ouput))
        {
            if (v_dist[t] == INF)//ko tìm dc
            {
                writer.WriteLine("-1");
                return;
            }
            writer.WriteLine(v_dist[t]);//in khoảng cách ngắn nhất

            List<int> path = new List<int>();
            for (int i = t; i != -1; i = v_parent[i])
                path.Add(i);
            path.Reverse();
            writer.WriteLine(string.Join(" ", path));//in đường đi
        }
    }

    public void Bai2()
    {
        string input = "U:\\THToandothi\\NganNhatX.INP";
        string output = "U:\\THToandothi\\NganNhatX.OUT";
        ReadMatrix2(input);
        //FindShortestPath2();
        WriteFile2(output);
    }


    // Hàm đọc ma trận kề từ file
    static void ReadMatrix2(string input)
    {
        string[] lines = File.ReadAllLines(input);
        string[] Firstline = lines[0].Split();
        n = int.Parse(Firstline[0]);  // Số đỉnh
        m = int.Parse(Firstline[1]);  // Số cạnh
        s = int.Parse(Firstline[2]);  // Đỉnh s
        t = int.Parse(Firstline[3]);  // Đỉnh t
        x = int.Parse(Firstline[4]);  // Đỉnh x (trung gian)

        // Khởi tạo danh sách kề cho đồ thị
        v_MatrixGraph = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            v_MatrixGraph[i] = new List<(int, int)>();
        }

        // Đọc các cạnh từ dữ liệu đầu vào
        for (int i = 1; i <= m; i++)
        {
            string[] edge = lines[i].Split();
            int u = int.Parse(edge[0]);
            int v = int.Parse(edge[1]);
            int w = int.Parse(edge[2]);

            v_MatrixGraph[u].Add((v, w));  // Đỉnh v kề u với trọng số w
            v_MatrixGraph[v].Add((u, w));  // Đỉnh u kề v với trọng số w (đồ thị vô hướng)
        }
    }

    // Hàm Dijkstra để tính khoảng cách ngắn nhất từ một đỉnh
    static (int[], int[]) Dijkstra2(int start)
    {
        int[] dist = new int[n + 1];  // Khoảng cách từ start đến các đỉnh
        int[] parent = new int[n + 1];  // Mảng lưu cha của mỗi đỉnh để truy vết đường đi
        bool[] visited = new bool[n + 1];  // Mảng đánh dấu đỉnh đã xét

        for (int i = 1; i <= n; i++)
        {
            dist[i] = INF;
            parent[i] = -1;  // Chưa có cha
        }
        dist[start] = 0;

        // Hàng đợi ưu tiên SortedSet (khoảng cách, đỉnh)
        SortedSet<(int, int)> pq = new SortedSet<(int, int)>();
        pq.Add((0, start));

        while (pq.Count > 0)
        {
            var (du, u) = pq.Min;  // Lấy đỉnh có khoảng cách nhỏ nhất
            pq.Remove(pq.Min);  // Xóa khỏi hàng đợi

            if (visited[u]) continue;  // Nếu đã xử lý, bỏ qua
            visited[u] = true;  // Đánh dấu đỉnh đã xét

            // Kiểm tra danh sách kề của u và duyệt qua các đỉnh kề
            foreach (var (v, w) in v_MatrixGraph[u])
            {
                if (dist[v] > dist[u] + w)
                {
                    dist[v] = dist[u] + w;  // Cập nhật khoảng cách mới
                    parent[v] = u;  // Cập nhật cha của v
                    pq.Add((dist[v], v));  // Thêm vào hàng đợi
                }
            }
        }

        return (dist, parent);
    }

    // Hàm tìm đường đi ngắn nhất từ s -> x -> t
    static (int, List<int>) FindShortestPath2()
    {
        var (distFromS, parentFromS) = Dijkstra2(s);  // Từ s đến mọi đỉnh
        var (distFromX, parentFromX) = Dijkstra2(x);  // Từ x đến mọi đỉnh

        if (distFromS[x] == INF || distFromX[t] == INF)  // Nếu không có đường đi
            return (-1, new List<int>());

        int totalDistance = distFromS[x] + distFromX[t];  // Tổng trọng số
        List<int> path = new List<int>();

        // Truy vết đường đi từ s -> x
        GetPath(s, x, parentFromS, path);

        // Truy vết đường đi từ x -> t
        GetPath(x, t, parentFromX, path);

        return (totalDistance, path);
    }

    // Hàm truy vết đường đi
    static void GetPath(int start, int end, int[] parent, List<int> path)
    {
        List<int> temp = new List<int>();
        int current = end;
        while (current != -1)  // Truy vết ngược từ đích về nguồn
        {
            temp.Add(current);
            current = parent[current];
        }
        temp.Reverse();

        if (path.Count > 0)
        {
            temp.RemoveAt(0);  // Loại bỏ đỉnh trùng lặp (vì s -> x sẽ trùng đỉnh x)
        }

        path.AddRange(temp);
    }

    // Hàm ghi kết quả ra file
    static void WriteFile2(string output)
    {
        using (StreamWriter sw = new StreamWriter(output))
        {
            var (distance, path) = FindShortestPath2();  // Gọi hàm tìm đường đi ngắn nhất
            if (distance == -1)  // Nếu không có đường đi
            {
                sw.WriteLine("-1");
                return;
            }
            sw.WriteLine(distance);  // In tổng trọng số
            sw.WriteLine(string.Join(" ", path));  // In đường đi
        }

        Console.WriteLine("Successfully processed.");
    }

    public void Bai3()
    {
        string input = "U:\\THToandothi\\FloydWarshall.INP";
        string output = "U:\\THToandothi\\FloydWarshall.OUT";
        ReadMatrix3(input);
        FloydWarshallAlgorithm();
        WriteFile3(output);
    }
    // Hàm đọc ma trận kề từ file
    static void ReadMatrix3(string input)
    {
        string[] lines = File.ReadAllLines(input);
        n = int.Parse(lines[0]);  // Số đỉnh

        v_dist3 = new int[n + 1, n + 1];
        for (int i = 1; i <= n; i++)
        {
            string[] row = lines[i].Split();
            for (int j = 1; j <= n; j++)
            {
                v_dist3[i, j] = int.Parse(row[j - 1]);
                if (i != j && v_dist3[i, j] == 0) // Không có cạnh thì gán vô cực
                {
                    v_dist3[i, j] = INF;
                }
            }
        }
    }

    // Thuật toán Floyd-Warshall
    static void FloydWarshallAlgorithm()
    {
        for (int k = 1; k <= n; k++) // Duyệt qua từng đỉnh trung gian k
        {
            for (int i = 1; i <= n; i++) // Duyệt qua từng đỉnh nguồn i
            {
                for (int j = 1; j <= n; j++) // Duyệt qua từng đỉnh đích j
                {
                    // Nếu tìm thấy đường đi ngắn hơn qua đỉnh k
                    if (v_dist3[i, j] > v_dist3[i, k] + v_dist3[k, j])
                    {
                        v_dist3[i, j] = v_dist3[i, k] + v_dist3[k, j]; // Cập nhật đường đi ngắn hơn
                    }
                }
            }
        }
    }

    // Hàm ghi kết quả ra file
    static void WriteFile3(string output)
    {
        using (StreamWriter sw = new StreamWriter(output))
        {
            sw.WriteLine(n);
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    // Nếu không có đường đi, in "INF"
                    if (v_dist3[i, j] == INF)
                        sw.Write("INF ");
                    else
                        sw.Write(v_dist3[i, j] + " ");
                }
                sw.WriteLine();
            }
        }
        Console.WriteLine("Successfully processed.");
    }
}
public class Buoi6
{
    private static List<(int, int)>[] v_MatrixGraph;
    private static int n;
    private static int m;
    private static int x;
    private static bool[] v_visited;
    static List<(int, int, int)> v_treeEdges;
    private static int[] v_parent;
    private static List<(int, int, int)> v_MintreeEdges;
    private static int v_totalEdges;
    private static int start;
    private static int u;
    private static int v;
    private static int w;




    static void DFS_Stack(int n)
    {
        //stack sẽ hiệu quả hơn trong project lớn nhưng dài
        Stack<int> v_stack = new Stack<int>();
        v_stack.Push(start);
        v_visited[start] = true;

        while (v_stack.Count > 0)
        {
            int u = v_stack.Pop();
            foreach (var (v, w) in v_MatrixGraph[u])//duyệt đỉnh kề
            {
                if (!v_visited[u])//kiểm tra đỉnh đã được duyệt trc đó chx
                {
                    v_visited[v] = true;
                    v_stack.Push(v);
                    v_treeEdges.Add((u, v, w));//cho vào xây khung
                }
            }

        }

    }
    public void Bai1()
    {
        string inFile = "U:\\THToandothi\\CayKhung.INP";
        string outFile = "U:\\THToandothi\\CayKhung.OUT";
        ReadMatrix(inFile);
        v_visited = new bool[n + 1];
        v_treeEdges = new List<(int, int, int)>();
        DFS(1);
        WriteFile(outFile);
    }

    static void ReadMatrix(string input)
    {
        string[] lines = File.ReadAllLines(input);
        string[] firstLine = lines[0].Split();
        n = int.Parse(firstLine[0]); // số đỉnh
        m = int.Parse(firstLine[1]); // số cạnh

        v_MatrixGraph = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            v_MatrixGraph[i] = new List<(int, int)>();
        }

        for (int i = 1; i <= m; i++) // đọc đúng số cạnh
        {
            string[] edge = lines[i].Split();
            int u = int.Parse(edge[0]);
            int v = int.Parse(edge[1]);
            int w = int.Parse(edge[2]);

            v_MatrixGraph[u].Add((v, w));
            v_MatrixGraph[v].Add((u, w)); // đồ thị vô hướng
        }
    }

    static void DFS(int u)
    {
        v_visited[u] = true;
        foreach (var (v, w) in v_MatrixGraph[u])
        {
            if (!v_visited[v])
            {
                v_treeEdges.Add((u, v, w));
                DFS(v);
            }
        }
    }

    static void WriteFile(string output)
    {
        using (StreamWriter sw = new StreamWriter(output))
        {
            sw.WriteLine(v_treeEdges.Count);
            foreach (var (u, v, w) in v_treeEdges)
            {
                sw.WriteLine($"{u} {v} {w}");
            }
        }
        Console.WriteLine("successfully");
    }

    public void Bai2()
    {
        string inFile = "U:\\THToandothi\\Kruskal.INP";
        string outFile = "U:\\THToandothi\\Kruskal.OUT";
        ReadMatrix2(inFile);
        Kruskal();
        WriteFile2(outFile);
    }
    //lưu dạng cạnh
    static void ReadMatrix2(string input)
    {
        // read inputed information
        string[] lines = File.ReadAllLines(input);
        //line 0  là đỉnh và startnode(s)
        string[] Firstline = lines[0].Split();
        n = int.Parse(Firstline[0]);// số đỉnh
        x = int.Parse(Firstline[1]);// startnode
        v_treeEdges = new List<(int, int, int)>();


        //khởi tạo danh sách kề
        v_MatrixGraph = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            v_MatrixGraph[i] = new List<(int, int)>();
        }
        for (int i = 1; i <= n; i++)
        {
            string[] edge = lines[i].Split();
            int u = int.Parse(edge[0]);
            int v = int.Parse(edge[1]);
            int w = int.Parse(edge[2]);

            v_treeEdges.Add((w, u, v));//thêm cạnh vào danh sách
        }
    }
    static void Union(int u, int v)
    {
        int rootU = Find(u);
        int rootV = Find(v);
        if (rootU != rootV)
            v_parent[rootV] = rootU;//hợp nhất 2 tập hợp, chuyển gốc của v cùng với gốc của u
    }
    static int Find(int u)
    {
        Stack<int> stack = new Stack<int>();
        while (v_parent[u] != u)
        {
            stack.Push(u);
            u = v_parent[u];

        }
        //áp dụng đường đi
        while (stack.Count > 0)
        {
            int node = stack.Pop();
            v_parent[node] = u;

        }
        return u;
    }
    static void Kruskal()
    {
        v_treeEdges.Sort();//sắp xếp cạnh theo trọng số tăng dần
        v_parent = new int[n + 1];
        v_MintreeEdges = new List<(int, int, int)>();
        for (int i = 1; i <= n; i++)
        {
            v_parent[i] = i;//khởi tạo tập hợp riêng biệt cho mỗi đỉnh, là gốc của chính mình
        }
        foreach (var (w, u, v) in v_treeEdges)
        {
            if (Find(u) != Find(v))//nếu u và v không cùng tập hợp không cùng gốc

            {
                Union(u, v);//ghép 2 tập hợp cùng gốc
                v_MintreeEdges.Add((u, v, w));//Thêm vào tập khung cây nhỏ nhất
                v_totalEdges += w;
                if (v_MintreeEdges.Count == n - 1)
                    break;

            }

        }

    }
    static void WriteFile2(string outfile)
    {
        using (StreamWriter sw = new StreamWriter(outfile))
        {
            sw.WriteLine($"{v_MintreeEdges.Count} {v_totalEdges}");
            foreach (var (u, v, w) in v_MintreeEdges)
                sw.WriteLine($"{u} {v} {w}");

        }
    }
    public void Bai3()
    {
        string inFile = "U:\\THToandothi\\Prim.INP";
        string outFile = "U:\\THToandothi\\Prim.OUT";
        ReadMatrix3(inFile);
        Prim();
        WriteFile3(outFile);
    }

    private void Prim()
    {
        v_MintreeEdges = new List<(int, int, int)>();
        v_visited = new bool[n + 1];//đánh dấu đỉnh thuộc cây khung nhỏ nhất
        SortedSet<(int, int, int)> v_pqueue = new SortedSet<(int, int, int)>();//(trọng số, đỉnh u,đỉnh v) , hàng đợi ưu tiên

        v_visited[1] = true;// bắt đầu từ đỉnh 1
        foreach (var (v, w) in v_MatrixGraph[1])
        {
            v_pqueue.Add((w, 1, v));//(trọng số, đỉnh 1, đỉnh kề)

        }
        while (v_pqueue.Count > 0 && v_MintreeEdges.Count < n - 1)//lập khi hàng đợ còn và số cạnh đủ n-1

        {
            var (w, u, v) = v_pqueue.Min;//lấy cạnh có trọng số nhỏ nhất
            v_pqueue.Remove(v_pqueue.Min);//xóa khỏi hàng đợi

            if (v_visited[v]) continue;//bỏ qua nếu đỉnh đã xem xét
            v_MintreeEdges.Add((u, v, w));//thêm cạnh vào tập cây khung nhỏ nhất
            v_totalEdges += w;//tính tổng trọng số đã đi qua
            v_visited[v] = true;//đánh dấu đã xét

            foreach (var (du, dw) in v_MatrixGraph[v])//duyệt các đỉnh kề v
                if (!v_visited[du])
                    v_pqueue.Add((dw, v, du));//nếu chưa xét thì thêm vào hàng đợi




        }



    }

    static void ReadMatrix3(string inFile)
    {
        ReadMatrix(inFile);
    }
    static void WriteFile3(string outfile)
    {
        using (StreamWriter sw = new StreamWriter(outfile))
        {
            sw.WriteLine($"{v_MintreeEdges.Count} {v_totalEdges}");
            foreach (var (u, v, w) in v_MintreeEdges)
            {
                sw.WriteLine($"{u} {v} {w}");
            }

        }



    }
    public void Bai4()//ko thỏa dk thì xóa
    {
        string inFile = "U:\\THToandothi\\CayKhungX.INP";
        string outFile = "U:\\THToandothi\\CayKhungX.OUT";
        ReadMatrix4(inFile);
        int v_rest = Kruskal4();
        WriteFile4(outFile, v_rest);
    }



    static List<(int, int, int)> v_edges; // Lưu tất cả các cạnh
    private static int q;

    static void ReadMatrix4(string input)
    {
        string[] lines = File.ReadAllLines(input);
        string[] Firstline = lines[0].Split();
        n = int.Parse(Firstline[0]); // số đỉnh
        m = int.Parse(Firstline[1]); // số cạnh
        x = int.Parse(Firstline[2]); // điều kiện trọng số tối thiểu

        v_edges = new List<(int, int, int)>(); // Khởi tạo danh sách cạnh

        for (int i = 1; i <= m; i++) // Chạy từ dòng 1 đến m (không phải n)
        {
            string[] edge = lines[i].Split();
            int u = int.Parse(edge[0]);
            int v = int.Parse(edge[1]);
            int w = int.Parse(edge[2]);

            v_edges.Add((w, u, v)); // Lưu cạnh vào danh sách
        }
    }

    //Hàm xử lý thuật toán krusal có điều kiện ( với số cạnh có trọng số >=x)
    static int Kruskal4()
    {
        int v_total = 0, v_count = 0;

        // Lọc cạnh có trọng số >= x
        List<(int, int, int)> v_filteredEdges = new List<(int, int, int)>();
        foreach (var edge in v_edges)
        {
            if (edge.Item1 >= x) // Lưu ý: ">= x" thay vì ">"
            {
                v_filteredEdges.Add(edge);
            }
        }

        // Sắp xếp các cạnh theo trọng số tăng dần
        v_filteredEdges.Sort();

        // Khởi tạo DSU (Disjoint Set Union)
        v_parent = new int[n + 1];
        v_MintreeEdges = new List<(int, int, int)>();

        for (int i = 1; i <= n; i++) v_parent[i] = i;

        foreach (var (w, u, v) in v_filteredEdges)
        {
            if (Find(u) != Find(v)) // Nếu u và v chưa cùng tập
            {
                Union(u, v);
                v_MintreeEdges.Add((u, v, w));
                v_total += w;
                v_count++;

                if (v_count == n - 1) // Nếu đủ n-1 cạnh thì dừng
                {
                    return v_total;
                }
            }
        }

        return -1; // Nếu không tạo được MST hợp lệ
    }

    private static void WriteFile4(string outFile, int result)
    {
        File.WriteAllText(outFile, result.ToString());
        Console.WriteLine("WriteFile2");
    }


    static int villageCount5, builtRoadCount5;
    static List<(int cost5, int villageA5, int villageB5)> roadList5;
    static int[] parentSet5;

    public void Bai5()
    {
        string inputPath5 = "U:\\THToandothi\\Roads.INP";
        string outputPath5 = "U:\\THToandothi\\Roads.OUT";
        LoadRoadData5(inputPath5);
        int totalBuildCost5 = BuildMinimumNetwork5();
        SaveOutput5(outputPath5, totalBuildCost5);
    }

    static void LoadRoadData5(string filePath5)
    {
        string[] fileLines5 = File.ReadAllLines(filePath5);
        villageCount5 = int.Parse(fileLines5[0]);
        roadList5 = new List<(int, int, int)>();

        // Load distance matrix (only upper triangle, undirected graph)
        for (int i5 = 1; i5 <= villageCount5; i5++)
        {
            string[] rowValues5 = fileLines5[i5].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j5 = i5 + 1; j5 <= villageCount5; j5++)
            {
                int distance5 = int.Parse(rowValues5[j5 - 1]);
                roadList5.Add((distance5, i5 - 1, j5 - 1));
            }
        }

        builtRoadCount5 = int.Parse(fileLines5[villageCount5 + 1]);

        for (int k5 = 0; k5 < builtRoadCount5; k5++)
        {
            string[] edgeInfo5 = fileLines5[villageCount5 + 2 + k5].Split();
            int builtA5 = int.Parse(edgeInfo5[0]) - 1;
            int builtB5 = int.Parse(edgeInfo5[1]) - 1;
            roadList5.Add((0, builtA5, builtB5)); // already built, zero cost
        }
    }

    static int FindRoot5(int node5)
    {
        if (parentSet5[node5] != node5)
            parentSet5[node5] = FindRoot5(parentSet5[node5]);
        return parentSet5[node5];
    }

    static void UnionSets5(int a5, int b5)
    {
        int rootA5 = FindRoot5(a5);
        int rootB5 = FindRoot5(b5);
        if (rootA5 != rootB5)
            parentSet5[rootA5] = rootB5;
    }

    static int BuildMinimumNetwork5()
    {
        parentSet5 = new int[villageCount5];
        for (int i5 = 0; i5 < villageCount5; i5++)
            parentSet5[i5] = i5;

        roadList5.Sort((x5, y5) => x5.cost5.CompareTo(y5.cost5));

        int addedCost5 = 0;
        int connectedEdges5 = 0;

        foreach (var (cost5, villageX5, villageY5) in roadList5)
        {
            if (FindRoot5(villageX5) != FindRoot5(villageY5))
            {
                UnionSets5(villageX5, villageY5);
                if (cost5 > 0)
                    addedCost5 += cost5;
                connectedEdges5++;

                if (connectedEdges5 == villageCount5 - 1)
                    break;
            }
        }

        return addedCost5;
    }

    static void SaveOutput5(string outputFile5, int resultCost5)
    {
        File.WriteAllText(outputFile5, resultCost5.ToString());
        Console.WriteLine("Minimum build cost (5): " + resultCost5);
    }


}
public class Buoi7
{
    private static int n;
    private static int x;
    private static List<int> v_eulerCycle;
    private static bool[] v_visited;

    public static int[,] V_arrayMatrix_tmp { get; private set; }
    public static int[,] V_arrayMatrix { get; private set; }

    public void Bai1()
    {
        string input = "U:\\THToandothi\\EulerVoHuong.INP";
        string output = "U:\\THToandothi\\EulerVoHuong.OUT";
        ReadMatrix(input);
        int v_result = Euler1();
        WriteFile1(output, v_result);
    }

    private static void WriteFile1(string output, int result)
    {
        File.WriteAllText(output, result.ToString());
        Console.WriteLine("writefile 1");
    }

    static void ReadMatrix(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File does not exist.");
            Console.ReadKey();
            return;
        }

        string[] lines = File.ReadAllLines(file);
        n = Convert.ToInt32(lines[0]);
        V_arrayMatrix = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            string[] row = lines[i + 1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < n; j++)
            {
                V_arrayMatrix[i, j] = Convert.ToInt32(row[j]);
            }
        }
    }

    static int Euler1()
    {
        if (!Connected()) return 0;

        int oddDegreeCount = CountOddDegree();

        if (oddDegreeCount == 0) return 1; // Có chu trình Euler
        if (oddDegreeCount == 2) return 2; // Có đường đi Euler

        return 0; // Không có
    }

    private static int CountOddDegree()
    {
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            int degree = 0;
            for (int j = 0; j < n; j++)
            {
                degree += V_arrayMatrix[i, j];
            }
            if (degree % 2 == 1) count++;
        }
        return count;
    }

    static void DFS1(int u)
    {
        v_visited[u] = true;
        for (int v = 0; v < n; v++)
        {
            if (V_arrayMatrix[u, v] > 0 && !v_visited[v])
            {
                DFS1(v);
            }
        }
    }

    private static bool Connected()
    {
        v_visited = new bool[n];
        int startNode = -1;

        // Tìm một đỉnh có ít nhất 1 cạnh để bắt đầu DFS
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (V_arrayMatrix[i, j] > 0)
                {
                    startNode = i;
                    break;
                }
            }
            if (startNode != -1) break;
        }

        if (startNode == -1) return false; // Không có cạnh nào

        DFS1(startNode);

        // Kiểm tra các đỉnh có bậc > 0 đã được duyệt hết chưa
        for (int i = 0; i < n; i++)
        {
            if (!v_visited[i])
            {
                for (int j = 0; j < n; j++)
                {
                    if (V_arrayMatrix[i, j] > 0)
                        return false;
                }
            }
        }

        return true;
    }

    public void Bai2()
    {
        string input = "U:\\THToandothi\\EulerCoHuong.INP";
        string output = "U:\\THToandothi\\EulerCoHuong.OUT";
        ReadMatrix2(input);
        int v_rest = Euler2();
        WriteFile2(output, v_rest);
    }

    static void ReadMatrix2(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File không tồn tại.");
            return;
        }

        string[] lines = File.ReadAllLines(file);
        n = int.Parse(lines[0]); // Số đỉnh
        V_arrayMatrix = new int[n + 1, n + 1]; // Khởi tạo ma trận

        // Đọc ma trận kề
        for (int i = 1; i <= n; i++)
        {
            string[] row = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 1; j <= n; j++)
            {
                V_arrayMatrix[i, j] = int.Parse(row[j - 1]);
            }
        }
    }

    static void DFS2(int u)
    {
        v_visited[u] = true;
        for (int v = 1; v <= n; v++)
        {
            // Kiểm tra liên thông yếu: xét các cạnh hai chiều
            if ((V_arrayMatrix[u, v] > 0 || V_arrayMatrix[v, u] > 0) && !v_visited[v])
            {
                DFS2(v); // Đệ quy DFS để kiểm tra liên thông yếu
            }
        }
    }

    static bool Isweakly()
    {
        v_visited = new bool[n + 1];
        DFS2(1); // Duyệt đỉnh u
        for (int i = 1; i <= n; i++)
        {
            if (!v_visited[i])
            {
                return false; // Nếu có đỉnh chưa được thăm, đồ thị không liên thông yếu
            }
        }
        return true;
    }

    private static int Euler2()
    {
        // Kiểm tra đồ thị có phải liên thông yếu không
        if (!Isweakly())
        {
            return 0; // Đồ thị không liên thông yếu
        }

        // Mảng lưu bậc vào và bậc ra của các đỉnh
        int[] inDegrees = new int[n + 1];
        int[] outDegrees = new int[n + 1];

        // Tính toán bậc vào và bậc ra cho từng đỉnh
        for (int u = 1; u <= n; u++)
        {
            for (int v = 1; v <= n; v++)
            {
                if (V_arrayMatrix[u, v] > 0) // Nếu có cạnh từ u đến v
                {
                    outDegrees[u]++;
                    inDegrees[v]++;
                }
            }
        }

        int startNodes = 0, endNodes = 0;

        // Kiểm tra điều kiện cho chu trình Euler và đường đi Euler
        for (int i = 1; i <= n; i++)
        {
            if (outDegrees[i] - inDegrees[i] == 1)
            {
                startNodes++; // Có một đỉnh có bậc ra > bậc vào 1 đơn vị (start node)
            }
            else if (inDegrees[i] - outDegrees[i] == 1)
            {
                endNodes++; // Có một đỉnh có bậc vào > bậc ra 1 đơn vị (end node)
            }
            else if (inDegrees[i] != outDegrees[i])
            {
                return 0; // Nếu có bất kỳ đỉnh nào mà bậc vào khác bậc ra hơn 1 đơn vị thì không có chu trình hay đường đi Euler
            }
        }

        // Kiểm tra các trường hợp
        if (startNodes == 0 && endNodes == 0)
        {
            return 1; // Đồ thị có chu trình Euler
        }
        else if (startNodes == 1 && endNodes == 1)
        {
            return 2; // Đồ thị có đường đi Euler
        }

        return 0; // Đồ thị không có chu trình Euler và cũng không có đường đi Euler
    }

    static void WriteFile2(string output, int result)
    {
        File.WriteAllText(output, result.ToString());
        Console.WriteLine("Output: " + result);
    }


    public void Bai3()
    {
        string input = "U:\\THToandothi\\ChuTrinhEuler.INP";
        string output = "U:\\THToandothi\\ChuTrinhEuler.OUT";
        ReadMatrix3(input);
        List<int> v_eulerCycle = FindHierholzer3();
        Writefile3(output, v_eulerCycle);
    }

    private static void Writefile3(string output, List<int> v_eulerCycle)
    {
        using (StreamWriter sw = new StreamWriter(output))
        {
            if (v_eulerCycle != null && v_eulerCycle.Count > 0)
            {
                for (int j = 0; j < v_eulerCycle.Count - 1; j++)
                {
                    sw.Write(v_eulerCycle[j] + " ");
                    Console.Write(v_eulerCycle[j] + " ");
                }
                sw.Write(v_eulerCycle[v_eulerCycle.Count - 1]);  // Không in "->" ở cuối chu trình
                Console.WriteLine(v_eulerCycle[v_eulerCycle.Count - 1]);
            }
            else
            {
                sw.WriteLine("Không có chu trình Euler.");
                Console.WriteLine("Không có chu trình Euler.");
            }
        }
    }

    private static List<int> FindHierholzer3()
    {
        if (Euler1() == 1)
        {
            List<int> eulerCycle = Hierholzer3();
            return eulerCycle;
        }
        return null;
    }

    // Hàm xử lý chu trình Euler
    private static List<int> Hierholzer3()
    {
        Stack<int> stack = new Stack<int>();
        List<int> eulerCycle = new List<int>();

        // Sao chép ma trận kề ban đầu
        V_arrayMatrix_tmp = (int[,])V_arrayMatrix.Clone();

        stack.Push(x); // Đẩy đỉnh bắt đầu vào stack

        while (stack.Count > 0)
        {
            int u = stack.Peek();
            bool hasEdge = false;

            // Duyệt qua tất cả các đỉnh kề u
            for (int v = 1; v <= n; v++)
            {
                if (V_arrayMatrix_tmp[u, v] > 0)
                {
                    // Thêm v vào stack và xóa cạnh giữa u và v
                    stack.Push(v);
                    V_arrayMatrix_tmp[u, v]--; // Xóa cạnh u->v
                    V_arrayMatrix_tmp[v, u]--; // Xóa cạnh v->u (đồ thị vô hướng)
                    hasEdge = true;
                    break; // Duyệt cạnh đầu tiên tìm thấy
                }
            }

            if (!hasEdge)
            {
                // Nếu không còn cạnh nào, pop đỉnh ra và thêm vào chu trình
                eulerCycle.Add(stack.Pop());
            }
        }

        // Đảm bảo rằng chu trình Euler khép kín tại đỉnh ban đầu
        if (eulerCycle[0] != x)
        {
            eulerCycle.Add(x); // Nếu không, thêm đỉnh bắt đầu vào cuối chu trình
        }

        return eulerCycle;
    }


    private static void ReadMatrix3(string input)
    {
        string[] lines = File.ReadAllLines(input);

        string[] firstline = lines[0].Split();
        n = int.Parse(firstline[0]); // Đọc số đỉnh
        x = int.Parse(firstline[1]); // Đọc đỉnh bắt đầu

        V_arrayMatrix = new int[n + 1, n + 1];

        for (int i = 1; i <= n; i++)
        {
            string[] row = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 1; j <= n; j++)
            {
                V_arrayMatrix[i, j] = int.Parse(row[j - 1]); // Đọc ma trận kề
            }
        }
    }


    static int numVertices;  // Số đỉnh
    static int[,] adjacencyMatrix;  // Ma trận kề của đồ thị
    static List<List<int>> drawingStrokes;  // Danh sách các nét vẽ

    // Hàm chính để thực hiện việc vẽ
    public void Bai4()
    {
        string inputFile = "U:\\THToandothi\\kNet.INP";
        string outputFile = "U:\\THToandothi\\kNet.OUT";

        ReadGraphData(inputFile);
        int minStrokes = FindMinStrokes();
        WriteResult(outputFile, minStrokes);
    }

    // Hàm đọc dữ liệu từ file
    private static void ReadGraphData(string inputFile)
    {
        string[] lines = File.ReadAllLines(inputFile);
        numVertices = int.Parse(lines[0]); // Số đỉnh
        adjacencyMatrix = new int[numVertices + 1, numVertices + 1]; // Ma trận kề

        for (int i = 1; i <= numVertices; i++)
        {
            string[] row = lines[i].Split(' ');
            for (int j = 1; j <= numVertices; j++)
            {
                adjacencyMatrix[i, j] = int.Parse(row[j - 1]);
            }
        }
    }

    // Hàm tính số nét vẽ tối thiểu và lưu kết quả vào drawingStrokes
    private static int FindMinStrokes()
    {
        List<int> oddDegreeVertices = CountOddDegreeVertices();
        drawingStrokes = new List<List<int>>();

        // Kiểm tra số lượng đỉnh có bậc lẻ
        if (oddDegreeVertices.Count == 0 || oddDegreeVertices.Count == 2)
        {
            // Có thể vẽ trong 1 nét vẽ hoặc 2 nét vẽ
            Console.WriteLine("Đỉnh có bậc lẻ: " + string.Join(",", oddDegreeVertices)); // Debug thông tin đỉnh có bậc lẻ
            if (oddDegreeVertices.Count == 0)
            {
                Hierholzer(1);  // Nếu không có đỉnh lẻ, bắt đầu từ bất kỳ đỉnh nào
            }
            else
            {
                Hierholzer(oddDegreeVertices[0]); // Nếu có 2 đỉnh lẻ, chọn 1 trong các đỉnh lẻ làm điểm bắt đầu
            }
            return 1;
        }
        return 0; // Không thể vẽ trong một nét vẽ
    }

    // Hàm đếm các đỉnh có bậc lẻ
    private static List<int> CountOddDegreeVertices()
    {
        List<int> oddDegreeVertices = new List<int>();

        for (int i = 1; i <= numVertices; i++)
        {
            int degree = 0;
            for (int j = 1; j <= numVertices; j++)
            {
                degree += adjacencyMatrix[i, j];
            }

            if (degree % 2 != 0)
                oddDegreeVertices.Add(i); // Lưu các đỉnh có bậc lẻ
        }

        return oddDegreeVertices;
    }

    // Hàm thực hiện thuật toán Hierholzer để vẽ các cạnh
    private static void Hierholzer(int start)
    {
        Stack<int> stack = new Stack<int>();
        List<int> stroke = new List<int>();
        int[,] tempGraph = (int[,])adjacencyMatrix.Clone(); // Clone ma trận kề để tránh thay đổi ban đầu
        stack.Push(start);

        while (stack.Count > 0)
        {
            int u = stack.Peek();
            bool hasEdge = false;

            for (int v = 1; v <= numVertices; v++)
            {
                if (tempGraph[u, v] > 0)
                {
                    stack.Push(v);
                    tempGraph[u, v]--;
                    tempGraph[v, u]--;
                    hasEdge = true;
                    break; // Tiến tới đỉnh tiếp theo
                }
            }

            if (!hasEdge)
            {
                stroke.Add(stack.Pop());
            }
        }

        stroke.Reverse(); // Đảo ngược danh sách để lấy đúng thứ tự
        drawingStrokes.Add(stroke); // Lưu nét vẽ vào danh sách drawingStrokes
    }

    // Hàm ghi kết quả ra file
    private static void WriteResult(string outputFile, int minStrokes)
    {
        using (StreamWriter sw = new StreamWriter(outputFile))
        {
            sw.WriteLine(minStrokes);
            if (minStrokes > 0)
            {
                foreach (var stroke in drawingStrokes)
                {
                    sw.WriteLine(string.Join("->", stroke));
                }
            }
            else
            {
                sw.WriteLine("No");
            }
        }
    }


}



