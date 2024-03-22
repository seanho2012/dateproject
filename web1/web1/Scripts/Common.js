function NewCancelBtn(selector, closeWindowselector) {//�������s�]�w
    $(selector).kendoButton({
        click: function (e) {
            e.preventDefault();
            $(closeWindowselector).data("kendoWindow").close();
        }
    });
}
function NewWindow(selector, width, height, title) {//�����]�w
    $(selector).kendoWindow({
        minWidth: width,
        maxWidth: width,
        minHeight: height,
        maxHeight: height,
        title: title,
        modal: true,
        visible: false
    });
}
function NewDropDownList(selector, url) {//�U�Կ��]�w
    $(selector).kendoDropDownList({
        dataTextField: "Text",
        dataValueField: "Value",
        dataSource: {
            transport: {
                read: {
                    type: "post",
                    url: url,
                    dataType: "json"
                }
            },
        },
        index: 0,
        size: "medium"
    });
    console.log($("#location123").data("kendoDropDownList"));
}