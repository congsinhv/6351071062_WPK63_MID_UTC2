<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultPageMaster.Master" AutoEventWireup="true" CodeBehind="CourseDetail.aspx.cs" Inherits="de1.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <div>
        <img id="CourseImage" runat="server" />
        <h2 id="CourseName" runat="server" ></h2>
        ------
        <p><strong>Category ID:</strong> <span id="CourseCategory" runat="server" ></span></p>
        <p><strong></strong> <span id="CourseDuration" runat="server" ></span> mins</p>
        <p id="CourseDescription" runat="server" ></p>:
        <span id="CourseViews" runat="server" ></span>
    </div>
</asp:Content>
