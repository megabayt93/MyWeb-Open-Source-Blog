function galeriekle() {
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
                var div = document.createElement("div");
                div.innerHTML = "<span><img class='thumbnail' src='" + picFile.result + "'" + "title='" + picFile.name + "'/></span>";
                output.insertBefore(div, null);
                $("output").addClass("yuklendi");
            });
            //Read the image
            picReader.readAsDataURL(file);
        }
    } else {
        console.log("HANGİ DÖNEMDE YAŞIYORSUN. GÜNCELLE ŞU TARAYICINI.");
    }
}

document.getElementById('files').addEventListener('change', galeriekle, false);