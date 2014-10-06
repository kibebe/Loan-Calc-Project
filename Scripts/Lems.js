

$(document).ready(function () {
    //Admin messaging persistance

    //state of accordion according to admin loged in
    var username = $('#admin-username').html();
    if (!!username) {
        $.cookie("persuser", username);
    }
    if (!username) {
        var retuser = $.cookie("persuser");
        $('#admin-username').html(retuser);
        username = $('#admin-username').html();
    }
    if (username != "Admin") {
        $('#cssmenu > ul > li:eq(1), #cssmenu > ul > li:eq(2)').addClass('admin-limited')
        $('admin-limited').css("background-color", "Gray");
    }

    // accordion
    $('#cssmenu  ul > li:has(ul)').addClass("has-sub");
    $('#cssmenu > ul > li > a').click(function () {
        if ($(this).parent().hasClass('admin-limited')) { return; }
        var checkElement = $(this).next();

        $('#cssmenu li').removeClass('active');
        $(this).closest('li').addClass('active');

        if ((checkElement.is('ul')) && (checkElement.is(':visible'))) {
            $(this).closest('li').removeClass('active');
            checkElement.slideUp('normal');
        }

        if ((checkElement.is('ul')) && (!checkElement.is(':visible'))) {
            $('#cssmenu ul ul:visible').slideUp('normal');
            checkElement.slideDown('normal');
        }

        if (checkElement.is('ul')) {
            return false;
        }
        else {
            return true;
        }
    });
    $('#cssmenu > ul > li > ul li').hover(
  function () {
      $('ul', this).stop().slideDown(300);
  },
  function () {
      $('ul', this).stop().slideUp(300);
  }
);
    //admin menu
    $('nav li ul').hide().removeClass('fallback');
    $('nav li').hover(
  function () {
      $('ul', this).css('padding-left', '2px');
      $('ul', this).stop().slideDown(300);

      if ($(this).is('nav > ul > li:last')) {
          $('#msg-count').html('');

          setTimeout(wait, 4000);
          if (parseInt($('#count-new').html(), 10) != 0) {
              newToOld();
          }
      }
  },
  function () {
      $('ul', this).stop().slideUp(300);
  }
);
    var countNew = parseInt($('#count-new').html(), 10);
    if (countNew == 0) {
        $('#msg-count').html('');
    }
    $('.not-sec').each(function () {
        var checkhtml = $(this).html();
        checkhtml = $.trim(checkhtml);
        if (checkhtml == '(0)') {
            $(this).html('');
        }
    });
    //ajax request to get messages to old state
    function newToOld() {
        $.ajax({
            url: "/Contact/NewToOld",
            type: "POST"

        }).done(function () {

        }).complete(function () {

        }).success(function (dv) {


        });


    }
    //wait before fading away message notification
    function wait() {
        $('.not-sec').fadeOut(900);
    }
    // add id attribute to status link on loan applications
    var idvalue = 1;
    $('span a').each(function () {
        $(this).attr('id', idvalue);
        idvalue++;
    });

    //set cookie for admin status

    var linkid = $.cookie("spana");
    if (linkid) $("#" + linkid).addClass("disabled");

    //change colour when mouse hovers over menus

    $('ul#menuitems li, .link-admin a').hover(
function () {
    $(this).css("background-color", "#52527a");
}, function () {
    $(this).css("background-color", "Gray");
}
);

    // calculate todays date
    function todayDate() {
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

    // form validation
    $('#date-field input:text').val(todayDate());
    $('#Email').attr('data-validation', 'email');
    $('#Password').attr('data-validation-strength', 1);

    $.validate({
        modules: 'security',
        onModulesLoaded: function () {
            var optionalConfig = {
                fontSize: '12pt',
                padding: '4px',
                bad: 'Very weak',
                weak: 'Weak',
                good: 'Good',
                strong: 'Strong'
            };

            $('input[name="Password"]').displayPasswordStrength(optionalConfig);
        }
    });
    //adding dynamic content
    var $text = {};
    var $text1, counter, counter1;
    counter = 0;
    counter1 = 0;
    $('.values').each(function () {
        $text[counter1] = $(this).html();
        counter1++;
    });
    $('.dynamic a').each(function () {


        $text1 = $text[counter];
        $(this).html($text1);
        counter++;
    });

    //ajax request on loan status
    $(document).on('click', 'span a', function (e) {
        e.preventDefault();
        if ($(this).hasClass('disabled')) { return; }
        $(this).addClass('disabled');
        $.cookie("spana", this.id);
        if ($(this).siblings().hasClass('disabled')) {
            $(this).siblings().removeClass('disabled');
        }
        var decision = confirm('Do you really want to proceed?');
        if (!decision) { return; }

        $.ajax({
            url: this.href,
            type: "POST"

        }).done(function () {

        }).complete(function () {

        }).success(function (dv) {


        });

    });
    $(document).ajaxStart(function () {

    }).ajaxSuccess(function (event, xhr, settings) {



    });
    $('#create-date input:text').val(todayDate());
    //filter and set th width
    $('table#actions th').filter(':not(:eq(2))').css('width', '150px');
});


       
  
