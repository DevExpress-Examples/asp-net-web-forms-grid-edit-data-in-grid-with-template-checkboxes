Imports Microsoft.VisualBasic
Imports System
Imports System.Data.OleDb
Imports System.Web.Configuration
Imports DevExpress.Web

Partial Public Class Default1
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub

	Protected Sub cb_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim checkBox As ASPxCheckBox = CType(sender, ASPxCheckBox)
		Dim container As GridViewDataItemTemplateContainer = CType(checkBox.NamingContainer, GridViewDataItemTemplateContainer)

		Dim key As String = String.Format("{0}_{1}", container.Column.FieldName, container.KeyValue)
		checkBox.ClientSideEvents.CheckedChanged = String.Format("function(s, e) {{ hf.Set('{0}', s.GetChecked()); }}", key)
	End Sub

	Protected Sub ASPxButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
		For Each item In ASPxHiddenField1
			Dim parts() As String = item.Key.Split(New Char() { "_"c }, StringSplitOptions.RemoveEmptyEntries)
			Dim value As Boolean = CBool(item.Value)

			Dim connection As New OleDbConnection(WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
			Dim updateCommand As New OleDbCommand(String.Format("UPDATE Settings SET {0} = {1} WHERE Id = {2}", parts(0), value, parts(1)), connection)

			connection.Open()
			updateCommand.ExecuteScalar()
			connection.Close()
		Next item

		ASPxHiddenField1.Clear()
	End Sub
End Class