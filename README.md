Có 2 cách tiếp cận đó là sử dụng dictionary và Linq.

So Sánh 2 cách tiếp cận:
+ Độ rõ ràng của code: Rõ ràng hơn, dễ hiểu hơn đặc biệt với người ít dùng Linq vì đây là cách code thuần túy.
+ Hiệu năng: Có lẽ dictionary nhanh hơn vì Linq cần phải tạo thêm object trung gian.
+ Khả năng mở rộng: Dictionary sẽ dễ dàng mở rộng hơn vì sự rõ ràng của code.

Vậy nhìn chung thì dictionary tiện lợi hơn, dễ dàng sử dụng hơn nhưng em thấy Linq được sử dụng khá nhiều, rộng rãi có lẽ do sự ngăn gọn của nó.

- Dictionary thường được dùng trong .NET Framework, console, winforms.
- Linq Thường được dùng trong ASP.NET core, entity frameword để xây dựng API, làm web, dễ dàng tương tác với database.
