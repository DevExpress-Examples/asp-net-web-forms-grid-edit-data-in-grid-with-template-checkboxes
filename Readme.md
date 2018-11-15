<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default1.aspx](./CS/WebSite/Default1.aspx) (VB: [Default1.aspx](./VB/WebSite/Default1.aspx))
* [Default1.aspx.cs](./CS/WebSite/Default1.aspx.cs) (VB: [Default1.aspx](./VB/WebSite/Default1.aspx))
* [Default2.aspx](./CS/WebSite/Default2.aspx) (VB: [Default2.aspx](./VB/WebSite/Default2.aspx))
* [Default2.aspx.cs](./CS/WebSite/Default2.aspx.cs) (VB: [Default2.aspx](./VB/WebSite/Default2.aspx))
<!-- default file list end -->
# ASPxGridView - How to implement instant editing with check boxes in columns


<p>This example illustrates how to implement instant editing in ASPxGridView. It is divided in two independent samples:</p><p>- The first sample (the Default1 page) illustrates how to post modified data to the underlying database on demand. Note that starting with v2013 vol 2, we provide a similar feature out-of-the-box: <a href="http://documentation.devexpress.com/#AspNet/CustomDocument16443"><u>Batch Edit Mode</u></a>.<br />
- The second sample (the Default2 page) illustrates how to post modified data to the underlying database immediately.</p><p>In both samples, we define a custom <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewGridViewDataColumn_DataItemTemplatetopic"><u>GridViewDataColumn.DataItemTemplate</u></a> with <a href="http://documentation.devexpress.com/#AspNet/clsDevExpressWebASPxEditorsASPxCheckBoxtopic"><u>ASPxCheckBox</u></a>. We handle the ASPxCheckBox' <strong>Init </strong>event (see <a href="https://www.devexpress.com/Support/Center/p/K18282">The general technique of using the Init/Load event handler</a>) to generate client-side <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxEditorsScriptsASPxClientCheckBox_CheckedChangedtopic"><u>ASPxClientCheckBox.CheckedChanged Event</u></a> handler dynamically based on the current filed name and row key:<br />
</p>

```cs
    // Default1.aspx.cs
    protected void cb_Init(object sender, EventArgs e) {
        ASPxCheckBox checkBox = (ASPxCheckBox)sender;
        GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)checkBox.NamingContainer;

        string key = string.Format("{0}_{1}", container.Column.FieldName, container.KeyValue);
        checkBox.ClientSideEvents.CheckedChanged = string.Format("function(s, e) {{ hf.Set('{0}', s.GetChecked()); }}", key);
    }

    // Default2.aspx.cs
    protected void cb_Init(object sender, EventArgs e) {
        ASPxCheckBox checkBox = (ASPxCheckBox)sender;
        GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)checkBox.NamingContainer;

        string key = string.Format("{0}|{1}", container.Column.FieldName, container.KeyValue);
        checkBox.ClientSideEvents.CheckedChanged = string.Format("function(s, e) {{ grid.PerformCallback('{0}|' + s.GetChecked()); }}", key);
    }

```

<p>As you can see, in the first case we just save the modified value to the hidden field via the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxHiddenFieldScriptsASPxClientHiddenField_Settopic"><u>ASPxClientHiddenField.Set Method</u></a>. These values will be extracted from it and posted to the database later when the "Save Changes" button is clicked. In the second case, we immediately initiate a saving callback via the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewScriptsASPxClientGridView_PerformCallbacktopic"><u>ASPxClientGridView.PerformCallback Method</u></a>.</p><p><strong>See Also:</strong><br />
<a href="https://www.devexpress.com/Support/Center/p/E2333">How to perform ASPxGridView instant updating using different editors in the DataItem template</a><strong><br />
</strong><a href="https://www.devexpress.com/Support/Center/p/E1318">How to implement the multi-edit functionality with a multi-page grid that is bound dynamically</a></p>

<br/>


