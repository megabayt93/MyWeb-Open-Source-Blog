function onecikan() {
    //Check File API support
    if (window.File && window.FileList && window.FileReader) {

        var files = event.target.files; //FileList object
        var output = document.getElementById("result");

        for (var i = 0; i < files.length; i++) {
            var file = files[i];
            //Only pics
            if (!file.type.match('image')) continue;

            var picReader = new FileReader();
            picReader.addEventListener("load", function (event) {
                var picFile = event.target;
                $(".resimekleic label img").attr("src",picFile.result)
            });
            //Read the image
            picReader.readAsDataURL(file);
        }
    } else {
        console.log("HANGİ DÖNEMDE YAŞIYORSUN. GÜNCELLE ŞU TARAYICINI.");
    }
}

document.getElementById('Image').addEventListener('change', onecikan, false);


$("[type=file]").on("change", function () {
    // Name of file and placeholder
    var file = this.files[0].name;
    var dflt = $(this).attr("placeholder");
    if ($(this).val() != "") {
        $(this).next().text(file);
    } else {
        $(this).next().text(dflt);
    }
});
