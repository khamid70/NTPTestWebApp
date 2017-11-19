<%@ Page Title="List of Questions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Questions.aspx.cs" Inherits="NTPTest.Questions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <script type="text/javascript">
        $(document).ready(function ()
        {
            $('#<%=txtFromDate.ClientID%>').datepicker({ dateFormat: 'dd/mm/yy' });
            $('#<%=txtToDate.ClientID%>').datepicker({ dateFormat: 'dd/mm/yy' });
            $("#content").animate({ marginTop: "80px" }, 600);
        });
    </script>

    <h2>
        <%: Title %>.
    </h2>
    <br />
    <div>
        <table id="tblMainInputData">
            <tr>
                <td>
                    <asp:Label ID="lblPageId" runat="server" Text="Page Id:" Width="160px"></asp:Label>
                </td>
                <td>
                   <asp:TextBox ID="txtPageId" runat="server" ValidationGroup="AllControls" Width="200px" TextMode="Number" >1</asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="lblPageSize" runat="server" Text="Page Size:" Width="160px"></asp:Label>
                </td>
                <td>
                   <asp:TextBox ID="txtPageSize" runat="server" ValidationGroup="AllControls" Width="200px" >50</asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblOrderBy" runat="server" Text="Order By:" Width="160px" ></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlOrderBy" runat="server" AutoPostBack="False" Width="200px" >
                        <asp:ListItem Value="Desc" Selected="True">Descending</asp:ListItem>
                        <asp:ListItem Value="Asc">Ascending</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="lblSortBy" runat="server" Text="Sort By:" Width="160px" ></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSortBy" runat="server" AutoPostBack="False" Width="200px" >
                        <asp:ListItem Value="Creation" Selected="True">Creation</asp:ListItem>
                        <asp:ListItem Value="Activity">Activity</asp:ListItem>
                        <asp:ListItem Value="Hot">Hot</asp:ListItem>
                        <asp:ListItem Value="Month">Month</asp:ListItem>
                        <asp:ListItem Value="Votes">Votes</asp:ListItem>
                        <asp:ListItem Value="Week">Week</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblFromDate" runat="server" Text="From Date:" Width="160px" ></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFromDate" runat="server" ValidationGroup="AllControls" Width="200px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="lblToDate" runat="server" Text="To Date:" Width="160px" ></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtToDate" runat="server" ValidationGroup="AllControls" Width="200px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <br />

        
    </div>
    <br />
    <div>
        <table id="tblButtons" style="width: 100%;">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnGetQuestions" CssClass="btn btn-default" runat="server" Text="Search Questions" ValidationGroup="AllControls" OnClick="btnGetQuestions_Click" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnClearScreen" CssClass="btn btn-default" runat="server" Text="Clear Screen" ValidationGroup="AllControls" OnClick="btnClearScreen_Click" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div>
        <br />
        <asp:Label ID="lblOperationResult" runat="server" ForeColor="Maroon" ></asp:Label>
        <asp:ValidationSummary ID="vsPageValidation" CssClass="failureNotification" runat="server" ValidationGroup="AllControls" />
    </div>
    <br />
    <div>
        <asp:Panel ID="pnlViewAll" runat="server"
            HorizontalAlign="Left"
            Direction="LeftToRight"
            Wrap="False"
            >
            <asp:GridView ID="gvAllRecords" runat="server" 
                AutoGenerateColumns="False"
                HorizontalAlign="Left"
                EmptyDataText="No Data Available"
                AllowPaging="True"
                BorderWidth="1px" 
                BorderStyle="None" 
                BackColor="#f8f9f9"
                BorderColor="#f5f5f5"
                AlternatingRowStyle-BackColor="#eeeeee"
                CellPadding="3" CellSpacing="2"
                PageSize="50"
                >
                <Columns>
                    <asp:BoundField DataField="QuestionId" HeaderText="Qs ID" SortExpression="QuestionId" >
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Left" Width="60"></ItemStyle>
                    </asp:BoundField>
                    <asp:HyperLinkField HeaderText="Question Link" ItemStyle-Width="400" ItemStyle-Wrap="True"
                        DataTextField="Title"
                        DataNavigateUrlFields="Link"
                        DataNavigateUrlFormatString="{0}"
                        Target="_blank" />
                    <asp:BoundField DataField="Score" HeaderText="Qs Score" SortExpression="Score" >
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Left" Width="60"></ItemStyle>
                    </asp:BoundField>
                    <asp:CheckBoxField DataField="IsAnswered" HeaderText="Answered" ></asp:CheckBoxField>
                </Columns>
                <FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5" HorizontalAlign="Center"></FooterStyle>
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center"></PagerStyle>
                <HeaderStyle ForeColor="White" BackColor="Blue" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
            </asp:GridView>
        </asp:Panel>
    </div>
    
</asp:Content>
