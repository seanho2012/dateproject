$(function () {
    //scheduler項目樣板
    var schedulerTemplate = kendo.template("\
        <div> Title: #: title #</div> \
        <div>Atendees: #: location #\
        </div>\
    ");

    $("#scheduler").kendoScheduler({
        date: new Date(),
        editable: {
            template: kendo.template($("#custom-template").html())
        },
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
                    url: "/Scheduler/GetScheduler"
                },
                create: {
                    type: "post",
                    dataType: "json", // "jsonp" is required for cross-domain requests; use "json" for same-domain requests
                    url: "/Scheduler/CreateScheduler",
                    data: function (data) {
                        debugger;
                        var scheduler = {
                            SchedulerID: data.id,
                            StartTime: data.start.toJSON(),
                            EndTime: data.end.toJSON(),
                            Title: data.title,
                            Description: data.description,
                            Location: data.location,
                            ColorID: data.schedulerColor.ColorID
                        };
                        return scheduler;
                    }
                },
                update: {
                    type: "post",
                    dataType: "json", // "jsonp" is required for cross-domain requests; use "json" for same-domain requests
                    url: "/Scheduler/UpdateScheduler",
                    data: function (data) {
                        debugger;
                        var scheduler = {
                            SchedulerID: data.id,
                            StartTime: data.start.toJSON(),
                            EndTime: data.end.toJSON(),
                            Title: data.title,
                            Description: data.description,
                            Location: data.location,
                            ColorID: data.schedulerColor
                        };
                        return scheduler;
                    }
                },
                destroy: function (e) {
                    debugger;
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
                            location: response[i].Location,
                            description: response[i].Description,
                            schedulerColor: response[i].ColorID
                        };
                        schedulers.push(scheduler);
                    }
                    return schedulers;
                }
            }
        },
        resources: [
            {
                field: "schedulerColor",
                title: "Color",
                dataColorField: "key",
                dataSource: {
                    transport: {
                        read: {
                            type: "post",
                            dataType: "json",
                            url: "/Scheduler/GetSchedulerColor"
                        }
                    },
                    schema: {
                        parse: function (response) {
                            var colors = [];
                            for (var i = 0; i < response.length; i++) {
                                var color = {
                                    value: response[i].ColorID,
                                    text: response[i].ColorName,
                                    key: response[i].ColorKey
                                };
                                colors.push(color);
                            }
                            return colors;
                        }
                    }
                }
            },
            {
                field: "location",
                dataSource: {
                    transport: {
                        read: {
                            type: "post",
                            dataType: "json",
                            url: "/Scheduler/GetScheduler"
                        }
                    },
                    schema: {
                        parse: function (response) {
                            var locations = [];
                            for (var i = 0; i < response.length; i++) {
                                var location = {
                                    text: response[i].Location
                                };
                                locations.push(location);
                            }
                            return locations;
                        }
                    }
                }
            }
        ],
        edit: function (e) {
            e.container.find("#schedulerColor").kendoDropDownList({
                dataTextField: "ColorName",
                dataValueField: "ColorID",
                dataSource: {
                    transport: {
                        read: {
                            type: "post",
                            dataType: "json",
                            url: "/Scheduler/GetSchedulerColor"
                        }
                    }
                }
            });
            $(e.container).parent().css({
                width: '500px',
                height: '600px'
            });
        },
        save: function (e) {
            CreateOrUpdateScheduler(e);
        },
        remove: function (e) {
            $.ajax({
                url: "/Scheduler/DeleteScheduler",
                dataType: "json", 
                method: "POST",
                data: {
                    schedulerID: e.event.id
                },
                success: function (result) {
                    $("#scheduler").data("kendoScheduler").dataSource.read();
                    e.preventDefault();
                },
                error: function (result) {
                    console.log(result);
                }
            });
            //$("#scheduler").data("kendoScheduler").dataSource.read();
            //e.preventDefault();
        }
    });

    function CreateOrUpdateScheduler(e) {
        //e.event為更新的data
        var dataSource = $("#scheduler").data("kendoScheduler").dataSource;
        //更新scheduler
        dataSource.sync();
        debugger;
        //重載scheduler
        dataSource.read();
        //不繼續執行，不然會跑兩次update
        e.preventDefault();
    }

    var app = angular.module('myApp', []);
    app.controller('myCtrl', ['$scope', function ($scope) {
            $scope.msg = "oHnaeS";
        }]);
    app.filter('reverse', function () { //可以注入依赖
        return function (text) {
            return text.split("").reverse().join("");
        }
    });
})