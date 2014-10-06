@ModelType IEnumerable(Of LEMS.Loan)
@Code
    Layout = Nothing
   
End Code

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Admin</title>
    <link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />
     <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js" type="text/javascript"></script>
     <script  type="text/javascript" src="@Url.Content("~/Scripts/jquery.cookie.js")"></script>
     <script  type="text/javascript" src="@Url.Content("~/Scripts/Lems.js")"></script>

</head>
<body class="admin-page" style="background-color:#B2B2B2">
<div class="admin-header"><h2>Administration</h2></div>
<ul class="Logout">
<li>@Html.ActionLink("Log Out","LogOut","Admin")</li>
</ul>
<div id="admin-display">
<fieldset>
<legend>Loan Details</legend>
<p class="link-admin">
    @Html.ActionLink("Create New", "Create")
</p>

<table>
    <tr>
        <th>
           Type Of<br /> Loan
        </th>
        <th>
           Interest <br />Rate
        </th>
        <th>
            Max Repayment period<br />(in months)
        </th>
        <th>
            Pegged on <br />Share deposit
        </th>
        <th>
            Multiplication<br />Factor
        </th>
        <th></th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.LoanType)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.InterestRate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.MaxPeriod)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.PeggedOn)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Factor)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = currentItem.ID}) |
            @Html.ActionLink("Details", "Details", New With {.id = currentItem.ID}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.ID})
        </td>
    </tr>
Next

</table>
</fieldset>
</div>

<nav>
  <ul>
    <li>@Html.ActionLink("View Users","Index","Profile")</li>
    <li>
      @Html.ActionLink("Create Users","Create","Profile")
    </li>
    <li>@Html.ActionLink("Loan Applications","Index","LoanApplication")</li>
    <li><a href="#">Reports</a>
        <ul class="fallback">
            <li><a href="userReportViewer.aspx?">Users</a></li>
            <li><a href="applicationReportViewer.aspx?">Loan Applications</a></li>
            <li><a href="applicationGraph.aspx?">Application Chart</a></li>
        </ul>
    </li>
    <li><a href="#">Messages <span id="msg-count" style="color:red">(@ViewBag.NewMsgs)</span></a>
        <ul class="fallback">
        @Code
            Dim trackNewlist = New List(Of Integer)
            Dim i As Integer = 0
            'individual number of new messages
            Dim trackcount = New List(Of Integer)
            Dim j As Integer = 0
            'unique identifiers
            Dim ids = New List(Of Integer)
            Dim k As Integer=0
        End Code
        @For Each item In ViewBag.IndividualNew
            Dim iteminlist = item
            trackNewlist.Add(iteminlist)
        Next
        @For Each item In ViewBag.IndividualCount
            Dim iteminlist = item
            trackcount.Add(iteminlist)
        Next
        @For Each item In ViewBag.Ids
            Dim iteminlist = item
            ids.Add(iteminlist)
        Next     
        @For Each person In ViewBag.Names
            Dim name = person
            Dim notif As String
            Dim countTimes = trackcount.ElementAt(j)
            Dim id =ids.ElementAt(k)
            If  trackNewlist.ElementAt(i)=1 Then
                 notif = "New"
            Else
                notif = ""
            End If
            @<li><a href="@Url.Action("Messaging","Contact",New With {.uid=id})">From @name<span class="not-sec" style="color:red">@notif (@countTimes)</span></a></li>
            i = i + 1
            j = j + 1
            k=k+1
        Next
        </ul>
    </li>
 </ul>
</nav>
<div id="cssmenu">
	<ul>
		<li><a href="#"><span>Home</span></a></li>
		<li><a href="#"><span>Audit Trails</span></a>
			<ul>
				<li>@Html.ActionLink("User Actions","AuditRecords")</li>
				<li><a href="#"><span>Admin Actions &nbsp;<b>>></b></span></a>
                    <ul>
                        <li>@Html.ActionLink("Loan Tracking","AuditStatus")</li>
                        <li>@Html.ActionLink("Admins Created","AdminDetailAudit")</li>
                    </ul>
                </li>
				<li><a href="#">Products</a></li>
			</ul>
		</li>
        
        <li><a href="#"><span>New</span></a>
			<ul>
			   <li>@Html.ActionLink("Create New Admin","Create","Admin")</li>
               <li>@Html.ActionLink("Details of Admin","Index","Admin")</li>
			</ul>
		</li>
        <li><a href="#"><span>Branches</span></a>
			<ul>
				<li><a href="#">Nairobi</a></li>
				<li><a href="#">Kisumu</a></li>
				<li><a href="#">Mombasa</a></li>
			</ul>
		</li>
    </ul>
</div>
<div id="admin-username">@ViewBag.Username</div>
<div id="count-new" style="display:none">@ViewBag.NewMsgs</div>
</body>
</html>