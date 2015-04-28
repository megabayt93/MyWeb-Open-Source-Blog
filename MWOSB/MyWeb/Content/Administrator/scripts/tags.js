
            $('#ArticleTags').bind('keypress', function (event) {
                var regex = new RegExp("[a-zA-Z0-9, ,ç,i,ı,ş,Ç,Ş,İ,I,ğ,Ğ,ö,Ö]");
                var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
                if (!regex.test(key)) {
                    event.preventDefault();
                    return false;
                }
            });

            $('#FileTags').bind('keypress', function (event) {
                var regex = new RegExp("[a-zA-Z0-9, ,ç,i,ı,ş,Ç,Ş,İ,I,ğ,Ğ,ö,Ö]");
                var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
                if (!regex.test(key)) {
                    event.preventDefault();
                    return false;
                }
            });

            $('#WhatIDoTags').bind('keypress', function (event) {
                var regex = new RegExp("[a-zA-Z0-9, ,ç,i,ı,ş,Ç,Ş,İ,I,ğ,Ğ,ö,Ö]");
                var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
                if (!regex.test(key)) {
                    event.preventDefault();
                    return false;
                }
            });
