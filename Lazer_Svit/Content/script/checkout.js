$(document).ready(function(){
	console.clear();
	$('.name__error-message').hide();
	$('.tel__error-message').hide();
	$('.email__error-message').hide();
	$('.region__error-message').hide();
	$('.city__error-message').hide();
	$('.address__error-message').hide();
	$('.delivery__error-message').hide();
	$('.payment__error-message').hide();
	let errorInput = false;
	let errorName = false;	
	let errorTel = false;
	let errorEmail = false;
	let errorRegion = false;
	let errorCity = false;
	let errorAddress = false;
	let name = $('.form-input__name');
	let tel = $('.form-input__tel');
	let region = $('.form-input__region');
	let city = $('.form-input__city');
	let address = $('.form-input__address');
	
	$('.form-input__name').focusout(function() {		
		checkInput(name);
		errorName = errorInput;		
	});
	$('.form-input__tel').focusout(function() {		
		checkInput(tel);
		errorTel = errorInput;	
	});
	$('.form-input__email').focusout(function() {
		checkEmail();		
	});
	$('.form-input__region').focusout(function() {
		checkInput(region);
		errorRegion = errorInput;		
	});
	$('.form-input__city').focusout(function() {
		checkInput(city);
		errorCity = errorInput;			
	});
	$('.form-input__address').focusout(function() {
		checkInput(address);
		errorAddress = errorInput;		
	});

	function checkEmail(){
		var pattern = new RegExp(/^(?!.*@.*@.*$)(?!.*@.*\-\-.*\..*$)(?!.*@.*\-\..*$)(?!.*@.*\-$)(.*@.+(\..{1,11})?)$/i);		
		if(pattern.test($('.form-input__email').val())) {			
			errorEmail = false;			
			$('.email__error-message').fadeOut(1000);
		} else {				
			errorEmail = true;			
			$('.email__error-message').fadeIn(1000);		
		}
	}
	function checkInput(input,errorValue){	
		let messageText = input.val().length;		
		if(messageText >= 1) {		
			errorInput = false;	
			input.siblings().eq(2).fadeOut(1000);		
		} else {				
			errorInput = true;			
			input.siblings().eq(2).fadeIn(1000);	
			console.log(input);	
		}
	}
	$('.no_delivery').click(function(){
		let delivery = $( ".no_delivery:checked" ).length;
		if(delivery == 1){		
			$('.form-input__delivery')[0].checked=true;
			$('.form-input__payment')[0].checked=true;
			$('.form-input__region').attr("disabled", "disabled");	
			$('.form-input__city').attr("disabled", "disabled");
			$('.form-input__address').attr("disabled", "disabled");
			$('.address__error-message').fadeOut(1000);				
			$('.form-input__delivery').attr("disabled", "disabled");
			$('.form-input__payment').attr("disabled", "disabled");
			$('.form-input__payment:checked').val() = "nalichnymi";
		}
		else{
			$('.form-input__region').removeAttr("disabled");
			$('.form-input__city').removeAttr("disabled");
			$('.form-input__address').removeAttr("disabled");
			$('.form-input__delivery').removeAttr("disabled");
			$('.form-input__payment').removeAttr("disabled");
		}
    })

    window.CheckoutConfirm = function ()
    {
        let delivery = $(".no_delivery:checked").length;
        if (delivery !== 1) {
            checkInput(name);
            errorName = errorInput;
            checkInput(tel);
            errorTel = errorInput;
            checkEmail();
            checkInput(region);
            errorRegion = errorInput;
            checkInput(city);
            errorCity = errorInput;
            checkInput(address);
            errorAddress = errorInput;
            if (errorName == false && errorTel == false && errorEmail == false && errorRegion == false && errorCity == false && errorAddress == false) {
                if ($('.form-input__payment:checked').val() == "Visa/MaterCard") {
                    $("#secondform").submit();
                }
                else {
                    $("#firstform").submit();
                    ////window.location.href = "http://lazer-svit.com.ua";
                    //setCookieOrder();
                }
            } else {
                return false;
            }
        }
        else {
            checkInput(name);
            errorName = errorInput;
            checkInput(tel);
            errorTel = errorInput;
            checkEmail();
            if (errorName == false && errorTel == false && errorEmail == false) {
                $("#firstform").submit();
                //window.location.href = "http://lazer-svit.com.ua";
                setCookieOrder();
            } else {
                return false;
            }
        }
    }
	function setCookieOrder(){
		document.cookie = "successfulOrder=true";
	}
	let mainOffsetTop = $('.main').offset().top;
	let mainHeight = $('.main').outerHeight();
	let BillHeight = $('.totall-bill').outerHeight();
	let BillOffsetTop = $('.totall-bill').offset().top;
	movingTotallBill();
	$(window).scroll(function (){ 
		movingTotallBill();
	})
	function movingTotallBill(){		
		if(window.innerWidth>=768){
			if ($(window).scrollTop() > BillOffsetTop) 
			{
				if($(window).scrollTop() < mainOffsetTop+mainHeight-BillHeight) 
				{	
					$('.totall-bill').css({
				    position: 'fixed',
				    top: 0
					});  
				}
				else
				{	
					$('.totall-bill').css({
				    position: 'absolute',
				    top: mainHeight-BillHeight-(BillOffsetTop-mainOffsetTop)
					}); 

				}				  
			}
			else
			{
				$('.totall-bill').css({
				    position: 'static',
				    top: 'auto'
				});  
			}	
		}
		else{
			$('.totall-bill').css({
			    position: 'static',
			    top: 'auto'
			}); 
		}		
	}

})	