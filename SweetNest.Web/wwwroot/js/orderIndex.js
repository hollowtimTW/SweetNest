var dataTable;

$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("approved")) {
        loadDataTable("approved");
    }
    else {
        if (url.includes("readyforpickup")) {
            loadDataTable("readyforpickup");
        }
        else {
            if (url.includes("cancelled")) {
                loadDataTable("cancelled");
            }
            else {
                loadDataTable("all");
            }
        }
    }
});

function loadDataTable(status) {
    dataTable = $('#tblData').DataTable({
        order: [[0, 'desc']],
        "ajax": { url: "/order/getall?status=" + status },
        "columns": [
            { data: 'orderHeaderId', "width": "10%" },
            { data: 'email', "width": "20%" },
            { data: 'name', "width": "15%" },
            { data: 'phone', "width": "15%" },
            {
                data: 'status',
                "render": function (data) {
                    return getStatusInChinese(data);
                },
                "width": "10%"
            },
            { data: 'orderTotal', "width": "10%" },
            {
                data: 'orderHeaderId',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/order/orderDetail?orderId=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i></a>
                    </div>`
                },
                "width": "10%"
            }
        ],
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.13.6/i18n/zh-HANT.json"
        }
    })
}


function getStatusInChinese(status) {
    switch (status) {
        case "pending":
            return "待處理";
        case "approved":
            return "已批准";
        case "readyforpickup":
            return "可取貨";
        case "completed":
            return "已完成";
        case "refunded":
            return "已退款";
        case "cancelled":
            return "已取消";
        default:
            return "未知";
    }
}