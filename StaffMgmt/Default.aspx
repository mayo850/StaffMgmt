<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GrantStaffManagement.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title class="text-align-center">Staff Management</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Styles/default.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="heading mb-3 text-center">CPRD Staff</div>
            <div class="line mb-3"></div>

            <div class="row mb-4">
                <div class="col-md-6">
                    <asp:Label ID="GrantLabel" runat="server" Text="Select Grant:"></asp:Label>
                    <asp:DropDownList ID="GrantDropdown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="GrantDropdown_SelectedIndexChanged" CssClass="form-select"></asp:DropDownList>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="StaffActiveLabel" runat="server" Text="Staff Active:"></asp:Label>
                    <asp:DropDownList ID="StaffActiveDropdown" runat="server" AutoPostBack="true" Enabled="true" OnSelectedIndexChanged="StaffActiveDropdown_SelectedIndexChanged" CssClass="form-select">
                        <asp:ListItem Text="--Select--" Value="" />
                        <asp:ListItem Text="Yes" Value="Yes" />
                        <asp:ListItem Text="No" Value="No" />
                    </asp:DropDownList>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <div class="staff-list-title">Staff List</div>
                    <div class="staff-list">
                        <asp:ListBox ID="StaffList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="StaffList_SelectedIndexChanged" Width="100%" Height="100%"></asp:ListBox>
                    </div>
                </div>

                <div class="col-md-8 info-section">
                    <div class="mb-3 row">
                        <label for="NameField" class="col-sm-3 col-form-label">Name:</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="NameField" runat="server" CssClass="form-control" />
                        </div>
                    </div>

                    <div class="mb-3 row">
                        <label for="StartDateField" class="col-sm-3 col-form-label">Start Date:</label>
                        <div class="col-sm-4">
                            <div class="input-group">
                                <asp:TextBox ID="StartDateField" runat="server" CssClass="form-control" />
                                <span class="input-group-text"><i class="fas fa-calendar-alt"></i></span>
                            </div>
                        </div>

                        <label for="EndDateField" class="col-sm-2 col-form-label">End Date:</label>
                        <div class="col-sm-3">
                            <div class="input-group">
                                <asp:TextBox ID="EndDateField" runat="server" CssClass="form-control" />
                                <span class="input-group-text"><i class="fas fa-calendar-alt"></i></span>
                            </div>
                        </div>
                    </div>

                    <div class="mb-3 row">
                        <label for="EmailField" class="col-sm-3 col-form-label">Email:</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="EmailField" runat="server" CssClass="form-control" />
                        </div>
                    </div>

                    <div class="mb-3 row">
                        <label for="CertificationDateField" class="col-sm-3 col-form-label">Certification Date:</label>
                        <div class="col-sm-9">
                            <div class="input-group">
                                <asp:TextBox ID="CertificationDateField" runat="server" CssClass="form-control" />
                                <span class="input-group-text"><i class="fas fa-calendar-alt"></i></span>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
