define(["application"], function (app) {
    return {
        formDialog: null,
        self: null,
        initForm: function (data) {
            self.formDialog.html(data);
            var form = self.formDialog.find("#product-form");
            form.submit(self.onFormSubmit);
        },
        onFormSubmit: function (e) {
            var $this = $(this);
            $.post(this.action, $this.serializeArray(), function (result) {
                if (result.Success) {
                    window.location.reload();
                } else {
                    self.initForm(result.View);
                }
            }, "json");
            e.preventDefault();
        },
        init: function () {
            self = this;

            this.formDialog = $("#product-form-dialog").dialog({ autoOpen: false, resizable: false, modal: true, draggable: false, width: 800, height: 600 });
            $('#add-new-product-btn, .edit-product-btn').click(function () {
                $.get($(this).data('action'), function (data) {
                    self.initForm(data);
                    self.formDialog.dialog("open");
                });
                return false;
            });


        }
    };
});