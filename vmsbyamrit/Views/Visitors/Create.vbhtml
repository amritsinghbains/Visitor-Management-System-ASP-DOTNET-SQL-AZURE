@ModelType vmsbyamrit.Visitor
@Code
    ViewData("Title") = "Create"
End Code
    <link href="http://code.jquery.com/ui/1.10.4/themes/ui-lightness/jquery-ui.css" rel="stylesheet">
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
<script src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <script src="../Scripts/jquery-ui-timepicker-addon.js"></script>

<script>
    function dateChecker(dt1, dt2) {
        dt1 = new Date(dt1);
        dt2 = new Date(dt2);
        if (dt1 > dt2) {
            alert("Sign in time should be less than Sign out time");
            $("#submitButton").hide();
        } else {
            $("#submitButton").show();
        }
    }
    function initCheck(){
        if ($("#Signin").val().length > 0 && $("#Signout").val().length > 0) {
            dateChecker($("#Signin").val(), $("#Signout").val())
        }
    }
    function validation() {
        if ($("#Signin").val().length > 0 && $("#Signout").val().length > 0 && ("#Name").val().length > 0 && $("#VisitingPerson").val().length > 0) {
            $("#submitButton").show();
        }
    }
</script>


<link href="../Scripts/jquery-ui-timepicker-addon.css" rel="stylesheet">
    <script>
        $(function () {
            $('#Signin').datetimepicker({
                timeInput: true,
                timeFormat: "hh:mm tt",
                showHour: false,
                showMinute: false
            });
            $('#Signout').datetimepicker({
                timeInput: true,
                timeFormat: "hh:mm tt",
                showHour: false,
                showMinute: false
            });
            $("#Signout").datepicker("show");



        });
    </script>
    <h2>Create</h2>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-horizontal">
            <h4>Visitor</h4>
            <hr />
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Name, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.Name, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.VisitingPerson, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.VisitingPerson, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.VisitingPerson, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Signin, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Signin, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.Signin, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Signout, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Signout, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.Signout, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <input id="submitButton" type="submit" value="Create" class="btn btn-default" />
                </div>
            </div>
        </div>
    End Using
<script>

    $("#Signin").blur(function () {
        initCheck();
        validation();
    });
    $("#Signout").blur(function () {
        initCheck();
        validation();
    });
    $("#Name").blur(function () {
        validation();
    });
    $("#VisitingPerson").blur(function () {
        validation();
    });
    $("#submitButton").hide();

    
    
</script>
    @Section Scripts
        @Scripts.Render("~/bundles/jqueryval")
    End Section
