using System;
using System.Collections.Generic;
using System.Linq;

namespace LTDLLesson01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("      CHUONG TRINH QUAN LY SINH VIEN");
            Console.WriteLine("==========================================");
            Console.WriteLine();

            List<Student> students = new List<Student>()
            {
                new Student(
                    "001",
                    "Nguyen Thi Hoa",
                    new DateTime(2010, 11, 10),
                    "Nu",
                    "Hoa@gmail.com",
                    "0123456789",
                    "CNTT",
                    8.9,
                    "Đang hoc"
                ),

                new Student(
                    "002",
                    "Nguyen Thanh Binh",
                    new DateTime(2008, 5, 20),
                    "Nu",
                    "binh@gmail.com",
                    "0123456790",
                    "Dien",
                    8.8,
                    "Đang hoc"
                ),

                new Student(
                    "003",
                    "Le Van Chuong",
                    new DateTime(2009, 8, 15),
                    "Nam",
                    "chuong@gmail.com",
                    "0123456791",
                    "CNTT",
                    9.1,
                    "Đang hoc"
                ),

                new Student(
                    "004",
                    "Pham Van Dung",
                    new DateTime(2005, 3, 12),
                    "Nam",
                    "dung@gmail.com",
                    "0123456792",
                    "Kinh Te",
                    7.8,
                    "Bao luu"
                ),

                new Student(
                    "005",
                    "Tran Thu Van",
                    new DateTime(2004, 11, 5),
                    "Nam",
                    "van@gmail.com",
                    "0123456793",
                    "CNTT",
                    9.1,
                    "Đang hoc"
                )
            };

            string choice;

            do
            {
                Menu();

                Console.Write("Nhap lua chon: ");
                choice = Console.ReadLine();

                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(students);
                        break;

                    case "2":
                        DisplayStudents(students);
                        break;

                    case "3":
                        FindStudentById(students);
                        break;

                    case "4":
                        SearchStudentByName(students);
                        break;

                    case "5":
                        UpdateStudent(students);
                        break;

                    case "6":
                        DeleteStudent(students);
                        break;

                    case "7":
                        SortByName(students);
                        break;

                    case "8":
                        SortByScore(students);
                        break;

                    case "9":
                        DisplayStudentsAbove8(students);
                        break;

                    case "10":
                        DisplayTopStudents(students);
                        break;

                    case "11":
                        CalculateAverage(students);
                        break;

                    case "12":
                        StatisticsByMajor(students);
                        break;

                    case "13":
                        StatisticsByStatus(students);
                        break;

                    case "14":
                        Console.WriteLine(
                            "Ban da ket thuc chuong trinh.");
                        break;

                    default:
                        Console.WriteLine(
                            "Lua chon khong hop le!");
                        Console.WriteLine(
                            "Vui long chon tu 1 den 14.");
                        break;
                }

                Console.WriteLine();

            } while (choice != "14");
        }


        // ================= MENU =================

        static void Menu()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("       CHUONG TRINH QUAN LY SINH VIEN");
            Console.WriteLine("==========================================");
            Console.WriteLine("1. Them sinh vien");
            Console.WriteLine("2. Hien thi danh sach sinh vien");
            Console.WriteLine("3. Tim sinh vien theo ma");
            Console.WriteLine("4. Tim gan dung theo ho ten");
            Console.WriteLine("5. Cap nhat sinh vien");
            Console.WriteLine("6. Xoa sinh vien");
            Console.WriteLine("7. Sap xep theo ho ten");
            Console.WriteLine("8. Sap xep theo diem trung binh");
            Console.WriteLine("9. Hien thi sinh vien co diem tu 8 tro len");
            Console.WriteLine("10. Hien thi sinh vien co diem cao nhat");
            Console.WriteLine("11. Tinh diem trung binh");
            Console.WriteLine("12. Thong ke sinh vien theo nganh");
            Console.WriteLine("13. Thong ke sinh vien theo trang thai");
            Console.WriteLine("14. Thoat");
            Console.WriteLine("==========================================");
        }


        // ================= THEM SINH VIEN =================

        static void AddStudent(List<Student> students)
        {
            Console.WriteLine("===== THEM SINH VIEN =====");

            string mssv;

            while (true)
            {
                Console.Write("Nhap ma sinh vien: ");
                mssv = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(mssv))
                {
                    Console.WriteLine(
                        "Ma sinh vien khong duoc de trong!");
                    continue;
                }

                mssv = mssv.Trim();

                if (students.Any(x =>
                    x.mssv.Equals(
                        mssv,
                        StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine(
                        "Ma sinh vien da ton tai!");
                    continue;
                }

                break;
            }


            string name;

            while (true)
            {
                Console.Write("Nhap ho ten: ");
                name = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(name))
                {
                    name = name.Trim();
                    break;
                }

                Console.WriteLine(
                    "Ho ten khong duoc de trong!");
            }


            DateTime ngaysinh;

            while (true)
            {
                Console.Write(
                    "Nhap ngay sinh (yyyy-MM-dd): ");

                string input = Console.ReadLine();

                if (DateTime.TryParse(
                    input,
                    out ngaysinh))
                {
                    break;
                }

                Console.WriteLine(
                    "Ngay sinh khong hop le!");
            }


            Console.Write("Nhap gioi tinh: ");
            string gioiTinh = Console.ReadLine();


            string email;

            while (true)
            {
                Console.Write("Nhap email: ");
                email = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(email)
                    && email.Contains("@"))
                {
                    email = email.Trim();
                    break;
                }

                Console.WriteLine(
                    "Email khong hop le!");
            }


            Console.Write("Nhap so dien thoai: ");
            string soDienThoai = Console.ReadLine();


            Console.Write("Nhap nganh hoc: ");
            string nganhHoc = Console.ReadLine();


            double diemTrungBinh;

            while (true)
            {
                Console.Write(
                    "Nhap diem trung binh (0-10): ");

                string input = Console.ReadLine();

                if (double.TryParse(
                    input,
                    out diemTrungBinh)
                    && diemTrungBinh >= 0
                    && diemTrungBinh <= 10)
                {
                    break;
                }

                Console.WriteLine(
                    "Diem phai nam trong khoang tu 0 den 10!");
            }


            Console.Write(
                "Nhap trang thai hoc tap: ");

            string trangThaiHocTap =
                Console.ReadLine();


            Student student = new Student(
                mssv,
                name,
                ngaysinh,
                gioiTinh,
                email,
                soDienThoai,
                nganhHoc,
                diemTrungBinh,
                trangThaiHocTap
            );

            students.Add(student);

            Console.WriteLine();
            Console.WriteLine(
                "Them sinh vien thanh cong!");
        }


        // ================= HIEN THI =================

        static void DisplayStudents(List<Student> students)
        {
            Console.WriteLine(
                "===== DANH SACH SINH VIEN =====");

            if (students.Count == 0)
            {
                Console.WriteLine(
                    "Danh sach sinh vien dang rong.");
                return;
            }

            Console.WriteLine(
                "Tong so sinh vien: " +
                students.Count);

            foreach (Student student in students)
            {
                PrintStudent(student);
            }

            Console.WriteLine(
                "==========================================");
        }


        // ================= IN THONG TIN =================

        static void PrintStudent(Student student)
        {
            Console.WriteLine(
                "------------------------------------------");

            Console.WriteLine(
                "Ma SV: " + student.mssv);

            Console.WriteLine(
                "Ho ten: " + student.name);

            Console.WriteLine(
                "Ngay sinh: " +
                student.Ngaysinh?.ToString("dd/MM/yyyy"));

            Console.WriteLine(
                "Gioi tinh: " +
                student.GioiTinh);

            Console.WriteLine(
                "Email: " +
                student.Email);

            Console.WriteLine(
                "So dien thoai: " +
                student.SoDienThoai);

            Console.WriteLine(
                "Nganh hoc: " +
                student.NganhHoc);

            Console.WriteLine(
                "Diem trung binh: " +
                student.DiemTrungBinh.ToString("F2"));

            Console.WriteLine(
                "Trang thai: " +
                student.TrangThaiHocTap);
        }


        // ================= TIM THEO MA =================

        static void FindStudentById(
            List<Student> students)
        {
            Console.WriteLine(
                "===== TIM SINH VIEN THEO MA =====");

            Console.Write("Nhap ma sinh vien: ");
            string mssv = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(mssv))
            {
                Console.WriteLine(
                    "Ma sinh vien khong duoc de trong!");
                return;
            }

            Student student =
                students.FirstOrDefault(x =>
                    x.mssv.Equals(
                        mssv.Trim(),
                        StringComparison.OrdinalIgnoreCase));

            if (student == null)
            {
                Console.WriteLine(
                    "Khong tim thay sinh vien.");
                return;
            }

            Console.WriteLine(
                "Da tim thay sinh vien:");

            PrintStudent(student);
        }


        // ================= TIM GAN DUNG THEO TEN =================

        static void SearchStudentByName(
            List<Student> students)
        {
            Console.WriteLine(
                "===== TIM GAN DUNG THEO HO TEN =====");

            Console.Write(
                "Nhap ho ten can tim: ");

            string keyword = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                Console.WriteLine(
                    "Tu khoa khong duoc de trong!");
                return;
            }

            var result = students
                .Where(x =>
                    x.name.Contains(
                        keyword.Trim(),
                        StringComparison.OrdinalIgnoreCase))
                .OrderBy(x => x.name)
                .ToList();

            if (result.Count == 0)
            {
                Console.WriteLine(
                    "Khong tim thay sinh vien phu hop.");
                return;
            }

            Console.WriteLine(
                "Tim thay " +
                result.Count +
                " sinh vien:");

            foreach (Student student in result)
            {
                Console.WriteLine(
                    student.mssv +
                    " - " +
                    student.name +
                    " - " +
                    student.NganhHoc +
                    " - Diem: " +
                    student.DiemTrungBinh.ToString("F2"));
            }
        }


        // ================= CAP NHAT =================

        static void UpdateStudent(
            List<Student> students)
        {
            Console.WriteLine(
                "===== CAP NHAT SINH VIEN =====");

            Console.Write(
                "Nhap ma sinh vien can cap nhat: ");

            string mssv = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(mssv))
            {
                Console.WriteLine(
                    "Ma sinh vien khong duoc de trong!");
                return;
            }

            Student student =
                students.FirstOrDefault(x =>
                    x.mssv.Equals(
                        mssv.Trim(),
                        StringComparison.OrdinalIgnoreCase));

            if (student == null)
            {
                Console.WriteLine(
                    "Khong tim thay sinh vien.");
                return;
            }

            Console.WriteLine(
                "Thong tin sinh vien hien tai:");

            PrintStudent(student);

            Console.WriteLine();
            Console.WriteLine(
                "===== NHAP THONG TIN MOI =====");


            string name;

            while (true)
            {
                Console.Write("Ho ten moi: ");
                name = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(name))
                {
                    break;
                }

                Console.WriteLine(
                    "Ho ten khong duoc de trong!");
            }


            DateTime ngaysinh;

            while (true)
            {
                Console.Write(
                    "Ngay sinh moi (yyyy-MM-dd): ");

                if (DateTime.TryParse(
                    Console.ReadLine(),
                    out ngaysinh))
                {
                    break;
                }

                Console.WriteLine(
                    "Ngay sinh khong hop le!");
            }


            Console.Write(
                "Gioi tinh moi: ");

            string gioiTinh = Console.ReadLine();


            string email;

            while (true)
            {
                Console.Write("Email moi: ");
                email = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(email)
                    && email.Contains("@"))
                {
                    break;
                }

                Console.WriteLine(
                    "Email khong hop le!");
            }


            Console.Write(
                "So dien thoai moi: ");

            string soDienThoai =
                Console.ReadLine();


            Console.Write(
                "Nganh hoc moi: ");

            string nganhHoc =
                Console.ReadLine();


            double diemTrungBinh;

            while (true)
            {
                Console.Write(
                    "Diem trung binh moi (0-10): ");

                if (double.TryParse(
                    Console.ReadLine(),
                    out diemTrungBinh)
                    && diemTrungBinh >= 0
                    && diemTrungBinh <= 10)
                {
                    break;
                }

                Console.WriteLine(
                    "Diem phai tu 0 den 10!");
            }


            Console.Write(
                "Trang thai hoc tap moi: ");

            string trangThaiHocTap =
                Console.ReadLine();


            student.name = name.Trim();
            student.Ngaysinh = ngaysinh;
            student.GioiTinh = gioiTinh;
            student.Email = email.Trim();
            student.SoDienThoai = soDienThoai;
            student.NganhHoc = nganhHoc;
            student.DiemTrungBinh =
                diemTrungBinh;
            student.TrangThaiHocTap =
                trangThaiHocTap;


            Console.WriteLine();
            Console.WriteLine(
                "Cap nhat sinh vien thanh cong!");

            Console.WriteLine();
            Console.WriteLine(
                "Thong tin sau khi cap nhat:");

            PrintStudent(student);
        }


        // ================= XOA =================

        static void DeleteStudent(
            List<Student> students)
        {
            Console.WriteLine(
                "===== XOA SINH VIEN =====");

            Console.Write(
                "Nhap ma sinh vien can xoa: ");

            string mssv = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(mssv))
            {
                Console.WriteLine(
                    "Ma sinh vien khong duoc de trong!");
                return;
            }

            Student student =
                students.FirstOrDefault(x =>
                    x.mssv.Equals(
                        mssv.Trim(),
                        StringComparison.OrdinalIgnoreCase));

            if (student == null)
            {
                Console.WriteLine(
                    "Khong tim thay sinh vien.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine(
                "Thong tin sinh vien:");

            PrintStudent(student);

            Console.WriteLine();
            Console.Write(
                "Ban co chac muon xoa? (Y/N): ");

            string confirm =
                Console.ReadLine();

            if (confirm.Equals(
                "Y",
                StringComparison.OrdinalIgnoreCase))
            {
                students.Remove(student);

                Console.WriteLine(
                    "Xoa sinh vien thanh cong!");
            }
            else
            {
                Console.WriteLine(
                    "Da huy thao tac xoa.");
            }
        }


        // ================= SAP XEP THEO TEN =================

        static void SortByName(
            List<Student> students)
        {
            Console.WriteLine(
                "===== SAP XEP THEO HO TEN =====");

            var result = students
                .OrderBy(x => x.name)
                .ToList();

            foreach (Student student in result)
            {
                Console.WriteLine(
                    student.mssv +
                    " - " +
                    student.name +
                    " - " +
                    student.DiemTrungBinh.ToString("F2"));
            }
        }


        // ================= SAP XEP THEO DIEM =================

        static void SortByScore(
            List<Student> students)
        {
            Console.WriteLine(
                "===== SAP XEP THEO DIEM =====");

            var result = students
                .OrderByDescending(
                    x => x.DiemTrungBinh)
                .ThenBy(x => x.name)
                .ToList();

            foreach (Student student in result)
            {
                Console.WriteLine(
                    student.mssv +
                    " - " +
                    student.name +
                    " - Diem: " +
                    student.DiemTrungBinh.ToString("F2"));
            }
        }


        // ================= DIEM TU 8 TRO LEN =================

        static void DisplayStudentsAbove8(
            List<Student> students)
        {
            Console.WriteLine(
                "===== SINH VIEN CO DIEM TU 8 TRO LEN =====");

            var result = students
                .Where(x =>
                    x.DiemTrungBinh >= 8)
                .OrderByDescending(
                    x => x.DiemTrungBinh)
                .ThenBy(x => x.name)
                .ToList();

            if (result.Count == 0)
            {
                Console.WriteLine(
                    "Khong co sinh vien nao.");
                return;
            }

            foreach (Student student in result)
            {
                Console.WriteLine(
                    student.mssv +
                    " - " +
                    student.name +
                    " - " +
                    student.DiemTrungBinh.ToString("F2"));
            }
        }


        // ================= DIEM CAO NHAT =================

        static void DisplayTopStudents(
            List<Student> students)
        {
            Console.WriteLine(
                "===== SINH VIEN CO DIEM CAO NHAT =====");

            if (students.Count == 0)
            {
                Console.WriteLine(
                    "Danh sach dang rong.");
                return;
            }

            double maxScore =
                students.Max(
                    x => x.DiemTrungBinh);

            var result = students
                .Where(x =>
                    x.DiemTrungBinh == maxScore)
                .OrderBy(x => x.name)
                .ToList();

            Console.WriteLine(
                "Diem cao nhat: " +
                maxScore.ToString("F2"));

            foreach (Student student in result)
            {
                Console.WriteLine(
                    student.mssv +
                    " - " +
                    student.name +
                    " - " +
                    student.DiemTrungBinh.ToString("F2"));
            }
        }


        // ================= TINH DIEM TRUNG BINH =================

        static void CalculateAverage(
            List<Student> students)
        {
            Console.WriteLine(
                "===== THONG KE DIEM =====");

            if (students.Count == 0)
            {
                Console.WriteLine(
                    "Danh sach dang rong.");
                return;
            }

            double average =
                students.Average(
                    x => x.DiemTrungBinh);

            double highest =
                students.Max(
                    x => x.DiemTrungBinh);

            double lowest =
                students.Min(
                    x => x.DiemTrungBinh);

            Console.WriteLine(
                "So sinh vien: " +
                students.Count);

            Console.WriteLine(
                "Diem trung binh: " +
                average.ToString("F2"));

            Console.WriteLine(
                "Diem cao nhat: " +
                highest.ToString("F2"));

            Console.WriteLine(
                "Diem thap nhat: " +
                lowest.ToString("F2"));
        }


        // ================= THONG KE THEO NGANH =================

        static void StatisticsByMajor(
            List<Student> students)
        {
            Console.WriteLine(
                "===== THONG KE THEO NGANH =====");

            if (students.Count == 0)
            {
                Console.WriteLine(
                    "Danh sach dang rong.");
                return;
            }

            var result = students
                .GroupBy(x => x.NganhHoc)
                .OrderBy(x => x.Key);

            foreach (var group in result)
            {
                double average =
                    group.Average(
                        x => x.DiemTrungBinh);

                Console.WriteLine(
                    group.Key +
                    ": " +
                    group.Count() +
                    " sinh vien" +
                    " - DTB: " +
                    average.ToString("F2"));
            }
        }


        // ================= THONG KE THEO TRANG THAI =================

        static void StatisticsByStatus(
            List<Student> students)
        {
            Console.WriteLine(
                "===== THONG KE THEO TRANG THAI =====");

            if (students.Count == 0)
            {
                Console.WriteLine(
                    "Danh sach dang rong.");
                return;
            }

            var result = students
                .GroupBy(
                    x => x.TrangThaiHocTap)
                .OrderBy(x => x.Key);

            foreach (var group in result)
            {
                Console.WriteLine(
                    group.Key +
                    ": " +
                    group.Count() +
                    " sinh vien");
            }
        }
    }
}