<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128534838/13.1.9%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E5128)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# Grid View for ASP.NET Web Forms - How to edit data in the grid with template checkboxes

This example demonstrates how to create templated columns, add checkbox editors to the templates, and configure the grid's cell edit functionality. The following approaches are available:

* Save modified data to a hidden field and pass it in batches to the server on a button click. Note that starting with v13.2, this functionality is available out-of-the-box: [Grid in Batch Edit Mode](https://docs.devexpress.com/AspNet/16443/components/grid-view/concepts/edit-data/batch-edit-mode).
* Pass modified cell values to the server immediately after changing.

## Overview

Specify a column's [DataItemTemplate](https://docs.devexpress.com/AspNet/DevExpress.Web.GridViewDataColumn.DataItemTemplate) property and add a checkbox to the template. In the checkbox's server-side `Init` event, dynamically get the current column's field name and the row's key value and pass these values to the checkbox's client-side [CheckedChanged](https://docs.devexpress.com/AspNet/js-ASPxClientCheckBox.CheckedChanged) event.

For the first approach, save modified values to a hidden field - call the hidden field's [Set](https://docs.devexpress.com/AspNet/js-ASPxClientHiddenField.Set(propertyName-propertyValue)) method. These values are saved to the data source after a user clicks the **Save Changes** button.

For the second approach, call the grid's client-side [PerformCallback](https://docs.devexpress.com/AspNet/js-ASPxClientGridView.PerformCallback(args)) method immediately after a user changes a checkbox's value and pass this value to the server to save it to the data source.

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

## Files to Review

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default1.aspx](./CS/WebSite/Default1.aspx) (VB: [Default1.aspx](./VB/WebSite/Default1.aspx))
* [Default1.aspx.cs](./CS/WebSite/Default1.aspx.cs) (VB: [Default1.aspx.vb](./VB/WebSite/Default1.aspx.vb))
* [Default2.aspx](./CS/WebSite/Default2.aspx) (VB: [Default2.aspx](./VB/WebSite/Default2.aspx))
* [Default2.aspx.cs](./CS/WebSite/Default2.aspx.cs) (VB: [Default2.aspx.vb](./VB/WebSite/Default2.aspx.vb))

## Documentation

* [Access Controls in Templates on the Server](https://docs.devexpress.com/AspNet/403575/common-concepts/access-controls-in-templates-on-the-server)

## More Examples

* [Grid View for ASP.NET Web Forms - How to use template editors to update grid data](https://github.com/DevExpress-Examples/how-to-perform-aspxgridview-instant-updating-using-different-editors-in-the-dataitem-template-e2333)
* [Grid View for ASP.NET Web Forms - Implement the multi-row edit functionality in a dynamically bound multi-page grid](https://github.com/DevExpress-Examples/implement-the-multi-row-editing-functionality-with-a-multi-page-grid-bound-dynamically-e1318)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-web-forms-grid-edit-data-in-grid-with-template-checkboxes&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-web-forms-grid-edit-data-in-grid-with-template-checkboxes&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
