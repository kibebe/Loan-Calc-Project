﻿@ModelType IEnumerable(Of LEMS.UserTable)

@Code
    ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table>
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.AccountNo)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Email)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Password)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ConfirmPassword)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.AccountNo)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Email)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Password)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.ConfirmPassword)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = currentItem.ID}) |
            @Html.ActionLink("Details", "Details", New With {.id = currentItem.ID}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.ID})
        </td>
    </tr>
Next

</table>
