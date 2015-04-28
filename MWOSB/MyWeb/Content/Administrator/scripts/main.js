$( window ).resize(function() {
	var wR  = $(window).width();
	var hR = $(window).height();
	

	
});
$(function(){
	var w  = $(window).width();
	var h = $(window).height();
	$(".girisyap").attr("style","top:"+(h/2)+"px;margin-top:-"+($(".girisyap").height()/2)+"px");
	$(".nav li ul").hide();
	$(".nav li.active ul").show();
	$(".nav li.active ul li:first-child").addClass("active");
	$(".popup").html('<div class="popupic"><a class="sil" href="">SİLMEYE DEVAM ET</a><a class="kapat" href="#">KAPAT</a></div>')
	for(var j = 0; j < $(".nav li").length; j++){
		$(".nav li:nth-child("+j+")").addClass("list-item").addClass("list-item-"+j+"");
	}
	$(".nav li ul li").removeClass("list-item").removeClass("list-item-1").removeClass("list-item-2").removeClass("list-item-3").removeClass("list-item-4");
	if($("nav li").hasClass('active')){
		$("nav li ul").slideDown(400);
	}
	$('.nav .list-item').click(
		  function () {
		  	$('.nav .list-item').removeClass("active");
			$('ul li:first-child', this).addClass("active");
		  	$('.nav .list-item ul').slideUp(400);
		    $('ul', this).slideToggle(400);
		    if($(this).hasClass('active')){
		   		$('ul', this).slideDown(400);
		    }else{
		    	$(this).addClass("active");

		    }
		  }
		);
	$('.nav li ul li').click(
		  function () {
		  	$('.nav li ul li').removeClass("active");
			$(this).addClass("active");
		  }
		);
	$( ".ac-custom li label" ).after('<a href="#"><i class="fa fa-times"></i></a>');
	$(".ac-custom li a").click(function(){
		var sil = $(this).next().html();
		$(".popup .sil").attr("href",sil);
		$(".popup").fadeIn(400);
	});
	$(".tum").after("<div class='resimurl'><input type='text' value='' /><div class='kapatresimurl'>KAPAT</div></div>");
	$(".kapatresimurl").click(function(){
		$(".resimurl").fadeOut(400);
	})
	$(".popup .kapat").click(function(){
		$(".popup").fadeOut(400);
	});
	$("input:reset").click(function(){
		$("#result").html("");
        $("#result").removeClass("yuklendi");
	});
	$(".kategorisec").click(function(){
		$(".kategoriler").slideToggle(400);
	});

	$(".tum .kategoriler div").click(function(){
		$(".tum .galerisec .kategorisec .kategori_ismi").html($(this).html());

		$(".kategoriler").slideUp(400);
		$(".tum .galeri .resim").fadeOut(400);
		$(".tum .galeri .resim[data-yusuf='"+$(this).html()+"']").fadeIn();

	});
	$(".tum .kategoriler div.sabit").click(function(){
		$(".tum .galerisec .kategorisec .kategori_ismi").html($(this).html());

		$(".kategoriler").slideUp(400);
		$(".tum .galeri .resim").fadeIn(400);
	});
	$(".tum .galeri .resim .galeriresim").click(function(){
		var imgval = $(this).find("img").attr("src");
		$(".resimurl input").attr("value",imgval);
		$(".resimurl").fadeIn(400);
	})

});

