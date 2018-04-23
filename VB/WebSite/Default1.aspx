<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default1.aspx.vb" Inherits="Default1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>GridCheckBoxesWeb</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<h1>Instant editing example</h1>
		<h2>Check boxes state is saved on-demand (batch data update)</h2>

		<dx:ASPxGridView ID="ASPxGridView1" runat="server" ClientInstanceName="grid" AutoGenerateColumns="False"
			DataSourceID="AccessDataSource1" KeyFieldName="Id">
			<Columns>
				<dx:GridViewDataTextColumn FieldName="Id" ReadOnly="True" VisibleIndex="0">
					<EditFormSettings Visible="False" />
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataColumn FieldName="Sun" VisibleIndex="1">
					<DataItemTemplate>
						<dx:ASPxCheckBox ID="cb" runat="server" Checked='<%#Eval("Sun")%>' OnInit="cb_Init" />
					</DataItemTemplate>
				</dx:GridViewDataColumn>
				<dx:GridViewDataCheckColumn FieldName="Mon" VisibleIndex="2">
					<DataItemTemplate>
						<dx:ASPxCheckBox ID="cb" runat="server" Checked='<%#Eval("Mon")%>' OnInit="cb_Init" />
					</DataItemTemplate>
				</dx:GridViewDataCheckColumn>
				<dx:GridViewDataCheckColumn FieldName="Tue" VisibleIndex="3">
					<DataItemTemplate>
						<dx:ASPxCheckBox ID="cb" runat="server" Checked='<%#Eval("Tue")%>' OnInit="cb_Init" />
					</DataItemTemplate>
				</dx:GridViewDataCheckColumn>
				<dx:GridViewDataCheckColumn FieldName="Wed" VisibleIndex="4">
					<DataItemTemplate>
						<dx:ASPxCheckBox ID="cb" runat="server" Checked='<%#Eval("Wed")%>' OnInit="cb_Init" />
					</DataItemTemplate>
				</dx:GridViewDataCheckColumn>
				<dx:GridViewDataCheckColumn FieldName="Thu" VisibleIndex="5">
					<DataItemTemplate>
						<dx:ASPxCheckBox ID="cb" runat="server" Checked='<%#Eval("Thu")%>' OnInit="cb_Init" />
					</DataItemTemplate>
				</dx:GridViewDataCheckColumn>
				<dx:GridViewDataCheckColumn FieldName="Fri" VisibleIndex="6">
					<DataItemTemplate>
						<dx:ASPxCheckBox ID="cb" runat="server" Checked='<%#Eval("Fri")%>' OnInit="cb_Init" />
					</DataItemTemplate>
				</dx:GridViewDataCheckColumn>
				<dx:GridViewDataCheckColumn FieldName="Sat" VisibleIndex="7">
					<DataItemTemplate>
						<dx:ASPxCheckBox ID="cb" runat="server" Checked='<%#Eval("Sat")%>' OnInit="cb_Init" />
					</DataItemTemplate>
				</dx:GridViewDataCheckColumn>
			</Columns>
		</dx:ASPxGridView>

		<br />
		<dx:ASPxButton ID="ASPxButton1" runat="server" Text="Save Changes" OnClick="ASPxButton1_Click" />

		<dx:ASPxHiddenField ID="ASPxHiddenField1" runat="server" ClientInstanceName="hf" />
	</div>
	<asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/data.mdb"
		SelectCommand="SELECT * FROM [Settings]" />
	</form>
</body>
</html>