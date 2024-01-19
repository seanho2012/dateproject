$(function () {
    $("#scheduler").kendoScheduler({
        date: new Date("2013/6/6"),
        allDayEventTemplate: $("#event-template").html(),
        dataSource: [
            {
                id: 1,
                start: new Date("2013/6/6 08:00 AM"),
                end: new Date("2013/6/6 09:00 AM"),
                isAllDay: true,
                title: "Interview",
                attendees: [1, 2]
            }
        ],
        resources: [
            {
                field: "attendees",
                dataSource: [
                    { value: 1, text: "Alex" },
                    { value: 2, text: "Bob" }
                ],
                multiple: true
            }
        ]
    });
    var app = angular.module('myApp', []);
    app.controller('myCtrl', function ($scope) {
        $scope.msg = "oHnaeS";
    });
    app.filter('reverse', function () { //可以注入依赖
        return function (text) {
            return text.split("").reverse().join("");
        }
    });
})