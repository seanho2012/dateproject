$(function () {
    var schedulerTemplate = kendo.template("\
        <div> Title: #: title #</div> \
        <div>Atendees: \
            #if(resources.length > 0){#\
                #: resources[0].text #\
            #}#\
        </div>\
    ");

    $("#scheduler").kendoScheduler({
        date: new Date(),
        eventTemplate: schedulerTemplate,
        views: [
            "day",
            { type: "week", selected: true },
            "workWeek",
            "month",
            "agenda",
        ],
        dataSource: {
            transport: {
                read: {
                    type: "post",
                    dataType: "json",
                    url: "/Scheduler/GetSchedulerData",
                    data: function () {
                        return { "title": "front" }
                    }
                },
                create: {
                    type: "post",
                    dataType: "json", // "jsonp" is required for cross-domain requests; use "json" for same-domain requests
                    url: "/Scheduler/CreateSchedulerData",
                    data: function (data) {
                        console.log("data", data);
                        var scheduler = {
                            SchedulerID: data.id,
                            StartTime: data.start.toJSON(),
                            EndTime: data.end.toJSON(),
                            Title: data.title,
                            LocationID: data.location
                        };
                        console.log("scheduler", scheduler);
                        return scheduler;
                    }
                },
                update: {
                    type: "post",
                        dataType: "json", // "jsonp" is required for cross-domain requests; use "json" for same-domain requests
                            url: "/Scheduler/CreateSchedulerData",
                                data: function (data) {
                                    console.log("data", data);
                                    var scheduler = {
                                        SchedulerID: data.id,
                                        StartTime: data.start.toJSON(),
                                        EndTime: data.end.toJSON(),
                                        Title: data.title,
                                        LocationID: data.location
                                    };
                                    console.log("scheduler", scheduler);
                                    return scheduler;
                                }
                },
                destroy: function (e) {
                    console.log("destroy:");
                }
            },
            schema: {
                parse: function (response) {
                    var schedulers = [];
                    for (var i = 0; i < response.length; i++) {
                        var scheduler = {
                            id: response[i].SchedulerID,
                            start: response[i].StartTime,
                            end: response[i].EndTime,
                            title: response[i].Title,
                            location: response[i].LocationID,
                            location2: response[i].LocationID
                        };
                        schedulers.push(scheduler);
                    }
                    return schedulers;
                }
            }
        },
        resources: [
            {
                field: "location",
                dataSource: [
                    { value: 1, text: "Alex" },
                    { value: 2, text: "Bob" }
                ]
            },
            {
                field: "location2",
                dataSource: [
                    { value: 1, text: "Alex" },
                    { value: 2, text: "Bob" }
                ]
            },
        ],
        save: function (e) {
            var dataSource = $("#scheduler").data("kendoScheduler").dataSource;
            dataSource.read();
        }
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