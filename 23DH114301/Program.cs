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
            Buoi2 buoi3 = new Buoi2();
            buoi3.Bai2();


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

    public void Bai1()
    {
        string input = "U:\\THToandothi\\Ke2Canh.INP";
        string output = "U:\\THToandothi\\Ke2Canh.OUT";
        ReadMatrix(input);
        //DegreesofVertices();
        //Writefile(output);
    }
    public static void ReadMatrix(string file)
    {
        string[] lines = File.ReadAllLines(file);//đọc số cạnh
        //dòng đầu tiên chứa số cạnh và số đỉnh
        if (!File.Exists(file))
        {
            Console.WriteLine("file is not exit");
        }
        // số đỉnh của đồ thị
        n = Convert.ToInt32(lines[0]);
        V_arrayMatrix1 = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            string[] row = lines[i + 1].Split(' ');
            for (int j = 0; j < n; j++)
            {
                V_arrayMatrix1[i, j] = Convert.ToInt32(row[j]);

            }


        }
    }
    public void Bai2()
    {
        string input = "U:\\THToandothi\\Ke2Canh.INP";
        string output = "U:\\THToandothi\\Ke2Canh.OUT";
        ReadMatrix2(input);
        ConvertToEdgeList2();
        WriteFile2(output);


    }
    static void ReadMatrix2(string file)
    {
        //đọc dữ liệu từ file 
        string[] line = File.ReadAllLines(file);
        if (!File.Exists(file))
        {
            Console.WriteLine("error read matrix bai 2");

        }
        v_listMatrix2 = new List<List<int>>();
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
                    v_list.Add(int.Parse(canhke));

                }
                v_listMatrix2.Add(v_list);
            }
            else
            {
                v_listMatrix2.Add(new List<int>());//đỉnh cô lập
            }
        }
    }
    class CEdge
    {
        public int u
        {
            get; set;
        }
        public int v
        {
            get; set;
        }
        public CEdge(int u, int v) { }
    }
    public static void ConvertToEdgeList2()
    {
        v_edges2 = new List<CEdge>();
        //tạo chuỗi không trùng phần tử
        HashSet<string> v_seenEdges = new HashSet<string>();
        for (int u = 0; u < n; u++)
        {
            foreach (int v in v_listMatrix2[u])
            {
                //u+1 : đỉnh 1..5
                string edgeKey = u + 1 < v ? $"{u + 1}-{v}" : $"{v}-{u + 1}";//đảm bảo không bị trùng lặp
                if (!v_seenEdges.Contains(edgeKey))
                {
                    v_edges2.Add(new CEdge(u + 1, v));
                    //thêm vào hash
                    v_seenEdges.Add(edgeKey);

                }

            }
        }
    }
    static void WriteFile2(string Oufile)
    {
        using (StreamWriter writer = new StreamWriter(Oufile))
        {
            writer.WriteLine($"{n} {v_edges2.Count}");
            foreach (var edge in v_edges2)
            {
                writer.WriteLine(edge.u + " " + edge.v);
            }
            Console.WriteLine("successfully");
        }


    }
    public static void Findnote3()
    {
        Node3 = new int[n];
        for (int i = 0; i < n; i++)
        {
            bool hasOutEdge = false;


        }
    }
    public static void Bai4()
    {
        string inFile = "U:\\THToandothi\\ChuyenVi.INP";
        string outFile = "U:\\THToandothi\\ChuyenVi.OUT";
        ReadMatrix4(inFile);
        WriteFile4(outFile);
    }
    static void ReadMatrix4(string infile)
    {
        string[] Lines = File.ReadAllLines(infile);
        n = int.Parse(Lines[0]);//đọc cố định
        v_adjList4 = new List<int>[n + 1];
        for (int i = 1; i < n; i++)
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

    }
    public static void WriteFile4(string outfile)
    {

    }
    public static void Bai5()
    {

    }
    static void ReadMatrix5(string infile)
    {

    }
    static void AvgEdge5()
    {

    }
    public static void WriteFile5(string outfile)
    {

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
                    int neighbor = v_adjList[node][j];
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
        string input = "U:\\THToandothi\\Dijkstra.INP";
        string output = "U:\\THToandothi\\Dijkstra.OUT";
        ReadMatrix2(input);
        FindShortestPath2();
        WriteFile2(output);
    }
    static void ReadMatrix2(string input)
    {
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
    static (int[], int[]) Dijkstra2(int start)
    {
        int[] dist = new int[n + 1];//lưu khoảng cách từ start đến các đỉnh
        int[] parrent = new int[n + 1];//mảng lưu cha của mỗi đỉnh truy vết đường đi
        bool[] visited = new bool[n + 1];//mảng đánh dấu đã xét

        for (int i = 1; i <= n; i++)
        {
            dist[i] = INF;
            parrent[i] = -1;//chưa có cha

        }
        dist[start] = 0;
        // Hàng đợi ưu tiên SortedSet (khoảng cách, đỉnh)
        SortedSet<(int, int)> pq = new SortedSet<(int, int)>();
        pq.Add((0, start));
        while (pq.Count > 0)
        {
            var (du, u) = pq.Min;//lấy đỉnh có khoảng cách nhỏ nhất
            pq.Remove(pq.Min);//xóa khỏi hàng đợi
            if (visited[u]) continue;//nếu đã xử lý , bỏ qua
            visited[u] = true;//đánh dấu đỉnh đã xét
            //int newDist w; khoảng cách mới đến y

            foreach (var (v, w) in v_MatrixGraph[u])//nếu tìm thấy đường đi tốt hơn
            {
                dist[v] = dist[u] + w;//cập nhật khoảng cách mới đến v
                parrent[v] = u;//cập nhật để truy vết
                pq.Add((dist[v], v));// thêm vào hàng đợi ưu tiên
            }
        }
        return (dist, parrent);

    }
    //tìm đường đi ngắn nhất từ s->x-> t
    static (int, List<int>) FindShortestPath2()
    {
        var (distFromS, parentFromS) = Dijkstra2(s);//từ s đến mọi đỉnh
        var (distFromX, parentFromX) = Dijkstra2(x);//từ x đến mọi đỉnh

        if (distFromS[x] == INF || distFromX[t] == INF)
            return (-1, new List<int>());//ko có đường đi

        int totalDistance = distFromS[x] + distFromX[t];// tổng trọng số
        List<int> path = new List<int>();
        //truy vết đường đi từ s->x
        GetPath(s, x, parentFromS, path);
        //truy vết đường đi từ x-> t
        GetPath(x, t, parentFromX, path);

        return (totalDistance, path);
    }
    static void GetPath(int start, int end, int[] parent, List<int> path)
    {
        List<int> temp = new List<int>();
        int current = end;
        //vòng lặp truy ngược đường đi
        while (current != -1)
        {
            temp.Add(current);
            current = parent[current];
        }
        temp.Reverse();

        //Nếu path không rỗng(đã có sẵn phần tử s+x), loại bỏ phần tử trùng lập
        if (path.Count > 0)
        {
            temp.RemoveAt(0);

        }
        path.AddRange(temp);
    }
    static void WriteFile2(string output)
    {
        using (StreamWriter sw = new StreamWriter(output))
        {
            //gọi hàm xử lý
            var (distance, v_path) = FindShortestPath2();
            if (distance == -1)//ko co
            {
                sw.WriteLine("-1");
                return;
            }
            sw.WriteLine(distance);
            sw.WriteLine(string.Join(" ", v_path));
        }


    }
    public void Bai3()
    {
        string input = "U:\\THToandothi\\FloydWarshall.INP";
        string output = "U:\\THToandothi\\FloydWarshall.OUT";
        ReadMatrix3(input);
        FloydWarshallAlgorithm();
        WriteFile3(output);
    }
    static void ReadMatrix3(string input)
    {
        string[] lines = File.ReadAllLines(input);
        n = int.Parse(lines[0]);//số đỉnh

        v_dist3 = new int[n + 1, n + 1];
        for (int i = 1; i <= n; i++)
        {
            string[] row = lines[i].Split();
            for (int j = 1; j <= n; j++)
            {
                v_dist3[i, j] = int.Parse(row[j - 1]);
                if (i != j && v_dist3[i, j] == 0)//ko có cạnh thì gán vô cực
                {
                    v_dist3[i, j] = INF / 2;
                }
            }
        }


    }
    //thuật toán Floyd-Warshall
    static void FloydWarshallAlgorithm()
    {
        for (int k = 1; k <= n; k++)//duyệt qua từng đỉnh
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (v_dist3[i, j] > v_dist3[i, k] + v_dist3[k, j])//tính lại trọng số nếu nhỏ hơn thì thay thế
                    {
                        v_dist3[i, j] -= v_dist3[i, k] + v_dist3[k, j];
                    }
                }
            }
        }
    }
    static void WriteFile3(string output)
    {
        using (StreamWriter sw = new StreamWriter(output))
        {
            sw.WriteLine(n);
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (v_dist3[i, j] == INF / 2)
                        sw.Write("INF ");
                    else
                        sw.Write(v_dist3[i, j] + " ");

                    sw.WriteLine();
                }

            }

        }
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

    public void Bai1()
    {
        string inFile = "U:\\THToandothi\\CayKhung.INP";
        string outFile = "U:\\THToandothi\\CayKhung.OUT";
        ReadMatrix(inFile);
        //DFS_Stack(1);
        v_visited = new bool[n + 1];
        v_treeEdges = new List<(int, int, int)>();//khai báo trc đệ qui
        DFS(1);
        WriteFile(outFile);
    }

    static void ReadMatrix(string input)
    {
        // read inputed information
        string[] lines = File.ReadAllLines(input);
        //line 0  là đỉnh và startnode(s)
        string[] Firstline = lines[0].Split();
        n = int.Parse(Firstline[0]);// số đỉnh
        m = int.Parse(Firstline[1]);// startnode


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

            v_MatrixGraph[u].Add((v, w));
            v_MatrixGraph[v].Add((u, w));//đồ thị vô hướng
        }

    }
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
    static void DFS(int u)
    {
        //cơ sở
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

                sw.WriteLine($"{u}  {v} {w}");
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
    static public void Bai4()
    {

    }

}


