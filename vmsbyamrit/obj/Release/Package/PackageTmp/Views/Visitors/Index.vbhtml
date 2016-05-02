@ModelType IEnumerable(Of vmsbyamrit.Visitor)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>
<script src="http://code.jquery.com/jquery-1.10.2.js"></script>
<script>
    function diff(dt1, dt2, id) {
        dt1 = new Date(dt1);
        dt2 = new Date(dt2);
        value = (dt2 - dt1) / 60000;
        $('#' + id).text(value + " min")
    }
</script>
<p>
    @Html.ActionLink("Create New", "Create")
</p>

Search <input type="text" id="searchInput">

<select id="signedStatusString">
    <option value="all">All</option>
    <option value="present">Present</option>
    <option value="absent">Absent</option>
</select>

<select id="durationString">
    <option value="0">All</option>
    <option value="1">Less than 30 min</option>
    <option value="2">30 min to 1 hour</option>
    <option value="3">1 hour to 2 hours</option>
    <option value="4">More than 2 hours</option>
</select>

<input type="submit" value="Submit" onclick="return submitButtonClicked();">

<script>

    function submitButtonClicked() {
        var searchString = $('#searchInput').val();
        var e = document.getElementById("signedStatusString");
        var signedStatusString = e.options[e.selectedIndex].value;
        var e2 = document.getElementById("durationString");
        var durationString = e2.options[e2.selectedIndex].value;

        var urlExtra = '?';
        if (searchString.length > 0) {
            urlExtra += 'searchString=' + searchString + '&';
        }
        if (signedStatusString != 'all') {
            urlExtra += 'signedStatusString=' + signedStatusString + '&';
        }
        switch (parseInt(durationString)) {
            case 1: urlExtra += 'durationString1=0&durationString2=30'; break;
            case 2: urlExtra += 'durationString1=30&durationString2=60'; break;
            case 3: urlExtra += 'durationString1=60&durationString2=120'; break;
            case 4: urlExtra += 'durationString1=120&durationString2=10000'; break;
        }

        console.log(urlExtra);
        window.location.replace('Index' + urlExtra);
    }
</script>

<Table Class="table">
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
        <th>
            Duration
        </th>
        <th></th>
    </tr>

@If Request.IsAuthenticated Then
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
         <td id="@Html.ValueFor(Function(modelItem) item.VisitorId)">
            <script>
                diff("@Html.ValueFor(Function(modelItem) item.Signin)", "@Html.ValueFor(Function(modelItem) item.Signout)", "@Html.ValueFor(Function(modelItem) item.VisitorId)")
             </script>
         </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.VisitorId}) |
            @Html.ActionLink("Details", "Details", New With {.id = item.VisitorId}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.VisitorId })
        </td>
    </tr>
Next
End If  
</table>
 