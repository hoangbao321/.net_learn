@*
    -Partial View : la file .cshtml không có @page
        -Chia nhỏ page thành các file nhỏ
        -Sử dụng lại các thành phần tránh trùng lập code

    -Component ~ Partial view (view con chèn vào file cshtml)
                sử dụng D Inject , để inject những cái dịch vụ hệ thống vào đối tượng COMPONENT
                Để COMPONENT sử dụng dịch vụ đó, COMPONET coi như các trang mini Razor Page

*@

gọi componnent thì trong Page->Shared->Component ->  tạo 1) ProductBox.cs 2) Default.cshtml
Index.cshtml 
	@await Component.InvokeAsync("_ProductBox");
Index.cshtml.cs
	public IViewComponnet Invoke()
	{
		return ViewComponnet("_ProductBox");
	}
Page->Shared-> ProductBox -> 1) ProductBox.cs 2) Default.cshtml

nếu gọi partial chỉ cần tạo trong Page-> Share -> tạo _Message.cshtml
Index.cshtml
	<partial name="_Message" /> hoặc là @{ await Html.RenderPartialAsync("_Message");}
Index.cshtml.cs 
	public IViewComponnet Invoke()
	{
		return Partial("_Message");
	}