var files = document.querySelector('input[name="files"]');

files.addEventListener("change", function (file) {
    var input = file.target;

    var reader = new FileReader();

    reader.onload = function () {
        var dataURL = reader.result;
        var output = document.getElementById('output');
        output.src = dataURL;
    };

    reader.readAsDataURL(input.files[0]);
});


// PREVIEW FOTO
/*function PreviewImage() {
    var oFReader = new FileReader();
oFReader.readAsDataURL(document.getElementById("uploadImage").files[0]);

oFReader.onload = function (oFREvent) {
    document.getElementById("uploadPreview").src = oFREvent.target.result;
    };
};*/
