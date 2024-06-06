tinymce.init({
    selector: '#tinymce-editor',
    plugins: [
        'advlist', 'autolink', 'link', 'image', 'lists', 'charmap', 'preview', 'anchor', 'pagebreak',
        'searchreplace', 'wordcount', 'visualblocks', 'code', 'fullscreen', 'insertdatetime', 'media',
        'table', 'emoticons', 'help'
    ],
    toolbar: 'undo redo | styles | bold italic | alignleft aligncenter alignright alignjustify | ' +
        'bullist numlist outdent indent | link image | print preview media fullscreen | ' +
        'forecolor backcolor emoticons | help',
    menubar: 'favs file edit view insert format tools table help',
    content_style: 'body { font-family: Helvetica, Arial, sans-serif; font-size: 16px }',
    height: 800,
    resize: true,
});

document.getElementById('confirmAction').addEventListener('click', function () {
    var fetchPath = `/Operations/${userAction}EmailTemplate/${id}`;
    var afterFetchPath = `/Operations/EmailTemplates/${id}`;

    performAction(fetchPath, afterFetchPath);
});