var xhrPartial = new Object();
xhrPartial['siteMenu'] = new XMLHttpRequest();

var IsAjaxActivePartial = new Object();
IsAjaxActivePartial['siteMenu'] = false;
$(document).ready(function () {
    //Dashboard Chart
    var data = {
        labels: ["January", "February", "March", "April", "May"],
        datasets: [
      		{
      		    label: "My First dataset",
      		    fillColor: "rgba(220,220,220,0.2)",
      		    strokeColor: "rgba(220,220,220,1)",
      		    pointColor: "rgba(220,220,220,1)",
      		    pointStrokeColor: "#fff",
      		    pointHighlightFill: "#fff",
      		    pointHighlightStroke: "rgba(220,220,220,1)",
      		    data: [65, 59, 80, 81, 56]
      		},
      		{
      		    label: "My Second dataset",
      		    fillColor: "rgba(151,187,205,0.2)",
      		    strokeColor: "rgba(151,187,205,1)",
      		    pointColor: "rgba(151,187,205,1)",
      		    pointStrokeColor: "#fff",
      		    pointHighlightFill: "#fff",
      		    pointHighlightStroke: "rgba(151,187,205,1)",
      		    data: [28, 48, 40, 19, 86]
      		}
        ]
    };
    var pdata = [
      {
          value: 300,
          color: "#46BFBD",
          highlight: "#5AD3D1",
          label: "Complete"
      },
      {
          value: 50,
          color: "#F7464A",
          highlight: "#FF5A5E",
          label: "In-Progress"
      }
    ]

    var ctxl = $("#lineChartDemo").get(0).getContext("2d");
    var lineChart = new Chart(ctxl).Line(data);

    var ctxp = $("#pieChartDemo").get(0).getContext("2d");
    var pieChart = new Chart(ctxp).Pie(pdata);

    $('ul li a').click(function () {
        $('li a').removeClass("active");
        $(this).addClass("active");
    });

    try {
        $("input[type='text']").each(function () {
            $(this).attr("autocomplete", "off");
        });
    }
    catch (e)
    { }
    var urlToLaunch = "/Home/SiteMenu";

    xhrPartial['siteMenu'] = $.ajax({
        url: urlToLaunch,
        type: "get",
        async: false,
        beforeSend: function () {
            //Abort previous ajax requests.
            if (IsAjaxActivePartial['siteMenu']) {
                xhrPartial['siteMenu'].abort();
            }
            IsAjaxActivePartial['siteMenu'] = true;
        },
        success: function (data) {
            if (data != null && data != "" && data.error == true) {
                return ShowErrorMsg(errorMsg.loadMenuListError);
            }
            if (data != null && data != "" && data.Redirect != null) {
                window.location.href = data.Redirect;
            }
            else {
                $("#menunavigation").html(data);
            }
        },
        complete: function () {
            IsAjaxActivePartial['siteMenu'] = false;
        }
    });
});

function urlToRedirect() {
    var curController = "Home";
    var curAction = "Index";

    $.ajax({
        type: "POST",
        data: { "contrl": curController, "viewName": curAction },
        url: "/Account/URLRedirect",
        contentType: 'application/json',
        dataType: "json",
        beforeSend: function () {
        },
        success: function (data) {
          
            if (data == "error") {
            }
        },
        failure: function (data) {
        },
        error: function (data) {
        },
        complete: function () {
            
        }
    });
}


