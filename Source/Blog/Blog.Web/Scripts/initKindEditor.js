var content;
KindEditor.ready(function (K) {
    content = K.create('#articleContent', {
        cssPath: '/content/kindeditor/plugins/code/prettify.css',
        uploadJson: '/AdminConsole/Kindeditor/Upload',
        fileManagerJson: '/AdminConsole/Kindeditor/Manager',
        allowFileManager: false,
        afterCreate: function () {
            var self = this;
            K.ctrl(document, 13, function () {
                self.sync();
                K('form[name=form]')[0].submit();
            });
            K.ctrl(self.edit.doc, 13, function () {
                self.sync();
                K('form[name=form]')[0].submit();
            });
        }
    });

    //标题颜色
    var colorpicker;
    K('#style').bind('click', function (e) {
        e.stopPropagation();
        if (colorpicker) {
            colorpicker.remove();
            colorpicker = null;
            return;
        }

        var colorpickerPos = K('#style').pos();
        colorpicker = K.colorpicker({
            x: colorpickerPos.x,
            y: colorpickerPos.y + K('#style').height(),
            z: 19811214,
            selectedColor: 'default',
            noColor: '无颜色',
            click: function (color) {
                K('#style').val(color);
                K('#title').css({ "color": color });
                colorpicker.remove();
                colorpicker = null;
            }
        });
    });

    K(document).click(function () {
        if (colorpicker) {
            colorpicker.remove();
            colorpicker = null;
        }
    });

    prettyPrint();
});

var editor;
KindEditor.ready(function (K) {
    editor = K.editor({
        allowFileManager: false,
        allowFlashUpload: true,
        uploadJson: '/AdminConsole/Kindeditor/Upload',
        fileManagerJson: '/AdminConsole/Kindeditor/Manager'
    });
});

function doUploadImage(field) {
    editor.loadPlugin('image', function () {
        editor.plugin.imageDialog({
            imageUrl: $('#' + field).val(),
            clickFn: function (url, title, width, height, border, align) {
                $('#' + field).val(url);
                editor.hideDialog();
            }
        });
    });
}

function doUploadFile(field) {
    editor.loadPlugin('insertfile', function () {
        editor.plugin.fileDialog({
            fileUrl: $('#' + field).val(),
            clickFn: function (url, title) {
                $('#' + field).val(url);
                editor.hideDialog();
            }
        });
    });
}

function doUploadManager(field, dir) {
    editor.loadPlugin('filemanager', function () {
        editor.plugin.filemanagerDialog({
            viewType: 'VIEW',
            dirName: dir,
            clickFn: function (url, title) {
                $('#' + field).val(url);
                editor.hideDialog();
            }
        });
    });
}