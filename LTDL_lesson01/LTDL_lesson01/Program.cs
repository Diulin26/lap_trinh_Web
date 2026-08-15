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
                    "Nguyen Van An",
                    new DateTime(2005, 1, 10),
                    "Nam",
                    "an@gmail.com",
                    "0123456789",
                    "CNTT",
                    8.5,
                    "Đang học"
                ),

                new Student(
                    "002",
                    "Tran Thi Binh",
                    new DateTime(2005, 5, 20),
                    "Nu",
                    "binh@gmail.com",
                    "0123456790",
                    "Ke toan",
                    7.2,
                    "Đang học"
                ),

                new Student(
                    "003",
                    "Le Van Cuong",
                    new DateTime(2004, 8, 15),
                    "Nam",
                    "cuong@gmail.com",
                    "0123456791",
                    "CNTT",
                    9.1,
                    "Đang học"
                ),

                new Student(
                    "004",
                    "Pham Thi Dung",
                    new DateTime(2005, 3, 12),
                    "Nu",
                    "dung@gmail.com",
                    "0123456792",
                    "Marketing",
                    6.8,
                    "Bao luu"
                ),

                new Student(
                    "005",
                    "Hoang Van Em",
                    new DateTime(2004, 11, 5),
                    "Nam",
                    "em@gmail.com",
                    "0123456793",
                    "CNTT",
                    9.1,
                    "Đang học"
                )
            };

            string choice;

            do
            {
                Menu();

                Console.Write("Nhap lua chon: ");
                choice = Console.ReadLine();

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
                        Console.WriteLine("Ban da ket thuc chuong trinh.");
                        break;

                    default:
                        Console.WriteLine("Sai chuc nang, vui long chon lai!");
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

            do
            {
                Console.Write("Nhap ma sinh vien: ");
                mssv = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(mssv))
                {
                    Console.WriteLine("Ma sinh vien khong duoc de trong!");
                }
                else if (students.Any(x => x.mssv == mssv))
                {
                    Console.WriteLine("Ma sinh vien da ton tai!");
                    mssv = "";
                }

            } while (string.IsNullOrWhiteSpace(mssv));


            string name;

            do
            {
                Console.Write("Nhap ho ten: ");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Ho ten khong duoc de trong!");
                }

            } while (string.IsNullOrWhiteSpace(name));


            DateTime ngaysinh;

            while (true)
            {
                Console.Write("Nhap ngay sinh (yyyy-MM-dd): ");

                if (DateTime.TryParse(
                    Console.ReadLine(),
                    out ngaysinh))
                {
                    break;
                }

                Console.WriteLine(
                    "Ngay sinh khong hop le, vui long nhap lai!");
            }


            Console.Write("Nhap gioi tinh: ");
            string gioiTinh = Console.ReadLine();


            string email;

            do
            {
                Console.Write("Nhap email: ");
                email = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(email))
                {
                    Console.WriteLine("Email khong duoc de trong!");
                }

            } while (string.IsNullOrWhiteSpace(email));


            Console.Write("Nhap so dien thoai: ");
            string soDienThoai = Console.ReadLine();


            Console.Write("Nhap nganh hoc: ");
            string nganhHoc = Console.ReadLine();


            double diemTrungBinh;

            while (true)
            {
                Console.Write("Nhap diem trung binh: ");

                if (double.TryParse(
                    Console.ReadLine(),
                    out diemTrungBinh)
                    && diemTrungBinh >= 0
                    && diemTrungBinh <= 10)
                {
                    break;
                }

                Console.WriteLine(
                    "Diem trung binh phai tu 0 den 10, vui long nhap lai!");
            }


            Console.Write("Nhap trang thai hoc tap: ");
            string trangThaiHocTap = Console.ReadLine();


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

            Console.WriteLine("Them sinh vien thanh cong!");
        }


        // ================= HIEN THI =================

        static void DisplayStudents(List<Student> students)
        {
            Console.WriteLine("===== DANH SACH SINH VIEN =====");

            if (students.Count == 0)
            {
                Console.WriteLine("Danh sach sinh vien dang rong.");
                return;
            }

            foreach (Student student in students)
            {
                PrintStudent(student);
            }

            Console.WriteLine("------------------------------------------");
        }


        // ================= IN THONG TIN =================

        static void PrintStudent(Student student)
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Ma SV: " + student.mssv);
            Console.WriteLine("Ho ten: " + student.name);
            Console.WriteLine(
                "Ngay sinh: " +
                student.Ngaysinh?.ToString("dd/MM/yyyy")
            );
            Console.WriteLine("Gioi tinh: " + student.GioiTinh);
            Console.WriteLine("Email: " + student.Email);
            Console.WriteLine("So dien thoai: " + student.SoDienThoai);
            Console.WriteLine("Nganh hoc: " + student.NganhHoc);
            Console.WriteLine(
                "Diem trung binh: " +
                student.DiemTrungBinh
            );
            Console.WriteLine(
                "Trang thai: " +
                student.TrangThaiHocTap
            );
        }


        // ================= TIM THEO MA =================

        static void FindStudentById(List<Student> students)
        {
            Console.WriteLine("===== TIM SINH VIEN THEO MA =====");

            Console.Write("Nhap ma sinh vien: ");
            string mssv = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(mssv))
            {
                Console.WriteLine("Ma sinh vien khong duoc de trong!");
                return;
            }

            Student student =
                students.FirstOrDefault(x =>
                    x.mssv.Equals(
                        mssv,
                        StringComparison.OrdinalIgnoreCase));

            if (student == null)
            {
                Console.WriteLine("Khong tim thay sinh vien.");
                return;
            }

            Console.WriteLine("Da tim thay sinh vien:");
            PrintStudent(student);
        }


        // ================= TIM GAN DUNG THEO TEN =================

        static void SearchStudentByName(List<Student> students)
        {
            Console.WriteLine("===== TIM GAN DUNG THEO HO TEN =====");

            Console.Write("Nhap ho ten can tim: ");
            string keyword = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                Console.WriteLine(
                    "Tu khoa tim kiem khong duoc de trong!");
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
                    student.DiemTrungBinh
                );
            }
        }


        // ================= CAP NHAT =================

        static void UpdateStudent(List<Student> students)
        {
            Console.WriteLine("===== CAP NHAT SINH VIEN =====");

            Console.Write("Nhap ma sinh vien can cap nhat: ");
            string mssv = Console.ReadLine();

            Student student =
                students.FirstOrDefault(x => x.mssv == mssv);

            if (student == null)
            {
                Console.WriteLine("Khong tim thay sinh vien.");
                return;
            }

            Console.Write("Ho ten moi: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Ho ten khong duoc de trong!");
                return;
            }

            Console.Write("Ngay sinh moi (yyyy-MM-dd): ");

            if (!DateTime.TryParse(
                Console.ReadLine(),
                out DateTime ngaysinh))
            {
                Console.WriteLine("Ngay sinh khong hop le!");
                return;
            }

            Console.Write("Gioi tinh moi: ");
            string gioiTinh = Console.ReadLine();

            Console.Write("Email moi: ");
            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email khong duoc de trong!");
                return;
            }

            Console.Write("So dien thoai moi: ");
            string soDienThoai = Console.ReadLine();

            Console.Write("Nganh hoc moi: ");
            string nganhHoc = Console.ReadLine();

            Console.Write("Diem trung binh moi: ");

            if (!double.TryParse(
                Console.ReadLine(),
                out double diemTrungBinh))
            {
                Console.WriteLine("Diem khong hop le!");
                return;
            }

            if (diemTrungBinh < 0 || diemTrungBinh > 10)
            {
                Console.WriteLine("Diem phai tu 0 den 10!");
                return;
            }

            Console.Write("Trang thai hoc tap moi: ");
            string trangThaiHocTap = Console.ReadLine();

            student.name = name;
            student.Ngaysinh = ngaysinh;
            student.GioiTinh = gioiTinh;
            student.Email = email;
            student.SoDienThoai = soDienThoai;
            student.NganhHoc = nganhHoc;
            student.DiemTrungBinh = diemTrungBinh;
            student.TrangThaiHocTap = trangThaiHocTap;

            Console.WriteLine("Cap nhat sinh vien thanh cong!");
        }


        // ================= XOA =================

        static void DeleteStudent(List<Student> students)
        {
            Console.WriteLine("===== XOA SINH VIEN =====");

            Console.Write("Nhap ma sinh vien can xoa: ");
            string mssv = Console.ReadLine();

            Student student =
                students.FirstOrDefault(x => x.mssv == mssv);

            if (student == null)
            {
                Console.WriteLine("Khong tim thay sinh vien.");
                return;
            }

            Console.WriteLine(
                "Sinh vien: " +
                student.mssv +
                " - " +
                student.name
            );

            Console.Write("Ban co chac muon xoa? (Y/N): ");
            string confirm = Console.ReadLine();

            if (confirm.Equals(
                "Y",
                StringComparison.OrdinalIgnoreCase))
            {
                students.Remove(student);
                Console.WriteLine("Xoa sinh vien thanh cong!");
            }
            else
            {
                Console.WriteLine("Da huy thao tac xoa.");
            }
        }


        // ================= SAP XEP THEO TEN =================

        static void SortByName(List<Student> students)
        {
            Console.WriteLine("===== SAP XEP THEO HO TEN =====");

            students.Sort((a, b) =>
                string.Compare(
                    a.name,
                    b.name,
                    StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("Da sap xep sinh vien theo ho ten.");

            DisplayStudents(students);
        }


        // ================= SAP XEP THEO DIEM =================

        static void SortByScore(List<Student> students)
        {
            Console.WriteLine("===== SAP XEP THEO DIEM =====");

            students.Sort((a, b) =>
                b.DiemTrungBinh.CompareTo(a.DiemTrungBinh));

            Console.WriteLine(
                "Da sap xep sinh vien theo diem giam dan.");

            DisplayStudents(students);
        }


        // ================= DIEM TU 8 TRO LEN =================

        static void DisplayStudentsAbove8(List<Student> students)
        {
            Console.WriteLine(
                "===== SINH VIEN CO DIEM TU 8 TRO LEN =====");

            var result = students
                .Where(x => x.DiemTrungBinh >= 8)
                .ToList();

            if (result.Count == 0)
            {
                Console.WriteLine(
                    "Khong co sinh vien nao co diem tu 8 tro len.");
                return;
            }

            foreach (Student student in result)
            {
                Console.WriteLine(
                    student.mssv + " - " +
                    student.name + " - " +
                    student.DiemTrungBinh
                );
            }
        }


        // ================= DIEM CAO NHAT =================

        static void DisplayTopStudents(List<Student> students)
        {
            Console.WriteLine("===== SINH VIEN CO DIEM CAO NHAT =====");

            if (students.Count == 0)
            {
                Console.WriteLine("Danh sach dang rong.");
                return;
            }

            double maxScore =
                students.Max(x => x.DiemTrungBinh);

            var result = students
                .Where(x => x.DiemTrungBinh == maxScore)
                .ToList();

            Console.WriteLine(
                "Diem cao nhat: " + maxScore);

            foreach (Student student in result)
            {
                Console.WriteLine(
                    student.mssv + " - " +
                    student.name + " - " +
                    student.DiemTrungBinh
                );
            }
        }


        // ================= TINH DIEM TRUNG BINH =================

        static void CalculateAverage(List<Student> students)
        {
            Console.WriteLine("===== DIEM TRUNG BINH CUA LOP =====");

            if (students.Count == 0)
            {
                Console.WriteLine("Danh sach dang rong.");
                return;
            }

            double average =
                students.Average(x => x.DiemTrungBinh);

            Console.WriteLine(
                "Diem trung binh cua lop: " +
                average.ToString("F2"));
        }


        // ================= THONG KE THEO NGANH =================

        static void StatisticsByMajor(List<Student> students)
        {
            Console.WriteLine("===== THONG KE THEO NGANH =====");

            var result = students
                .GroupBy(x => x.NganhHoc)
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


        // ================= THONG KE THEO TRANG THAI =================

        static void StatisticsByStatus(List<Student> students)
        {
            Console.WriteLine("===== THONG KE THEO TRANG THAI =====");

            var result = students
                .GroupBy(x => x.TrangThaiHocTap)
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