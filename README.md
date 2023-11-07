# LyThuyetDoThi
Đồ án Lý thuyết đồ thị:
Yêu cầu 1: Phân tích thông tin đồ thị (2 điểm)
Hiển thị các thông tin sau lên màn hình
	a. (0.25đ) Ma trận kề của đồ thị
	b. (0.25đ) Xác định tính có hướng của đồ thị: đây là đồ thị có hướng hay đồ thị vô hướng
	c. (0.25đ) Số đỉnh của đồ thị (kể cả đỉnh đặc biệt)
	d. (0.25đ) Số cạnh của đồ thị (kể cả cạnh đặc biệt)
	e. (0.25đ) Số lượng cặp đỉnh xuất hiện cạnh bội, số cạnh khuyên
	f. (0.25đ) Số đỉnh treo, số đỉnh cô lập
	g. (0.5đ) Xác định bậc (nếu là đồ thị vô hướng) hoặc bậc vào – bậc ra (nếu là đồ thị có hướng) 
	của từng đỉnh trong đồ thị
Quy ước:
- Trong đồ thị có hướng, bậc của đỉnh là tổng bậc vào và bậc ra
- Cạnh khuyên tạo 1 bậc vào và 1 bậc ra cho TH có hướng hoặc 2 bậc cho TH vô hướng. 
- Đỉnh treo là đỉnh có bậc bằng 1, đỉnh cô lập là đỉnh có bậc bằng 0.

Yêu cầu 2: Duyệt đồ thị (2 điểm)
	Người dùng nhập từ bàn phím đỉnh bắt đầu source (chỉ mục bắt đầu từ 0).
	a. (0.5đ) In ra danh sách đỉnh được viếng thăm theo giải thuật duyệt đồ thị theo chiều sâu, bắt 
	đầu từ source. Giữ nguyên thứ tự duyệt, không sắp xếp lại danh sách đỉnh.
	b. (0.5đ) In ra danh sách đỉnh được viếng thăm theo giải thuật duyệt đồ thị theo chiều rộng, bắt 
	đầu từ source. Giữ nguyên thứ tự duyệt, không sắp xếp lại danh sách đỉnh.
	c. (1đ) Kiểm tra đồ thị được cho có phải là đồ thị vô hướng hay không? Nếu không kiểm tra thì 
	trừ 0.5đ. Nếu là đồ thị vô hướng, in ra màn hình số lượng thành phần liên thông và danh sách 
	đỉnh thuộc mỗi thành phần liên thông (không quan trọng thứ tự đỉnh). Ngược lại, dừng.

Yêu cầu 3: Tìm cây khung nhỏ nhất (2 điểm)
        Kiểm tra đồ thị được cho có phải là đồ thị vô hướng liên thông hay không? Nếu không kiểm tra thì 
        trừ 0.5đ.
        Thực hiện các yêu cầu dưới đây nếu đồ thị đã cho là đồ thị vô hướng liên thông.
        a. (1đ) Tìm cây khung nhỏ nhất trên đồ thị đã cho bằng giải thuật Prim. Đỉnh bắt đầu là đỉnh 0.
        Xuất ra màn hình thông tin của cây khung nhỏ nhất tìm được 
        - Danh sách cạnh thuộc cây khung nhỏ nhất theo thứ tự được phát hiện bởi giải thuật. Quy 
        ước: In mỗi cạnh trên một dòng riêng biệt theo mẫu <x>-<y>: <z>, với x và y là hai đỉnh của 
        cạnh và z là trọng số của cạnh.
        - Trọng số của cây khung nhỏ nhất 
        b. (1đ) Tìm cây khung nhỏ nhất trên đồ thị đã cho bằng giải thuật Kruskal. Xuất ra màn hình 
        thông tin của cây khung nhỏ nhất theo quy cách tương tự như ở câu a.

Yêu cầu 4: Tìm đường đi ngắn nhất (2 điểm)
	Người dùng nhập từ bàn phím đỉnh bắt đầu source (chỉ mục bắt đầu từ 0).
	Kiểm tra đồ thị được cho có phải là đồ thị có trọng số dương? Nếu không kiểm tra thì trừ 0.5đ.
	a. (1đ) Nếu đó là đồ thị có trọng số dương, tìm đường đi ngắn nhất từ source đến các đỉnh còn lại 
	bằng giải thuật Dijkstra. Ngược lại, dừng.
	Với mỗi đỉnh dest khác source, nếu tồn tại đường đi ngắn nhất từ source đến dest thì in ra màn 
	hình chi phí của đường đi và chi tiết của đường đi theo một trong hai định dạng sau
		- Đường đi ngược, ví dụ 3 <- 2 <- 1 <- 0 hoặc 
		- Đường đi thuận. ví dụ 0 -> 1 -> 2 -> 3 
	Ngược lại, thông báo “Khong co duong di”.
	b. (1đ) Tìm đường đi ngắn nhất từ source đến các đỉnh còn lại bằng giải thuật Ford-Bellman. In 
	ra màn hình kết quả tìm đường đi ngắn nhất theo quy cách tương tự như ở câu a.
	Lưu ý: Nếu đồ thị tồn tại mạch âm, in thêm câu thông báo “Do thi co mach am”. Chương trình 
	vẫn in ra các đường đi ngắn nhất cho đến thời điểm dừng giải thuật.

Yêu cầu 5: Tìm chu trình hoặc đường đi Euler (2 điểm)
	Người dùng nhập từ bàn phím đỉnh bắt đầu source (chỉ mục bắt đầu từ 0).
	Kiểm tra đồ thị được cho có phải là đơn đồ thị hay không? Nếu không kiểm tra thì trừ 0.5đ.
	Thực hiện các yêu cầu dưới đây nếu đồ thị đã cho đơn đồ thị.
	a. (1đ) Kiểm tra tính chất Euler của đồ thị dựa vào các định lý, tính chất đã học trong lý thuyết 
	(chưa chạy các giải thuật tìm chu trình/đường đi Ếuler).
	Nếu đó là đồ thị Euler, in thông báo “Do thi Ếuler”. Nếu đó là đồ thị nửa Euler, in thông báo “Do 
	thi nua Ếuler”. Ngược lại, in thông báo “Do thi khong Euler”.
	b. (1đ) Nếu đồ thị đã cho là đồ thị Euler (hoặc đồ thị nửa Euler) thì tiếp tục xác định chu trình 
	Euler (hoặc đường đi Ếuler) xuất phát từ source.
		• Nếu tồn tại lời giải, in ra chuỗi đỉnh thuộc về chu trình hoặc đường đi.
		• Ngược lại, in thông báo, “Không có lời giải”.
	Quy ước: Tại một đỉnh bất kỳ, nếu bước tiếp theo có nhiều lựa chọn để đi đến đỉnh kề, hãy chọn đỉnh 
	theo thứ tự chỉ mục từ nhỏ đến lớn