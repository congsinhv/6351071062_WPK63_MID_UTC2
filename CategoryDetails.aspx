<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultPageMaster.Master" AutoEventWireup="true" CodeBehind="CategoryDetails.aspx.cs" Inherits="de1.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="CourseListView" runat="server" AllowPaging="true">
        <LayoutTemplate>
            <div>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </div>
            <div>
                <asp:DataPager ID="CoursePager" runat="server" PageSize="5">
                    <Fields>
                        <asp:NumericPagerField />
                    </Fields>
                </asp:DataPager>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div style="margin-bottom: 20px;">
                <h3><%# Eval("Name") %></h3>
                <img src="<%# "images/Courses/" + Eval("ImageFilePath") %>" alt="Course Image" style="width: 150px; height: 100px;" />
                <p><strong></strong> <%# Eval("Duration") %>mins</p>
                <a href="CourseDetail.aspx?Courses=<%# Eval("ID")%>">Details</a>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>

