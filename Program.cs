using System;

namespace Tuan2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=======================================================");
            Console.Write("Nhap so ban muon tim: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Ban muon random so lon nhat la bao nhieu?: ");
            int max = int.Parse(Console.ReadLine());
            Console.Write("Ban muon co bao nhieu phan tu trong mang?: ");
            int len = int.Parse(Console.ReadLine());
            MyIntArray a = new MyIntArray(len);
            a.RandomArray(max);
            a.OutputArray();
            if (a.FindContent(n) == -1)
            {
                Console.WriteLine("\nKhong tim thay gia tri can tim!");
            }
            else
            {
                Console.WriteLine($"\nTim thay {n} o vi tri i = {a.FindContent(n)}");
            }
            
            if(a.CheckArray(len) == "TangDan"){
                Console.WriteLine("Co the sap xep tuyen tinh vi mang tang dan");
            }
            else if(a.CheckArray(len) == "GiamDan")
            {
                Console.WriteLine("Co the sap xep tuan tu vi mang giam dan");
            }
            else
            {
                Console.WriteLine("Co the sap xep tuan tu vi mang khong co thu tu");
            }
            Console.WriteLine($"So lan thuc hien so sanh tuan tu la: {a.CountLinearSearchSteps(n)}");
            Array.Sort(a.Mang);
            Console.WriteLine($"So lan thuc hien so sanh nhi phan (sau khi duoc sap xep) la: {a.CountBinarySearchSteps(n)}");
            Console.WriteLine("=======================================================");
        }
    }
    class MyIntArray
    {
        private int[] array;
        public int[] Mang
        {
            get => this.array;
            set { this.array = value; }
        }

        public MyIntArray(int n = 8)
        {
            Mang = new int[n];
        }

        public int this[int i]
        {
            get => array[i];
            set => array[i] = value;
        }

        public void RandomArray(int max)        //phát sinh ngẫu nhiên mảng
        {
            for (int i = 0; i < Mang.Length; i++)
            {
                Random x = new Random();
                Mang[i] = x.Next(max);
            }
        }
        public void OutputArray()               //Xuất mảng
        {
            Console.WriteLine("KET QUA MANG:");
            for (int i = 0; i < Mang.Length; i++)
            {
                Console.Write(Mang[i] + " ");
            }
        }
        public int FindContent(int x)           //Tìm kiếm theo phương pháp tuần tự
        {
            for (int i = 0; i < Mang.Length; i++)
            {
                if (Mang[i] == x)
                {
                    return i;
                }
            }
            return -1;
        }
        public int CountLinearSearchSteps(int number_being_find)        //Đếm số lần thực hiện tìm kiếm theo phương pháp tuần tự
        {
            for (int i = 0; i < Mang.Length; i++)
            {
                if (Mang[i] == number_being_find)
                {
                    return i + 1;
                }
            }
            return Mang.Length;
        }
        public int CountBinarySearchSteps(int number_being_find)        //Đếm số lần thực hiện tìm kiếm theo phương pháp nhị phân
        {
            int left = 0;
            int right = Mang.Length - 1;
            int mid;
            int found = 0;
            while (left <= right)
            {
                mid = (left + right) / 2;
                found++;
                if (Mang[mid] == number_being_find)
                {
                    break;
                }
                else if (number_being_find < Mang[mid])
                {
                    right = mid - 1;
                }
                else if (number_being_find > Mang[mid])
                {
                    left = mid + 1;
                }
            }
            return found;
        }
        public string CheckArray(int chieudaimang)         //Kiểm tra xem mảng tăng dần, giảm dần hay không có thứ tự
        {
            MyIntArray b = new MyIntArray(chieudaimang);
            MyIntArray c = new MyIntArray(chieudaimang);
            for(int i = 0;i<chieudaimang;i++){
                b.Mang[i] = this.Mang[i];
                c.Mang[i] = this.Mang[i];
            }
            Array.Sort(b.Mang);
            Array.Sort(c.Mang);
            Array.Reverse(c.Mang);
            if(this.Mang == b.Mang)
            {
                return "TangDan";
            }
            else if(this.Mang == c.Mang)
            {
                return "GiamDan";
            }
            else
            {
                return "KhongCoThuTu";
            }
        }
    }
}


