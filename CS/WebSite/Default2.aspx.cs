using System;
using System.Data.OleDb;
using System.Web.Configuration;
using DevExpress.Web;

public partial class Default2 : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

    }

    protected void cb_Init(object sender, EventArgs e) {
        ASPxCheckBox checkBox = (ASPxCheckBox)sender;
        GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)checkBox.NamingContainer;

        string key = string.Format("{0}|{1}", container.Column.FieldName, container.KeyValue);
        checkBox.ClientSideEvents.CheckedChanged = string.Format("function(s, e) {{ grid.PerformCallback('{0}|' + s.GetChecked()); }}", key);
    }

    protected void ASPxGridView1_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e) {
        string[] parts = e.Parameters.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

        OleDbConnection connection = new OleDbConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        OleDbCommand updateCommand = new OleDbCommand(string.Format("UPDATE Settings SET {0} = {1} WHERE Id = {2}", parts[0], parts[2], parts[1]), connection);

        connection.Open();
        updateCommand.ExecuteScalar();
        connection.Close();
    }
}