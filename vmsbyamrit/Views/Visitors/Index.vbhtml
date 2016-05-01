@ModelType IEnumerable(Of vmsbyamrit.Visitor)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.VisitingPerson)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Signin)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Signout)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.VisitingPerson)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Signin)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Signout)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.VisitorId }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.VisitorId }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.VisitorId })
        </td>
    </tr>
Next

</table>
