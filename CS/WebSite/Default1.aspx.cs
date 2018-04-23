using System;
using System.Data.OleDb;
using System.Web.Configuration;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;

public partial class Default1 : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

    }

    protected void cb_Init(object sender, EventArgs e) {
        ASPxCheckBox checkBox = (ASPxCheckBox)sender;
        GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)checkBox.NamingContainer;

        string key = string.Format("{0}_{1}", container.Column.FieldName, container.KeyValue);
        checkBox.ClientSideEvents.CheckedChanged = string.Format("function(s, e) {{ hf.Set('{0}', s.GetChecked()); }}", key);
    }

    protected void ASPxButton1_Click(object sender, EventArgs e) {
        foreach (var item in ASPxHiddenField1) {
            string[] parts = item.Key.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            bool value = (bool)item.Value;

            OleDbConnection connection = new OleDbConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            OleDbCommand updateCommand = new OleDbCommand(string.Format("UPDATE Settings SET {0} = {1} WHERE Id = {2}", parts[0], value, parts[1]), connection);

            connection.Open();
            updateCommand.ExecuteScalar();
            connection.Close();
        }

        ASPxHiddenField1.Clear();
    }
}