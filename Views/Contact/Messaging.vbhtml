@ModelType IEnumerable(Of LEMS.contact)

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Messages</title>
<link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />
     <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js" type="text/javascript"></script>
     <script  type="text/javascript" src="@Url.Content("~/Scripts/jquery.cookie.js")"></script>
     <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/jquery-form-validator/2.1.47/jquery.form-validator.min.js"></script>
     <script  type="text/javascript" src="@Url.Content("~/Scripts/Lems.js")"></script>
     <style type="text/css">
     th,td
     {
         width:190px;
         }
         td
         {
             text-align:center;
             }
             .home
             {
                 position:absolute;
                 top:150px;
                 left:210px;
                 font-size:23px;
                 }
     </style>
</head>
<body class="admin-page" style="background-color:#B2B2B2">
  <div class="admin-header"><h2>Administration</h2></div>
   <ul class="Logout">
<li>@Html.ActionLink("Log Out","LogOut","Admin")</li>
</ul>
<div class="home">@Html.ActionLink("Home", "Index","Loan")</div>
         <h3>Messages</h3>
         <div style="margin-left:200px;margin-right:200px;">
    @For Each item In Model
          Dim currentItemName = item
          @<p>From: @Html.DisplayFor(Function(modelItem) currentItemName.Name)</p>
        Exit For
     Next
    <table>
        <tr>
          
            <th>
                @Html.DisplayNameFor(Function(model) model.Subject)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Email)
            </th>
       
            <th>
                @Html.DisplayNameFor(Function(model) model.TimeSent)
            </th>
            <th></th>
        </tr>
        @code
            'unique identifiers
            Dim ids = New List(Of Integer)
            Dim i As Integer = 0
            Dim persUid As Integer=Request("uid")
        End Code
    @For Each item In ViewBag.Ids
            Dim iteminlist = item
            ids.Add(iteminlist)
    Next 
    @For Each item In Model
        Dim currentItem = item
        Dim uid As Integer = ids.ElementAt(i)
        @<tr>
        
            <td>
                @Html.DisplayFor(Function(modelItem) currentItem.Subject)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) currentItem.Email)
            </td>
          
            <td>
                @Html.DisplayFor(Function(modelItem) currentItem.TimeSent)
            </td>
            <td>
                @Html.ActionLink("View", "ViewDetail", New With {.id = uid,.puid=persUid}) |
            </td>
   
        </tr>
        i=i+1
    Next
    
    </table>
    </div>
    
</body>
</html>
