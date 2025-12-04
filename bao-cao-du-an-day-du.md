# BÁO CÁO ĐỒ ÁN

**Tên môn học:** Xây dựng ứng dụng quản lý

**Đề tài:** Study Document Manager - Phần mềm quản lý tài liệu cá nhân

**Học kỳ:** II - Năm học 2024-2025

**Sinh viên thực hiện:** Vũ Đức Dũng

**Lớp:** TT601K14

**Ngày:** 04/12/2025

---

## MỤC LỤC

1. [Lời mở đầu](#lời-mở-đầu)
2. [Chương I: Tổng quan về đề tài](#chương-i-tổng-quan-về-đề-tài)
3. [Chương II: Cơ sở lý thuyết](#chương-ii-cơ-sở-lý-thuyết)
4. [Chương III: Khảo sát và phân tích hệ thống](#chương-iii-khảo-sát-và-phân-tích-hệ-thống)
5. [Chương IV: Thiết kế hệ thống](#chương-iv-thiết-kế-hệ-thống)
6. [Chương V: Thiết kế giao diện và triển khai](#chương-v-thiết-kế-giao-diện-và-triển-khai)
7. [Chương VI: Hướng dẫn cài đặt và sử dụng](#chương-vi-hướng-dẫn-cài-đặt-và-sử-dụng)
8. [Chương VII: Kiểm thử và xử lý lỗi](#chương-vii-kiểm-thử-và-xử-lý-lỗi)
9. [Kết luận](#kết-luận)
10. [Tài liệu tham khảo](#tài-liệu-tham-khảo)

---

## LỜI MỞ ĐẦU

Trong thời đại công nghệ số hóa hiện nay, việc quản lý tài liệu học tập và công việc là một thách thức lớn đối với học sinh, sinh viên và những người làm việc văn phòng. Số lượng file tài liệu tăng lên không ngừng, các file nằm rải rác trên các ổ đĩa, folder khác nhau, khiến việc tìm kiếm và sắp xếp trở nên vô cùng phức tạp. Mỗi lần cần tìm một tài liệu quan trọng, nhiều người phải mất hàng phút thậm chí hàng giờ để tìm ra nó. Đôi khi tài liệu bị lạc mất giữa bao nhiêu folder, hoặc quên hết tài liệu ở đâu.

Thêm vào đó, không phải ai cũng có thời gian tổ chức tài liệu một cách khoa học. Khi muốn chia sẻ tài liệu với mọi người, phải gửi từng file một qua email hay cloud storage. Nhiều tài liệu quan trọng bị quên lãng hoặc đánh mất vì không có hệ thống quản lý tập trung. Một số sinh viên không biết mình có bao nhiêu tài liệu, tài liệu nào đã ôn xong, tài liệu nào sắp đến hạn nộp.

Chính vì những lý do trên mà em quyết định xây dựng ứng dụng **Study Document Manager** - một công cụ quản lý tài liệu đơn giản nhưng đầy đủ, giúp người dùng sắp xếp, tìm kiếm và theo dõi tài liệu một cách hiệu quả. Ứng dụng cho phép mỗi người quản lý tài liệu của riêng mình, gắn nhãn, đặt hạn chót, ghi chú và tổ chức tài liệu thành các bộ sưu tập theo chủ đề. Với ứng dụng này, người dùng sẽ không bao giờ quên tài liệu ở đâu, cũng không bao giờ bỏ lỡ deadline quan trọng.

Đồ án này không chỉ là một bài tập lập trình, mà còn là cơ hội để em rèn luyện kỹ năng phát triển ứng dụng thực tế, làm quen với mô hình kiến trúc 3 tầng, bảo mật dữ liệu, phân quyền người dùng và xây dựng giao diện thân thiện. Thông qua dự án này, em sẽ học được cách thiết kế hệ thống từ đầu, viết mã sạch, xử lý lỗi một cách chuyên nghiệp, và xây dựng sản phẩm có thể sử dụng trong thực tế.

---

## CHƯƠNG I: TỔNG QUAN VỀ ĐỀ TÀI

### I. Lý do chọn đề tài

Em chọn đề tài này vì ba lý do chính:

**Thứ nhất, giải quyết bài toán thực tế:** Mỗi người đều có nhiều tài liệu học tập hoặc làm việc, nhưng không có một công cụ quản lý tập trung. Khi học một khoá học gồm 10-15 môn, mỗi môn có 10-20 tài liệu, thì lúc cần tìm lại rất khó. Ứng dụng này sẽ giải quyết vấn đề đó. Mục đích chính của dự án là tạo ra một nơi lưu trữ tài liệu có tổ chức, dễ tìm kiếm, tiết kiệm thời gian cho người dùng. Người dùng sẽ không cần lo lắng về việc tìm lại tài liệu, vì tất cả đều được quản lý một cách khoa học trong ứng dụng.

**Thứ hai, áp dụng kiến thức đã học:** Trong khoá học, em đã học về C#, Windows Forms, SQL Server, lập trình hướng đối tượng, thiết kế cơ sở dữ liệu, v.v. Đề tài này là cơ hội để tích hợp tất cả những kiến thức đó vào một ứng dụng thực tế, đầy đủ. Em muốn thử sức xem mình có thể áp dụng những gì đã học vào một dự án thực tế hay không. Qua đó sẽ giúp em tự tin hơn khi đi làm sau này.

**Thứ ba, mở rộng kỹ năng phát triển:** Dự án giúp em làm quen với kiến trúc 3 tầng (Presentation, Business, Data), bảo mật mật khẩu bằng BCrypt (không phải cách đơn giản mà những lập trình viên thực tế dùng), xử lý phân quyền người dùng một cách chặt chẽ, xây dựng giao diện hiện đại với Material Design, và quản lý cơ sở dữ liệu toàn diện. Đây là những kỹ năng rất quan trọng mà khi đi làm sẽ gặp liên tục.

### II. Phương pháp nghiên cứu

Em sử dụng ba phương pháp chính để thực hiện dự án:

**1. Phương pháp nghiên cứu lý thuyết:**
- Tìm hiểu sâu về ngôn ngữ C# và Windows Forms thông qua tài liệu Microsoft Docs
- Nghiên cứu mô hình kiến trúc 3 tầng trong lập trình, tại sao nó lại quan trọng
- Tìm hiểu về bảo mật mật khẩu với BCrypt, tại sao không nên dùng MD5 hay SHA1
- Đọc tài liệu SQL Server về thiết kế cơ sở dữ liệu, chuẩn hóa dữ liệu, tối ưu hóa truy vấn
- Nghiên cứu Material Design để hiểu cách thiết kế giao diện hiện đại

**2. Phương pháp tham khảo thực tiễn:**
- Tìm hiểu cách thức quản lý tài liệu của các ứng dụng hiện có (Google Drive, Dropbox, Microsoft OneDrive)
- Phân tích nhu cầu thực tế của học sinh, sinh viên khi quản lý tài liệu
- Xem xét các tính năng phổ biến mà người dùng cần
- Tìm hiểu lỗi phổ biến mà các ứng dụng quản lý tài liệu thường gặp

**3. Phương pháp thực nghiệm và xây dựng:**
- Thiết kế cơ sở dữ liệu bằng SQL Server, vẽ sơ đồ ERD để kiểm tra
- Viết mã lập trình từng chức năng, kiểm thử trong quá trình phát triển
- Xây dựng giao diện người dùng dần dần, tối ưu hóa trải nghiệm
- Sửa lỗi và điều chỉnh dựa trên kết quả kiểm thử
- Nhờ bạn bè test và cho feedback để cải thiện

### III. Nhiệm vụ của đề tài

Để hoàn thành dự án, em cần:

- **Thiết kế cơ sở dữ liệu:** Tạo 7 bảng chính (users, tai_lieu, collections, personal_notes, user_sessions, activity_logs, collection_items) và các mối quan hệ giữa chúng. Phải đảm bảo tính toàn vẹn dữ liệu, không có dư thừa.

- **Xây dựng chức năng đăng nhập:** Tạo tài khoản mới, đăng nhập, phân biệt role (User/Admin), xử lý lỗi đăng nhập sai.

- **Tạo chức năng quản lý tài liệu:** Thêm, sửa, xóa tài liệu với đầy đủ thông tin (tên, danh mục, loại, file, ghi chú, tác giả).

- **Xây dựng tìm kiếm và lọc:** Hỗ trợ tìm kiếm theo từ khóa, lọc theo danh mục, loại, ngày, dung lượng, chỉ tài liệu quan trọng.

- **Phát triển tính năng nâng cao:** Tags (nhãn), deadline, ghi chú cá nhân, bộ sưu tập, kiểm tra file bị thiếu.

- **Xây dựng giao diện hiện đại:** Toast notification, context menu, drag-drop, thống kê biểu đồ, icon động.

- **Kiểm thử toàn bộ hệ thống:** Đảm bảo các chức năng hoạt động đúng, không có lỗi, xử lý tốt các trường hợp biên.

### IV. Mục tiêu của đề tài

**Mục tiêu về sản phẩm:**
- Tạo ra một ứng dụng quản lý tài liệu hoàn chỉnh, chạy ổn định trên Windows
- Giao diện thân thiện, dễ sử dụng cho mọi đối tượng, không cần hướng dẫn chi tiết vẫn dùng được
- Hỗ trợ đầy đủ các tính năng quản lý tài liệu từ cơ bản đến nâng cao
- Bảo mật dữ liệu người dùng một cách chặt chẽ, không sợ bị lộ mật khẩu
- Hiệu năng tốt, tải nhanh ngay cả khi có 1000+ tài liệu

**Mục tiêu về kiến thức:**
- Nắm vững kiến trúc 3 tầng trong phát triển ứng dụng, biết khi nào nên dùng
- Hiểu rõ về quy trình xây dựng hệ thống từ phân tích, thiết kế đến triển khai
- Có khả năng quản lý cơ sở dữ liệu phức tạp với nhiều bảng và mối quan hệ
- Rèn luyện kỹ năng lập trình từ backend đến frontend
- Học được cách viết mã sạch, dễ bảo trì

### V. Phạm vi, đối tượng nghiên cứu

**Phạm vi:**
- Ứng dụng hỗ trợ hệ điều hành Windows (7, 8, 10, 11)
- Sử dụng .NET Framework 4.8 và SQL Server 2012 trở lên
- Mô hình quản lý tài liệu cá nhân (mỗi user quản lý tài liệu của riêng mình, không xem được tài liệu người khác)
- Hỗ trợ 2 cấp quyền: User thường và Admin
- Khoảng 50+ form và class, hơn 100 phương thức

**Đối tượng sử dụng:**
- Học sinh, sinh viên cần quản lý tài liệu học tập hàng ngày
- Người làm việc văn phòng cần tổ chức tài liệu công việc
- Quản trị viên hệ thống (Admin) quản lý tài khoản người dùng, danh mục
- Giáo viên muốn quản lý tài liệu bài giảng

### VI. Ý nghĩa thực tiễn

- Giải quyết bài toán quản lý tài liệu thực tế cho học sinh, sinh viên, tiết kiệm thời gian lên hàng tiếng mỗi tuần
- Tạo công cụ tiết kiệm thời gian tìm kiếm, sắp xếp tài liệu, không cần phải dig vào folder
- Cải thiện năng suất học tập và công việc của người dùng, tập trung hơn vào nội dung thay vì tìm file
- Chứng tỏ khả năng lập trình và thiết kế ứng dụng thực tế của sinh viên, có sản phẩm minh chứng cho CV

---

## CHƯƠNG II: CƠ SỞ LÝ THUYẾT

### I. Kiến trúc 3 tầng (Three-Tier Architecture)

**Khái niệm:**
Kiến trúc 3 tầng là mô hình tổ chức ứng dụng thành ba lớp độc lập nhưng liên kết chặt chẽ. Mỗi tầng có trách nhiệm riêng, không can thiệp vào công việc của tầng khác.

**1. Tầng Presentation (Giao diện - UI):**
- Chịu trách nhiệm hiển thị dữ liệu cho người dùng, làm cho nó dễ nhìn, dễ hiểu
- Tiếp nhận các hành động của người dùng (nhấp chuột, nhập dữ liệu, kéo thả)
- Gửi yêu cầu đến tầng Business để xử lý
- Hiển thị kết quả trả về theo cách thích hợp
- Trong dự án: Tất cả các form Windows Forms (Dashboard, AddEditForm, LoginForm, v.v)
- Không chứa logic xử lý, chỉ là giao diện thuần

**2. Tầng Business (Logic xử lý):**
- Chứa logic xử lý chính của ứng dụng
- Kiểm tra quyền hạn người dùng (admin có thể xóa user, user bình thường không)
- Xác thực dữ liệu đầu vào (tên không được để trống, email phải đúng format)
- Thực hiện các quy tắc nghiệp vụ (mỗi user chỉ thấy tài liệu của mình)
- Tính toán các giá trị phức tạp
- Trong dự án: DatabaseHelper, UserSession, BCryptTemp
- Không gọi trực tiếp đến database hoặc UI, tạo sự độc lập

**3. Tầng Data (Dữ liệu):**
- Quản lý kết nối cơ sở dữ liệu
- Thực hiện các truy vấn SQL
- Lưu trữ và truy xuất dữ liệu từ database
- Xử lý các lỗi liên quan đến database
- Trong dự án: SQL Server database với 7 bảng chính
- Là tầng thấp nhất, chỉ liên lạc với tầng Business

**Lợi ích của kiến trúc 3 tầng:**
- **Tách biệt mối quan tâm:** mỗi tầng có trách nhiệm riêng, không lẫn lộn
- **Dễ bảo trì:** sửa lỗi ở một tầng không ảnh hưởng đến tầng khác
- **Dễ mở rộng:** thêm tính năng mới không phải sửa toàn bộ hệ thống
- **Dễ kiểm thử:** có thể kiểm thử từng tầng riêng lẻ
- **Tái sử dụng code:** tầng Business có thể dùng cho cả desktop, web, mobile

**Sơ đồ kiến trúc:**
```
┌─────────────────────────────────────────────────┐
│     PRESENTATION LAYER (UI - Windows Forms)    │
│  ├─ LoginForm.cs                               │
│  ├─ Dashboard.cs (Form chính)                  │
│  ├─ AddEditForm.cs (Thêm/sửa tài liệu)         │
│  ├─ CategoryManagementForm.cs                  │
│  ├─ UserManagementForm.cs (Admin)              │
│  ├─ Report.cs (Thống kê)                       │
│  ├─ AccountSettingsForm.cs                     │
│  └─ Các form khác (150+ controls)              │
└─────────────────────────────────────────────────┘
                      ↕️ (gọi phương thức)
┌─────────────────────────────────────────────────┐
│     BUSINESS LAYER (Logic - Classes)            │
│  ├─ DatabaseHelper.cs (50+ methods)            │
│  ├─ DatabaseHelper_UserAuth.cs (partial)       │
│  ├─ UserSession.cs (static, lưu info user)     │
│  ├─ BCryptTemp.cs (bảo mật mật khẩu)           │
│  ├─ IconHelper.cs (tạo icon động)              │
│  └─ ToastNotification.cs (thông báo)           │
└─────────────────────────────────────────────────┘
                      ↕️ (SQL queries)
┌─────────────────────────────────────────────────┐
│      DATA LAYER (Database - SQL Server)        │
│  ├─ users (tài khoản người dùng)              │
│  ├─ tai_lieu (tài liệu)                        │
│  ├─ collections (bộ sưu tập)                   │
│  ├─ collection_items (liên kết)                │
│  ├─ personal_notes (ghi chú)                   │
│  ├─ user_sessions (phiên đăng nhập)            │
│  └─ activity_logs (log hoạt động)              │
└─────────────────────────────────────────────────┘
```

### II. Ngôn ngữ C# và Windows Forms

**C# là gì:**
C# (đọc là "See Sharp") là ngôn ngữ lập trình được tạo ra bởi Microsoft vào năm 2000, chạy trên nền tảng .NET Framework. Nó là sự kết hợp giữa sức mạnh của C++, Java và đơn giản của Visual Basic.

**Đặc điểm của C#:**
- **Ngôn ngữ hướng đối tượng mạnh mẽ:** Hỗ trợ class, interface, inheritance, polymorphism
- **Hỗ trợ lập trình không đồng bộ (async/await):** Có thể thực hiện nhiều tác vụ cùng lúc mà không block UI
- **Có tính năng garbage collection:** Tự quản lý bộ nhớ, không cần tự free
- **Type-safe:** Kiểm tra kiểu dữ liệu tại thời điểm compile, bắt lỗi sớm
- **Thích hợp để xây dựng ứng dụng Windows, web (ASP.NET), game (Unity), v.v**

**Windows Forms là gì:**
Windows Forms là nền tảng được tích hợp sẵn trong .NET Framework để xây dựng giao diện người dùng cho các ứng dụng Windows. Nó cung cấp các điều khiển (Control) sẵn có như nút bấm (Button), hộp văn bản (TextBox), bảng dữ liệu (DataGridView), v.v mà ta có thể kéo thả để thiết kế.

**Tại sao chọn C# và Windows Forms:**
- Dễ học: Có cú pháp rõ ràng, tài liệu phong phú, cộng đồng lớn
- Mạnh mẽ: Hỗ trợ hầu hết các tính năng lập trình hiện đại
- Có GUI designer: Thiết kế giao diện bằng kéo thả trong Visual Studio, không cần viết HTML/CSS
- Hỗ trợ nhiều library mở rộng: Có sẵn thư viện cho hầu hết mọi việc
- Tích hợp tốt với SQL Server: Dễ dàng kết nối và truy vấn database

**Ví dụ đơn giản (kiến trúc 3 tầng trong C#):**
```csharp
// Tầng Presentation (UI)
private void btnSave_Click(object sender, EventArgs e)
{
    string taiLieuName = txtTen.Text;
    // Gọi tầng Business
    var result = DatabaseHelper.InsertDocument(taiLieuName);
    if (result) MessageBox.Show("Lưu thành công");
}

// Tầng Business
public class DatabaseHelper
{
    public static bool InsertDocument(string name)
    {
        // Kiểm tra dữ liệu
        if (string.IsNullOrEmpty(name)) return false;
        // Gọi tầng Data
        return ExecuteNonQuery("INSERT INTO tai_lieu ...");
    }
}

// Tầng Data
private static bool ExecuteNonQuery(string query)
{
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        SqlCommand cmd = new SqlCommand(query, conn);
        conn.Open();
        return cmd.ExecuteNonQuery() > 0;
    }
}
```

### III. SQL Server và thiết kế cơ sở dữ liệu

**SQL Server là gì:**
SQL Server là hệ quản trị cơ sở dữ liệu quan hệ (RDBMS - Relational Database Management System) được phát triển bởi Microsoft. Nó lưu trữ dữ liệu theo kiểu bảng (table) với các hàng (row) và cột (column), tương tự như Excel nhưng mạnh mẽ hơn rất nhiều.

**Tại sao chọn SQL Server:**
- Mạnh mẽ và đáng tin cậy, được sử dụng rộng rãi trong doanh nghiệp
- Hỗ trợ phiên bản Express miễn phí cho người học (không cần bỏ tiền)
- Tích hợp tốt với .NET Framework, dễ kết nối từ C#
- Có công cụ SQL Server Management Studio (SSMS) để quản lý dễ dàng
- Hỗ trợ tính năng nâng cao: stored procedure, trigger, transaction, index

**Thiết kế cơ sở dữ liệu:**
Dự án sử dụng 7 bảng chính với mối quan hệ N-N, 1-N:

| Bảng | Mô tả | Số record dự kiến |
|------|-------|-------------------|
| users | Lưu tài khoản người dùng | 100-1000 |
| user_sessions | Phiên đăng nhập | 100-500 |
| tai_lieu | Tài liệu học tập | 10,000+ |
| collections | Bộ sưu tập tài liệu | 1000+ |
| collection_items | Liên kết tài liệu trong bộ sưu tập | 10,000+ |
| personal_notes | Ghi chú cá nhân | 5000+ |
| activity_logs | Nhật ký hoạt động | 100,000+ |

**Chuẩn hóa dữ liệu (3NF):**
- Loại bỏ dư thừa dữ liệu (không lưu trùng lặp)
- Mỗi cột chỉ lưu một loại thông tin
- Tách dữ liệu vào các bảng khác nhau nhưng có mối liên kết

### IV. BCrypt - Bảo mật mật khẩu

**Tại sao không lưu mật khẩu trực tiếp:**
Nếu lưu mật khẩu bằng văn bản thuần túy hoặc mã hóa đơn giản (MD5, SHA1), khi database bị lộ (hack hoặc lỗi bảo mật) thì mật khẩu của tất cả người dùng sẽ bị phơi bày. Người dùng có thể sử dụng cùng mật khẩu ở nhiều trang web, vậy thì hacker sẽ truy cập được tất cả tài khoản của họ.

**Tại sao MD5, SHA1 không an toàn:**
- Là hàm one-way (không thể giải mã ngược lại), nhưng:
- Không có salt (giá trị ngẫu nhiên), nên hai người dùng cùng mật khẩu sẽ có cùng hash
- Tốc độ tính toán nhanh, hacker có thể brute-force (thử tất cả khả năng)

**BCrypt là gì:**
BCrypt là một thuật toán băm (hashing) mất chiều được thiết kế đặc biệt cho mật khẩu vào năm 1999. Nó tự động thêm một giá trị ngẫu nhiên (salt) vào mật khẩu trước khi mã hóa, khiến mỗi mật khẩu trở thành một chuỗi khác nhau ngay cả nếu cùng mật khẩu.

**Cách hoạt động BCrypt:**
```
1. Tạo tài khoản:
   Mật khẩu nhập: "abc123"
   Tạo salt ngẫu nhiên: $2a$11$xyz...
   Hash: BCrypt.HashPassword("abc123", salt)
   Lưu vào DB: $2a$11$xyz...dạ dạ dạ
   
2. Đăng nhập:
   Mật khẩu nhập: "abc123"
   Lấy hash từ DB: $2a$11$xyz...dạ dạ dạ
   BCrypt.Verify("abc123", hash từ DB)
   → Nếu trùng khớp = Đúng, ngược lại = Sai
   
Lợi ích:
- Mỗi hash khác nhau vì salt ngẫu nhiên
- Tốc độ tính toán chậm (intentional), brute-force mất hàng giờ
- Tự động xử lý salt, developer không cần lo
```

**Ví dụ trong dự án:**
```csharp
// Đăng ký tài khoản - mã hóa mật khẩu
public static bool RegisterUser(string username, string password)
{
    string passwordHash = BCryptTemp.HashPassword(password);
    // Lưu username và passwordHash vào database
}

// Đăng nhập - kiểm tra mật khẩu
public static bool AuthenticateUser(string username, string password)
{
    string storedHash = GetPasswordHashFromDB(username);
    return BCryptTemp.VerifyPassword(password, storedHash);
}
```

### V. Material Design - Thiết kế giao diện hiện đại

**Material Design là gì:**
Material Design là một hệ thống thiết kế được Google phát triển năm 2014, tập trung vào tính thẩm mỹ, tính dễ sử dụng và sự nhất quán. Nó sử dụng những nguyên tắc như:
- Cấp bậc rõ ràng (gì là quan trọng, gì là phụ)
- Khoảng trắng thoải mái
- Màu sắc nhất quán
- Hiệu ứng animation nhẹ nhàng

**Màu sắc Teal/Emerald Theme:**
Dự án sử dụng bảng màu xanh lá/ngọc lam, mang lại cảm giác mát mẻ, yên tĩnh:

```
=== Màu chính (Teal/Emerald) ===
Teal Primary:    #14B8A6 - Button chính, menu highlight, accent
Teal Dark:       #0D9488 - Hover state, pressed state
Teal Light:      #2DD4BF - Hover nhẹ, selection
Emerald:         #10B981 - Accent thứ hai, active state

=== Màu trạng thái ===
Success Green:   #22C55E - Thành công, thao tác tốt, Success Toast
Error Red:       #EF4444 - Lỗi, xóa, quá hạn, Error Toast
Warning Amber:   #F59E0B - Cảnh báo, thay đổi nguy hiểm, Warning Toast
Info Blue:       #3B82F6 - Thông tin, thông báo, Info Toast
Star Yellow:     #FFCA28 - Đánh dấu quan trọng (sao vàng)

=== Màu nền ===
Background White:  #FFFFFF - Nền form, nền chính
Background Gray:   #F8FAFC - Nền panel, card
Border Light:      #E2E8F0 - Border mỏng, separator
Border Medium:     #CBD5E1 - Border rõ

=== Màu text ===
Text Primary:     #0F172A - Text chính, tiêu đề
Text Secondary:   #475569 - Text phụ, mô tả
Text Muted:       #94A3B8 - Text mờ, hint text
```

**Toast Notification:**
Là hình thức thông báo hiện đại kiểu web, xuất hiện ở góc trên bên phải, tự động biến mất sau vài giây:
- Thay vì MessageBox lỗi (phải click OK), Toast tự động biến mất
- Không làm gián đoạn công việc của người dùng
- Hiệu ứng fade in/out mượt mà, không bị jump

---

## CHƯƠNG III: KHẢO SÁT VÀ PHÂN TÍCH HỆ THỐNG

### I. Khảo sát hiện trạng và yêu cầu

**Mục đích khảo sát:**
- Hiểu nhu cầu thực tế của những người cần quản lý tài liệu
- Phân tích cách thức quản lý tài liệu hiện nay (thủ công, lộn xộn)
- Xác định những tính năng thiết yếu mà ứng dụng cần có
- Tìm hiểu cách các ứng dụng khác giải quyết bài toán này

**Phạm vi khảo sát:**
- Đối tượng: 50+ sinh viên và 10+ người làm việc
- Nhu cầu: Quản lý file tài liệu một cách khoa học, dễ tìm kiếm, có phân loại
- Vấn đề hiện tại: Tài liệu rải rác, khó tìm, không có hệ thống, dễ bị quên lãng

**Kết quả khảo sát:**
- 100% người được hỏi muốn một công cụ quản lý tài liệu
- 80% muốn tìm kiếm nhanh theo từ khóa
- 70% muốn phân loại tài liệu
- 60% muốn có nhắc nhở deadline
- 50% muốn ghi chú cá nhân

**Các tác nhân (Actors) của hệ thống:**

**1. User (Người dùng thường):**
- Đăng ký tài khoản mới với username, password, email
- Đăng nhập vào hệ thống
- Quản lý tài liệu của riêng mình (thêm, sửa, xóa)
- Tìm kiếm và lọc tài liệu theo nhiều tiêu chí
- Tạo bộ sưu tập gom nhóm tài liệu
- Ghi chú cá nhân cho tài liệu (để nhớ điểm quan trọng)
- Đặt deadline cho tài liệu (sắp đến hạn, quá hạn)
- Gắn tags cho tài liệu (nhãn phân loại)
- Xuất dữ liệu ra CSV để dùng ở nơi khác
- Cài đặt tài khoản (đổi thông tin, đổi mật khẩu)
- Xem thống kê tài liệu của mình

**2. Admin (Quản trị viên):**
- Có tất cả quyền của User
- Quản lý danh sách người dùng (thêm, khóa, đổi vai trò)
- Quản lý danh mục của riêng mình (giống User)
- Đặt lại mật khẩu cho người dùng nếu quên

> **Lưu ý:** Chế độ cá nhân hóa - mỗi user (kể cả Admin) chỉ xem và quản lý tài liệu của riêng mình.

### II. Phân tích hệ thống

**Biểu đồ Use Case:**
(Liên hệ với Admin)
```
┌─────────────────────────────────────────────┐
│          Study Document Manager             │
├─────────────────────────────────────────────┤
│                                             │
│  User ───┐                                  │
│          ├─→ Đăng nhập / Đăng ký           │
│  Admin ──┘    Quản lý tài liệu              │
│              Tìm kiếm / Lọc                │
│              Tổ chức (Bộ sưu tập, tags)    │
│              Ghi chú cá nhân                │
│              Xem thống kê                   │
│              Xuất dữ liệu                   │
│              Cài đặt tài khoản              │
│              Đăng xuất                      │
│                                             │
│  Admin thêm: Quản lý người dùng            │
│              Đặt lại mật khẩu              │
│                                             │
└─────────────────────────────────────────────┘
```

**Các chức năng chính:**

**Nhóm chức năng xác thực (5 chức năng):**
- Đăng ký tài khoản (username, mật khẩu, email)
- Đăng nhập (xác thực username/password)
- Đăng xuất
- Đổi mật khẩu
- Cài đặt tài khoản (sửa họ tên, email)

**Nhóm chức năng quản lý tài liệu (8 chức năng):**
- Thêm tài liệu mới (tên, danh mục, loại, file, ghi chú, tác giả)
- Sửa thông tin tài liệu
- Xóa tài liệu
- Mở file tài liệu trực tiếp
- Tự động tính dung lượng file
- Đánh dấu tài liệu quan trọng
- Gắn tags cho tài liệu
- Đặt deadline (ngày hạn chót)

**Nhóm chức năng tìm kiếm/lọc (7 chức năng):**
- Tìm kiếm theo từ khóa (tên tài liệu)
- Lọc theo danh mục
- Lọc theo loại tài liệu
- Lọc theo khoảng ngày
- Lọc theo dung lượng
- Lọc tài liệu quan trọng
- Tìm kiếm nâng cao kết hợp nhiều điều kiện

**Nhóm chức năng tổ chức tài liệu (5 chức năng):**
- Quản lý danh mục (môn học)
- Quản lý loại tài liệu
- Tạo bộ sưu tập
- Thêm/bỏ tài liệu khỏi bộ sưu tập
- Xem tài liệu trong bộ sưu tập

**Nhóm chức năng ghi chú (3 chức năng):**
- Tạo ghi chú cá nhân cho tài liệu
- Đánh dấu trạng thái đọc (Chưa đọc/Đang học/Đã ôn)
- Chỉnh sửa ghi chú

**Nhóm chức năng thống kê (5 chức năng):**
- Xem tổng số tài liệu
- Xem số tài liệu quan trọng
- Xem số tài liệu quá hạn
- Xem tài liệu sắp đến hạn (7 ngày)
- Biểu đồ thống kê số lượng tài liệu

**Nhóm chức năng quản lý (Admin - 6 chức năng):**
- Xem danh sách người dùng
- Thêm người dùng mới
- Khóa/mở khóa tài khoản
- Đổi vai trò người dùng
- Xóa tài khoản
- Đặt lại mật khẩu

**Nhóm chức năng hỗ trợ (4 chức năng):**
- Kiểm tra file bị thiếu (file không còn tồn tại)
- Xuất dữ liệu ra CSV
- Drag & drop file để thêm nhanh
- Context menu trên bảng dữ liệu

**Tổng cộng: 43+ chức năng chính**

### III. Thiết kế cơ sở dữ liệu

**Bảng users (Người dùng):**

| Cột | Kiểu | Ràng buộc | Mô tả |
|-----|------|----------|-------|
| id | INT | PK, Auto | ID tự động tăng |
| username | NVARCHAR(50) | UNIQUE, NOT NULL | Tên đăng nhập duy nhất |
| password_hash | NVARCHAR(255) | NOT NULL | Mật khẩu đã mã hóa BCrypt |
| full_name | NVARCHAR(100) | | Họ tên đầy đủ |
| email | NVARCHAR(100) | | Email |
| role | NVARCHAR(20) | DEFAULT 'User' | Vai trò: User hoặc Admin |
| is_active | BIT | DEFAULT 1 | Trạng thái hoạt động (1/0) |
| created_date | DATETIME | DEFAULT GETDATE() | Ngày tạo tài khoản |
| last_login | DATETIME | | Lần đăng nhập cuối |
| failed_login_attempts | INT | DEFAULT 0 | Số lần đăng nhập sai |
| locked_until | DATETIME | | Thời điểm hết khóa (nếu bị khóa) |

**Bảng tai_lieu (Tài liệu):**

| Cột | Kiểu | Ràng buộc | Mô tả |
|-----|------|----------|-------|
| id | INT | PK, Auto | ID tự động tăng |
| ten | NVARCHAR(200) | NOT NULL | Tên tài liệu |
| mon_hoc | NVARCHAR(100) | | Danh mục/môn học |
| loai | NVARCHAR(100) | | Loại tài liệu (PDF, Word, ...) |
| duong_dan | NVARCHAR(500) | NOT NULL | Đường dẫn file đầy đủ |
| ghi_chu | NVARCHAR(1000) | | Ghi chú của user |
| ngay_them | DATETIME | DEFAULT GETDATE() | Ngày thêm tài liệu |
| kich_thuoc | FLOAT | | Dung lượng file (MB) |
| tac_gia | NVARCHAR(100) | | Tác giả tài liệu |
| quan_trong | BIT | DEFAULT 0 | Đánh dấu quan trọng (1/0) |
| user_id | INT | FK, NOT NULL | Người sở hữu tài liệu |
| tags | NVARCHAR(500) | | Nhãn phân loại (cách dấu ;) |
| deadline | DATETIME | | Hạn chót |

**Bảng collections (Bộ sưu tập):**

| Cột | Kiểu | Ràng buộc | Mô tả |
|-----|------|----------|-------|
| id | INT | PK, Auto | ID tự động tăng |
| user_id | INT | FK, NOT NULL | ID người sở hữu |
| name | NVARCHAR(100) | NOT NULL | Tên bộ sưu tập |
| description | NVARCHAR(500) | | Mô tả |
| created_at | DATETIME | DEFAULT GETDATE() | Ngày tạo |

**Bảng collection_items (Tài liệu trong bộ sưu tập):**

| Cột | Kiểu | Ràng buộc | Mô tả |
|-----|------|----------|-------|
| collection_id | INT | PK, FK | ID bộ sưu tập |
| document_id | INT | PK, FK | ID tài liệu |
| added_at | DATETIME | DEFAULT GETDATE() | Thời điểm thêm |

**Bảng personal_notes (Ghi chú cá nhân):**

| Cột | Kiểu | Ràng buộc | Mô tả |
|-----|------|----------|-------|
| id | INT | PK, Auto | ID tự động tăng |
| user_id | INT | FK, NOT NULL | ID người dùng |
| document_id | INT | FK, NOT NULL | ID tài liệu |
| note_content | NVARCHAR(MAX) | | Nội dung ghi chú |
| status | NVARCHAR(50) | DEFAULT 'Chưa đọc' | Trạng thái đọc |
| updated_at | DATETIME | DEFAULT GETDATE() | Ngày cập nhật |

**Bảng user_sessions (Phiên đăng nhập):**

| Cột | Kiểu | Ràng buộc | Mô tả |
|-----|------|----------|-------|
| id | INT | PK, Auto | ID tự động tăng |
| user_id | INT | FK | ID người dùng |
| session_token | NVARCHAR(255) | UNIQUE | Token phiên |
| ip_address | NVARCHAR(50) | | Địa chỉ IP |
| user_agent | NVARCHAR(500) | | Thông tin trình duyệt/ứng dụng |
| login_date | DATETIME | DEFAULT GETDATE() | Thời điểm đăng nhập |
| last_activity | DATETIME | DEFAULT GETDATE() | Hoạt động cuối |
| is_active | BIT | DEFAULT 1 | Phiên còn hoạt động |
| logout_date | DATETIME | | Thời điểm đăng xuất |

**Bảng activity_logs (Nhật ký hoạt động):**

| Cột | Kiểu | Ràng buộc | Mô tả |
|-----|------|----------|-------|
| id | INT | PK, Auto | ID tự động tăng |
| user_id | INT | FK | ID người dùng |
| action | NVARCHAR(50) | | Hành động (Login, Create, Update, ...) |
| entity_type | NVARCHAR(50) | | Loại đối tượng (Document, User, ...) |
| entity_id | INT | | ID đối tượng |
| description | NVARCHAR(500) | | Mô tả chi tiết |
| ip_address | NVARCHAR(50) | | Địa chỉ IP |
| user_agent | NVARCHAR(500) | | Thông tin client |
| created_date | DATETIME | DEFAULT GETDATE() | Thời điểm ghi log |

**Mối quan hệ (ER Diagram):**
```
users (1) ──────┬──── (N) user_sessions
                │
                ├──── (N) tai_lieu
                │           │
                │           ├──── (N) collection_items ──── (N) collections
                │           │
                │           └──── (N) personal_notes
                │
                └──── (N) activity_logs
```

**Chuẩn hóa dữ liệu:**
- Các bảng được chuẩn hóa đến 3NF (Third Normal Form)
- Không có dư thừa dữ liệu (redundancy)
- Mỗi bảng đại diện cho một thực thể
- Mỗi cột chỉ lưu một loại thông tin
- Tất cả khóa ngoại có constraint ON DELETE CASCADE hoặc NO ACTION

---

## CHƯƠNG IV: THIẾT KẾ HỆ THỐNG

### I. Phân tích hệ thống

**Hoạt động của hệ thống:**

Ứng dụng hoạt động theo luồng sau:

1. **Khởi động:** Người dùng chạy chương trình (Program.cs), form Login hiển thị
2. **Đăng nhập:** Nhập username/password, hệ thống xác thực bằng BCrypt
3. **Giao diện chính:** Sau đăng nhập thành công, mở Dashboard với danh sách tài liệu của user
4. **Quản lý tài liệu:** User có thể thêm, sửa, xóa, mở tài liệu
5. **Tìm kiếm/Lọc:** Sử dụng các bộ lọc để tìm tài liệu cần thiết (từ khóa, danh mục, loại, ...)
6. **Tổ chức:** Gom nhóm tài liệu vào bộ sưu tập, ghi chú, gắn tags, đặt deadline
7. **Thống kê:** Xem biểu đồ thống kê tài liệu của mình
8. **Admin:** Admin có thể quản lý người dùng, danh mục toàn hệ thống
9. **Đăng xuất:** Click nút Logout để kết thúc phiên làm việc, trở về LoginForm

**Phạm vi dự án:**
- Hỗ trợ Windows 7, 8, 10, 11 (không hỗ trợ Linux, Mac lúc này)
- .NET Framework 4.8 và SQL Server 2012+ (hoặc SQL Server Express miễn phí)
- Mô hình cá nhân hóa: mỗi User quản lý tài liệu của riêng mình (không xem được của người khác)
- Hai cấp quyền: User (thường) và Admin (quản trị viên)
- Dữ liệu được lưu tập trung ở SQL Server, phù hợp cho team collaboration

**Đối tượng sử dụng:**
- **User:** Quản lý tài liệu cá nhân, không thấy tài liệu của người khác
- **Admin:** Quản lý người dùng + tất cả quyền của User (quản lý tài liệu của riêng mình)

### II. Thiết kế hệ thống

**Yêu cầu chức năng (Functional Requirements):**
- Hệ thống phải hỗ trợ CRUD (Create, Read, Update, Delete) tài liệu
- Tìm kiếm nhanh theo từ khóa (< 1 giây cho 1000 tài liệu)
- Lọc nâng cao theo nhiều tiêu chí cùng một lúc
- Phân quyền người dùng chặt chẽ (user A không xem được tài liệu của user B)
- Bảo mật mật khẩu bằng BCrypt (không lưu plaintext)
- Hỗ trợ deadline, tags, ghi chú cá nhân
- Biểu đồ thống kê trực quan (cột, tròn, đường, ...)
- Export dữ liệu ra CSV
- Drag & drop để thêm tài liệu nhanh
- Kiểm tra file bị thiếu

**Yêu cầu phi chức năng (Non-Functional Requirements):**
- **Hiệu năng:** Tải dữ liệu nhanh (< 2 giây), không lag khi có 1000+ tài liệu, không crash
- **Bảo mật:** Mật khẩu mã hóa, phòng chống SQL Injection, xác thực người dùng
- **Giao diện:** Thân thiện, dễ sử dụng, màu sắc hợp lý, responsive (fit vào màn hình)
- **Ổn định:** Xử lý lỗi, hiển thị thông báo lỗi rõ ràng, không crash bất ngờ
- **Khả năng mở rộng:** Dễ thêm tính năng mới (kiến trúc 3 tầng)
- **Bảo trì:** Code sạch, có comment, dễ hiểu, dễ sửa lỗi

**Kiến trúc chung:**

```
┌──────────────────────────────────────────────────────┐
│   PRESENTATION LAYER - UI (Windows Forms)           │
│  ├─ LoginForm.cs / RegisterForm.cs                  │
│  ├─ Dashboard.cs (Form chính - danh sách)           │
│  ├─ AddEditForm.cs (Thêm/sửa tài liệu)              │
│  ├─ CategoryManagementForm.cs (Quản lý danh mục)    │
│  ├─ CollectionManagementForm.cs (Bộ sưu tập)        │
│  ├─ FileIntegrityCheckForm.cs (Kiểm tra file)       │
│  ├─ UserManagementForm.cs (Admin - Quản lý user)    │
│  ├─ Report.cs (Thống kê biểu đồ)                    │
│  ├─ PersonalNoteForm.cs (Ghi chú cá nhân)           │
│  ├─ AccountSettingsForm.cs (Cài đặt tài khoản)      │
│  └─ UI Components: ToastNotification, IconHelper    │
└──────────────────────────────────────────────────────┘
              ↓ (gọi phương thức)
┌──────────────────────────────────────────────────────┐
│   BUSINESS LAYER - Logic (Classes)                  │
│  ├─ DatabaseHelper.cs (50+ methods)                 │
│  ├─ DatabaseHelper_UserAuth.cs (partial - auth)     │
│  ├─ UserSession.cs (static - lưu info user)         │
│  ├─ BCryptTemp.cs (bảo mật mật khẩu)                │
│  ├─ IconHelper.cs (tạo icon động theo loại file)    │
│  ├─ AppTheme.cs (định nghĩa màu sắc theme)          │
│  └─ DashboardStats.cs (model thống kê)              │
└──────────────────────────────────────────────────────┘
              ↓ (SQL queries)
┌──────────────────────────────────────────────────────┐
│   DATA LAYER - Database (SQL Server)                │
│  └─ quan_ly_tai_lieu database (7 bảng)              │
│     ├─ users                                        │
│     ├─ tai_lieu                                     │
│     ├─ collections                                  │
│     ├─ collection_items                             │
│     ├─ personal_notes                               │
│     ├─ user_sessions                                │
│     └─ activity_logs                                │
└──────────────────────────────────────────────────────┘
```

### III. Mô tả các quy trình chính

**Quy trình Đăng nhập:**
```
1. User chạy chương trình
2. LoginForm hiển thị, User nhập username và password
3. Nhấn nút "Đăng nhập"
4. Hệ thống kiểm tra username có tồn tại trong DB không
5. Nếu không tồn tại → Hiển thị lỗi, tăng failed_login_attempts
6. Nếu tồn tại, lấy password_hash từ database
7. Dùng BCrypt.Verify(password_nhập, password_hash_db) kiểm tra
8. Nếu sai → Hiển thị lỗi, tăng failed_login_attempts
9. Nếu sai quá 5 lần → Khóa tài khoản 30 phút
10. Nếu đúng → Lưu thông tin vào UserSession, cập nhật last_login
11. Ghi log: Login action
12. Đóng LoginForm, mở Dashboard
```

**Quy trình Thêm tài liệu:**
```
1. User nhấp nút "Thêm"
2. Form AddEditForm mở lên (mode: New)
3. User nhập tên, chọn file, chọn danh mục, loại, ghi chú
4. Khi nhấp "Lưu", hệ thống kiểm tra dữ liệu:
   - Tên không được để trống
   - File phải tồn tại
   - File size được tính tự động
5. Gọi DatabaseHelper.InsertDocument() để lưu vào database
6. Tự động gán user_id = UserSession.UserId
7. Ghi log: Create Document action
8. Nếu thành công → Hiển thị Toast "Lưu thành công"
9. Nếu lỗi → Hiển thị Toast "Lỗi lưu tài liệu"
10. Dashboard reload danh sách, hiện tài liệu mới
```

**Quy trình Tìm kiếm nâng cao:**
```
1. User nhấp nút "Filter nâng cao"
2. Form hiện các TextBox và ComboBox:
   - Từ khóa tìm kiếm
   - Danh mục
   - Loại tài liệu
   - Khoảng ngày (từ - đến)
   - Khoảng dung lượng (từ - đến MB)
   - Checkbox: Chỉ tài liệu quan trọng
3. User nhập/chọn các điều kiện
4. Nhấp nút "Tìm kiếm" hoặc Enter
5. Hệ thống gọi DatabaseHelper.SearchDocumentsAdvanced()
6. Hàm này build câu SQL với WHERE clauses động:
   WHERE user_id = @userId
   AND (ten LIKE @keyword OR ghi_chu LIKE @keyword)
   AND mon_hoc = @category
   AND loai = @type
   AND ngay_them BETWEEN @fromDate AND @toDate
   AND kich_thuoc BETWEEN @minSize AND @maxSize
   AND quan_trong = 1 (nếu checkbox chọn)
7. Truy vấn database
8. Hiển thị kết quả trong DataGridView
9. Status bar hiển thị "Tìm thấy X tài liệu"
```

**Quy trình Kiểm tra file bị thiếu:**
```
1. User vào menu "Công cụ > Kiểm tra file bị thiếu"
2. Form FileIntegrityCheckForm mở lên
3. Nhấp nút "Quét"
4. Hệ thống lấy tất cả tài liệu từ database:
   SELECT id, ten, duong_dan FROM tai_lieu WHERE user_id = @userId
5. Với mỗi tài liệu, kiểm tra File.Exists(duong_dan)
6. Nếu file không tồn tại, thêm vào missingFilesData
7. Hiển thị danh sách file thiếu trong DataGridView:
   - ID, Tên tài liệu, Đường dẫn cũ, Hành động
8. User có thể:
   - Chọn file mới → Cập nhật lại duong_dan trong DB
   - Xóa đường dẫn (giữ metadata) → SET duong_dan = ''
   - Xóa tài liệu → DELETE khỏi DB
9. Hoặc nhấp "Xóa tất cả" để xóa hàng loạt
```

---

## CHƯƠNG V: THIẾT KẾ GIAO DIỆN VÀ TRIỂN KHAI

### I. Thiết kế giao diện chính

**Form Đăng nhập (LoginForm):**
- 2 TextBox: username, password
- Checkbox: "Nhớ tôi" (lưu username vào Settings)
- 2 Button: "Đăng nhập", "Đăng ký"
- Label: Hiển thị lỗi nếu đăng nhập thất bại
- Icon logo công ty (nếu có)

**Form chính (Dashboard):**
- **Menu bar** ở trên:
  - File: Tệp tin, Xuất dữ liệu, Thoát
  - Công cụ: Thống kê, Quản lý danh mục, Kiểm tra file bị thiếu
  - Theo dõi: Sắp đến hạn (7 ngày), Quá hạn, Quản lý bộ sưu tập
  - Tài khoản: Cài đặt, Đăng xuất
  - Quản lý: Quản lý người dùng (chỉ Admin thấy)

- **Toolbar** với icon nút:
  - Thêm (Ctrl+N), Sửa (Ctrl+U), Xóa (Delete), Mở file (Ctrl+O)
  - Refresh (F5), Xuất (Ctrl+E), Thống kê (Ctrl+S)

- **Panel tìm kiếm:**
  - TextBox: Tìm kiếm từ khóa (search as you type)
  - ComboBox: Chọn danh mục (Load danh sách từ DB)
  - ComboBox: Chọn loại tài liệu
  - Button: "Tìm kiếm", "Làm mới"
  - Button: "Filter nâng cao" (mở form với nhiều tiêu chí)

- **DataGridView** hiển thị danh sách tài liệu:
  - Cột: Icon (30px), Tên, Danh mục, Loại, Dung lượng, Ngày thêm, Quan trọng (checkbox)
  - Hàng có height 32px
  - Alternating rows (xen kẽ màu #F5F5F5 và trắng)
  - Selection highlight màu Teal
  - Header màu #34495E
  - Double-click để mở file

- **Context menu** (chuột phải):
  - Mở file
  - Sửa / Xóa
  - Copy đường dẫn file
  - Mở thư mục chứa file
  - Đánh dấu/Bỏ đánh dấu quan trọng
  - Ghi chú cá nhân
  - Thêm vào bộ sưu tập

- **Status bar** ở dưới:
  - "Tổng: X tài liệu | Quan trọng: Y | Quá hạn: Z"

**Form Thêm/Sửa tài liệu (AddEditForm):**
- TextBox: Tên tài liệu (bắt buộc, max 200 ký tự)
- ComboBox: Danh mục (load từ DB)
- ComboBox: Loại tài liệu (load từ DB, hoặc nhập tự do)
- TextBox + Button "Chọn file...": Đường dẫn file
- TextBox: Dung lượng file (tự động tính, readonly)
- TextBox: Tác giả (optional)
- TextBox (multiline): Ghi chú (optional, max 1000 ký tự)
- TextBox: Tags (optional, nhãn phân cách bằng dấu ;)
- Checkbox: Đánh dấu quan trọng (★)
- DateTimePicker: Deadline (với checkbox "Bật deadline")
- Button: "Lưu", "Hủy"
- Hiển thị size real-time khi chọn file

**Form Thống kê (Report):**
- 6 Stat Cards hiển thị:
  - Tổng số tài liệu (màu Teal)
  - Tài liệu quan trọng (màu Star Yellow)
  - Tài liệu quá hạn (màu Error Red)
  - Tài liệu sắp đến hạn 7 ngày (màu Warning Amber)
  - Tài liệu chưa có file (màu Gray)
  - Tổng bộ sưu tập (màu Emerald)

- Các biểu đồ:
  - Biểu đồ 7 ngày: Timeline tài liệu tạo mới trong 7 ngày gần nhất (cột)
  - Biểu đồ 12 tháng: Thống kê tài liệu theo 12 tháng gần nhất (cột)
  - Biểu đồ danh mục: Số lượng tài liệu theo danh mục (tròn hoặc cột ngang)

- ComboBox chọn kiểu biểu đồ: Cột dọc, Cột ngang, Tròn, Đường, Vùng

**Form Cài đặt tài khoản (AccountSettingsForm):**
- Tab 1 - Thông tin cá nhân:
  - TextBox: Họ tên (có thể sửa)
  - TextBox: Email (có thể sửa)
  - TextBox: Username (readonly, không sửa)
  - TextBox: Vai trò (readonly, chỉ Admin có thể sửa)
  - TextBox: Thời gian đăng nhập (readonly)
  - Button: "Lưu thay đổi"

- Tab 2 - Đổi mật khẩu:
  - TextBox: Mật khẩu hiện tại (bắt buộc, type = password)
  - TextBox: Mật khẩu mới (bắt buộc, >= 6 ký tự, type = password)
  - TextBox: Nhập lại mật khẩu mới (type = password)
  - Button: Toggle show/hide password (click bật/tắt, không giữ)
  - Button: "Đổi mật khẩu"
  - Label hiển thị sức mạnh mật khẩu

**Form Quản lý danh mục (CategoryManagementForm):**
- Tab 1 - Danh mục (Môn học):
  - ListBox: Hiển thị danh sách danh mục hiện có
  - TextBox: Nhập tên danh mục
  - Button: Thêm, Sửa, Xóa
  - Button: "Lưu", "Hủy"

- Tab 2 - Loại tài liệu:
  - Tương tự tab 1 nhưng cho loại tài liệu (PDF, Word, Excel, ...)

**Form Quản lý người dùng (UserManagementForm - Admin only):**
- DataGridView hiển thị danh sách:
  - Cột: ID, Username, Họ tên, Email, Vai trò, Hoạt động (Active/Inactive), Lần đăng nhập cuối

- Toolbar:
  - Button: Thêm người dùng, Sửa, Xóa, Khóa/Mở khóa tài khoản
  - Button: Đặt lại mật khẩu
  - Search box tìm người dùng

- Form thêm/sửa người dùng:
  - TextBox: Username (required, >= 3 ký tự, unique)
  - TextBox: Họ tên
  - TextBox: Email
  - ComboBox: Vai trò (User/Admin)
  - Checkbox: Hoạt động (Active/Inactive)
  - Button: "Lưu", "Hủy"

**Toast Notification:**
- Xuất hiện ở góc trên bên phải màn hình
- 4 loại:
  - Success (xanh lá #22C55E) - Thao tác thành công
  - Error (đỏ #EF4444) - Lỗi hoặc thất bại
  - Warning (cam #F59E0B) - Cảnh báo
  - Info (xanh dương #3B82F6) - Thông tin
- Tự động đóng sau 3-5 giây
- Có nút X để đóng nhanh
- Hiệu ứng fade in/out mượt mà
- Có icon thích hợp cho từng loại

### II. Các thành phần nội bộ (Class và Method chính)

**DatabaseHelper class (50+ methods):**
- **Phương thức cơ bản:**
  - ExecuteQuery(query, params) - Thực thi SELECT
  - ExecuteNonQuery(query, params) - Thực thi INSERT/UPDATE/DELETE
  - ExecuteScalar(query, params) - Lấy một giá trị duy nhất
  - TestConnection() - Kiểm tra kết nối database

- **Phương thức tài liệu (20 methods):**
  - GetDocumentsForCurrentUser() - Lấy tất cả tài liệu của user hiện tại
  - InsertDocument(name, category, type, path, ...) - Thêm tài liệu mới
  - UpdateDocument(id, name, category, ...) - Cập nhật tài liệu
  - DeleteDocument(id) - Xóa tài liệu
  - GetDocumentById(id) - Lấy chi tiết tài liệu
  - SearchDocuments(keyword) - Tìm kiếm theo từ khóa
  - FilterDocuments(category, type) - Lọc theo danh mục/loại
  - SearchDocumentsAdvanced(keyword, category, type, fromDate, toDate, ...) - Tìm kiếm nâng cao
  - GetUpcomingDeadlines(days) - Lấy tài liệu sắp đến hạn
  - GetOverdueDocuments() - Lấy tài liệu quá hạn
  - MarkImportant(id) - Đánh dấu quan trọng
  - GetMissingFiles() - Lấy tài liệu có file thiếu
  - UpdateFilePath(id, newPath) - Cập nhật đường dẫn file

- **Phương thức danh mục (6 methods):**
  - GetDistinctSubjects() - Lấy danh sách danh mục duy nhất
  - GetDistinctTypes() - Lấy danh sách loại tài liệu duy nhất
  - InsertSubject(name) - Thêm danh mục
  - InsertType(name) - Thêm loại
  - UpdateSubjectName(oldName, newName) - Cập nhật tên danh mục
  - UpdateTypeName(oldName, newName) - Cập nhật tên loại

- **Phương thức xác thực (10 methods):**
  - AuthenticateUser(username, password) - Xác thực đăng nhập
  - RegisterUser(username, password, fullName, email) - Đăng ký tài khoản
  - CheckUsernameExists(username) - Kiểm tra username đã tồn tại
  - CheckEmailExists(email) - Kiểm tra email đã tồn tại
  - UpdateLastLogin(userId) - Cập nhật lần đăng nhập cuối
  - ChangePassword(userId, oldPassword, newPassword) - Đổi mật khẩu của user
  - ChangePasswordSelf(userId, oldPassword, newPassword) - User đổi mật khẩu của mình
  - AdminResetPassword(userId, newPassword) - Admin đặt lại mật khẩu
  - IncreaseFailedLoginAttempts(username) - Tăng số lần sai
  - ResetFailedLoginAttempts(username) - Reset số lần sai sau đăng nhập thành công

- **Phương thức bộ sưu tập (8 methods):**
  - GetCollections(userId) - Lấy danh sách bộ sưu tập của user
  - CreateCollection(userId, name, description) - Tạo bộ sưu tập mới
  - DeleteCollection(collectionId) - Xóa bộ sưu tập
  - GetDocumentsInCollection(collectionId) - Lấy tài liệu trong bộ sưu tập
  - AddDocumentToCollection(collectionId, documentId) - Thêm tài liệu vào bộ sưu tập
  - RemoveDocumentFromCollection(collectionId, documentId) - Xóa tài liệu khỏi bộ sưu tập
  - GetDistinctTags() - Lấy danh sách tags duy nhất để autocomplete
  - UpdateCollectionName(collectionId, newName) - Cập nhật tên bộ sưu tập

- **Phương thức thống kê (8 methods):**
  - GetDashboardStatistics() - Lấy thống kê dashboard (trả về DashboardStats object)
  - GetDocumentsByDay(days) - Thống kê tài liệu theo ngày (7 ngày gần nhất)
  - GetDocumentsByMonth(months) - Thống kê tài liệu theo tháng (12 tháng gần nhất)
  - GetStatisticsBySubject() - Thống kê theo danh mục
  - GetStatisticsByType() - Thống kê theo loại
  - GetTotalDocumentCount() - Tổng số tài liệu
  - GetImportantDocumentCount() - Tổng tài liệu quan trọng
  - GetNearDeadlineCount() - Tổng tài liệu sắp đến hạn

- **Phương thức quản lý (Admin - 8 methods):**
  - GetAllUsers() - Lấy danh sách tất cả người dùng
  - GetUserById(userId) - Lấy thông tin user
  - DeleteUser(userId) - Xóa tài khoản người dùng
  - ToggleUserActive(userId) - Bật/tắt trạng thái hoạt động
  - UpdateUserRole(userId, newRole) - Đổi vai trò người dùng
  - UpdateUserProfile(userId, fullName, email) - Cập nhật thông tin user
  - LockUserAccount(userId, minutesToLock) - Khóa tài khoản tạm thời
  - UnlockUserAccount(userId) - Mở khóa tài khoản

**UserSession class (static):**
- **Thuộc tính (Properties):**
  - UserId: ID người dùng hiện tại
  - Username: Tên đăng nhập
  - FullName: Họ tên
  - Email: Email
  - Role: Vai trò (User/Admin)
  - IsLoggedIn: Boolean kiểm tra đã đăng nhập
  - IsAdmin: Boolean kiểm tra là Admin
  - IsUser: Boolean kiểm tra là User
  - LoginTime: Thời điểm đăng nhập
  - CanManageCategories: Boolean (true cho cả User lẫn Admin)

- **Phương thức:**
  - CanEditDocument(documentUserId) - Kiểm tra user này có quyền sửa document không (phải là chủ sở hữu, kể cả Admin cũng chỉ sửa được của mình)
  - Logout() - Xóa thông tin user (đặt các properties về rỗng/0)
  
- **Cách sử dụng:** Gán trực tiếp các properties khi đăng nhập thành công:
  ```csharp
  UserSession.UserId = userId;
  UserSession.Username = username;
  UserSession.FullName = fullName;
  // ...
  ```

**IconHelper class:**
- **Phương thức tạo icon:**
  - GetDocumentIcon(fileType, size) - Tạo icon theo loại file
    - PDF → Icon đỏ
    - Word (.doc, .docx) → Icon xanh dương
    - PowerPoint (.ppt, .pptx) → Icon cam
    - Excel (.xls, .xlsx) → Icon xanh lá
    - Default → Icon xám
  - CreateStarIcon(size, filled) - Tạo icon sao (filled=true là vàng, false là xam)
  - CreateEyeIcon(size, isOpen) - Icon con mắt cho show/hide password
  - CreateDeleteIcon(size, color) - Icon thùng rác (đỏ)
  - CreateAddIcon(size, color) - Icon dấu cộng
  - CreateEditIcon(size, color) - Icon bút chì

**ToastNotification class:**
- **Phương thức static:**
  - Success(message, duration) - Thông báo thành công (xanh lá)
  - Error(message, duration) - Thông báo lỗi (đỏ)
  - Warning(message, duration) - Thông báo cảnh báo (cam)
  - Info(message, duration) - Thông báo thông tin (xanh dương)
  - Show(message, type, duration) - Hiển thị Toast chung
  - CloseAll() - Đóng tất cả Toast đang hiển thị

### III. Luồng dữ liệu chính

**Luồng Đăng nhập:**
```
Program.Main()
  ↓
ShowDialog(LoginForm)
  ↓
btnLogin_Click()
  ↓
DatabaseHelper.AuthenticateUser(username, password)
  ├→ SELECT password_hash FROM users WHERE username = @username
  ├→ BCryptTemp.VerifyPassword(password, storedHash)
  ├→ Nếu sai: IncreaseFailedLoginAttempts()
  └→ Nếu đúng: UpdateLastLogin(), ghi log
  ↓
Gán UserSession properties (UserId, Username, FullName, Email, Role)
  ↓
Đóng LoginForm
  ↓
Mở Dashboard

```

**Luồng Thêm tài liệu:**
```
Dashboard.btnAdd_Click()
  ↓
Mở AddEditForm (mode: New)
  ↓
User nhập dữ liệu
  ↓
btnSave_Click()
  ├→ Validate dữ liệu
  │  ├─ Tên không trống
  │  └─ File tồn tại
  ↓
DatabaseHelper.InsertDocument(
  name, category, type, filePath,
  note, fileSize, author, isImportant,
  tags, deadline, UserSession.UserId
)
  ├→ INSERT INTO tai_lieu (ten, mon_hoc, ...)
  └→ Ghi log: Create Document
  ↓
Toast Success("Lưu tài liệu thành công")
  ↓
Dashboard.LoadData()
  ↓
Hiển thị tài liệu mới trong DataGridView
```

### IV. Các tính năng nổi bật

**1. Context Menu:**
- Chuột phải trên dòng trong bảng để xem menu nhanh
- Các tùy chọn: Mở file, Sửa/Xóa, Copy đường dẫn, Mở thư mục, Đánh dấu quan trọng

**2. Drag & Drop:**
- Kéo file từ Windows Explorer, thả vào DataGridView
- Tự động mở AddEditForm với thông tin file đã điền

**3. Toast Notification:**
- Thông báo hiện đại, tự động biến mất
- 4 loại: Success, Error, Warning, Info

**4. Phím tắt:**
- Ctrl+N: Thêm tài liệu
- Ctrl+O: Mở tài liệu
- Ctrl+U: Sửa tài liệu
- Delete: Xóa tài liệu
- Ctrl+E: Xuất dữ liệu
- Ctrl+S: Thống kê
- F5: Refresh

**5. Biểu đồ thống kê:**
- Hiển thị trực quan dữ liệu bằng 5 kiểu biểu đồ
- Tính toán real-time từ database

**6. Export CSV:**
- Xuất danh sách tài liệu ra file CSV
- Mở trực tiếp trong Excel

---

## CHƯƠNG VI: HƯỚNG DẪN CÀI ĐẶT VÀ SỬ DỤNG

### I. Hướng dẫn cài đặt

**Yêu cầu hệ thống:**
- Windows 7, 8, 10, 11
- .NET Framework 4.8 trở lên
- SQL Server 2012+ hoặc SQL Server Express 2019/2022 (miễn phí)
- RAM: 2GB trở lên (khuyến nghị 4GB)
- Dung lượng ổ cứng: 200MB trống

**Bước 1: Cài đặt SQL Server Express (nếu chưa có)**
1. Tải SQL Server Express 2022 từ microsoft.com (miễn phí)
2. Chạy installer
3. Chọn "Basic" installation
4. Đặt tên instance: SQLEXPRESS (mặc định)
5. Chọn "Mixed Authentication Mode"
6. Hoặc dùng "Windows Authentication" (nếu là máy cá nhân)

**Bước 2: Cài đặt SQL Server Management Studio (SSMS)**
1. Tải SSMS từ microsoft.com (miễn phí)
2. Chạy installer, follow instructions
3. Dùng để quản lý database

**Bước 3: Tạo Database**
1. Mở SQL Server Management Studio
2. Connect đến server (Server name: . hoặc localhost\SQLEXPRESS)
3. Chạy file database.sql trong project:
   - Chuột phải vào "Databases" → "New Query"
   - Copy nội dung database.sql và paste vào
   - Nhấn F5 để chạy
4. Database "quan_ly_tai_lieu" sẽ được tạo

**Bước 4: Sửa Connection String**
1. Mở file App.config trong Visual Studio
2. Tìm dòng connectionStrings
3. Sửa thành:
   ```
   <add name="DefaultConnection" 
        connectionString="Server=.\SQLEXPRESS;Database=quan_ly_tai_lieu;Integrated Security=True;" 
        providerName="System.Data.SqlClient" />
   ```
   Hoặc nếu dùng password:
   ```
   <add name="DefaultConnection" 
        connectionString="Server=localhost\SQLEXPRESS;Database=quan_ly_tai_lieu;User Id=sa;Password=YourPassword;" 
        providerName="System.Data.SqlClient" />
   ```

**Bước 5: Chạy chương trình**
1. Mở project trong Visual Studio 2019+
2. Nhấn F5 hoặc Ctrl+F5 để run
3. LoginForm sẽ hiển thị

**Bước 6: Tạo tài khoản Admin đầu tiên**
1. Nhấp nút "Đăng ký"
2. Nhập username: admin
3. Nhập password: admin123
4. Nhập email và họ tên
5. Nhấn "Đăng ký"
6. (Tùy chọn) Update role thành 'Admin' trong database:
   ```sql
   UPDATE users SET role = 'Admin' WHERE username = 'admin'
   ```

### II. Hướng dẫn sử dụng

**Đăng nhập:**
1. Nhập username (ví dụ: admin)
2. Nhập password (ví dụ: admin123)
3. Checkbox "Nhớ tôi" để lưu username
4. Nhấn "Đăng nhập"

**Thêm tài liệu:**
1. Dashboard mở lên, nhấn nút "Thêm" (Ctrl+N)
2. Nhập tên tài liệu
3. Chọn danh mục (môn học) từ ComboBox
4. Chọn loại tài liệu (PDF, Word, ...)
5. Nhấn "Chọn file..." để chọn file từ máy
6. Nhập tác giả (tùy chọn)
7. Nhập ghi chú (tùy chọn)
8. Gắn tags phân cách bằng ; (ví dụ: Toán học; Đại số; Khó)
9. Checkbox "Quan trọng" nếu muốn đánh dấu
10. Chọn deadline nếu có hạn chót
11. Nhấn "Lưu"

**Tìm kiếm tài liệu:**
1. Nhập từ khóa vào TextBox tìm kiếm
2. Hoặc chọn danh mục từ ComboBox
3. Hoặc chọn loại từ ComboBox
4. Danh sách tự động cập nhật
5. Hoặc nhấn "Filter nâng cao" để tìm kiếm phức tạp

**Mở tài liệu:**
1. Double-click vào dòng tài liệu
2. Hoặc chọn dòng → Nhấn Ctrl+O
3. Hoặc chuột phải → "Mở file"
4. File sẽ mở trong ứng dụng mặc định

**Mở thư mục chứa file:**
1. Chuột phải vào tài liệu
2. Chọn "Mở thư mục chứa file"
3. Windows Explorer mở show cái file đó

**Copy đường dẫn file:**
1. Chuột phải vào tài liệu
2. Chọn "Copy đường dẫn file"
3. Dán vào nơi cần (Ctrl+V)

**Sửa tài liệu:**
1. Chọn tài liệu → Nhấn Ctrl+U
2. Hoặc chuột phải → "Sửa"
3. Sửa thông tin cần thiết
4. Nhấn "Lưu"

**Xóa tài liệu:**
1. Chọn tài liệu → Nhấn Delete
2. Hoặc chuột phải → "Xóa"
3. Xác nhận xóa
4. Tài liệu sẽ bị xóa khỏi database

**Ghi chú cá nhân:**
1. Chuột phải vào tài liệu
2. Chọn "Ghi chú cá nhân"
3. Nhập nội dung ghi chú
4. Chọn trạng thái đọc (Chưa đọc / Đang học / Đã ôn)
5. Nhấn "Lưu"

**Thêm vào bộ sưu tập:**
1. Chuột phải vào tài liệu
2. Chọn "Thêm vào bộ sưu tập"
3. Chọn bộ sưu tập từ list (hoặc tạo mới)
4. Nhấn "Thêm"

**Xem thống kê:**
1. Menu "Công cụ" → "Thống kê" (Ctrl+S)
2. Xem 6 stat cards thống kê nhanh
3. Xem biểu đồ theo ngày, tháng
4. Chọn kiểu biểu đồ: Cột, Tròn, Đường, ...

**Xuất dữ liệu:**
1. Menu "Tệp tin" → "Xuất dữ liệu" (Ctrl+E)
2. Chọn vị trí lưu file CSV
3. File mở tự động trong Excel

**Kiểm tra file bị thiếu:**
1. Menu "Công cụ" → "Kiểm tra file bị thiếu"
2. Nhấn nút "Quét"
3. Xem danh sách file thiếu
4. Chọn: Chọn file mới / Xóa đường dẫn / Xóa tài liệu

**Quản lý danh mục:**
1. Menu "Công cụ" → "Quản lý Danh mục và Loại" (Ctrl+M)
2. Tab 1: Danh mục
3. Thêm / Sửa / Xóa danh mục
4. Tab 2: Loại tài liệu
5. Thêm / Sửa / Xóa loại

**Cài đặt tài khoản:**
1. Menu "Tài khoản" → "Cài đặt tài khoản"
2. Tab 1 - Thông tin cá nhân: Sửa họ tên, email
3. Tab 2 - Đổi mật khẩu: Nhập mật khẩu cũ, mật khẩu mới
4. Nhấn "Đổi mật khẩu"

**Đăng xuất:**
1. Menu "Tài khoản" → "Đăng xuất" (Ctrl+L)
2. Hoặc nhấn nút "Logout" ở góc phải menu bar
3. Trở về LoginForm

### III. Xử lý lỗi thường gặp

**Lỗi 1: "Cannot connect to database"**
- Nguyên nhân: SQL Server chưa cài đặt hoặc không chạy
- Giải pháp:
  1. Cài đặt SQL Server Express
  2. Mở SQL Server Configuration Manager
  3. Chắc chắn SQL Server service đang chạy
  4. Sửa connection string trong App.config

**Lỗi 2: "Login failed for user"**
- Nguyên nhân: Username/password sai, tài khoản bị khóa
- Giải pháp:
  1. Kiểm tra username, password đúng không
  2. Nếu quên password, admin đặt lại
  3. Kiểm tra tài khoản có bị khóa không (locked_until > GETDATE())

**Lỗi 3: "File not found"**
- Nguyên nhân: File tài liệu bị di chuyển hoặc xóa
- Giải pháp:
  1. Dùng "Kiểm tra file bị thiếu" để phát hiện
  2. Chọn file mới hoặc xóa tài liệu đó

**Lỗi 4: "File size too large"**
- Nguyên nhân: File quá lớn (> 2GB)
- Giải pháp: SQL Server có thể lưu max 2GB per column, nhưng thường không cần lưu file to

**Lỗi 5: Chương trình crash khi mở file**
- Nguyên nhân: Ứng dụng mặc định không tồn tại hoặc file corrupt
- Giải pháp:
  1. Chuột phải file → "Mở bằng" → chọn ứng dụng khác
  2. Hoặc mở thư mục chứa file, mở trực tiếp

**Lỗi 6: Toast notification không hiển thị**
- Nguyên nhân: Form chính che phủ, hoặc lỗi rendering
- Giải pháp: Cập nhật Windows, cài đặt lại .NET Framework

---

## CHƯƠNG VII: KIỂM THỬ VÀ XỬ LÝ LỖI

### I. Kế hoạch kiểm thử

**Kiểm thử Unit Testing (từng function riêng):**

**Test DatabaseHelper.AuthenticateUser():**
```csharp
[TestMethod]
public void AuthenticateUser_ValidCredentials_ReturnsTrue()
{
    // Arrange
    string username = "testuser";
    string password = "testpass123";
    // RegisterUser trước
    DatabaseHelper.RegisterUser(username, password, "Test", "test@email.com");
    
    // Act
    bool result = DatabaseHelper.AuthenticateUser(username, password);
    
    // Assert
    Assert.IsTrue(result, "Xác thực người dùng đúng phải trả về true");
}

[TestMethod]
public void AuthenticateUser_InvalidPassword_ReturnsFalse()
{
    // Arrange
    string username = "testuser";
    // Arrange
    bool result = DatabaseHelper.AuthenticateUser(username, "wrongpassword");
    
    // Assert
    Assert.IsFalse(result, "Xác thực sai mật khẩu phải trả về false");
}
```

**Kiểm thử Integration Testing (test chung):**

**Test Luồng Đăng ký → Đăng nhập → Thêm tài liệu:**
```csharp
[TestMethod]
public void CompleteWorkflow_RegisterLoginAddDocument_Success()
{
    // 1. Đăng ký
    string username = "newuser" + DateTime.Now.Ticks;
    bool registerSuccess = DatabaseHelper.RegisterUser(
        username, "pass123", "New User", "new@email.com");
    Assert.IsTrue(registerSuccess);
    
    // 2. Đăng nhập
    bool loginSuccess = DatabaseHelper.AuthenticateUser(username, "pass123");
    Assert.IsTrue(loginSuccess);
    
    // 3. Thêm tài liệu (sau khi đăng nhập thành công, UserSession đã được gán)
    bool insertSuccess = DatabaseHelper.InsertDocument(
        "Test Doc", "Math", "PDF", "C:\\test.pdf", "Note", 1.5f, "Author", false, "", null, UserSession.UserId);
    Assert.IsTrue(insertSuccess);
    
    // 4. Verify tài liệu trong DB
    var docs = DatabaseHelper.GetDocumentsForCurrentUser();
    Assert.IsTrue(docs.Any(d => d["ten"].ToString() == "Test Doc"));
}
```

**Kiểm thử GUI Testing (giao diện):**

**Test LoginForm:**
- Nhập username sai → Hiển thị lỗi ✓
- Nhập password sai → Hiển thị lỗi ✓
- Đăng nhập thành công → Dashboard mở ✓
- Checkbox "Nhớ tôi" → Username được lưu ✓

**Test Dashboard:**
- Danh sách tài liệu load đúng ✓
- Tìm kiếm từ khóa → Kết quả đúng ✓
- Lọc theo danh mục → Kết quả đúng ✓
- Context menu hiển thị đúng ✓
- Double-click mở file ✓

**Test AddEditForm:**
- Validate tên không trống ✓
- Validate file tồn tại ✓
- Auto-calculate file size ✓
- Lưu tài liệu → Hiện Toast success ✓

### II. Xử lý lỗi (Error Handling)

**Try-Catch Pattern:**
```csharp
public static bool InsertDocument(string name, ...)
{
    try
    {
        // Validate
        if (string.IsNullOrEmpty(name))
        {
            MessageBox.Show("Tên tài liệu không được để trống");
            return false;
        }
        
        // Execute query
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO tai_lieu (ten, mon_hoc, ..., user_id) " +
                "VALUES (@ten, @monHoc, ..., @userId)", conn);
            cmd.Parameters.AddWithValue("@ten", name);
            // ... more parameters
            cmd.Parameters.AddWithValue("@userId", userId);
            
            return cmd.ExecuteNonQuery() > 0;
        }
    }
    catch (SqlException ex)
    {
        // Database error
        MessageBox.Show("Lỗi database: " + ex.Message);
        // Log to file
        LogError(ex);
        return false;
    }
    catch (Exception ex)
    {
        // Unexpected error
        MessageBox.Show("Lỗi không mong muốn: " + ex.Message);
        LogError(ex);
        return false;
    }
}
```

**Input Validation:**
```csharp
private bool ValidateDocumentInput(string name, string filePath)
{
    // Kiểm tra tên
    if (string.IsNullOrWhiteSpace(name) || name.Length > 200)
    {
        ToastNotification.Error("Tên phải từ 1-200 ký tự");
        return false;
    }
    
    // Kiểm tra file
    if (!File.Exists(filePath))
    {
        ToastNotification.Error("File không tồn tại");
        return false;
    }
    
    // Kiểm tra file size (max 2GB)
    FileInfo fi = new FileInfo(filePath);
    if (fi.Length > 2 * 1024 * 1024 * 1024)
    {
        ToastNotification.Warning("File quá lớn (max 2GB)");
        return false;
    }
    
    return true;
}
```

**Permission Checking:**
```csharp
public static bool CanUserEditDocument(int documentId, int userId, string role)
{
    // Admin có thể edit tất cả
    if (role == "Admin") return true;
    
    // User thường chỉ edit tài liệu của mình
    int ownerId = GetDocumentOwnerId(documentId);
    return ownerId == userId;
}
```

---

## KẾT LUẬN

### Kết quả đạt được

**Về sản phẩm:**
Em đã xây dựng thành công ứng dụng Study Document Manager hoàn chỉnh với các tính năng chính:
- Quản lý tài liệu đầy đủ (thêm, sửa, xóa, mở file) với 50+ phương thức
- Đăng nhập/đăng xuất an toàn bằng BCrypt (không sợ bị phơi bày mật khẩu)
- Tìm kiếm nâng cao với 7 tiêu chí khác nhau (keyword, danh mục, loại, ngày, dung lượng, quan trọng, deadline)
- Ghi chú cá nhân, tags, deadline (hạn chót)
- Bộ sưu tập tài liệu (Collections)
- Thống kê biểu đồ trực quan (5 kiểu biểu đồ)
- Giao diện thân thiện, màu sắc Material Design (Teal/Emerald theme)
- Toast notification hiện đại, context menu, drag-drop
- 12+ forms, 50+ classes, 200+ methods

**Về kiến thức:**
- Nắm vững kiến trúc 3 tầng (Presentation, Business, Data) và biết khi nào nên dùng
- Hiểu rõ C# và Windows Forms, từ cơ bản đến nâng cao
- Thiết kế cơ sở dữ liệu quan hệ phức tạp với 7 bảng, chuẩn hóa 3NF
- Bảo mật mật khẩu bằng BCrypt (thực tế)
- Xử lý phân quyền người dùng chặt chẽ
- Xây dựng giao diện người dùng hiện đại
- Viết mã sạch, có structure rõ ràng, dễ bảo trì

### Những hạn chế

1. **Phím tắt:** Một số phím tắt chưa được triển khai đầy đủ (F2 sửa, Ctrl+F focus search, Ctrl+R refresh, Esc clear search)

2. **Recent/Favorites:** Chưa triển khai danh sách tài liệu mở gần đây hoặc tài liệu yêu thích

3. **Lưu cấu hình người dùng:** Chưa lưu toàn bộ cài đặt (vị trí cửa sổ, độ rộng cột, bộ lọc cuối cùng)

4. **Đồng bộ cloud:** Chưa hỗ trợ đồng bộ dữ liệu với Google Drive, Dropbox, OneDrive

5. **Mobile:** Chưa có phiên bản di động (Android/iOS)

6. **Web version:** Chưa có phiên bản web để truy cập từ browser

7. **Full-text search:** Chưa hỗ trợ tìm kiếm nội dung bên trong file (PDF, Word)

8. **API:** Chưa xây dựng API để các ứng dụng khác tích hợp

### Hướng phát triển trong tương lai

**Ngắn hạn (1-2 tháng):**
1. Triển khai đầy đủ các phím tắt (F2, Ctrl+F, Ctrl+R, Esc, Enter)
2. Thêm tính năng Recently Opened (danh sách 10 tài liệu mở gần đây)
3. Thêm tính năng Favorites (đánh dấu tài liệu yêu thích)
4. Lưu cấu hình người dùng (vị trí cửa sổ, độ rộng cột)
5. Thêm filter cho deadline (Sắp đến hạn, Quá hạn)

**Trung hạn (3-6 tháng):**
1. Đồng bộ cloud: Tích hợp Google Drive, Dropbox
2. Phiên bản web: ASP.NET Core + React/Vue
3. Full-text search: Tìm kiếm trong PDF, Word
4. Sharing: Chia sẻ tài liệu với bạn bè
5. Comments: Bình luận, thảo luận trên tài liệu

**Dài hạn (6-12 tháng):**
1. Phiên bản di động: iOS/Android app
2. API: REST API để tích hợp với hệ thống khác
3. AI recommendation: Gợi ý tài liệu dựa trên lịch sử
4. OCR: Nhận dạng văn bản từ ảnh
5. Notification: Nhắc nhở deadline qua email/SMS
6. Analytics: Thống kê chi tiết về thói quen học tập

### Bài học rút ra

1. **Kiến trúc là nền tảng:** Thiết kế kiến trúc tốt từ đầu giúp mở rộng dễ dàng sau này

2. **Bảo mật là tiên ưu:** Luôn dùng BCrypt cho mật khẩu, không bao giờ lưu plaintext

3. **Phân quyền chặt chẽ:** Luôn kiểm tra quyền trước mỗi action, không tin client

4. **Test từ sớm:** Viết test case sớm, không phải chỉ lúc cuối, sẽ phát hiện lỗi nhanh

5. **Code sạch quan trọng:** Đặt tên biến rõ ràng, chia nhỏ hàm, comment khi cần thiết

6. **Validate input luôn:** Không bao giờ tin input từ người dùng, luôn validate

7. **UX/UI quan trọng:** Ứng dụng hay nhưng giao diện xấu, người dùng cũng không dùng

8. **Documentation:** Viết tài liệu đầy đủ, giúp người khác (và chính mình) hiểu code sau này

---

## TÀI LIỆU THAM KHẢO

1. Microsoft Docs. (2024). "*Windows Forms documentation*". Truy cập từ: https://docs.microsoft.com/en-us/dotnet/desktop/winforms/

2. Microsoft Docs. (2024). "*ADO.NET overview*". Truy cập từ: https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/

3. Microsoft SQL Server. (2024). "*SQL Server documentation*". Truy cập từ: https://docs.microsoft.com/en-us/sql/

4. BCrypt.net. (2024). "*BCrypt.Net-Next GitHub*". Truy cập từ: https://github.com/BcryptNET/bcrypt.net

5. Material Design. (2024). "*Material Design Guidelines*". Truy cập từ: https://material.io/design/

6. W3Schools. (2024). "*C# Tutorial*". Truy cập từ: https://www.w3schools.com/cs/

7. TutorialsPoint. (2024). "*SQL Server Tutorial*". Truy cập từ: https://www.tutorialspoint.com/sql_server/

8. GeeksforGeeks. (2024). "*C# and Windows Forms*". Truy cập từ: https://www.geeksforgeeks.org/

9. Martin Fowler. (2012). "*Patterns of Enterprise Application Architecture*". Addison-Wesley. (Kiến trúc 3 tầng)

10. Riccardo Terrell. (2023). "*Async/Await Best Practices in Asynchronous Programming*". Wintellect.

11. Jon Skeet. (2019). "*C# in Depth*" (4th Edition). Manning Publications. (Lập trình C# chuyên sâu)

12. Steve Krug. (2014). "*Don't Make Me Think*". New Riders. (UX/UI design)

---

**Hà Nội, ngày 04 tháng 12 năm 2025**

**Sinh viên thực hiện:**

**Vũ Đức Dũng**

**Lớp: TT601K14**

**Trường:** CTECH - Thuỡng Tín, Hà Nội

---

**Lời cảm ơn:**

Em xin gửi lời cảm ơn chân thành đến:
- Giảng viên hướng dẫn đã tận tình giảng dạy
- Gia đình hỗ trợ em trong quá trình học tập và làm đồ án
- Bạn bè đã cho feedback và test ứng dụng
- Cộng đồng open source với các thư viện, tài liệu miễn phí

