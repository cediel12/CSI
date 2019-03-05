<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="calendario.aspx.cs" Inherits="CSI.Home.calendario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        #wrap {
            width: 1100px;
            margin: 0 auto;
        }

        #external-events {
            float: left;
            width: 150px;
            padding: 0 10px;
            text-align: left;
        }

            #external-events h4 {
                font-size: 16px;
                margin-top: 0;
                padding-top: 1em;
            }

        .external-event { /* try to mimick the look of a real event */
            margin: 10px 0;
            padding: 2px 4px;
            background: #3366CC;
            color: #fff;
            font-size: .85em;
            cursor: pointer;
        }

        #external-events p {
            margin: 1.5em 0;
            font-size: 11px;
            color: #666;
        }

            #external-events p input {
                margin: 0;
                vertical-align: middle;
            }

        #calendar {
            /* 		float: right; */
            margin: 0 auto;
            width: 900px;
            background-color: #FFFFFF;
            border-radius: 6px;
            box-shadow: 0 1px 2px #C3C3C3;
        }
    </style>
</head>
<link href="../Estilos/styles.css" rel="stylesheet" />
<script src="../Estilos/Calendario/jquery/jquery-1.10.2.js"></script>
<link href="../Estilos/Calendario/fullcalendar.css" rel="stylesheet" />
<script src="../Estilos/Calendario/jquery/jquery-ui.custom.min.js"></script>
<script src="../Estilos/Calendario/fullcalendar.js"></script>
<script>

    $(document).ready(function () {
        var date = new Date();
        var d = date.getDate();
        var m = date.getMonth();
        var y = date.getFullYear();

        /*  className colors
    
        className: default(transparent), important(red), chill(pink), success(green), info(blue)
    
        */


        /* initialize the external events
        -----------------------------------------------------------------*/

        $('#external-events div.external-event').each(function () {

            // create an Event Object (http://arshaw.com/fullcalendar/docs/event_data/Event_Object/)
            // it doesn't need to have a start or end
            var eventObject = {
                title: $.trim($(this).text()) // use the element's text as the event title
            };

            // store the Event Object in the DOM element so we can get to it later
            $(this).data('eventObject', eventObject);

            // make the event draggable using jQuery UI
            $(this).draggable({
                zIndex: 999,
                revert: true,      // will cause the event to go back to its
                revertDuration: 0  //  original position after the drag
            });

        });


        /* initialize the calendar
        -----------------------------------------------------------------*/

        var calendar = $('#calendar').fullCalendar({
            events: [
                {
                    title: 'All Day Event',
                    start: '2019-02-2',
                    end: '2019-02-11',
                    allDay: true,
                    className: 'info'
                },
                {
                    id: 999,
                    title: 'Repeating Event',
                    start: new Date(y, m, d - 3, 16, 0),
                    allDay: true,
                    className: 'info'
                },
                {
                    id: 999,
                    title: 'Repeating Event',
                    start: new Date(y, m, d + 4, 16, 0),
                    allDay: true,
                    className: 'info'
                },
                {
                    title: 'Meeting',
                    start: new Date(y, m, d, 10, 30),
                    allDay: true,
                    className: 'important'
                },
                {
                    title: 'Lunch',
                    start: '2019-02-11',
                    end: '2019-02-13',
                    allDay: true,
                    className: 'important'
                },
                {
                    title: 'Birthday Party',
                    start: new Date(y, m, d + 1, 19, 0),
                    end: new Date(y, m, d + 1, 22, 30),
                    allDay: false,
                },
                {
                    title: 'Click for Google',
                    start: new Date(y, m, 28),
                    end: new Date(y, m, 29),
                    url: 'http://google.com/',
                    className: 'success'
                }
            ],
        });


    });

</script>

<body>
    <form id="form1" runat="server">
            <div id='calendar'></div>
            <div style='clear: both'></div>
    </form>
</body>
</html>
