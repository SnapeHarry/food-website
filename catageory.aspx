<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="catageory.aspx.cs" Inherits="middleeast_project.admin.catageory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        window.onload = function () {
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=lblmsg.ClientID%>").style.display = "none";
            }, seconds * 1000);
        };
    </script>
    <script>
        function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imgCategory.ClientID%>').prop('src', e.target.result).width(200).height(200);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pcoded-inner-content pt-0">
        <div class="align-align-self-end">
            <asp:Label ID="lblmsg" runat="server" Visable="false"></asp:Label>
        </div>
        <div class="main-body">
            <div class="pcoded-wrapper">
                <div class="page-body">
                    <div class="row">
                        <div class="col-sm-12 ">
                            <div class="card">
                                <div class="card-header">
                                </div>
                                <div class="card-block">
                                    <div class="row">
                                        <div class="col-sm-6 col-md-4 col-lg-4">
                                            <h4 class="sub-title">catogeary</h4>
                                            <div>
                                                <div class="form-group">
                                                    <label>Categeory Name</label>
                                                    <div>
                                                        <asp:TextBox ID="Textname" runat="server" CssClass="form-control" placeholder="Enter Catageory Name" required></asp:TextBox>
                                                        <asp:HiddenField ID="hdnid" runat="server" Value="0" />

                                                    </div>
                                                </div>

                                                <div class="form-group">
                                                    <label>Catageory Image</label>
                                                    <div>
                                                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-Control"
                                                            onchange="ImagePreview(This);" />
                                                    </div>
                                                </div>
                                                <div class="form-check pl-4">
                                                    <div>
                                                        <asp:CheckBox ID="cbisactive" runat="server" Text="&nbsp; IsActive"
                                                            CssClass="form-check-input" />
                                                    </div>
                                                </div>
                                                <div class="pb-5">
                                                    
                                                    <div>
                                                        <asp:Button ID="Button1" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="Button1_Click" />
                                                        &nbsp;
                                                    <asp:Button ID="Button2" runat="server" Text="Clear" CssClass="btn btn-primary" OnClick="Button2_Click"
                                                        CausesValidation="false" />
                                                    </div>
                                                    <div>
                                                        <asp:Image ID="imgCategory" runat="server" CssClass="img-thumbnail" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6 col-md-8 col-lg-8 mobile-inputes" >
                                            <h4 class="sub-title">catogeary List</h4>
                                            <div class="card-block table-border-style" >
                                                <div class="table-responsive">
                                                    <asp:Repeater ID="rcategory" runat="server">
                                                        <HeaderTemplate>
                                                            <table>
                                                                <tr>
                                                                    <th>Name</th>
                                                                    <th>Image</th>
                                                                    <th>IsActive</th>
                                                                    <th>CreatedDate</th>
                                                                    <th>Action</th>
                                                                </tr>
                                                            </table>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td> <%# Eval("Name") %> </td>
                                                                <td> <%# Eval("imageurl") %> </td>
                                                                <td> <%# Eval("isactive") %> </td>
                                                                <td> <%# Eval("created_Date") %> </td>
                                                            </tr>
                                                            
                                                        </ItemTemplate>
                                                    </asp:Repeater>

                                                </div>
                                            </div>
                                            </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
