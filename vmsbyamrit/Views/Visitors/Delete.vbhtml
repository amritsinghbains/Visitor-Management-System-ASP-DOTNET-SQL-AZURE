@ModelType vmsbyamrit.Visitor
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
