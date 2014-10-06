@ModelType IEnumerable(Of LEMS.Loan)

@Code
    ViewData("Title") = "Loan Calculator"
End Code

@Section JS
<script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/jquery-form-validator/2.1.47/jquery.form-validator.min.js"></script>
<script language="JavaScript" type="text/javascript" src="@Url.Content("~/Scripts/notify.mini.js")"></script>
<script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/floatthead/1.2.8/jquery.floatThead.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        var accno1 = parseInt($('#accno').html(), 10);

        if (accno1 != 0) {
            $.cookie("persacc", accno1);
            var hasApplied1 = parseInt($('#applied').html());
            var state1 = parseInt($('#state').html(), 10);
         
            $.cookie("persapp", hasApplied1);
            $.cookie("persstate", state1);
       
        }
        if (accno1 == 0) {
            var retacc = $.cookie("persacc");
            var retapp = $.cookie("persapp");
            var retstate = $.cookie("persstate");
            var retrd = $.cookie("persrd");
            $('#accno').html(retacc);
            $('#applied').html(retapp);
            $('#state').html(retstate);
          
        }

        var $success = parseFloat($('#success').html(), 10);
        if ($success == 1) {
            $.notify.defaults({ autoHideDelay: 25000 })
            $('#notify-success').notify('Your loan application was received \n We will notify you \n in due course. Thank you.. ', 'success');

        }
        var rd = parseInt($('#read').html(), 10);
        var beep = 0
        if (rd == 0) {
            $("<span id='notification'>(1)</span>")
                .appendTo($('ul#menuitems li:last')).css({ 'color': 'red' });

            while (beep < 100) {
                $('#notification').animate({ opacity: 'toggle' }, 'slow');
                beep++
            }

        }

        function todayDate1() {
            var today = new Date();
            var dd = today.getDate();
            var mm = today.getMonth() + 1;
            var yyyy = today.getFullYear();

            if (dd < 10) {
                dd = '0' + dd
            }

            if (mm < 10) {
                mm = '0' + mm
            }

            today = mm + '/' + dd + '/' + yyyy;
            return today;
        }
        $('#rate').attr('disabled', 'disabled');
        $('#select-loans').change(function () {
            $('thead,#data-table,#amount').html("");
            $('#report').hide();
            var $ltype = parseInt($(this).val(), 10);
            switch ($ltype) {
                case 1:
                    $('#type').html('Fixed Instalments');
                    break;
                case 2:
                    $('#type').html('Fixed Principle');
                    break;
                case 3:
                    $('#type').html('Flat Rate');
                    break;
                default:
                    $('#type').html('');
            }
        });
        $('input:text').val("");

        $('#share').on('blur', function () {

            var $factor = parseInt($('#multi-factor').html(), 10);
            var $share_amount = parseInt($(this).val(), 10);
            if (!$share_amount || !$factor) { return };
            var max_amount = $share_amount * $factor;
            $('#max-loan').val(max_amount);
        });
        var linkurl;
        (function ($) {
            $('.dynamic a').click(function (e) {
                e.preventDefault();
                $('thead,#data-table,#amount').html("");
                $('#report').hide();
                linkurl = this.href;
                $.ajax({
                    url: this.href,
                    type: "POST"

                }).done(function () {

                }).complete(function () {

                }).success(function (dv) {
                    $("#replace").html(dv);

                });
            });
            $(document).ajaxStart(function () {
                $('input:text').select();
            }).ajaxSuccess(function (event, xhr, settings) {
                if (settings.url == linkurl) {
                    var text = $('#intrate').html();
                    var text1 = $('#max-period').html();
                    $('#rate').val(text);
                    $('#duration').val(text1);
                }
            });
        })(jQuery);
        $(function () {
            $('#Submit1').click(function (e) {
                e.preventDefault();

                var irateRaw, principleRaw, monthsRaw, selectedValue;

                selectedValue = parseInt($('#select-loans').val(), 10);

                irateRaw = parseFloat($('#rate').val());
                principleRaw = parseInt($('#max-loan').val());
                monthsRaw = parseInt($('#duration').val());

                var $maxvalue = $('#max-period').html();
                if (monthsRaw > $maxvalue) {
                    $('#duration').notify('Value entered is greater than max value:' + $maxvalue);
                    return;
                }

                if (!selectedValue || !irateRaw || !principleRaw || !monthsRaw) {
                    $(this).notify("Required Fields must be filled");
                    return
                };
                if (selectedValue == 1) {
                    $.ajax({
                        url: "/Home/FixedInstalments",
                        type: "POST",
                        data: { irate: irateRaw, principle: principleRaw, months: monthsRaw }

                    }).done(function () {

                    }).complete(function () {

                    }).success(function (dv) {
                        $("#data-table").html(dv);

                    });
                }
                else if (selectedValue == 2) {
                    $.ajax({
                        url: "/Home/FixedPrinciple",
                        type: "POST",
                        data: { irate: irateRaw, principle: principleRaw, months: monthsRaw }

                    }).done(function () {

                    }).complete(function () {

                    }).success(function (dv) {
                        $("#data-table").html(dv);

                    });
                }
                else if (selectedValue == 3) {
                    $.ajax({
                        url: "/Home/FlatRate",
                        type: "POST",
                        data: { irate: irateRaw, principle: principleRaw, months: monthsRaw }

                    }).done(function () {

                    }).complete(function () {

                    }).success(function (dv) {
                        $("#data-table").html(dv);

                    });
                }

            });

            $(document).ajaxStart(function () {

            }).ajaxSuccess(function (event, xhr, settings) {
                var url1, url2, url3;
                url1 = "/Home/FixedInstalments";
                url2 = "/Home/FixedPrinciple";
                url3 = "/Home/FlatRate";
                if (settings.url == url1 || settings.url == url2 || settings.url == url3) {
                    $('#report').show();
                    var $finalAmount = $('.final-amount').html();
                    $('#amount').html($finalAmount);

                    $('.final-amount').hide();
                    var $table = $('table.display');
                    $table.floatThead({
                        scrollContainer: function ($table) {
                            return $table.closest('#data-table');
                        }
                    });
                    var datatableOffset = $('#data-table').offset(),
                    destination = datatableOffset.top;
                    jQuery(document).scrollTop(destination);
                }
            });
        });
        $('#button').on('click', function () {
            var hasApplied = parseInt($('#applied').html());
            if (hasApplied == 1) {
                $(this).notify('You have already requested \n for a loan!', { position: 'top' });
                return;
            }

            var accno = parseInt($('#accno').html(), 10);
            var loanids = parseInt($('#loan-id').html(), 10);
            var principles = parseInt($('#max-loan').val());
            var intrates = parseFloat($('#rate').val());
            var totalinterest = parseFloat($('.total-interest').html());
            var totalinstalments = parseFloat($('.final-int').html());

            $('thead,#data-table,#amount').html("");

            $.ajax({
                url: "/Home/LoanForm",
                type: "POST",
                data: { accounts: accno, loanid: loanids, principle: principles, intrate: intrates, totalint: totalinterest,
                    totalamount: totalinstalments
                }

            }).done(function () {

            }).complete(function () {

            }).success(function (dv) {
                $("#data-table").html(dv);

            });
        });
        $(document).ajaxStart(function () {

        }).ajaxSuccess(function (event, xhr, settings) {
            var loanurl = "/Home/LoanForm"
            if (settings.url == loanurl) {

                $('input:text#loan-date').val(todayDate1());
                $('#loan-form input:text').attr('readonly', 'readonly').css('color', 'gray');
                var datatableOffset = $('#data-table').offset(),
                    destination = datatableOffset.top;
                jQuery(document).scrollTop(destination);
            }
        });
        var noturl;
        var $state = parseInt($('#state').html(), 10);
        $('ul#menuitems li:last a').on('click', function (e) {
            e.preventDefault();
            $('#notification').html('');
            var rd1 = parseInt($('#read').html(), 10);
            var hasApp = parseInt($('#applied').html());
            if (rd1 != 0) {
                if ($state == 1) {
                    $(this).notify('Your loan request was accepted \n and is being processed');
                }
                else if ($state == 0) {
                    $(this).notify('Your loan request was rejected!');
                }
                else if (!!hasApp) {
                    $(this).notify('Your loan is pending!');
                }
                else {
                    $(this).notify("You have not requested any loans yet...");
                }
                return
            }
            var $accno = parseInt($('#accno').html(), 10);

            noturl = this.href
            $.ajax({
                url: this.href,
                type: "POST",
                data: { acc: $accno }

            }).done(function () {

            }).complete(function () {

            }).success(function (dv) {


            });
        });

        $(document).ajaxStart(function () {

        }).ajaxSuccess(function (event, xhr, settings) {

            if (settings.url == noturl) {
                $('#read').html('1');
                if ($state == 1) {
                    $('ul#menuitems li:last a').notify('Your loan request was accepted \n and is being processed');
                }
                else {
                    $('ul#menuitems li:last a').notify('Your loan request was rejected!');
                }
            }
        });

    });

   
</script>
End Section
<h5>Choose the loan and enter the share deposit to see your the maximum loan eligible(Edit to your preference)<br />
and enter the number of months. Rate is set for you.<span class="required-fields"> (* Required fields)</span>
</h5>

<ul class="Logout-user">
<li>Welcome @ViewBag.Name</li>
<li>@Html.ActionLink("Log Out","Index","LogOut")</li>
</ul>
<div id="loans">
<hr />
<ul id="loan-items">
 <li id="loan-header">Loans</li>
 <hr />
@For Each item In Model
    Dim currentitem = item
   

   @<li class="values"> @Html.DisplayTextFor(Function(modelItem) currentitem.LoanType)</li>
     

   @<li class="dynamic"> @Html.ActionLink("Development Loan","GetRate",New With { .id = item.ID })
</li>
Next
 </ul>
</div>
<div id="loan-calculator">
<form method="post" action="" id="form-calculator">
<table border="0">
    <tr>
        <td>
            <label for="share">Share Deposit</label>
        </td>
    
    
        <td>
            <span class="required-fields">*</span>
            <label for="loan-type" id="loan-type" style="font-weight:bold">Select Loan Type:</label>
        </td>
    </tr>
    <tr>
        <td>
            <input id="share" type="text" />
        </td>
          <td>
            <select id="select-loans">
            <option value="" selected="selected">Select Type</option>
            <option value="1">Reducing Balance on Fixed Instalments</option>
            <option value="2">Reducing Balance on Fixed Principle</option>
            <option value="3">Flat rate</option>
            </select>
        </td>
       </tr>
    <tr>
        <td>
            <span class="required-fields">*</span>
            <label for="max-loan">Maximum Loan:(Edit)</label>
        </td>
        <td>
            <span class="required-fields">*</span>
            <label for="duration">Duration:in months</label>&nbsp;
            <span class="required-fields">*</span>
            <label for="rate">Interest rate:(Default)</label>
        </td>
      
    </tr>
    <tr>
        <td>
            <input id="max-loan" type="text" />
        </td>
        <td>
            <input id="duration" type="text" />
             <input id="rate" type="text" />
        </td>
       
    </tr>
    <tr>
    <td>
        <input id="Submit1" type="submit" value="Calculate" /></td>
    </tr>
</table>
</form>
<div id="replace"></div>
<h2 id="type"></h2>
<div id="amount"></div>
<div id="data-table"></div>
<div id="accno">@ViewBag.Accno</div>
</div>
<div id="report"><ul><li><a href="/frmReportViewer.aspx?">View Report</a></li>
<li><input type="button" id="button" value="Apply Loan" /></li>
</ul>
</div>
<div id="state">@ViewBag.State</div>
<div id="read">@ViewBag.Read</div>
<div id="available">@ViewBag.Available</div>
<div id="applied">@ViewBag.Applied</div>
<div id="success">@ViewBag.Success</div>
<div id="notify-success"> </div>