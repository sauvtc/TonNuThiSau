using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TonNuThiSau
{
    internal class Program
    {
        static List<congviec> listCV = new List<congviec>();
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            congviec congviec = new congviec();
            bool flag = false;
           
            while (true)
            {
                Menu();
                string msg = "Nhập số từ 1-6 để thực  hiện chức năng: ";
                int number = Number(msg);
                //kiểm tra nhập chuổi hay số
                while (flag==false)
                {
                    if (number == 1)
                    {
                        flag = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Bạn chưa nhập công việc, vui lòng bấm phím 1 để nhập dữ liệu công việc");
                        number = Number(msg);
                    }

                } 
                switch (number)
                    {
                    case 1:
                        while(true)
                        {
                            Input();
                            msg = "Nhấn phím Escap để dừng chức năng nhập dữ liệu vào danh sách";
                            bool stop=Stoppro(msg);
                            if (stop==true) break;
                        }
                        break;
                    case 2:
                        Delete();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Searchname();
                        break;
                    case 5:
                        SortDesender();
                        break;
                    case 6:
                        Show();
                        break;
                    default: Console.WriteLine("Bạn nhập sai chức năng, chỉ nhập từ 1-6: ");
                        break;
                    
                }
                msg = "Nhấn phím Escap để dừng chương trình";
                bool stop1 = Stoppro(msg);
                if (stop1==true) break;
                Console.Clear();
            }
        }
        public static void Menu()
        {
            Console.WriteLine("1. Khai báo thông  tin cong việc cần làm");
            Console.WriteLine("2. Xóa thông  tin công việc cần làm theo vị trí");
            Console.WriteLine("3. Cập nhật trạng thái công  việc theo vị trí");
            Console.WriteLine("4. Tìm kiến công việc theo tên công việc");
            Console.WriteLine("5. Hiển thị danh sách công việc cần làm theo độ ưu tiên giảm dần");
            Console.WriteLine("6. Hiển thi danh sách công việc cần làm mà người dùng đã khai báo");
            
        }
        public static bool Stoppro(string msg)
        {
            Console.WriteLine();
            Console.WriteLine("Bạn có muốn tiếp tục không?");
            Console.WriteLine("Nhấn phím bất kỳ để tiếp tục");
            Console.WriteLine(msg);
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Escape) return true;
            return false;
        }

        public static void Input()
        {
            congviec cv = new congviec();
            bool flag = true;
            string msg="Nhập vào mã công việc: ";
            cv.MaCv = Number(msg);
            Console.Write("Nhập vào tên công việc: ");
            cv.TenCv=Console.ReadLine();
            flag = true;
            do
            {
                Console.Write("Nhập vào độ ưu tiên công việc: ");
                var douutien = Console.ReadLine();
                if (IsNumber(douutien) == true && int.Parse(douutien) >= 1 && int.Parse(douutien) <= 5)
                {
                    cv.DoUuTienCv = int.Parse(douutien);
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Bạn phải nhập độ ưu tiên từ 1-5");
                }


            } while (flag == true);

            Console.Write("Nhập vào mô tả công việc: ");
            cv.MoTaCV = Console.ReadLine();
            Console.Write("Nhập vào trạng  thái công việc: ");
            cv.TrangThaiCV = Console.ReadLine();
            listCV.Add(cv);
        }
        public static void Show() 
        { 
            foreach(var cv in listCV)
            {
                Console.WriteLine("Mã công việc: {0}", cv.MaCv);
                Console.WriteLine("Tên công việc: {0}", cv.TenCv);
                Console.WriteLine("Độ ưu tiên: {0}", cv.DoUuTienCv);
                Console.WriteLine("Mô tả công việc: {0}", cv.MoTaCV);
                Console.WriteLine("Trang thái công việc: {0}", cv.TrangThaiCV);
                Console.WriteLine();
            }
            
        }
        public static void SortDesender()
        {
            var listtem=listCV.OrderByDescending(c=>c.DoUuTienCv).ToList();
            foreach(var cv in listtem)
            {
                Console.WriteLine("Mã công việc: {0}", cv.MaCv);
                Console.WriteLine("Tên công việc: {0}", cv.TenCv);
                Console.WriteLine("Độ ưu tiên: {0}", cv.DoUuTienCv);
                Console.WriteLine("Mô tả công việc: {0}", cv.MoTaCV);
                Console.WriteLine("Trang thái công việc: {0}", cv.TrangThaiCV);
                Console.WriteLine();
            }
        }
        public static void Delete()
        {
            string msg="Nhập vào vị trí cần xoa: ";
            int pos= Number(msg);
            if ( pos <= 0 || pos >= listCV.Count )
            {
                Console.WriteLine("Bạn nhập vào vị trí không hợp lệ");
            }
            else
            {
                listCV.RemoveAt(pos);
            }
            Console.WriteLine("Danh sách công việc còn lại sau khi xóa: ");
            Show();
        }
        public static void Searchname()
        {
            Console.Write("Nhập vào tên việc cần tìm: ");
            string tencv = Console.ReadLine();
            congviec cv =new congviec();
            var item = listCV.FirstOrDefault(c=>c.TenCv==tencv);
            if(item is null)
            {
                Console.WriteLine("Tên công việc cần tìm không có");
            }
            else
            {
                Console.WriteLine("Mã công việc: {0}", item.MaCv);
                Console.WriteLine("Tên công việc: {0}", item.TenCv);
                Console.WriteLine("Độ ưu tiên: {0}", item.DoUuTienCv);
                Console.WriteLine("Mô tả công việc: {0}", item.MoTaCV);
                Console.WriteLine("Trang thái công việc: {0}", item.TrangThaiCV);
            }
        }
        public static void Update()
        {
            Console.Write("Nhập vào vị trí cần cập nhật trạng thái: ");
            int pos = int.Parse(Console.ReadLine());
            if(pos<0 && pos<listCV.Count) 
            {
                Console.WriteLine("Bạn nhập vào vị trí không hợp lệ");
            }
            else
            {
                Console.WriteLine("Trạng thái công việc cũ của vị trí {0} là {1}", pos, listCV[pos].TrangThaiCV);
                Console.Write("Nhập vào trạng thái công việc mới: ");
                listCV[pos].TrangThaiCV=Console.ReadLine();
            }
        }
        public static bool IsNumber(string pText)
        {
            //kiểm tra chuổi nhập là số hay text
            Regex regex = new Regex(@"^[-+]?[0-9]*.?[0-9]+$");
            return regex.IsMatch(pText);
        }
        public static int Number(string msg)
        {
            //Nhập một số kiểm tra số đó có phải là chuổi không nếu  không phải thì phải nhập lại
            string str;
            int number = 1;
            bool flag=false;
            do
            {
                Console.Write(msg);
                str = Console.ReadLine();
                if (IsNumber(str))
                {
                    number = int.Parse(str);
                    flag = true;
                    break;
                }
            } while (flag == false);
            return number;
        }
    }
}
