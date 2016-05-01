@ModelType vmsbyamrit.Visitor
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Visitor</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.VisitingPerson)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.VisitingPerson)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Signin)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Signin)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Signout)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Signout)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.VisitorId }) |
    @Html.ActionLink("Back to List", "Index")
</p>
