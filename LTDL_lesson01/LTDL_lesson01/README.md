# STUDENT MANAGEMENT

## 1. Giới thiệu

Chương trình quản lý sinh viên được xây dựng bằng ngôn ngữ C#.

Chương trình cho phép người dùng quản lý thông tin sinh viên thông qua menu trên màn hình Console.

## 2. Công nghệ sử dụng

- C#
- .NET
- Visual Studio
- Git
- GitHub
- List<T>
- LINQ
- Object-Oriented Programming

## 3. Thông tin sinh viên

Mỗi sinh viên gồm các thông tin:

- Mã sinh viên
- Họ tên
- Ngày sinh
- Giới tính
- Email
- Số điện thoại
- Ngành học
- Điểm trung bình
- Trạng thái học tập

## 4. Chức năng

### Quản lý sinh viên

1. Thêm sinh viên
2. Hiển thị danh sách sinh viên
3. Tìm sinh viên theo mã
4. Tìm gần đúng theo họ tên
5. Cập nhật sinh viên
6. Xóa sinh viên

### Xử lý dữ liệu

7. Sắp xếp theo họ tên
8. Sắp xếp theo điểm trung bình
9. Hiển thị sinh viên có điểm từ 8 trở lên
10. Hiển thị sinh viên có điểm cao nhất
11. Tính điểm trung bình
12. Thống kê sinh viên theo ngành
13. Thống kê sinh viên theo trạng thái

14. Thoát chương trình

## 5. Kiểm tra dữ liệu

Chương trình có kiểm tra một số dữ liệu đầu vào:

- Mã sinh viên không được trùng
- Mã sinh viên không được để trống
- Họ tên không được để trống
- Email không được để trống
- Điểm trung bình phải từ 0 đến 10
- Ngày sinh phải đúng định dạng

## 6. Cấu trúc chương trình

```text
LTDLLesson01
│
├── Program.cs
├── Student.cs
└── README.md