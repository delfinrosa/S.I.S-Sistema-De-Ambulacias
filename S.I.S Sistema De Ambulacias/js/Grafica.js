google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawChart);
function drawChart() {
    var data = google.visualization.arrayToDataTable(<%=graficaArea()%>);

    var options = {
        title: 'Cantidad De Traslados'
    };

    var chart = new google.visualization.PieChart(document.getElementById('myChart'));

    chart.draw(data, options);

}