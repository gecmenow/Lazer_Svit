$(document).ready(function(){	
	$('.name__error-message').hide();
	$('.email__error-message').hide();
	$('.message__error-message').hide();
	let errorUserName = false;	
	let errorEmail = false;
	let errorMessage = false;

	formValidation();

	$('.form-input__name').focusout(function() {
		checkUserName();		
	});
	$('.form-input__email').focusout(function() {
		checkEmail();		
	});
	$(".form-textarea__message").focusout(function() {
		checkMessage();		
	});
	$('input[type="file"]').change(function(){
		var value = $("input[type='file']").val();
		$('.js-value').text(value);
	});

	
	function formValidation(){	
		$('.contact-form').submit(function() {			
			checkUserName();
			checkEmail();
			checkMessage();

			if(errorUserName == false && errorEmail == false && errorMessag == false){
				return true;
			} else {
				return false;	
			}			
		})
	}
	function checkUserName(){
		let userName = $('.form-input__name').val().length;
		
		if(userName >= 1) {	
			errorUserName = false;	
			$('.name__error-message').fadeOut(1000);		
		} else {
			errorUserName = true;
			$('.name__error-message').fadeIn(1000);		
		}
	}
	function checkEmail(){
		var pattern = new RegExp(/^(?!.*@.*@.*$)(?!.*@.*\-\-.*\..*$)(?!.*@.*\-\..*$)(?!.*@.*\-$)(.*@.+(\..{1,11})?)$/i);		
		if(pattern.test($('.form-input__email').val())) {
			errorEmail = false;			
			$('.email__error-message').fadeOut(1000);
		} else {				
			$('.email__error-message').fadeIn(1000);		
		}
	}
	function checkMessage(){
		let messageText = $('.form-textarea__message').val().length;
		
		if(messageText >= 1) {	
			errorMessage = false;	
			$('.message__error-message').fadeOut(1000);		
		} else {
			errorMessage = true;
			$('.message__error-message').fadeIn(1000);		
		}
	}

})	