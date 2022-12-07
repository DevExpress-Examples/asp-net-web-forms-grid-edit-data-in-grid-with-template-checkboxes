Imports Microsoft.VisualBasic
Imports System
Imports System.Data.OleDb
Imports System.Web.Configuration
Imports DevExpress.Web

Partial Public Class Default2
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub

	Protected Sub cb_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim checkBox As ASPxCheckBox = CType(sender, ASPxCheckBox)
		Dim container As GridViewDataItemTemplateContainer = CType(checkBox.NamingContainer, GridViewDataItemTemplateContainer)

		Dim key As String = String.Format("{0}|{1}", container.Column.FieldName, container.KeyValue)
		checkBox.ClientSideEvents.CheckedChanged = String.Format("function(s, e) {{ grid.PerformCallback('{0}|' + s.GetChecked()); }}", key)
	End Sub

	Protected Sub ASPxGridView1_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
		Dim parts() As String = e.Parameters.Split(New Char() { "|"c }, StringSplitOptions.RemoveEmptyEntries)

		Dim connection As New OleDbConnection(WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
		Dim updateCommand As New OleDbCommand(String.Format("UPDATE Settings SET {0} = {1} WHERE Id = {2}", parts(0), parts(2), parts(1)), connection)

		connection.Open()
		updateCommand.ExecuteScalar()
		connection.Close()
	End Sub
End Class