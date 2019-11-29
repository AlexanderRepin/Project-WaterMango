<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlantMango.aspx.cs" Inherits="Project_WaterMango.PlantMango" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Plant Watering System</title>

    <link href="~/Plant.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <asp:Label id="lblTimeWatered" runat="server" Text="Plant has not been watered in 6 hours..."></asp:Label>
    <form id="form1" runat="server">
        <div>
            
            <asp:GridView 
                ID="PlantGridView" 
                runat="server" 
                BackColor="White" 
                BorderColor="#336666" 
                BorderStyle="Double" 
                BorderWidth="3px" 
                CellPadding="5" 
                GridLines="Horizontal" 
                AutoGenerateColumns="false" OnRowDataBound="PlantGridView_RowDataBound"
                
                
                >
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                         <ItemTemplate>
                            <asp:Label ID="plantID" Text='<%# Eval("Plant ID") %>' runat="server" size="85" ></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="plantID" Text='<%# Eval("Plant ID") %>' runat="server" size="85" ></asp:Label>
                        </EditItemTemplate>
                        <ItemStyle Width="200px"/>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Name">
                         <ItemTemplate>
                            <asp:Label ID="plantName" Text='<%# Eval("Plant Name") %>' runat="server" size="85" ></asp:Label>
                        </ItemTemplate>
                         <EditItemTemplate>
                             <asp:Label ID="plantName" Text='<%# Eval("Plant Name") %>' runat="server" size="85" ></asp:Label>
                         </EditItemTemplate>
                         <ItemStyle Width="200px"/>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                         <ItemTemplate>
                            <asp:Label ID="plantStatus" Text='<%# Eval("Plant Status") %>' runat="server" size="85" ></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="plantStatus" Text='<%# Eval("Plant Status") %>' runat="server" size="85" ></asp:Label>
                        </EditItemTemplate>
                        <ItemStyle Width="200px"/>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Command">
                         <ItemTemplate>
                            <asp:Label ID="plantCommand" Text='<%# Eval("Plant Command") %>' runat="server" size="85" ></asp:Label>
                         </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="plantCommand" Text='<%# Eval("Plant Command") %>' runat="server" size="85" ></asp:Label>
                        </EditItemTemplate>
                        <ItemStyle Width="200px"/>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Button ID="btnSubmit" runat="server" OnClick="waterButtonClick" Text="Water Plant" />
                        </ItemTemplate>
                        <ItemStyle Width="200px"/>
                    </asp:TemplateField>

                    
                </Columns>
                
            </asp:GridView>
            
        </div>

    </form>
</body>
</html>
