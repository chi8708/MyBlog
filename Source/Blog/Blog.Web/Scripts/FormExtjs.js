function OnBegin() {

}

function OnSuccess(data) {
    if (data.RedirectNow && data.RedirectUrl) {
        window.top.location = data.RedirectUrl;
        return;
    }
    if (data.Msg) {
        appendModel('提示', data.Msg);
        $('#saveTipModal').modal('show').css({
            "top": function () {
                return ($(window).innerHeight() -$(this).height())/2;//垂直居中
            }
        });
        $('#saveTipModal').on('hidden.bs.modal', function (e) {
            if (data.RedirectUrl) {
                window.top.location = data.RedirectUrl;
            }
        })
        // alert(data.Msg);
    }

}

function appendModel(title, message) {
    var html = "";
    html += '<div id="saveTipModal" class="modal modal_align fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel">';
    html += '<div class="modal-dialog modal-sm">';
    html += '<div class="modal-content">';
    html += '<div class="modal-header"><button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>';
    html += ' <h6 class="modal-title" id="mySmallModalLabel">' + title + '</h6></div>';
    html += ' <div class="modal-body"><h4>' + message + '</h4></div>';
    html += ' </div>';
    html += '</div>';
    html += '</div>';
    if ($("#saveTipModal").length>0) {
       $("#saveTipModal").remove();
    }
    $("body").append(html);
}