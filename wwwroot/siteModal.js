showInPopup = (controller,viewname,id, title) => {
    alert('hi');
   var url = '/' + controller + '/' + viewname + '/id=' + id;
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
        }
    })
}
